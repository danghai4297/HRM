using HRMSolution.Application.Catalog.NguoiThans.Dtos;
using HRMSolution.Data.EF;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.NguoiThans
{
    public class FamilyRelationshipService : IFamilyRelationshipService
    {
        private readonly HRMDbContext _context;
        public FamilyRelationshipService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(NguoiThanCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenNguoiThan = request.tenNguoiThan.Trim(charsToTrim);
            var quanHe = request.quanHe.Trim(charsToTrim);
            var ngheNghiep = request.ngheNghiep.Trim(charsToTrim);
            var diaChi = request.diaChi.Trim(charsToTrim);
            var khac = request.khac;
            if (request.khac != null)
            {
                khac = khac.Trim(charsToTrim);
            }

            if (request.tenNguoiThan == null || request.ngaySinh == null || request.ngheNghiep == null || request.diaChi == null || request.dienThoai == null || request.idDanhMucNguoiThan == 0 || request.maNhanVien == null)
            {
                return 0;
            }
            else
            {
                var nguoiThan = new NguoiThan()
                {
                    tenNguoiThan = tenNguoiThan,
                    gioiTinh = request.gioiTinh,
                    ngaySinh = request.ngaySinh,
                    quanHe = quanHe,
                    ngheNghiep = ngheNghiep,
                    diaChi = diaChi,
                    dienThoai = request.dienThoai,
                    khac = khac,
                    idDanhMucNguoiThan = request.idDanhMucNguoiThan,
                    maNhanVien = request.maNhanVien
                };
                _context.nguoiThans.Add(nguoiThan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int id)
        {
            var nguoiThan = await _context.nguoiThans.FindAsync(id);
            if (nguoiThan == null)
            {
                return 0;
            }
            else
            {
                _context.nguoiThans.Remove(nguoiThan);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<NguoiThanViewModel> GetById(int id)
        {
            var nguoiThan = await _context.nguoiThans.FindAsync(id);
            if (nguoiThan == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.nguoiThans
                            join dmnt in _context.danhMucNguoiThans on p.idDanhMucNguoiThan equals dmnt.id
                            join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                            where p.id == id
                            select new { p, dmnt, nv };
                var data = await query.Select(x => new NguoiThanViewModel()
                {
                    id = x.p.id,
                    tenNguoiThan = x.p.tenNguoiThan,
                    gioiTinh = x.p.gioiTinh == true ? "Nam" : "Nữ",
                    ngaySinh = x.p.ngaySinh,
                    danhMucNguoiThan = x.dmnt.tenDanhMuc,
                    quanHe = x.p.quanHe,
                    ngheNghiep = x.p.ngheNghiep,
                    diaChi = x.p.diaChi,
                    dienThoai = x.p.dienThoai,
                    khac = x.p.khac,
                    maNhanVien = x.p.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idDanhMucNguoiThan = x.p.idDanhMucNguoiThan
                }).FirstOrDefaultAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, NguoiThanUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenNguoiThan = request.tenNguoiThan.Trim(charsToTrim);
            var quanHe = request.quanHe.Trim(charsToTrim);
            var ngheNghiep = request.ngheNghiep.Trim(charsToTrim);
            var diaChi = request.diaChi.Trim(charsToTrim);
            var khac = request.khac.Trim(charsToTrim);
            var nguoiThan = await _context.nguoiThans.FindAsync(id);
            if (nguoiThan == null || request.tenNguoiThan == null || request.ngaySinh == null || request.ngheNghiep == null || request.diaChi == null || request.dienThoai == null || request.idDanhMucNguoiThan == 0 || request.maNhanVien == null)
            {
                return 0;
            }
            else
            {
                nguoiThan.tenNguoiThan = tenNguoiThan;
                nguoiThan.gioiTinh = request.gioiTinh;
                nguoiThan.ngaySinh = request.ngaySinh;
                nguoiThan.quanHe = quanHe;
                nguoiThan.ngheNghiep = ngheNghiep;
                nguoiThan.diaChi = diaChi;
                nguoiThan.dienThoai = request.dienThoai;
                nguoiThan.khac = khac;
                nguoiThan.idDanhMucNguoiThan = request.idDanhMucNguoiThan;
                nguoiThan.maNhanVien = request.maNhanVien;

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
