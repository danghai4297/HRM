using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
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
    public class RewardDisciplineCategoryService : IRewardDisciplineCategoryService
    {
        private readonly HRMDbContext _context;
        public RewardDisciplineCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucKhenThuongKyLuatCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var check = await _context.danhMucKhenThuongKyLuats.Where(x => x.tenDanhMuc == request.tenDanhMuc).FirstOrDefaultAsync();
            if (request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucKTKL = new DanhMucKhenThuongKyLuat()
                {
                    tenDanhMuc = tenDanhMuc,
                    tieuDe = request.tieuDe
                };
                _context.danhMucKhenThuongKyLuats.Add(danhMucKTKL);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucKTKL)
        {
            var danhMucKTKL = await _context.danhMucKhenThuongKyLuats.FindAsync(idDanhMucKTKL);
            if (danhMucKTKL == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucKhenThuongKyLuats.Remove(danhMucKTKL);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKhenThuong()
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.tieuDe == "Khen thưởng"
                        select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    tieuDe = x.tieuDe
                }).ToListAsync();
                return data;
            }
        }

        public async Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKyLuat()
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.tieuDe == "Kỷ luật"
                        select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    tieuDe = x.tieuDe
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucKhenThuongKyLuatViewModel> GetById(int id)
        {
            var danhMucKTKL = await _context.danhMucKhenThuongKyLuats.FindAsync(id);

            if (danhMucKTKL == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucKhenThuongKyLuats
                            where p.id == id
                            select p;
                var check = await _context.khenThuongKyLuats.Where(x => x.idDanhMucKhenThuong == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc,
                    tieuDe = x.tieuDe,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucKhenThuongKyLuatUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenDanhMuc.Trim(charsToTrim);
            var danhMucKTKL = await _context.danhMucKhenThuongKyLuats.FindAsync(id);
            var check = await _context.danhMucKhenThuongKyLuats.Where(x => x.tenDanhMuc == request.tenDanhMuc).FirstOrDefaultAsync();
            if (danhMucKTKL == null || request.tenDanhMuc == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucKTKL.tenDanhMuc = tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
