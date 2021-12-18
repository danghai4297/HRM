using HRMSolution.Application.Catalog.HopDongs.Dtos;
using HRMSolution.Application.Common;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.HopDongs
{
    public class LaborContractService : ILaborContractService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public LaborContractService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(HopDongCreateRequest request)
        {
            if (request.maHopDong == null || request.idLoaiHopDong == 0 || request.idChucDanh == 0 || request.idChucVu == 0 || request.maNhanVien == null)
            {
                return 0;
            }
            else
            {
                var queryHopDong = await _context.hopDongs.Where(x => x.maNhanVien == request.maNhanVien && x.trangThai == true).FirstOrDefaultAsync();
                if (queryHopDong == null)
                {
                    var hopDong = new HopDong()
                    {
                        id = request.idCre,
                        maHopDong = request.maHopDong,
                        idLoaiHopDong = request.idLoaiHopDong,
                        idChucDanh = request.idChucDanh,
                        idChucVu = request.idChucVu,
                        hopDongTuNgay = request.hopDongTuNgay,
                        hopDongDenNgay = request.hopDongDenNgay,
                        ghiChu = request.ghiChu,
                        trangThai = true,
                        maNhanVien = request.maNhanVien
                    };
                    _context.hopDongs.Add(hopDong);
                }
                else
                {
                    var hopDong_update = await _context.hopDongs.FindAsync(queryHopDong.maHopDong);

                    hopDong_update.trangThai = false;

                    var queryLuong = await _context.luongs.Where(x => x.maHopDong == queryHopDong.maHopDong && x.trangThai == true).FirstOrDefaultAsync();
                    if (queryLuong == null)
                    {
                        var hopDong = new HopDong()
                        {
                            id = request.idCre,
                            maHopDong = request.maHopDong,
                            idLoaiHopDong = request.idLoaiHopDong,
                            idChucDanh = request.idChucDanh,
                            idChucVu = request.idChucVu,
                            hopDongTuNgay = request.hopDongTuNgay,
                            hopDongDenNgay = request.hopDongDenNgay,
                            ghiChu = request.ghiChu,
                            trangThai = true,
                            maNhanVien = request.maNhanVien
                        };
                        _context.hopDongs.Add(hopDong);
                    }
                    else
                    {
                        var luong_update = await _context.luongs.FindAsync(queryLuong.id);
                        luong_update.trangThai = false;
                        var hopDong = new HopDong()
                        {
                            id = request.idCre,
                            maHopDong = request.maHopDong,
                            idLoaiHopDong = request.idLoaiHopDong,
                            idChucDanh = request.idChucDanh,
                            idChucVu = request.idChucVu,
                            hopDongTuNgay = request.hopDongTuNgay,
                            hopDongDenNgay = request.hopDongDenNgay,
                            ghiChu = request.ghiChu,
                            trangThai = true,
                            maNhanVien = request.maNhanVien
                        };
                        _context.hopDongs.Add(hopDong);
                    }
                }
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(string maHopDong)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);
            if (hopDong == null)
            {
                return 0;
            }
            else
            {
                await _storageService.DeleteFileAsync(hopDong.bangChung);
                _context.hopDongs.Remove(hopDong);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<HopDongViewModel> GetHopDong(string maHopDong)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);

            if (hopDong == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.hopDongs
                            join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                            join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                            join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                            join dmcv in _context.danhMucChucVus on p.idChucVu equals dmcv.id
                            where p.maHopDong == maHopDong
                            select new { p, nv, dmcd, dmlhd, dmcv };
                var data = await query.Select(x => new HopDongViewModel()
                {
                    idCre = x.p.id,
                    id = x.p.maHopDong,
                    loaiHopDong = x.dmlhd.tenLoaiHopDong,
                    chucDanh = x.dmcd.tenChucDanh,
                    chucVu = x.dmcv.tenChucVu,
                    hopDongTuNgay = x.p.hopDongTuNgay,
                    hopDongDenNgay = x.p.hopDongDenNgay,
                    ghiChu = x.p.ghiChu,
                    trangThai = x.p.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                    bangChung = x.p.bangChung,
                    maNhanVien = x.p.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idChucDanh = x.p.idChucDanh,
                    idChucVu = x.p.idChucVu,
                    idLoaiHopDong = x.p.idLoaiHopDong,
                    phuCapChucDanh = x.dmcd.phuCap,
                    phuCapChucVu = x.dmcv.phuCap
                }).FirstAsync();

                return data;
            }
        }

        public async Task<List<HopDongViewModel>> GetAll()
        {
            var query = from p in _context.hopDongs
                        join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                        join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        join dmcv in _context.danhMucChucVus on p.idChucVu equals dmcv.id
                        orderby p.id descending
                        select new { p, nv, dmcd, dmlhd, dmcv };
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new HopDongViewModel()
                {
                    idCre = x.p.id,
                    id = x.p.maHopDong,
                    loaiHopDong = x.dmlhd.tenLoaiHopDong,
                    chucDanh = x.dmcd.tenChucDanh,
                    chucVu = x.dmcv.tenChucVu,
                    hopDongTuNgay = x.p.hopDongTuNgay,
                    hopDongDenNgay = x.p.hopDongDenNgay,
                    ghiChu = x.p.ghiChu,
                    trangThai = x.p.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                    bangChung = x.p.bangChung,
                    maNhanVien = x.p.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idChucDanh = x.p.idChucDanh,
                    idChucVu = x.p.idChucVu,
                    idLoaiHopDong = x.p.idLoaiHopDong,
                    phuCapChucDanh = x.dmcd.phuCap,
                    phuCapChucVu = x.dmcv.phuCap
                }).ToListAsync();
                return data;
            }
        }

        public async Task<List<HopDongViewModel>> GetAll(string maNhanVien)
        {
            var hopDong = await _context.hopDongs.FindAsync(maNhanVien);

            if (hopDong == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.hopDongs
                            join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                            join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                            join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                            join dmcv in _context.danhMucChucVus on p.idChucVu equals dmcv.id
                            orderby p.id descending
                            where p.maNhanVien == maNhanVien
                            select new { p, nv, dmcd, dmlhd, dmcv };
                var data = await query.Select(x => new HopDongViewModel()
                {
                    idCre = x.p.id,
                    id = x.p.maHopDong,
                    loaiHopDong = x.dmlhd.tenLoaiHopDong,
                    chucDanh = x.dmcd.tenChucDanh,
                    chucVu = x.dmcv.tenChucVu,
                    hopDongTuNgay = x.p.hopDongTuNgay,
                    hopDongDenNgay = x.p.hopDongDenNgay,
                    ghiChu = x.p.ghiChu,
                    trangThai = x.p.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                    bangChung = x.p.bangChung,
                    maNhanVien = x.p.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idChucDanh = x.p.idChucDanh,
                    idChucVu = x.p.idChucVu,
                    idLoaiHopDong = x.p.idLoaiHopDong,
                    phuCapChucDanh = x.dmcd.phuCap,
                    phuCapChucVu = x.dmcv.phuCap
                }).ToListAsync();

                return data;
            }
        }

        public async Task<int> Update(string maHopDong, HopDongUpdateRequest request)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);
            if (hopDong == null || request.idLoaiHopDong == 0 || request.idChucDanh == 0 || request.idChucVu == 0 || request.maNhanVien == null)
            {
                return 0;
            }
            else
            {
                if (request.trangThai == false)
                {
                    var luong = await _context.luongs.Where(x => x.maHopDong == maHopDong && x.trangThai == true).FirstOrDefaultAsync();
                    luong.trangThai = false;

                    hopDong.id = request.idCre;
                    hopDong.idLoaiHopDong = request.idLoaiHopDong;
                    hopDong.idChucDanh = request.idChucDanh;
                    hopDong.idChucVu = request.idChucVu;
                    hopDong.hopDongTuNgay = request.hopDongTuNgay;
                    hopDong.hopDongDenNgay = request.hopDongDenNgay;
                    hopDong.ghiChu = request.ghiChu;
                    hopDong.trangThai = request.trangThai;
                    hopDong.maNhanVien = request.maNhanVien;
                }
                else
                {
                    hopDong.id = request.idCre;
                    hopDong.idLoaiHopDong = request.idLoaiHopDong;
                    hopDong.idChucDanh = request.idChucDanh;
                    hopDong.idChucVu = request.idChucVu;
                    hopDong.hopDongTuNgay = request.hopDongTuNgay;
                    hopDong.hopDongDenNgay = request.hopDongDenNgay;
                    hopDong.ghiChu = request.ghiChu;
                    hopDong.trangThai = request.trangThai;
                    hopDong.maNhanVien = request.maNhanVien;
                }

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> UpdateBangChung(string maHopDong, HopDongUpdateBangChungRequest request)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);
            if (hopDong == null)
            {
                return 0;
            }
            else
            {
                hopDong.bangChung = await this.SaveFile(request.bangChung, request.tenFile);

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> DeleteBangChung(string maHopDong)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);
            if (hopDong == null)
            {
                return 0;
            }
            else
            {
                await _storageService.DeleteFileAsync(hopDong.bangChung);

                hopDong.bangChung = null;
                _context.hopDongs.Update(hopDong);

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
        private async Task<string> SaveFile(IFormFile file, string name)
        {
            var defaultName = name.Substring(0, name.LastIndexOf("."));
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{defaultName}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
