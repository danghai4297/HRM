using HRMSolution.Application.Catalog.HopDongs.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.HopDongs
{
    public class HopDongService : IHopDongService
    {
        private readonly HRMDbContext _context;
        public HopDongService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(HopDongCreateRequest request)
        {
            var queryHopDong = await _context.hopDongs.Where(x => x.maNhanVien == request.maNhanVien && x.trangThai == true).FirstOrDefaultAsync();

            if(queryHopDong == null)
            {
                var hopDong = new HopDong()
                {
                    maHopDong = request.maHopDong,
                    idLoaiHopDong = request.idLoaiHopDong,
                    idChucDanh = request.idChucDanh,
                    hopDongTuNgay = request.hopDongTuNgay,
                    hopDongDenNgay = request.hopDongDenNgay,
                    ghiChu = request.ghiChu,
                    trangThai = true,
                    maNhanVien = request.maNhanVien
                };
                _context.hopDongs.Add(hopDong);
            } else
            {
                var hopDong_update = await _context.hopDongs.FindAsync(queryHopDong.maHopDong);

                hopDong_update.trangThai = false;

                var queryLuong = await _context.luongs.Where(x => x.maHopDong == queryHopDong.maHopDong && x.trangThai == true).FirstOrDefaultAsync();
                if(queryLuong == null)
                {
                    var hopDong = new HopDong()
                    {
                        maHopDong = request.maHopDong,
                        idLoaiHopDong = request.idLoaiHopDong,
                        idChucDanh = request.idChucDanh,
                        hopDongTuNgay = request.hopDongTuNgay,
                        hopDongDenNgay = request.hopDongDenNgay,
                        ghiChu = request.ghiChu,
                        trangThai = true,
                        maNhanVien = request.maNhanVien
                    };
                    _context.hopDongs.Add(hopDong);
                }else 
                {
                    var luong_update = await _context.luongs.FindAsync(queryLuong.id);

                    luong_update.trangThai = false;

                    var hopDong = new HopDong()
                    {
                        maHopDong = request.maHopDong,
                        idLoaiHopDong = request.idLoaiHopDong,
                        idChucDanh = request.idChucDanh,
                        hopDongTuNgay = request.hopDongTuNgay,
                        hopDongDenNgay = request.hopDongDenNgay,
                        ghiChu = request.ghiChu,
                        trangThai = true,
                        maNhanVien = request.maNhanVien
                    };
                    _context.hopDongs.Add(hopDong);
                }
            }
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string maHopDong)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);
            if (hopDong == null) throw new HRMException($"Không tìm thấy hợp đồng có id : {maHopDong}");

            _context.hopDongs.Remove(hopDong);
            return await _context.SaveChangesAsync();
        }

        public async Task<HopDongViewModel> GetHopDong(string maHopDong)
        {
            var query = from p in _context.hopDongs
                        join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                        join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.maHopDong == maHopDong
                        select new { p, nv, dmcd, dmlhd };

            var data = await query.Select(x => new HopDongViewModel()
            {
                id = x.p.maHopDong,
                loaiHopDong = x.dmlhd.tenLoaiHopDong,
                chucDanh = x.dmcd.tenChucDanh,
                hopDongTuNgay = x.p.hopDongTuNgay,
                hopDongDenNgay = x.p.hopDongDenNgay,
                ghiChu = x.p.ghiChu,
                trangThai = x.p.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen,
                idChucDanh = x.p.idChucDanh,
                idLoaiHopDong = x.p.idLoaiHopDong
            }).FirstAsync();

            return data;
        }

        public async Task<List<HopDongViewModel>> GetAll()
        {
            var query = from p in _context.hopDongs 
                        join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                        join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        orderby p.id ascending
                        select new  { p, nv, dmcd, dmlhd};

            var data = await query.Select(x => new HopDongViewModel()
            {
                id = x.p.maHopDong,
                loaiHopDong = x.dmlhd.tenLoaiHopDong,
                chucDanh = x.dmcd.tenChucDanh,
                hopDongTuNgay = x.p.hopDongTuNgay,
                hopDongDenNgay = x.p.hopDongDenNgay,
                ghiChu = x.p.ghiChu,
                trangThai = x.p.trangThai ==true? "Kích hoạt": "Vô hiệu",
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();

            return data;
        }

        public async Task<List<HopDongViewModel>> GetAll(string maNhanVien)
        {
            var query = from p in _context.hopDongs
                        join dmlhd in _context.danhMucLoaiHopDongs on p.idLoaiHopDong equals dmlhd.id
                        join dmcd in _context.danhMucChucDanhs on p.idChucDanh equals dmcd.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.maNhanVien == maNhanVien
                        select new { p, nv, dmcd, dmlhd };

            var data = await query.Select(x => new HopDongViewModel()
            {
                id = x.p.maHopDong,
                loaiHopDong = x.dmlhd.tenLoaiHopDong,
                chucDanh = x.dmcd.tenChucDanh,
                hopDongTuNgay = x.p.hopDongTuNgay,
                hopDongDenNgay = x.p.hopDongDenNgay,
                ghiChu = x.p.ghiChu,
                trangThai = x.p.trangThai == true ? "Kích hoạt" : "Vô hiệu",
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).ToListAsync();

            return data;
        }

        public async Task<int> Update(string maHopDong, HopDongUpdateRequest request)
        {
            var hopDong = await _context.hopDongs.FindAsync(maHopDong);
            if (hopDong == null) throw new HRMException($"Không tìm thấy hợp đồng có id : {maHopDong}");

            hopDong.maHopDong = request.maHopDong;
            hopDong.idLoaiHopDong = request.idLoaiHopDong;
            hopDong.idChucDanh = request.idChucDanh;
            hopDong.hopDongTuNgay = request.hopDongTuNgay;
            hopDong.hopDongDenNgay = request.hopDongDenNgay;
            hopDong.ghiChu = request.ghiChu;
            hopDong.trangThai = request.trangThai;
            hopDong.maNhanVien = request.maNhanVien;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTrangThai(string maNhanVien)
        {
            var query = await _context.hopDongs.Where(x => x.maNhanVien == maNhanVien && x.trangThai == true).FirstOrDefaultAsync();

            var hopDong = await _context.hopDongs.FindAsync(query.maHopDong);
            if (hopDong == null) throw new HRMException($"Không tìm thấy hợp đồng có mã hợp đồng : {maNhanVien}");

            hopDong.trangThai = false;

            return await _context.SaveChangesAsync();
        }
    }
}
