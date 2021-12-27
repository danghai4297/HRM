
using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos.Dtos;
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

namespace HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos
{
    public class EducateCategoryService : IEducateCategoryService
    {
        private readonly HRMDbContext _context;
        public EducateCategoryService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DanhMucHinhThucDaoTaoCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenHinhThuc.Trim(charsToTrim);
            var check = await _context.hinhThucDaoTaos.Where(x => x.tenHinhThuc == tenDanhMuc).FirstOrDefaultAsync();
            if (request.tenHinhThuc == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucHinhThucDaoTao = new HinhThucDaoTao()
                {
                    tenHinhThuc = tenDanhMuc
                };
                _context.hinhThucDaoTaos.Add(danhMucHinhThucDaoTao);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucHinhThucDaoTao)
        {
            var danhMucHinhThucDaoTao = await _context.hinhThucDaoTaos.FindAsync(idDanhMucHinhThucDaoTao);
            if (danhMucHinhThucDaoTao == null)
            {
                return 0;
            }
            else
            {
                _context.hinhThucDaoTaos.Remove(danhMucHinhThucDaoTao);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucHinhThucDaoTaoViewModel>> GetAll()
        {
            var query = from p in _context.hinhThucDaoTaos select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucHinhThucDaoTaoViewModel()
                {
                    id = x.id,
                    tenHinhThuc = x.tenHinhThuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucHinhThucDaoTaoViewModel> GetById(int id)
        {
            var danhMucHinhThucDaoTao = await _context.hinhThucDaoTaos.FindAsync(id);
            if (danhMucHinhThucDaoTao == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.hinhThucDaoTaos where p.id == id select p;
                var check = await _context.trinhDoVanHoas.Where(x => x.idHinhThucDaoTao == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucHinhThucDaoTaoViewModel()
                {
                    id = x.id,
                    tenHinhThuc = x.tenHinhThuc,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucHinhThucDaoTaoUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenHinhThuc.Trim(charsToTrim);
            var danhMucHinhThucDaoTao = await _context.hinhThucDaoTaos.FindAsync(id);
            var check = await _context.hinhThucDaoTaos.Where(x => x.tenHinhThuc == tenDanhMuc).FirstOrDefaultAsync();
            if (danhMucHinhThucDaoTao == null || request.tenHinhThuc == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucHinhThucDaoTao.tenHinhThuc = tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
