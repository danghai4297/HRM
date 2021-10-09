using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HRMSolution.Data.Entities;

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
            var danhMucNgachCongChuc = new DanhMucNgachCongChuc()
            {
                
                tenNgach = request.tenNgach

            };
            _context.danhMucNgachCongChucs.Add(danhMucNgachCongChuc);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucNgachCongChucViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNgachCongChucs select p;

            var data = await query.Select(x => new DanhMucNgachCongChucViewModel()
            {
                id = x.id,
                tenNgach = x.tenNgach
            }).ToListAsync();


            return data;
        }
    }
}
