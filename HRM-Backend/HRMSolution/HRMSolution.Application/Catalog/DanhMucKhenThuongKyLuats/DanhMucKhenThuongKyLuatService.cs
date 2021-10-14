﻿using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
using HRMSolution.Data.EF;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats
{
    public class DanhMucKhenThuongKyLuatService : IDanhMucKhenThuongKyLuatService
    {   
        private readonly HRMDbContext _context;
        public DanhMucKhenThuongKyLuatService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucKhenThuongKyLuatCreateRequest request)
        {
            var danhMucKTKL = new DanhMucKhenThuongKyLuat()
            {
                tenDanhMuc = request.tenDanhMuc,
                tieuDe = request.tieuDe
            };
            _context.danhMucKhenThuongKyLuats.Add(danhMucKTKL);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucKTKL)
        {
            var danhMucKTKL = await _context.danhMucKhenThuongKyLuats.FindAsync(idDanhMucKTKL);
            if (danhMucKTKL == null) throw new HRMException($"Không tìm thấy danh mục khen thưởng kỉ luật : {idDanhMucKTKL}");

            _context.danhMucKhenThuongKyLuats.Remove(danhMucKTKL);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKhenThuong()
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.tieuDe == "Khen thưởng"
                        select p;

            var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc,
                tieuDe = x.tieuDe
            }).ToListAsync();


            return data;
        }

        public async Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKyLuat()
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.tieuDe == "Kỷ luật"
                        select p;

            var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc,
                tieuDe = x.tieuDe
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucKhenThuongKyLuatViewModel> GetDetail(int id)
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.id == id
                        select p;

            var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc,
                tieuDe = x.tieuDe
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(int id, DanhMucKhenThuongKyLuatUpdateRequest request)
        {
            var danhMucKTKL = await _context.danhMucHonNhans.FindAsync(id);
            if (danhMucKTKL == null) throw new HRMException($"Không tìm thấy danh mục khen thưởng kỉ luật có id: {id }");

            danhMucKTKL.tenDanhMuc = request.tenDanhMuc;
            return await _context.SaveChangesAsync();
        }
    }
}
