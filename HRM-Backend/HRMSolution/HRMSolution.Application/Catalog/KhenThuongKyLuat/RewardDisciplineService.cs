using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using System.Net.Http.Headers;
using HRMSolution.Application.Common;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats
{
    public class RewardDisciplineService : IRewardDisciplineService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public RewardDisciplineService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(KhenThuongKyLuatCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var noiDung = request.noiDung.Trim(charsToTrim);
            var lyDo = request.lyDo.Trim(charsToTrim);
            if (request.idDanhMucKhenThuong == 0 || request.noiDung == null || request.lyDo == null || request.maNhanVien == null)
            {
                return 0;
            }
            else
            {
                var ktkl = new KhenThuongKyLuat()
                {
                    idDanhMucKhenThuong = request.idDanhMucKhenThuong,
                    noiDung = noiDung,
                    lyDo = lyDo,
                    loai = request.loai,
                    maNhanVien = request.maNhanVien,
                };
                if (request.bangChung is null)
                {
                    ktkl.bangChung = null;
                }
                else
                {
                    ktkl.bangChung = await this.SaveFile(request.bangChung, request.tenFile);
                }
                _context.khenThuongKyLuats.Add(ktkl);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }


        public async Task<int> Delete(int idDanhMucKTKL)
        {
            var ktkl = await _context.khenThuongKyLuats.FindAsync(idDanhMucKTKL);
            if (ktkl == null)
            {
                return 0;
            }
            else
            {
                await _storageService.DeleteFileAsync(ktkl.bangChung);
                _context.khenThuongKyLuats.Remove(ktkl);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }


        public async Task<List<KhenThuongKyLuatViewModel>> GetAllKhenThuong()
        {
            var query = from p in _context.khenThuongKyLuats
                        join dmktkl in _context.danhMucKhenThuongKyLuats on p.idDanhMucKhenThuong equals dmktkl.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.loai == true
                        select new { p, dmktkl, nv };

            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new KhenThuongKyLuatViewModel()
                {
                    id = x.p.id,
                    DanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                    noiDung = x.p.noiDung,
                    lyDo = x.p.lyDo,
                    loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                    anh = x.nv.anh,
                    maNhanVien = x.p.maNhanVien,
                    hoTen = x.nv.hoTen,
                    idDanhMucKhenThuong = x.p.idDanhMucKhenThuong,
                    bangChung = x.p.bangChung
                }).ToListAsync();
                return data;
            }
        }

        public async Task<KhenThuongKyLuatViewModel> GetById(int id)
        {
            var ktkl = await _context.khenThuongKyLuats.FindAsync(id);


            if (ktkl == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.khenThuongKyLuats
                            join dmktkl in _context.danhMucKhenThuongKyLuats on p.idDanhMucKhenThuong equals dmktkl.id
                            join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                            where p.id == id
                            select new { p, dmktkl, nv };
                var data = await query.Select(x => new KhenThuongKyLuatViewModel()
                {
                    id = x.p.id,
                    DanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                    noiDung = x.p.noiDung,
                    lyDo = x.p.lyDo,
                    loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                    anh = x.nv.anh,
                    maNhanVien = x.p.maNhanVien,
                    hoTen = x.nv.hoTen,
                    idDanhMucKhenThuong = x.p.idDanhMucKhenThuong,
                    bangChung = x.p.bangChung
                }).FirstAsync();
                return data;
            }
        }

        public async Task<List<KhenThuongKyLuatViewModel>> GetAllKyLuat()
        {
            var query = from p in _context.khenThuongKyLuats
                        join dmktkl in _context.danhMucKhenThuongKyLuats on p.idDanhMucKhenThuong equals dmktkl.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.loai == false
                        select new { p, dmktkl, nv };
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new KhenThuongKyLuatViewModel()
                {
                    id = x.p.id,
                    DanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                    noiDung = x.p.noiDung,
                    lyDo = x.p.lyDo,
                    loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                    anh = x.nv.anh,
                    maNhanVien = x.p.maNhanVien,
                    hoTen = x.nv.hoTen,
                    idDanhMucKhenThuong = x.p.idDanhMucKhenThuong,
                    bangChung = x.p.bangChung
                }).ToListAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, KhenThuongKyLuatUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var noiDung = request.noiDung.Trim(charsToTrim);
            var lyDo = request.lyDo.Trim(charsToTrim);
            var ktkl = await _context.khenThuongKyLuats.FindAsync(id);
            if (ktkl == null || request.idDanhMucKhenThuong == 0 || request.noiDung == null || request.lyDo == null || request.maNhanVien == null)
            {
                return 0;
            }
            else
            {
                ktkl.idDanhMucKhenThuong = request.idDanhMucKhenThuong;
                ktkl.noiDung = noiDung;
                ktkl.lyDo = lyDo;
                ktkl.loai = request.loai;
                ktkl.maNhanVien = request.maNhanVien;
                if (request.bangChung is null)
                {

                }
                else
                {
                    await _storageService.DeleteFileAsync(ktkl.bangChung);
                    ktkl.bangChung = await this.SaveFile(request.bangChung, request.tenFile);
                }

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
