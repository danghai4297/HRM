
using HRMSolution.Application.Catalog.DanhMucChucVus;
using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
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

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs
{
    public class DanhMucChucVuService : IDanhMucChucVuService
    {
        private readonly HRMDbContext _context;
        public DanhMucChucVuService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucChucVuCreateRequest request)
        {
            var check = await _context.danhMucChucVus.Where(x => x.tenChucVu == request.tenChucVu).FirstOrDefaultAsync();
            if (request.maChucVu == null || request.tenChucVu == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucChucVu = new DanhMucChucVu()
                {
                    tenChucVu = request.tenChucVu,
                    maChucVu = request.maChucVu,
                    phuCap = request.phuCap
                };
                _context.danhMucChucVus.Add(danhMucChucVu);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public async Task<int> Delete(int idDanhMucChucVu)
        {
            var danhMucChucVu = await _context.danhMucChucVus.FindAsync(idDanhMucChucVu);
            if (danhMucChucVu == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucChucVus.Remove(danhMucChucVu);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public async Task<List<DanhMucChucVuViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChucVus select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucChucVuViewModel()
                {
                    id = x.id,
                    maChucVu = x.maChucVu,
                    tenChucVu = x.tenChucVu,
                    phuCap = x.phuCap
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucChucVuViewModel> GetById(int id)
        {
            var danhMucChucVu = await _context.danhMucChucVus.FindAsync(id);

            if (danhMucChucVu == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucChucVus where p.id == id select p;
                var check = await _context.hopDongs.Where(x => x.idChucVu == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucChucVuViewModel()
                {
                    id = x.id,
                    maChucVu = x.maChucVu,
                    tenChucVu = x.tenChucVu,
                    phuCap = x.phuCap,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucChucVuUpdateRequest request)
        {
            var danhMucChucVu = await _context.danhMucChucVus.FindAsync(id);
            if (danhMucChucVu == null || request.maChucVu == null || request.tenChucVu == null)
            {
                return 0;
            }
            else
            {
                danhMucChucVu.maChucVu = request.maChucVu;
                danhMucChucVu.tenChucVu = request.tenChucVu;
                danhMucChucVu.phuCap = request.phuCap;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
