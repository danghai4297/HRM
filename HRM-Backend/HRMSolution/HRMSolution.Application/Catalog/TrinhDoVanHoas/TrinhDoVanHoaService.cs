using HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.TrinhDoVanHoas
{
    public class TrinhDoVanHoaService : ITrinhDoVanHoaService
    {
        private readonly HRMDbContext _context;
        public TrinhDoVanHoaService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TrinhDoVanHoaCreateRequest request)
        {
            var tdvh = new TrinhDoVanHoa()
            {
                tenTruong = request.tenTruong,
                idChuyenMon = request.idChuyenMon,
                tuThoiGian = request.tuThoiGian,
                denThoiGian = request.denThoiGian,
                idHinhThucDaoTao = request.idHinhThucDaoTao,
                idTrinhDo = request.idTrinhDo,
                maNhanVien = request.maNhanVien
            };
            _context.trinhDoVanHoas.Add(tdvh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var trinhDoVanHoa = await _context.trinhDoVanHoas.FindAsync(id);
            if (trinhDoVanHoa == null) throw new HRMException($"Không tìm thấy trình độ văn hóa có id: {id}");

            _context.trinhDoVanHoas.Remove(trinhDoVanHoa);
            return await _context.SaveChangesAsync();
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


        public async Task<TrinhDoVanHoaViewModel> GetById(int id)
        {
            var query = from p in _context.trinhDoVanHoas
                        join dmtd in _context.danhMucTrinhDos on p.idTrinhDo equals dmtd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        join htdt in _context.hinhThucDaoTaos on p.idHinhThucDaoTao equals htdt.id
                        join dmcm in _context.danhMucChuyenMons on p.idChuyenMon equals dmcm.id
                        where p.id == id
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
            }).FirstAsync();

            return data;
        }

        public async Task<int> Update(int id, TrinhDoVanHoaUpdateRequest request)
        {
            var trinhDoVanHoa = await _context.trinhDoVanHoas.FindAsync(id);
            if (trinhDoVanHoa == null) throw new HRMException($"Không tìm thấy trình độ văn hóa có id: {id}");

            trinhDoVanHoa.tenTruong = request.tenTruong;
            trinhDoVanHoa.idChuyenMon = request.idChuyenMon;
            trinhDoVanHoa.tuThoiGian = request.tuThoiGian;
            trinhDoVanHoa.denThoiGian = request.denThoiGian;
            trinhDoVanHoa.idHinhThucDaoTao = request.idHinhThucDaoTao;
            trinhDoVanHoa.idTrinhDo = request.idTrinhDo;
            trinhDoVanHoa.maNhanVien = request.maNhanVien;

            return await _context.SaveChangesAsync();
        }
    }
}
