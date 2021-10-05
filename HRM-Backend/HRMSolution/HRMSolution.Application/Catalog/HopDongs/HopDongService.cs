using HRMSolution.Application.Catalog.HopDongs.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.HopDongs
{
    public class HopDongService : IHopDongService
    {
        private readonly HRMDbContext _context;
        public HopDongService(HRMDbContext context)
        {
            _context = context;
        }
        public Task<int> Create(HopDongCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int idDanhMucDanToc)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HopDongViewModel>> GetAll()
        {
            var query = from p in _context.hopDongs select p;

            var data = await query.Select(x => new HopDongViewModel()
            {
                maHopDong = x.maHopDong,
                idLoaiHopDong = x.idLoaiHopDong,
                idChucDanh = x.idChucDanh,
                hopDongTuNgay = x.hopDongTuNgay,
                hopDongDenNgay = x.hopDongDenNgay,
                ghiChu = x.ghiChu,
                maNhanVien = x.maNhanVien
            }).ToListAsync();

            return data;
        }


        public Task<int> Update(HopDongUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
