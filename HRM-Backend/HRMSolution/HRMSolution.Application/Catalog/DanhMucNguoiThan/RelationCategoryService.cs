using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucNguoiThans
{
    public class RelationCategoryService : IRelationCategoryService
    {
        private readonly HRMDbContext _context;
        public RelationCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNguoiThanCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var check = await _context.danhMucNguoiThans.Where(x => x.tenDanhMuc == request.tenDanhMuc).FirstOrDefaultAsync();
            if (request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucNguoiThan = new DanhMucNguoiThan()
                {
                    tenDanhMuc = tenDanhMuc

                };
                _context.danhMucNguoiThans.Add(danhMucNguoiThan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucNguoiThan)
        {
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(idDanhMucNguoiThan);
            if (danhMucNguoiThan == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucNguoiThans.Remove(danhMucNguoiThan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucNguoiThanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNguoiThans select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucNguoiThanViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucNguoiThanViewModel> GetById(int id)
        {
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(id);
            if (danhMucNguoiThan == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucNguoiThans where p.id == id select p;
                var check = await _context.nguoiThans.Where(x => x.idDanhMucNguoiThan == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucNguoiThanViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucNguoiThanUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(id);
            var check = await _context.danhMucNguoiThans.Where(x => x.tenDanhMuc == request.tenDanhMuc).FirstOrDefaultAsync();
            if (danhMucNguoiThan == null || request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucNguoiThan.tenDanhMuc = tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
