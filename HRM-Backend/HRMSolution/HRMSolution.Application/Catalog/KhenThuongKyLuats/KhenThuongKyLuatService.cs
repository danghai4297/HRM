using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats
{
    public class KhenThuongKyLuatService : IKhenThuongKyLuatService
    {
        private readonly HRMDbContext _context;
        public KhenThuongKyLuatService(HRMDbContext context)
        {
            _context = context;
        }
        public Task<int> Create(KhenThuongKyLuatCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int idDanhMucDanToc)
        {
            throw new NotImplementedException();
        }


        public async Task<List<KhenThuongKyLuatViewModel>> GetAllKhenThuong()
        {
            var query = from p in _context.khenThuongKyLuats
                        join dmktkl in _context.danhMucKhenThuongKyLuats on p.idDanhMucKhenThuong equals dmktkl.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.loai == true
                        select new { p, dmktkl, nv };


            var data = await query.Select(x => new KhenThuongKyLuatViewModel()
            {
                id = x.p.id,
                idDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen
            }).ToListAsync();


            return data;
        }

        public async Task<List<KhenThuongKyLuatViewModel>> GetAllKyLuat()
        {
            var query = from p in _context.khenThuongKyLuats
                        join dmktkl in _context.danhMucKhenThuongKyLuats on p.idDanhMucKhenThuong equals dmktkl.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.loai == false
                        select new { p, dmktkl, nv };


            var data = await query.Select(x => new KhenThuongKyLuatViewModel()
            {
                id = x.p.id,
                idDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen
            }).ToListAsync();


            return data;
        }

        public Task<int> Update(KhenThuongKyLuatUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
