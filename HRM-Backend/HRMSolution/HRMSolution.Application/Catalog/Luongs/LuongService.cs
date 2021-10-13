using HRMSolution.Application.Catalog.Luongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;

namespace HRMSolution.Application.Catalog.Luongs
{
    public class LuongService : ILuongService
    {
        private readonly HRMDbContext _context;
        public LuongService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(LuongCreateRequest request)
        {
            var luong = new Luong()
            {
                maHopDong = request.maHopDong,
                idNhomLuong = request.idNhomLuong,
                heSoLuong = request.heSoLuong,
                bacLuong = request.bacLuong,
                luongCoBan = request.luongCoBan,
                phuCapTrachNhiem = request.phuCapTrachNhiem,
                phuCapKhac = request.phuCapKhac,
                tongLuong = request.tongLuong,
                thoiHanLenLuong = request.thoiHanLenLuong,
                ngayHieuLuc = request.ngayHieuLuc,
                ngayKetThuc = request.ngayKetThuc,
                ghiChu = request.ghiChu,
                trangThai = true
            };
            _context.luongs.Add(luong);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<LuongViewModel>> GetAll()
        {
            var query = from nv in _context.nhanViens
                         join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                         join l in _context.luongs on hd.maHopDong equals l.maHopDong
                         join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                         where hd.maHopDong == l.maHopDong && hd.trangThai == true && l.trangThai == true
                        select new { hd, l, dml, nv };

            var data = await query.Select(x => new LuongViewModel()
            {
                id = x.l.id,
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
                maNhanVien = x.hd.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();

            return data;
        }

        public async Task<LuongViewModel> GetLuong(int id)
        {
            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                        where hd.maHopDong == l.maHopDong && l.id == id
                        select new { hd, l, dml };

            var data = await query.Select(x => new LuongViewModel()
            {
                id = x.l.id,
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
            }).FirstAsync();

            return data;
        }
    }
}
