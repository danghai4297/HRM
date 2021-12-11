using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
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

namespace HRMSolution.Application.Catalog.DanhMucTrinhDos
{
    public class LevelCategoryService : ILevelCategoryService
    {
        private readonly HRMDbContext _context;
        public LevelCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucTrinhDoCreateRequest request)
        {
            var check = await _context.danhMucTrinhDos.Where(x => x.tenTrinhDo == request.tenTrinhDo).FirstOrDefaultAsync();
            if (request.tenTrinhDo == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucTrinhDo = new DanhMucTrinhDo()
                {
                    tenTrinhDo = request.tenTrinhDo
                };
                _context.danhMucTrinhDos.Add(danhMucTrinhDo);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucTrinhDo)
        {
            var danhMucTrinhDo = await _context.danhMucTrinhDos.FindAsync(idDanhMucTrinhDo);
            if (danhMucTrinhDo == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucTrinhDos.Remove(danhMucTrinhDo);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucTrinhDoViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTrinhDos select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucTrinhDoViewModel()
                {
                    id = x.id,
                    tenTrinhDo = x.tenTrinhDo
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucTrinhDoViewModel> GetById(int id)
        {
            var danhMucTrinhDo = await _context.danhMucTrinhDos.FindAsync(id);
            if (danhMucTrinhDo == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucTrinhDos where p.id == id select p;
                var check = await _context.trinhDoVanHoas.Where(x => x.idTrinhDo == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucTrinhDoViewModel()
                {
                    id = x.id,
                    tenTrinhDo = x.tenTrinhDo,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucTrinhDoUpdateRequest request)
        {
            var danhMucTrinhDo = await _context.danhMucTrinhDos.FindAsync(id);
            var check = await _context.danhMucTrinhDos.Where(x => x.tenTrinhDo == request.tenTrinhDo).FirstOrDefaultAsync();
            if (danhMucTrinhDo == null || request.tenTrinhDo == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucTrinhDo.tenTrinhDo = request.tenTrinhDo;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
