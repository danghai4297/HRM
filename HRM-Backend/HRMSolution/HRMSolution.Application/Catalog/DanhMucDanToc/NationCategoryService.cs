using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucDanTocs
{
    public class NationCategoryService : INationCategoryService
    {
        private readonly HRMDbContext _context;
        public NationCategoryService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DanhMucDanTocCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var check = await _context.danhMucDanTocs.Where(x => x.tenDanhMuc == tenDanhMuc).FirstOrDefaultAsync();
            if (request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {

                var danhMucDanToc = new DanhMucDanToc()
                {
                    tenDanhMuc = tenDanhMuc
                };
                _context.danhMucDanTocs.Add(danhMucDanToc);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucDanToc)
        {
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(idDanhMucDanToc);
            if (danhMucDanToc == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucDanTocs.Remove(danhMucDanToc);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }


        public async Task<int> Update(int id, DanhMucDanTocUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(id);
            var check = await _context.danhMucDanTocs.Where(x => x.tenDanhMuc == tenDanhMuc).FirstOrDefaultAsync();
            if (danhMucDanToc == null || request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucDanToc.tenDanhMuc = tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucDanTocViewModel>> GetAll()
        {

            var query = from p in _context.danhMucDanTocs select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucDanTocViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucDanTocViewModel> GetById(int id)
        {
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(id);

            if (danhMucDanToc == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucDanTocs where p.id == id select p;
                var check = await _context.nhanViens.Where(x => x.idDanToc == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucDanTocViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }
    }
}
