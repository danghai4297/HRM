using HRMSolution.Application.Catalog.Luongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using HRMSolution.Application.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;

namespace HRMSolution.Application.Catalog.Luongs
{
    public class LuongService : ILuongService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public LuongService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(LuongCreateRequest request)
        {
            if (request.maHopDong == null || request.idNhomLuong == 0 || request.thoiHanLenLuong == null || request.ngayHieuLuc == null || request.ngayKetThuc == null || request.bacLuong == null
                || request.thoiHanLenLuong == null)
            {
                return 0;
            }
            else
            {
                var query = await _context.luongs.Where(x => x.maHopDong == request.maHopDong && x.trangThai == true).FirstOrDefaultAsync();

                if (query == null)
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
                        ngayHieuLuc = DateTime.Parse(request.ngayHieuLuc),
                        ngayKetThuc = DateTime.Parse(request.ngayKetThuc),
                        ghiChu = request.ghiChu,
                        trangThai = true,
                    };
                    if (request.bangChung is null)
                    {
                        luong.bangChung = null;
                    }
                    else
                    {
                        luong.bangChung = await this.SaveFile(request.bangChung);
                    }
                    _context.luongs.Add(luong);
                }
                else
                {
                    var luong_update = await _context.luongs.FindAsync(query.id);

                    luong_update.trangThai = false;

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
                        ngayHieuLuc = DateTime.Parse(request.ngayHieuLuc),
                        ngayKetThuc = DateTime.Parse(request.ngayKetThuc),
                        ghiChu = request.ghiChu,
                        trangThai = true,
                    };
                    if (request.bangChung is null)
                    {
                        luong.bangChung = null;
                    }
                    else
                    {
                        luong.bangChung = await this.SaveFile(request.bangChung);
                    }
                    _context.luongs.Add(luong);
                }

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int id)
        {
            var luong = await _context.luongs.FindAsync(id);
            if (luong == null)
            {
                return 0;
            }
            else
            {
                await _storageService.DeleteFileAsync(luong.bangChung);
                _context.luongs.Remove(luong);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<LuongViewModel>> GetAll()
        {
            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                        orderby l.id descending
                        where hd.maHopDong == l.maHopDong && hd.trangThai == true && l.trangThai == true
                        select new { hd, l, dml, nv };
            if (query == null)
            {
                return null;
            }
            else
            {
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
                    bangChung = x.l.bangChung,
                    maHopDong = x.hd.maHopDong,
                    maNhanVien = x.hd.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idNhomLuong = x.l.idNhomLuong
                }).ToListAsync();

                return data;
            }
        }

        public async Task<LuongViewModel> GetById(int id)
        {
            var luong = await _context.luongs.FindAsync(id);

            if (luong == null)
            {
                return null;
            }
            else
            {
                var query = from nv in _context.nhanViens
                            join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                            join l in _context.luongs on hd.maHopDong equals l.maHopDong
                            join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                            where hd.maHopDong == l.maHopDong && l.id == id
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
                    bangChung = x.l.bangChung,
                    maHopDong = x.hd.maHopDong,
                    maNhanVien = x.hd.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idNhomLuong = x.l.idNhomLuong,
                    ghiChu = x.l.ghiChu
                }).FirstAsync();

                return data;
            }
        }

        public async Task<int> Update(int id, LuongUpdateRequest request)
        {
            var luong = await _context.luongs.FindAsync(id);
            if (luong == null || request.idNhomLuong == 0 || request.thoiHanLenLuong == null || request.ngayHieuLuc == null || request.ngayKetThuc == null || request.bacLuong == null
                || request.thoiHanLenLuong == null)
            {
                return 0;
            }
            else
            {
                luong.idNhomLuong = request.idNhomLuong;
                luong.heSoLuong = request.heSoLuong;
                luong.bacLuong = request.bacLuong;
                luong.luongCoBan = request.luongCoBan;
                luong.phuCapTrachNhiem = request.phuCapTrachNhiem;
                luong.phuCapKhac = request.phuCapKhac;
                luong.tongLuong = request.tongLuong;
                luong.thoiHanLenLuong = request.thoiHanLenLuong;
                luong.ngayHieuLuc = DateTime.Parse(request.ngayHieuLuc);
                luong.ngayKetThuc = DateTime.Parse(request.ngayKetThuc);
                luong.ghiChu = request.ghiChu;
                luong.trangThai = request.trangThai;
                if (request.bangChung is null)
                {
                    //luong.bangChung = luong.bangChung;
                }
                else
                {
                    await _storageService.DeleteFileAsync(luong.bangChung);
                    luong.bangChung = await this.SaveFile(request.bangChung);
                }

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

    }
}
