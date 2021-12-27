using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
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

namespace HRMSolution.Application.Catalog.DanhMucHonNhans
{
    public class MarriageCategoryService : IMarriageCategoryService
    {
        private readonly HRMDbContext _context;
        public MarriageCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucHonNhanCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var check = await _context.danhMucHonNhans.Where(x => x.tenDanhMuc == tenDanhMuc).FirstOrDefaultAsync();
            if (request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucHonNhan = new DanhMucHonNhan()
                {
                    tenDanhMuc = tenDanhMuc

                };
                _context.danhMucHonNhans.Add(danhMucHonNhan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucHonNhan)
        {
            var danhMucHonNhan = await _context.danhMucHonNhans.FindAsync(idDanhMucHonNhan);
            if (danhMucHonNhan == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucHonNhans.Remove(danhMucHonNhan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucHonNhanViewModel>> GetALL()
        {
            var query = from p in _context.danhMucHonNhans select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucHonNhanViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucHonNhanViewModel> GetById(int id)
        {
            var danhMucHonNhan = await _context.danhMucHonNhans.FindAsync(id);
            if (danhMucHonNhan == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucHonNhans where p.id == id select p;
                var check = await _context.nhanViens.Where(x => x.idDanhMucHonNhan == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucHonNhanViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucHonNhanUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var danhMucHonNhan = await _context.danhMucHonNhans.FindAsync(id);
            var check = await _context.danhMucHonNhans.Where(x => x.tenDanhMuc == tenDanhMuc).FirstOrDefaultAsync();
            if (danhMucHonNhan == null || request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucHonNhan.tenDanhMuc = tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
