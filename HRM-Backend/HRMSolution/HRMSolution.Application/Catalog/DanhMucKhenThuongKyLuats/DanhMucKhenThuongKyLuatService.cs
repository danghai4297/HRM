using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
using HRMSolution.Data.EF;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats
{
    public class DanhMucKhenThuongKyLuatService : IDanhMucKhenThuongKyLuatService
    {   
        private readonly HRMDbContext _context;
        public DanhMucKhenThuongKyLuatService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKhenThuong()
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.tieuDe == "Khen thưởng"
                        select p;

            var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc,
                tieuDe = x.tieuDe
            }).ToListAsync();


            return data;
        }

        public async Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKyLuat()
        {
            var query = from p in _context.danhMucKhenThuongKyLuats
                        where p.tieuDe == "Kỷ luật"
                        select p;

            var data = await query.Select(x => new DanhMucKhenThuongKyLuatViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc,
                tieuDe = x.tieuDe
            }).ToListAsync();


            return data;
        }
    }
}
