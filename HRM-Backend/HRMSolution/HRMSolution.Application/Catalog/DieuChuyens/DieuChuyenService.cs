using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DieuChuyens
{
    public class DieuChuyenService : IDieuChuyenService
    {
        private readonly HRMDbContext _context;
        public DieuChuyenService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DieuChuyenCreateRequest request)
        {
            var dieuChuyen = new DieuChuyen()
            {
                maNhanVien = request.maNhanVien,
                ngayHieuLuc = request.ngayHieuLuc,
                idPhongBan = request.idPhongBan,
                to = request.to,
                chiTiet = request.chiTiet,
                idChucVu = request.idChucVu,
                trangThai = true
            };
            _context.dieuChuyens.Add(dieuChuyen);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDieuChuyen)
        {
            var dieuChuyen = await _context.dieuChuyens.FindAsync(idDieuChuyen);
            if (dieuChuyen == null) throw new HRMException($"Không tìm thấy điều chuyển có id: {idDieuChuyen}");

            _context.dieuChuyens.Remove(dieuChuyen);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DieuChuyenViewModel>> GetAll()
        {
            var query = from dc in _context.dieuChuyens
                        join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                        join to in _context.danhMucTos on dc.to equals to.idTo
                        join cv in _context.danhMucChucVus on dc.idChucVu equals cv.id
                        join nv in _context.nhanViens on dc.maNhanVien equals nv.maNhanVien
                        select new { dc, pb, to, cv, nv };
            var data = await query.Select(x => new DieuChuyenViewModel()
            {
                id = x.dc.id,
                maNhanVien = x.dc.maNhanVien,
                tenNhanVien = x.nv.hoTen,
                ngayHieuLuc = x.dc.ngayHieuLuc,
                idPhongBan = x.pb.tenPhongBan,
                to = x.to.tenTo,
                chiTiet = x.dc.chiTiet,
                idChucVu = x.cv.tenChucVu,
                trangThai = x.dc.trangThai == true ? "Kích hoạt" : "Vô hiệu"
            }).ToListAsync();
            return data;
        }

        public async Task<DieuChuyenViewModel> GetDetail(int id)
        {
            var query = from dc in _context.dieuChuyens
                        join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                        join to in _context.danhMucTos on dc.to equals to.idTo
                        join cv in _context.danhMucChucVus on dc.idChucVu equals cv.id
                        where dc.id == id
                        select new { dc, pb, to, cv };
            var data = await query.Select(x => new DieuChuyenViewModel()
            {
                id = x.dc.id,
                maNhanVien = x.dc.maNhanVien,
                ngayHieuLuc = x.dc.ngayHieuLuc,
                idPhongBan = x.pb.tenPhongBan,
                to = x.to.tenTo,
                chiTiet = x.dc.chiTiet,
                idChucVu = x.cv.tenChucVu,
                trangThai = x.dc.trangThai == true? "Kích hoạt": "Vô hiệu"
            }).FirstAsync();

            return data;
        }

        public async Task<int> Update(int id, DieuChuyenUpdateRequest request)
        {
            var dieuChuyen = await _context.dieuChuyens.FindAsync(id);
            if (dieuChuyen == null) throw new HRMException($"Không tìm thấy điều chuyển có id: {id}");

            dieuChuyen.maNhanVien = request.maNhanVien;
            dieuChuyen.ngayHieuLuc = request.ngayHieuLuc;
            dieuChuyen.idPhongBan = request.idPhongBan;
            dieuChuyen.to = request.to;
            dieuChuyen.chiTiet = request.chiTiet;
            dieuChuyen.idChucVu = request.idChucVu;
            dieuChuyen.trangThai = request.trangThai;

            return await _context.SaveChangesAsync();
        }
    }
}
