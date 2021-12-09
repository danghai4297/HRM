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
            if (request.tenNhanVien == null || request.tenTaiKhoan == null || request.thaoTac == null || request.maNhanVien == null)
            {
                return 0;
            }
            else
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
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<LichSuViewModel>> GetAll()
        {
            var query = from p in _context.lichSus
                        orderby p.id descending
                        select p;

            if (query == null)
            {
                return null;
            }
            else
            {
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
}
