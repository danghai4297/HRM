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
                maNhanVien = request.maNhanVien
            };
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
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen,
                idDanhMucKhenThuong = x.p.idDanhMucKhenThuong
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
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen,
                idDanhMucKhenThuong = x.p.idDanhMucKhenThuong
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
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen,
                idDanhMucKhenThuong = x.p.idDanhMucKhenThuong
            }).ToListAsync();


            return data;
        }

        public async Task<int> Update(int id, KhenThuongKyLuatUpdateRequest request)
        {
            var danhMucKTKL = await _context.khenThuongKyLuats.FindAsync(id);
            if (danhMucKTKL == null) throw new HRMException($"Không tìm thấy khen thưởng kỷ luật : {id}");

            danhMucKTKL.idDanhMucKhenThuong = request.idDanhMucKhenThuong;
            danhMucKTKL.noiDung = request.noiDung;
            danhMucKTKL.lyDo = request.lyDo;
            danhMucKTKL.loai = request.loai;
            danhMucKTKL.maNhanVien = request.maNhanVien;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int id, KhenThuongKyLuatUpdateRequest request)
        {
            var anh = await _context.khenThuongKyLuats.FindAsync(id);
            if (anh == null) throw new HRMException($"Không tìm thấy khen thưởng kỷ luật có id: {id}");

            anh.anh = await this.SaveFile(request.anh);

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
