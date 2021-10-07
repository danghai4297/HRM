using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
using HRMSolution.Data.EF;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucHonNhans
{
    public class DanhMucHonNhanService : IDanhMucHonNhanService
    {
        private readonly HRMDbContext _context;
        public DanhMucHonNhanService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<DanhMucHonNhanViewModel>> GetALL()
        {
            var query = from p in _context.danhMucHonNhans select p;

            var data = await query.Select(x => new DanhMucHonNhanViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }
    }
}