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
            var query = from p in _context.hopDongs 
                        join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                        join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        select new  { p, nv, dmcd, dmlhd};

            var data = await query.Select(x => new HopDongViewModel()
            {
                maHopDong = x.p.maHopDong,
                idLoaiHopDong = x.dmlhd.tenLoaiHopDong,
                idChucDanh = x.dmcd.tenChucDanh,
                hopDongTuNgay = x.p.hopDongTuNgay,
                hopDongDenNgay = x.p.hopDongDenNgay,
                ghiChu = x.p.ghiChu,
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();

            return data;
        }


        public Task<int> Update(HopDongUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
