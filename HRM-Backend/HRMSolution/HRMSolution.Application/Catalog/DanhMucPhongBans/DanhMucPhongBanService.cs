using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucPhongBans
{
    public class DanhMucPhongBanService : IDanhMucPhongBanService
    {
        private readonly HRMDbContext _context;
        public DanhMucPhongBanService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucPhongBanCreateRequest request)
        {
            var danhMucPhongBan = new DanhMucPhongBan()
            {
                maPhongBan = request.maPhongBan,
                tenPhongBan = request.tenPhongBan

            };
            _context.danhMucPhongBans.Add(danhMucPhongBan);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucPhongBanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucPhongBans select p;

            var data = await query.Select(x => new DanhMucPhongBanViewModel()
            {
                id = x.id,
                maPhongBan = x.maPhongBan,
                tenPhongBan = x.tenPhongBan
            }).ToListAsync();


            return data;
        }
    }
}