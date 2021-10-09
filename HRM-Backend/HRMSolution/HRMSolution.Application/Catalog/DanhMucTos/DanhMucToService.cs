using HRMSolution.Application.Catalog.DanhMucTos.Dtos;
using HRMSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTos
{
    public class DanhMucToService : IDanhMucToService
    {
        private readonly HRMDbContext _context;
        public DanhMucToService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<DanhMucToViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTos select p;

            var data = await query.Select(x => new DanhMucToViewModel()
            {
                idTo = x.idTo,
                maTo = x.maTo,
                tenTo=x.tenTo,
                idPhongBan=x.idPhongBan
            }).ToListAsync();
            return data;
        }
    }
}