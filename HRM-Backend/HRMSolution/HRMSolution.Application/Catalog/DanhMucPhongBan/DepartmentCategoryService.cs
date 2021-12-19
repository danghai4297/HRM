﻿using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucPhongBans
{
    public class DepartmentCategoryService : IDepartmentCategoryService
    {
        private readonly HRMDbContext _context;
        public DepartmentCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucPhongBanCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenPhongBan.Trim(charsToTrim);
            var check = await _context.danhMucPhongBans.Where(x => x.tenPhongBan == request.tenPhongBan).FirstOrDefaultAsync();
            if (request.maPhongBan == null || request.tenPhongBan == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucPhongBan = new DanhMucPhongBan()
                {
                    maPhongBan = request.maPhongBan,
                    tenPhongBan = tenDanhMuc
                };
                _context.danhMucPhongBans.Add(danhMucPhongBan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucPhongBan)
        {
            var danhMucPhongBan = await _context.danhMucPhongBans.FindAsync(idDanhMucPhongBan);
            if (danhMucPhongBan == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucPhongBans.Remove(danhMucPhongBan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucPhongBanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucPhongBans select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucPhongBanViewModel()
                {
                    id = x.id,
                    maPhongBan = x.maPhongBan,
                    tenPhongBan = x.tenPhongBan
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucPhongBanViewModel> GetById(int id)
        {
            var danhMucPhongBan = await _context.danhMucPhongBans.FindAsync(id);
            if (danhMucPhongBan == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucPhongBans where p.id == id select p;
                var check = await _context.dieuChuyens.Where(x => x.idPhongBan == id).FirstOrDefaultAsync();
                var check1 = await _context.danhMucTos.Where(x => x.idPhongBan == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucPhongBanViewModel()
                {
                    id = x.id,
                    maPhongBan = x.maPhongBan,
                    tenPhongBan = x.tenPhongBan,
                    trangThai = check == null && check1 == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucPhongBanUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenPhongBan.Trim(charsToTrim);
            var danhMucPhongBan = await _context.danhMucPhongBans.FindAsync(id);
            var check = await _context.danhMucPhongBans.Where(x => x.tenPhongBan == request.tenPhongBan).FirstOrDefaultAsync();
            if (danhMucPhongBan == null || request.maPhongBan == null || request.tenPhongBan == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucPhongBan.maPhongBan = request.maPhongBan;
                danhMucPhongBan.tenPhongBan = tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
