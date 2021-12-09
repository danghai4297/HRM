using HRMSolution.Application.Catalog.BaoCaos;
using HRMSolution.Application.Catalog.BaoCaos.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRMSolution.Application.Catalog.BaoCaos
{
    public class BaoCaoService : IBaoCaoService
    {
        private readonly HRMDbContext _context;
        public BaoCaoService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBan(int id)
        {

            //Phòng Ban
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien

                        select new { nv, d };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.d.pb.tenPhongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByGioiTinh(bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.gioiTinh == gioiTinh
                        select new { nv, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBanVaGioiTinh(int id, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien
                        where nv.gioiTinh == gioiTinh
                        select new { nv, d };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.d.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByTrangThai(bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBanVaTrangThai(int id, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien
                        where nv.trangThaiLaoDong == trangThai
                        select new { nv, d };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.d.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByTrangThaiVaGioiTinh(bool trangThai, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.trangThaiLaoDong == trangThai && nv.gioiTinh == gioiTinh
                        select new { nv, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllBaoCao()
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        select new { nv, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBanVaTrangThaiVaGioiTinh(int id, bool trangThai, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien
                        where nv.trangThaiLaoDong == trangThai && nv.gioiTinh == gioiTinh
                        select new { nv, d };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.d.phongBan
            }).ToListAsync();

            return data;
        }
        public async Task<List<BaoCaoViewModel>> GetAllByHopDongHL(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true
                          select new { nv, hd };

            var query = from nv in _context.nhanViens

                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where ngayBatDau <= d.hd.hopDongTuNgay && ngayKetThuc >= d.hd.hopDongTuNgay
                        select new { nv, d, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByHopDongHLVaTT(DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.trangThaiLaoDong == trangThai
                        select new { nv, d, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByHopDongHLVaGT(DateTime ngayBatDau, DateTime ngayKetThuc, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.gioiTinh == gioiTinh
                        select new { nv, d, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByHopDongHLVaTTVaGT(DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.gioiTinh == gioiTinh && nv.trangThaiLaoDong == trangThai
                        select new { nv, d, x, xx };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllBaoCao(int id, DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.gioiTinh == gioiTinh && nv.trangThaiLaoDong == trangThai
                        select new { nv, d, v };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBanVaHD(int id, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        select new { nv, d, v };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBanVaHDVaTrangThai(int id, DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.trangThaiLaoDong == trangThai
                        select new { nv, d, v };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoViewModel>> GetAllByPhongBanVaHDVaGioiTinh(int id, DateTime ngayBatDau, DateTime ngayKetThuc, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          where hd.trangThai == true && ngayBatDau <= hd.hopDongTuNgay && ngayKetThuc >= hd.hopDongTuNgay
                          select new { nv, hd };

            var query = from nv in _context.nhanViens
                        join d in queryHd on nv.maNhanVien equals d.hd.maNhanVien
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.gioiTinh == gioiTinh
                        select new { nv, d, v };

            var data = await query.Select(x => new BaoCaoViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                trangThai = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoLenLuongViewModel>> GetAllLenLuong(DateTime tuNgay, DateTime denNgay)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join lhd in _context.danhMucLoaiHopDongs on hd.idLoaiHopDong equals lhd.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where l.ngayKetThuc >= tuNgay && l.ngayKetThuc <= denNgay && nv.trangThaiLaoDong == true && hd.trangThai == true && l.trangThai == true
                        select new { nv, hd, l, lhd, x, xx };
            var data = await query.Select(x => new BaoCaoLenLuongViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                maHopDong = x.hd.maHopDong,
                tenHopDong = x.lhd.tenLoaiHopDong,
                luongCoBan = x.l.luongCoBan,
                tongLuong = x.l.tongLuong,
                thoiGianLenLuong = x.l.ngayKetThuc,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoLenLuongViewModel>> GetAllLenLuongPhongBan(int id, DateTime tuNgay, DateTime denNgay)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join lhd in _context.danhMucLoaiHopDongs on hd.idLoaiHopDong equals lhd.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where l.ngayKetThuc >= tuNgay && l.ngayKetThuc <= denNgay && nv.trangThaiLaoDong == true && hd.trangThai == true && l.trangThai == true
                        select new { nv, hd, l, lhd, v };
            var data = await query.Select(x => new BaoCaoLenLuongViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                maHopDong = x.hd.maHopDong,
                tenHopDong = x.lhd.tenLoaiHopDong,
                luongCoBan = x.l.luongCoBan,
                tongLuong = x.l.tongLuong,
                thoiGianLenLuong = x.l.ngayKetThuc,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoSinhNhatViewModel>> GetAllSinhNhat(int thang)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.ngaySinh.Month == thang && nv.trangThaiLaoDong == true
                        select new { nv, x, xx };
            var data = await query.Select(x => new BaoCaoSinhNhatViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoSinhNhatViewModel>> GetAllSinhNhatPhongBan(int id, int thang)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.ngaySinh.Month == thang && nv.trangThaiLaoDong == true
                        select new { nv, v };
            var data = await query.Select(x => new BaoCaoSinhNhatViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNhomLuongViewModel>> GetAllNhomLuong()
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join nl in _context.danhMucNhomLuongs on l.idNhomLuong equals nl.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where hd.trangThai == true && l.trangThai == true && nv.trangThaiLaoDong == true
                        select new { nv, hd, l, nl, x, xx };
            var data = await query.Select(x => new BaoCaoNhomLuongViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                tenNhomLuong = x.nl.tenNhomLuong,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNhomLuongViewModel>> GetAllNhomLuongPhongBan(int idPhongBan)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join nl in _context.danhMucNhomLuongs on l.idNhomLuong equals nl.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where hd.trangThai == true && l.trangThai == true && nv.trangThaiLaoDong == true
                        select new { nv, hd, l, nl, v };
            var data = await query.Select(x => new BaoCaoNhomLuongViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                tenNhomLuong = x.nl.tenNhomLuong,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoChinhSachViewModel>> GetAllChinhSach()
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.laConChinhSach == true && nv.trangThaiLaoDong == true
                        select new { nv, x, xx };
            var data = await query.Select(x => new BaoCaoChinhSachViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                chinhSach = x.nv.conChinhSach,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoChinhSachViewModel>> GetAllChinhSachPhongBan(int id)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.laConChinhSach == true && nv.trangThaiLaoDong == true
                        select new { nv, v };
            var data = await query.Select(x => new BaoCaoChinhSachViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                chinhSach = x.nv.conChinhSach,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoBHXHViewModel>> GetAllBHXH()
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.trangThaiLaoDong == true && nv.bhxh != null
                        select new { nv, x, xx };
            var data = await query.Select(x => new BaoCaoBHXHViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                bhxh = x.nv.bhxh,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoBHXHViewModel>> GetAllBHXHPhongBan(int id)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.trangThaiLaoDong == true && nv.bhxh != null
                        select new { nv, v };
            var data = await query.Select(x => new BaoCaoBHXHViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                bhxh = x.nv.bhxh,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoDangVienViewModel>> GetAllDangVien()
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where nv.trangThaiLaoDong == true && nv.vaoDang == true
                        select new { nv, x, xx };
            var data = await query.Select(x => new BaoCaoDangVienViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                dienThoai = x.nv.dienThoai,
                ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoDangVienViewModel>> GetAllDangVienPhongBan(int id)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == id
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.trangThaiLaoDong == true && nv.vaoDang == true
                        select new { nv, v };
            var data = await query.Select(x => new BaoCaoDangVienViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = x.nv.ngaySinh,
                dienThoai = x.nv.dienThoai,
                ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThan(int tuoiTu, int den)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMuc(int tuoiTu, int den, int idDanhMuc)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBan(int tuoiTu, int den, int idPhongBan)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoMaNhanVien(int tuoiTu, int den, string maNhanVien)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoGioiTinh(int tuoiTu, int den, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nt.gioiTinh == gioiTinh
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoTrangThai(int tuoiTu, int den, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBan(int tuoiTu, int den, int idDanhMuc, int idPhongBan)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && dmnt.id == idDanhMuc
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVien(int tuoiTu, int den, int idDanhMuc, string maNhanVien)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc && nv.maNhanVien == maNhanVien
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaGioiTinh(int tuoiTu, int den, int idDanhMuc, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc && nt.gioiTinh == gioiTinh
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaTrangThai(int tuoiTu, int den, int idDanhMuc, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaMaNhanVien(int tuoiTu, int den, int idPhongBan, string maNhanVien)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaGioiTinh(int tuoiTu, int den, int idPhongBan, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nt.gioiTinh == gioiTinh
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaTrangThai(int tuoiTu, int den, int idPhongBan, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoMaNhanVienVaGioiTinh(int tuoiTu, int den, string maNhanVien, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                                    && nt.gioiTinh == gioiTinh
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoMaNhanVienVaTrangThai(int tuoiTu, int den, string maNhanVien, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                                    && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoGioiTinhVaTrangThai(int tuoiTu, int den, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nt.gioiTinh == gioiTinh && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVien(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && dmnt.id == idDanhMuc && nv.maNhanVien == maNhanVien
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaGioiTinh(int tuoiTu, int den, int idDanhMuc, int idPhongBan, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && dmnt.id == idDanhMuc && nt.gioiTinh == gioiTinh
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && dmnt.id == idDanhMuc && nv.trangThaiLaoDong == trangThai
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }
        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVienVaGioiTinh(int tuoiTu, int den, int idDanhMuc, string maNhanVien, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc && nv.maNhanVien == maNhanVien && nt.gioiTinh == gioiTinh
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVienVaTrangThai(int tuoiTu, int den, int idDanhMuc, string maNhanVien, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc && nv.maNhanVien == maNhanVien && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && dmnt.id == idDanhMuc && nt.gioiTinh == gioiTinh && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaMaNhanVienVaGioiTinh(int tuoiTu, int den, int idPhongBan, string maNhanVien, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                                    && nt.gioiTinh == gioiTinh
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaMaNhanVienVaTrangThai(int tuoiTu, int den, int idPhongBan, string maNhanVien, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                                    && nv.trangThaiLaoDong == trangThai
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaGioiTinhVaTrangThai(int tuoiTu, int den, int idPhongBan, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nv.trangThaiLaoDong == trangThai && nt.gioiTinh == gioiTinh
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den && nv.maNhanVien == maNhanVien
                                    && nt.gioiTinh == gioiTinh && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVienVaGioiTinh(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool gioiTinh)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nt.gioiTinh == gioiTinh && nt.idDanhMucNguoiThan == idDanhMuc && nv.maNhanVien == maNhanVien
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVienVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nt.idDanhMucNguoiThan == idDanhMuc && nv.maNhanVien == maNhanVien && nv.trangThaiLaoDong == trangThai
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nt.gioiTinh == gioiTinh && nt.idDanhMucNguoiThan == idDanhMuc && nv.trangThaiLaoDong == trangThai
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nt.gioiTinh == gioiTinh && nt.idDanhMucNguoiThan == idDanhMuc && nv.maNhanVien == maNhanVien && nv.trangThaiLaoDong == trangThai
                        select new { nv, x, xx, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanPhongBanVaMaNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, int idPhongBan, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nt.gioiTinh == gioiTinh && nv.maNhanVien == maNhanVien && nv.trangThaiLaoDong == trangThai
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanDanhMucVaPhongBanVaMaNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true && pb.id == idPhongBan
                          select new { dc, pb, phongBan = pb.tenPhongBan };
            var query = from nv in _context.nhanViens
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where (DateTime.Now.Year - nt.ngaySinh.Year) >= tuoiTu && (DateTime.Now.Year - nt.ngaySinh.Year) <= den
                                    && nt.gioiTinh == gioiTinh && nv.maNhanVien == maNhanVien && nv.trangThaiLaoDong == trangThai && nt.idDanhMucNguoiThan == idDanhMuc
                        select new { nv, v, nt, dmnt };
            var data = await query.Select(x => new BaoCaoNguoiThanViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                dienThoai = x.nv.dienThoai,
                nt_id = x.nt.id,
                nt_tenNguoiThan = x.nt.tenNguoiThan,
                nt_gioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                nt_ngaySinh = x.nt.ngaySinh,
                nt_tenDanhMucNguoiThan = x.dmnt.tenDanhMuc,
                nt_quanHe = x.nt.quanHe,
                nt_diaChi = x.nt.diaChi,
                nt_ngheNghiep = x.nt.ngheNghiep,
                nt_dienThoai = x.nt.dienThoai,
                nt_khac = x.nt.khac,
                tenPhongBan = x.v.phongBan
            }).ToListAsync();

            return data;
        }

        public async Task<BaoCaoLuongViewModel> GetAllBaoCaoLuong(string maNhanVien)
        {
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          join to in _context.danhMucTos on dc.to equals to.idTo
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan, to = to.tenTo };
            var query = from nv in _context.nhanViens
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                        join v in queryPb on nv.maNhanVien equals v.dc.maNhanVien
                        where nv.maNhanVien == maNhanVien && hd.trangThai == true && l.trangThai == true
                        select new { nv, v, hd, l, dml };
            var data = await query.Select(x => new BaoCaoLuongViewModel()
            {
                maNhanVien = x.nv.maNhanVien,
                tenNhanVien = x.nv.hoTen,
                tenPhongBan = x.v.phongBan,
                tenTo = x.v.to,
                atm = x.nv.atm,
                nganHang = x.nv.nganHang,
                idLuong = x.l.id,
                maHopDong = x.l.maHopDong,
                tenNhomLuong = x.dml.tenNhomLuong,
                heSoLuong = x.l.heSoLuong,
                bacLuong = x.l.bacLuong,
                luongCoBan = x.l.luongCoBan,
                phuCapChucDanh = x.l.phuCapChucDanh,
                phuCapChucVu = x.l.phuCapChucVu,
                phuCapTrachNhiem = x.l.phuCapTrachNhiem,
                phuCapKhac = x.l.phuCapKhac,
                tongLuong = x.l.tongLuong,
                thoiHanLenLuong = x.l.thoiHanLenLuong,
                ngayHieuLuc = x.l.ngayHieuLuc,
                ngayKetThuc = x.l.ngayKetThuc,
                ghiChu = x.l.ghiChu
            }).FirstAsync();

            return data;
        }
    }
}
