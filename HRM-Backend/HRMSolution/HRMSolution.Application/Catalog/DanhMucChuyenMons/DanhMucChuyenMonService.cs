
using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
using HRMSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChuyenMons
{
    public class DanhMucChuyenMonService : IDanhMucChuyenMonService
    {
        private readonly HRMDbContext _context;
        public DanhMucChuyenMonService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<DanhMucChuyenMonViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChuyenMons select p;

            var data = await query.Select(x => new DanhMucChuyenMonViewModel()
            {
                id = x.id,
                tenChuyenMon = x.tenChuyenMon,
                maChuyenMon = x.maChuyenMon
            }).ToListAsync();


            return data;
        }
    }
}