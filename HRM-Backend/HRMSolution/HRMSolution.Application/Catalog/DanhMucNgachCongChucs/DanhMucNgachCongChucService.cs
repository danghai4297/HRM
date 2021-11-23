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
    public class DanhMucNgachCongChucService : IDanhMucNgachCongChucService
    {
        private readonly HRMDbContext _context;
        public DanhMucNgachCongChucService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNgachCongChucCreateRequest request)
        {
            if(request.tenNgach == null)
            {
                return 0;
            } else
            {
                var danhMucNgachCongChuc = new DanhMucNgachCongChuc()
                {
                    tenNgach = request.tenNgach
                };
                _context.danhMucNgachCongChucs.Add(danhMucNgachCongChuc);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int idDanhMucNgachCongChuc)
        {
            var danhMucNgachCongChuc = await _context.danhMucNgachCongChucs.FindAsync(idDanhMucNgachCongChuc);
            if (danhMucNgachCongChuc == null)
            {
                return 0;
            } else
            {
                _context.danhMucNgachCongChucs.Remove(danhMucNgachCongChuc);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DanhMucNgachCongChucViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNgachCongChucs select p;
            if(query == null)
            {
                return null;
            } else
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
            var query = from p in _context.danhMucNgachCongChucs where p.id == id select p;
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
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id,DanhMucNgachCongChucUpdateRequest request)
        {
            var danhMucNgachCongChuc = await _context.danhMucNgachCongChucs.FindAsync(id);
            if (danhMucNgachCongChuc == null || request.tenNgach == null)
            {
                return 0;
            } else
            {
                danhMucNgachCongChuc.tenNgach = request.tenNgach;
                return await _context.SaveChangesAsync();
            }
        }
    }
}
