﻿
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucNgoaiNgus
{
    public class DanhMucNgoaiNguService : IDanhMucNgoaiNguService
    {
        private readonly HRMDbContext _context;
        public DanhMucNgoaiNguService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNgoaiNguCreateRequest request)
        {
            if (request.tenDanhMuc == null)
            {
                return 0;
            }
            else
            {
                var danhMucNgoaiNgu = new DanhMucNgoaiNgu()
                {
                    tenDanhMuc = request.tenDanhMuc
                };
                _context.danhMucNgoaiNgus.Add(danhMucNgoaiNgu);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucNgoaiNgu)
        {
            var danhMucNgoaiNgu = await _context.danhMucNgoaiNgus.FindAsync(idDanhMucNgoaiNgu);
            if (danhMucNgoaiNgu == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucNgoaiNgus.Remove(danhMucNgoaiNgu);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucNgoaiNguViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNgoaiNgus select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucNgoaiNguViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucNgoaiNguViewModel> GetById(int id)
        {
            var danhMucNgoaiNgu = await _context.danhMucNgoaiNgus.FindAsync(id);
            if (danhMucNgoaiNgu == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucNgoaiNgus where p.id == id select p;
                var check = await _context.ngoaiNgus.Where(x => x.idDanhMucNgoaiNgu == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucNgoaiNguViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucNgoaiNguUpdateRequest request)
        {
            var danhMucNgoaiNgu = await _context.danhMucNgoaiNgus.FindAsync(id);
            if (danhMucNgoaiNgu == null || request.tenDanhMuc == null)
            {
                return 0;
            }
            else
            {
                danhMucNgoaiNgu.tenDanhMuc = request.tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
