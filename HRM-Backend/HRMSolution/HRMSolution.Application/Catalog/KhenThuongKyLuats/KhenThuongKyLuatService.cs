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

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats
{
    public class KhenThuongKyLuatService : IKhenThuongKyLuatService
    {
        private readonly HRMDbContext _context;
        public KhenThuongKyLuatService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(KhenThuongKyLuatCreateRequest request)
        {
            var ktkl = new KhenThuongKyLuat()
            {
                idDanhMucKhenThuong = request.idDanhMucKhenThuong,
                noiDung = request.noiDung,
                lyDo = request.lyDo,
                loai = request.loai,
                anh = request.anh,
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
                idDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen
            }).ToListAsync();


            return data;
        }

        public async Task<KhenThuongKyLuatViewModel> GetAllKTKLDetail(int id)
        {
            var query = from p in _context.khenThuongKyLuats
                        join dmktkl in _context.danhMucKhenThuongKyLuats on p.idDanhMucKhenThuong equals dmktkl.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.id == id
                        select new { p, dmktkl, nv };


            var data = await query.Select(x => new KhenThuongKyLuatViewModel()
            {
                id = x.p.id,
                idDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen
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
                idDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                noiDung = x.p.noiDung,
                lyDo = x.p.lyDo,
                loai = x.p.loai == true ? "Khen Thưởng" : "Kỷ Luật",
                anh = x.p.anh,
                maNhanVien = x.p.maNhanVien,
                hoTen = x.nv.hoTen
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
            danhMucKTKL.anh = request.anh;
            danhMucKTKL.maNhanVien = request.maNhanVien;

            return await _context.SaveChangesAsync();
        }
    }
}
