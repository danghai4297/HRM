using HRMSolution.Application.Catalog.NguoiThans.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRMSolution.Application.Catalog.NguoiThans
{
    public class NguoiThanService : INguoiThanService
    {
        private readonly HRMDbContext _context;
        public NguoiThanService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<NguoiThanViewModel>> GetAll(string maNhanVien)
        {
            var query = from p in _context.nguoiThans
                        join dmnt in _context.danhMucNguoiThans on p.idDanhMucNguoiThan equals dmnt.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where nv.maNhanVien == maNhanVien
                        select new { p, dmnt, nv };


            var data = await query.Select(x => new NguoiThanViewModel()
            {
                id = x.p.id,
                tenNguoiThan = x.p.tenNguoiThan,
                gioiTinh = x.p.gioiTinh == true?"Nam": "Nữ",
                ngaySinh = x.p.ngaySinh,
                danhMucNguoiThan = x.dmnt.tenDanhMuc,
                quanHe = x.p.quanHe,
                ngheNghiep = x.p.ngheNghiep,
                diaChi = x.p.diaChi,
                dienThoai = x.p.dienThoai,
                khac = x.p.khac,
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();


            return data;
        }
    }
}
