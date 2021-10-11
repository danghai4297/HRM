using HRMSolution.Application.Catalog.NguoiThans.Dtos;
using HRMSolution.Data.EF;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRMSolution.Data.Entities;

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
                ngaySinh = request.ngaySinh,
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

        public async Task<NguoiThanViewModel> GetNguoiThan(int id)
        {
            var query = from p in _context.nguoiThans
                        join dmnt in _context.danhMucNguoiThans on p.idDanhMucNguoiThan equals dmnt.id
                        where p.id == id
                        select new { p, dmnt };


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
                khac = x.p.khac
            }).FirstOrDefaultAsync();


            return data;
        }
    }
}
