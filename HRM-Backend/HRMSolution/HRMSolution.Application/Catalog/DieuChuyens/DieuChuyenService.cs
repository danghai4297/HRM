﻿using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using HRMSolution.Application.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;

namespace HRMSolution.Application.Catalog.DieuChuyens
{
    public class DieuChuyenService : IDieuChuyenService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public DieuChuyenService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(DieuChuyenCreateRequest request)
        {
            if (request.maNhanVien == null || request.ngayHieuLuc == null || request.idPhongBan == 0 || request.to == 0)
            {
                return 0;
            } else
            {
                var dieuChuyen = new DieuChuyen()
                {
                    maNhanVien = request.maNhanVien,
                    ngayHieuLuc = DateTime.Parse(request.ngayHieuLuc),
                    idPhongBan = request.idPhongBan,
                    to = request.to,
                    chiTiet = request.chiTiet,
                    trangThai = true
                };
                if (request.bangChung is null)
                {
                    dieuChuyen.bangChung = null;
                }
                else
                {
                    dieuChuyen.bangChung = await this.SaveFile(request.bangChung);
                }
                _context.dieuChuyens.Add(dieuChuyen);
                return await _context.SaveChangesAsync();
            }
            
        }

        public async Task<int> Delete(int idDieuChuyen)
        {
            var dieuChuyen = await _context.dieuChuyens.FindAsync(idDieuChuyen);
            if (dieuChuyen == null)
            {
                return 0;
            } else
            {
                await _storageService.DeleteFileAsync(dieuChuyen.bangChung);
                _context.dieuChuyens.Remove(dieuChuyen);
                return await _context.SaveChangesAsync();
            }        }

        public async Task<List<DieuChuyenViewModel>> GetAll()
        {
            var query = from dc in _context.dieuChuyens
                        join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                        join to in _context.danhMucTos on dc.to equals to.idTo
                        join nv in _context.nhanViens on dc.maNhanVien equals nv.maNhanVien
                        select new { dc, pb, to, nv };
            if(query == null)
            {
                return null;
            } else
            {
                var data = await query.Select(x => new DieuChuyenViewModel()
                {
                    id = x.dc.id,
                    maNhanVien = x.dc.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    ngayHieuLuc = x.dc.ngayHieuLuc,
                    PhongBan = x.pb.tenPhongBan,
                    to = x.to.tenTo,
                    chiTiet = x.dc.chiTiet,
                    trangThai = x.dc.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                    idPhongBan = x.dc.idPhongBan,
                    idTo = x.dc.to,
                    bangChung = x.dc.bangChung
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DieuChuyenViewModel> GetById(int id)
        {
            var query = from dc in _context.dieuChuyens
                        join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                        join to in _context.danhMucTos on dc.to equals to.idTo
                        join nv in _context.nhanViens on dc.maNhanVien equals nv.maNhanVien
                        where dc.id == id
                        select new { dc, pb, to, nv };
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DieuChuyenViewModel()
                {
                    id = x.dc.id,
                    maNhanVien = x.dc.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    ngayHieuLuc = x.dc.ngayHieuLuc,
                    PhongBan = x.pb.tenPhongBan,
                    to = x.to.tenTo,
                    chiTiet = x.dc.chiTiet,
                    trangThai = x.dc.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                    idPhongBan = x.dc.idPhongBan,
                    idTo = x.dc.to,
                    bangChung = x.dc.bangChung
                }).FirstAsync();

                return data;
            }
        }

        public async Task<int> Update(int id, DieuChuyenUpdateRequest request)
        {
            var dieuChuyen = await _context.dieuChuyens.FindAsync(id);
            if (dieuChuyen == null || request.maNhanVien == null || request.ngayHieuLuc == null || request.idPhongBan == 0 || request.to == 0)
            {
                return 0;
            } else
            {
                dieuChuyen.maNhanVien = request.maNhanVien;
                dieuChuyen.ngayHieuLuc = DateTime.Parse(request.ngayHieuLuc);
                dieuChuyen.idPhongBan = request.idPhongBan;
                dieuChuyen.to = request.to;
                dieuChuyen.chiTiet = request.chiTiet;
                dieuChuyen.trangThai = request.trangThai;
                if (request.bangChung is null)
                {
                    //dieuChuyen.bangChung = null;
                }
                else
                {
                    await _storageService.DeleteFileAsync(dieuChuyen.bangChung);
                    dieuChuyen.bangChung = await this.SaveFile(request.bangChung);
                }
                return await _context.SaveChangesAsync();
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
