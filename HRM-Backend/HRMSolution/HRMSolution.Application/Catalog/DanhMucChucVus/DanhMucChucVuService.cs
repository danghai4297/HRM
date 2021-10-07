
using HRMSolution.Application.Catalog.DanhMucChucVus;
using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
using HRMSolution.Data.EF;
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
        public async Task<List<DanhMucChucVuViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChucVus select p;

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
}