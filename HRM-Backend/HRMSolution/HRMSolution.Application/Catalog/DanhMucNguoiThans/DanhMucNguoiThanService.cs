using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRMSolution.Application.Catalog.DanhMucNguoiThans
{
    public class DanhMucNguoiThanService : IDanhMucNguoiThanService
    {
        private readonly HRMDbContext _context;
        public DanhMucNguoiThanService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<DanhMucNguoiThanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNguoiThans select p;

            var data = await query.Select(x => new DanhMucNguoiThanViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }
    }
}
