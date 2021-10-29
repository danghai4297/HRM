using HRMSolution.Application.Catalog.LichSus.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRMSolution.Application.Catalog.LichSus
{
    public class LichSuService : ILichSuService
    {
        private readonly HRMDbContext _context;
        public LichSuService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(LichSuCreateRequest request)
        {
            var lichSu = new LichSu()
            {
                tenTaiKhoan = request.tenTaiKhoan,
                thaoTac = request.thaoTac,
                tenNhanVien = request.tenNhanVien,
                ngayThucHien = DateTime.Now,
                maNhanVien = request.maNhanVien
            };
            _context.lichSus.Add(lichSu);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<LichSuViewModel>> GetAll()
        {
            var query = from p in _context.lichSus
                        orderby p.id descending
                        select p;


            var data = await query.Select(x => new LichSuViewModel()
            {
                id = x.id,
                tenTaiKhoan = x.tenTaiKhoan,
                thaoTac = x.thaoTac,
                tenNhanVien = x.tenNhanVien,
                ngayThucHien = x.ngayThucHien,
                maNhanVien = x.maNhanVien
            }).ToListAsync();

            return data;
        }
    }
}
