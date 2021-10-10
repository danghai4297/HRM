﻿using HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRMSolution.Application.Catalog.TrinhDoVanHoas
{
    public class TrinhDoVanHoaService : ITrinhDoVanHoaService
    {
        private readonly HRMDbContext _context;
        public TrinhDoVanHoaService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<TrinhDoVanHoaViewModel>> GetAll()
        {
            var query = from p in _context.trinhDoVanHoas
                        join dmtd in _context.danhMucTrinhDos on p.idTrinhDo equals dmtd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        join htdt in _context.hinhThucDaoTaos on p.idHinhThucDaoTao equals htdt.id
                        join dmcm in _context.danhMucChuyenMons on p.idChuyenMon equals dmcm.id
                        select new { p, dmtd, nv, htdt, dmcm };


            var data = await query.Select(x => new TrinhDoVanHoaViewModel()
            {
                id = x.p.id,
                tenTruong = x.p.tenTruong,
                chuyenMon = x.dmcm.tenChuyenMon,
                tuThoiGian = x.p.tuThoiGian,
                denThoiGian =x.p.denThoiGian,
                hinhThucDaoTao = x.htdt.tenHinhThuc,
                trinhDo = x.dmtd.tenTrinhDo,
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();

            return data;
        }

        public async Task<List<TrinhDoVanHoaViewModel>> GetAllByNV(string maNhanVien)
        {
            var query = from p in _context.trinhDoVanHoas
                        join dmtd in _context.danhMucTrinhDos on p.idTrinhDo equals dmtd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        join htdt in _context.hinhThucDaoTaos on p.idHinhThucDaoTao equals htdt.id
                        join dmcm in _context.danhMucChuyenMons on p.idChuyenMon equals dmcm.id
                        where nv.maNhanVien == maNhanVien
                        select new { p, dmtd, nv, htdt, dmcm };


            var data = await query.Select(x => new TrinhDoVanHoaViewModel()
            {
                id = x.p.id,
                tenTruong = x.p.tenTruong,
                chuyenMon = x.dmcm.tenChuyenMon,
                tuThoiGian = x.p.tuThoiGian,
                denThoiGian = x.p.denThoiGian,
                hinhThucDaoTao = x.htdt.tenHinhThuc,
                trinhDo = x.dmtd.tenTrinhDo,
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();

            return data;
        }
    }
}
