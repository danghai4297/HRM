
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs
{
    public class DanhMucChucDanhService : IDanhMucChucDanhService
    {
        private readonly HRMDbContext _context;
        public DanhMucChucDanhService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucChucDanhCreateRequest request)
        {
            var danhMucChucDanh = new DanhMucChucDanh()
            {
                tenChucDanh = request.tenChucDanh,
                maChucDanh = request.maChucDanh,
                phuCap = request.phuCap
            };
            _context.danhMucChucDanhs.Add(danhMucChucDanh);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucChucDanhViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChucDanhs select p;

            var data = await query.Select(x => new DanhMucChucDanhViewModel()
            {
                id = x.id,
                maChucDanh = x.maChucDanh,
                tenChucDanh =x.tenChucDanh,
                phuCap=x.phuCap
            }).ToListAsync();


            return data;
        }
    }
}