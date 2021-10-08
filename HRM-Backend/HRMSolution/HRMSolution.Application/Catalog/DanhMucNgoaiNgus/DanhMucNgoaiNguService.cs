
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRMSolution.Application.Catalog.DanhMucNgoaiNgus
{
    public class DanhMucNgoaiNguService : IDanhMucNgoaiNguService
    {
        private readonly HRMDbContext _context;
        public DanhMucNgoaiNguService(HRMDbContext context)
        {
            _context = context;
        }


        public async Task<List<DanhMucNgoaiNguViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNgoaiNgus select p;

            var data = await query.Select(x => new DanhMucNgoaiNguViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }
    }
}
