﻿using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
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
    public class KhenThuongKyLuatService : IKhenThuongKyLuatService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public KhenThuongKyLuatService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(KhenThuongKyLuatCreateRequest request)
        {
            var ktkl = new KhenThuongKyLuat()
            {
                idDanhMucKhenThuong = request.idDanhMucKhenThuong,
                noiDung = request.noiDung,
                lyDo = request.lyDo,
                loai = request.loai,
                maNhanVien = request.maNhanVien,
            };
            if(request.anh is null)
            {
                ktkl.anh = "";
            } else
            {
                ktkl.anh = await this.SaveFile(request.anh);
            }

            _context.khenThuongKyLuats.Add(ktkl);
            return await _context.SaveChangesAsync();
        }


        public async Task<int> Delete(int idDanhMucKTKL)
        {
            var danhMucKTKL = await _context.khenThuongKyLuats.FindAsync(idDanhMucKTKL);
            if (danhMucKTKL == null) throw new HRMException($"Không tìm thấy khen thưởng kỷ luật có id: {idDanhMucKTKL}");

            _context.khenThuongKyLuats.Remove(danhMucKTKL);
            return await _context.SaveChangesAsync();
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
                DanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.nv.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen,
                idDanhMucKhenThuong = x.p.idDanhMucKhenThuong,
                bangChung = x.p.anh
            }).ToListAsync();


            return data;
        }

        public async Task<KhenThuongKyLuatViewModel> GetById(int id)
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
                bangChung = x.p.anh
            }).FirstAsync();


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
                DanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.nv.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen,
                idDanhMucKhenThuong = x.p.idDanhMucKhenThuong,
                bangChung = x.p.anh
            }).ToListAsync();


            return data;
        }

        public async Task<int> Update(int id, KhenThuongKyLuatUpdateRequest request)
        {
            var ktkl = await _context.khenThuongKyLuats.FindAsync(id);
            if (ktkl == null) throw new HRMException($"Không tìm thấy khen thưởng kỷ luật : {id}");

            ktkl.idDanhMucKhenThuong = request.idDanhMucKhenThuong;
            ktkl.noiDung = request.noiDung;
            ktkl.lyDo = request.lyDo;
            ktkl.loai = request.loai;
            ktkl.maNhanVien = request.maNhanVien;
            if (request.bangChung is null)
            {
                ktkl.anh = "";
            }
            else
            {
                ktkl.anh = await this.SaveFile(request.bangChung);
            }

            return await _context.SaveChangesAsync();
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
