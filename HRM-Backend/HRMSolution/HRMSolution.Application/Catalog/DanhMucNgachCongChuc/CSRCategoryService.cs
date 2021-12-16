using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucNgachCongChucs
{
    public class CSRCategoryService : ICSRCategoryService
    {
        private readonly HRMDbContext _context;
        public CSRCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNgachCongChucCreateRequest request)
        {
            var check = await _context.danhMucNgachCongChucs.Where(x => x.tenNgach == request.tenNgach).FirstOrDefaultAsync();
            if (request.tenNgach == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucNgachCongChuc = new DanhMucNgachCongChuc()
                {
                    tenNgach = request.tenNgach
                };
                _context.danhMucNgachCongChucs.Add(danhMucNgachCongChuc);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucNgachCongChuc)
        {
            var danhMucNgachCongChuc = await _context.danhMucNgachCongChucs.FindAsync(idDanhMucNgachCongChuc);
            if (danhMucNgachCongChuc == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucNgachCongChucs.Remove(danhMucNgachCongChuc);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;

            }
        }

        public async Task<List<DanhMucNgachCongChucViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNgachCongChucs select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucNgachCongChucViewModel()
                {
                    id = x.id,
                    tenNgach = x.tenNgach
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucNgachCongChucViewModel> GetById(int id)
        {
            var danhMucNgachCongChuc = await _context.danhMucNgachCongChucs.FindAsync(id);
            if (danhMucNgachCongChuc == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucNgachCongChucs where p.id == id select p;
                var check = await _context.nhanViens.Where(x => x.idNgachCongChuc == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucNgachCongChucViewModel()
                {
                    id = x.id,
                    tenNgach = x.tenNgach,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucNgachCongChucUpdateRequest request)
        {
            var danhMucNgachCongChuc = await _context.danhMucNgachCongChucs.FindAsync(id);
            var check = await _context.danhMucNgachCongChucs.Where(x => x.tenNgach == request.tenNgach).FirstOrDefaultAsync();
            if (danhMucNgachCongChuc == null || request.tenNgach == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucNgachCongChuc.tenNgach = request.tenNgach;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
