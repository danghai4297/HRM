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
    public class NguoiThanService : INguoiThanService
    {
        private readonly HRMDbContext _context;
        public NguoiThanService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(NguoiThanCreateRequest request)
        {
            var nguoiThan = new NguoiThan()
            {
                tenNguoiThan = request.tenNguoiThan,
                gioiTinh = request.gioiTinh,
                ngaySinh = DateTime.Parse(request.ngaySinh),
                quanHe = request.quanHe,
                ngheNghiep = request.ngheNghiep,
                diaChi = request.diaChi,
                dienThoai = request.dienThoai,
                khac = request.khac,
                idDanhMucNguoiThan = request.idDanhMucNguoiThan,
                maNhanVien = request.maNhanVien
            };
            _context.nguoiThans.Add(nguoiThan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var nguoiThan = await _context.nguoiThans.FindAsync(id);
            if (nguoiThan == null) throw new HRMException($"Không tìm thấy người thân có id: {id}");

            _context.nguoiThans.Remove(nguoiThan);
            return await _context.SaveChangesAsync();
        }

        public async Task<NguoiThanViewModel> GetById(int id)
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
                tenNhanVien = x.nv.hoTen
            }).FirstOrDefaultAsync();


            return data;
        }

        public async Task<int> Update(int id, NguoiThanUpdateRequest request)
        {
            var nguoiThan = await _context.nguoiThans.FindAsync(id);
            if (nguoiThan == null) throw new HRMException($"Không tìm thấy người thân có id: {id}");

            nguoiThan.tenNguoiThan = request.tenNguoiThan;
            nguoiThan.gioiTinh = request.gioiTinh;
            nguoiThan.ngaySinh = DateTime.Parse(request.ngaySinh);
            nguoiThan.quanHe = request.quanHe;
            nguoiThan.ngheNghiep = request.ngheNghiep;
            nguoiThan.diaChi = request.diaChi;
            nguoiThan.dienThoai = request.dienThoai;
            nguoiThan.khac = request.khac;
            nguoiThan.idDanhMucNguoiThan = request.idDanhMucNguoiThan;
            nguoiThan.maNhanVien = request.maNhanVien;

            return await _context.SaveChangesAsync();
        }
    }
}
