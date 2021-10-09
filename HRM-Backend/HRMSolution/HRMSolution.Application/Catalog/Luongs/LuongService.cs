using HRMSolution.Application.Catalog.Luongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.EF;

namespace HRMSolution.Application.Catalog.Luongs
{
    public class LuongService : ILuongService
    {
        private readonly HRMDbContext _context;
        public LuongService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<List<LuongViewModel>> GetAll()
        {
            var query = from nv in _context.nhanViens
                         join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                         join l in _context.luongs on hd.maHopDong equals l.maHopDong
                         join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                         where hd.maHopDong == l.maHopDong && hd.trangThai == true && l.trangThai == true
                         select new { hd, l, dml };

            var data = await query.Select(x => new LuongViewModel()
            {
                nhomLuong = x.dml.tenNhomLuong,
                heSoLuong = x.l.heSoLuong,
                bacLuong = x.l.bacLuong,
                luongCoBan = x.l.luongCoBan,
                phuCapTrachNhiem = x.l.phuCapTrachNhiem,
                phuCapKhac = x.l.phuCapKhac,
                tongLuong = x.l.tongLuong,
                thoiHanLenLuong = x.l.thoiHanLenLuong,
                ngayHieuLuc = x.l.ngayHieuLuc,
                ngayKetThuc = x.l.ngayKetThuc,
                trangThai = x.l.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                maHopDong = x.hd.maHopDong,
                maNhanVien = x.hd.maNhanVien
            }).ToListAsync();

            return data;
        }
    }
}
