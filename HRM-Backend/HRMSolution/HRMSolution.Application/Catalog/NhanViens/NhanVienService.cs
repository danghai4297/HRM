using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Application.Common;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public class NhanVienService : INhanVienService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public NhanVienService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(NhanVienCreateRequest request)
        {
            var nhanVien = new NhanVien()
            {
                maNhanVien = request.id,
                hoTen = request.hoTen,
                quocTich = request.quocTich,
                ngaySinh = request.ngaySinh,
                gioiTinh = request.gioiTinh,
                dienThoai = request.dienThoai,
                dienThoaiKhac = request.dienThoaiKhac,
                diDong = request.diDong,
                email = request.email,
                facebook = request.facebook,
                skype = request.skype,
                maSoThue = request.maSoThue,
                cccd = request.cccd,
                noiCapCCCD = request.noiCapCCCD,
                ngayCapCCCD = request.ngayCapCCCD,
                ngayHetHanCCCD = request.ngayHetHanCCCD,
                hoChieu = request.hoChieu,
                noiCapHoChieu = request.noiCapHoChieu,
                ngayCapHoChieu = request.ngayCapHoChieu,
                ngayHetHanHoChieu = request.ngayHetHanHoChieu,
                noiSinh =request.noiSinh,
                queQuan = request.queQuan,
                thuongTru = request.thuongTru,
                tamTru = request.tamTru,
                ngheNghiep = request.ngheNghiep,
                chucVuHienTai = request.chucVuHienTai,
                ngayTuyenDung = request.ngayTuyenDung,
                ngayThuViec = request.ngayThuViec,
                congViecChinh = request.congViecChinh,
                ngayVaoBan = request.ngayVaoBan,
                ngayChinhThuc = request.ngayChinhThuc,
                coQuanTuyenDung  = request.coQuanTuyenDung,
                ngachCongChucNoiDung = request.ngachCongChucNoiDung,
                vaoDang = request.vaoDang,
                ngayVaoDang = request.ngayVaoDang,
                ngayVaoDangChinhThuc = request.ngayVaoDangChinhThuc,
                quanNhan = request.quanNhan,
                ngayNhapNgu = request.ngayNhapNgu,
                ngayXuatNgu = request.ngayXuatNgu,
                quanHamCaoNhat = request.quanHamCaoNhat,
                danhHieuCaoNhat = request.danhHieuCaoNhat,
                ngayVaoDoan = request.ngayVaoDoan,
                noiThamGia = request.noiThamGia,
                laThuongBinh = request.laThuongBinh,
                laConChinhSach = request.laConChinhSach,
                thuongBinh = request.thuongBinh,
                conChinhSach = request.conChinhSach,
                bhxh = request.bhxh,
                bhyt = request.bhyt,
                atm = request.atm,
                nganHang = request.nganHang,
                trangThaiLaoDong = request.trangThaiLaoDong,
                ngayNghiViec = request.ngayNghiViec,
                lyDoNghiViec = request.lyDoNghiViec,
                tinhChatLaoDong = request.tinhChatLaoDong,
                idDanhMucHonNhan = request.idDanhMucHonNhan,
                idDanToc = request.idDanToc,
                idTonGiao = request.idTonGiao,
                idNgachCongChuc = request.idNgachCongChuc,
                YTe = new YTe()
                {
                    yt_nhomMau = request.yt_nhomMau,
                    yt_chieuCao = request.yt_chieuCao,
                    yt_canNang = request.yt_canNang,
                    yt_tinhTrangSucKhoe = request.yt_tinhTrangSucKhoe,
                    yt_benhTat = request.yt_benhTat,
                    yt_luuY = request.yt_luuY,
                    yt_khuyetTat = request.yt_khuyetTat,
                    yt_maNhanVien = request.yt_maNhanVien
                },
                LichSuBanThan = new LichSuBanThan()
                {
                    lsbt_biBatDiTu = request.lsbt_biBatDiTu,
                    lsbt_thamGiaChinhTri = request.lsbt_thamGiaChinhTri,
                    lsbt_thanNhanNuocNgoai = request.lsbt_thanNhanNuocNgoai,
                    lsbt_maNhanVien = request.lsbt_maNhanVien
                },
                LienHeKhanCap = new LienHeKhanCap()
                {
                    lhkc_hoTen = request.lhkc_hoTen,
                    lhkc_quanHe = request.lhkc_quanHe,
                    lhkc_dienThoai = request.lhkc_dienThoai,
                    lhkc_email = request.lhkc_email,
                    lhkc_diaChi = request.lhkc_diaChi,
                    lhkc_maNhanVien = request.lhkc_maNhanVien,
                }

            };
            //lưu ảnh
             //if(request.anh != null)
             //{
             //   nhanVien.anh = await this.SaveFile(request.anh);
             //}
            _context.nhanViens.Add(nhanVien);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(int idDanhMucDanToc)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(string id, NhanVienUpdateRequest request)
        {
            var nhanVien = await _context.nhanViens.FindAsync(id);
            var lhkc = await _context.lienHeKhanCaps.FindAsync(id);
            var yt = await _context.yTes.FindAsync(id);
            var lsbt = await _context.lichSuBanThans.FindAsync(id);

            if (nhanVien == null) throw new HRMException($"Không tìm thấy nhân viên có mã nhân viên là : {id}");

            nhanVien.hoTen = request.hoTen;
            nhanVien.quocTich = request.quocTich;
            nhanVien.ngaySinh = request.ngaySinh;
            nhanVien.gioiTinh = request.gioiTinh;
            nhanVien.dienThoai = request.dienThoai;
            nhanVien.dienThoaiKhac = request.dienThoaiKhac;
            nhanVien.diDong = request.diDong;
            nhanVien.email = request.email;
            nhanVien.facebook = request.facebook;
            nhanVien.skype = request.skype;
            nhanVien.maSoThue = request.maSoThue;
            nhanVien.cccd = request.cccd;
            nhanVien.noiCapCCCD = request.noiCapCCCD;
            nhanVien.ngayCapCCCD = request.ngayCapCCCD;
            nhanVien.ngayHetHanCCCD = request.ngayHetHanCCCD;
            nhanVien.hoChieu = request.hoChieu;
            nhanVien.noiCapHoChieu = request.noiCapHoChieu;
            nhanVien.ngayCapHoChieu = request.ngayCapHoChieu;
            nhanVien.ngayHetHanHoChieu = request.ngayHetHanHoChieu;
            nhanVien.noiSinh = request.noiSinh;
            nhanVien.queQuan = request.queQuan;
            nhanVien.thuongTru = request.thuongTru;
            nhanVien.tamTru = request.tamTru;
            nhanVien.ngheNghiep = request.ngheNghiep;
            nhanVien.chucVuHienTai = request.chucVuHienTai;
            nhanVien.ngayTuyenDung = request.ngayTuyenDung;
            nhanVien.ngayThuViec = request.ngayThuViec;
            nhanVien.congViecChinh = request.congViecChinh;
            nhanVien.ngayVaoBan = request.ngayVaoBan;
            nhanVien.ngayChinhThuc = request.ngayChinhThuc;
            nhanVien.coQuanTuyenDung = request.coQuanTuyenDung;
            nhanVien.ngachCongChucNoiDung = request.ngachCongChucNoiDung;
            nhanVien.vaoDang = request.vaoDang;
            nhanVien.ngayVaoDang = request.ngayVaoDang;
            nhanVien.ngayVaoDangChinhThuc = request.ngayVaoDangChinhThuc;
            nhanVien.quanNhan = request.quanNhan;
            nhanVien.ngayNhapNgu = request.ngayNhapNgu;
            nhanVien.ngayXuatNgu = request.ngayXuatNgu;
            nhanVien.quanHamCaoNhat = request.quanHamCaoNhat;
            nhanVien.danhHieuCaoNhat = request.danhHieuCaoNhat;
            nhanVien.ngayVaoDoan = request.ngayVaoDoan;
            nhanVien.noiThamGia = request.noiThamGia;
            nhanVien.laThuongBinh = request.laThuongBinh;
            nhanVien.laConChinhSach = request.laConChinhSach;
            nhanVien.thuongBinh = request.thuongBinh;
            nhanVien.conChinhSach = request.conChinhSach;
            nhanVien.bhxh = request.bhxh;
            nhanVien.bhyt = request.bhyt;
            nhanVien.atm = request.atm;
            nhanVien.nganHang = request.nganHang;
            nhanVien.trangThaiLaoDong = request.trangThaiLaoDong;
            nhanVien.ngayNghiViec = request.ngayNghiViec;
            nhanVien.lyDoNghiViec = request.lyDoNghiViec;
            nhanVien.tinhChatLaoDong = request.tinhChatLaoDong;
            nhanVien.idDanhMucHonNhan = request.idDanhMucHonNhan;
            nhanVien.idDanToc = request.idDanToc;
            nhanVien.idTonGiao = request.idTonGiao;
            nhanVien.idNgachCongChuc = request.idNgachCongChuc;
            yt.yt_nhomMau = request.yt_nhomMau;
            yt.yt_chieuCao = request.yt_chieuCao;
            yt.yt_canNang = request.yt_canNang;
            yt.yt_tinhTrangSucKhoe = request.yt_tinhTrangSucKhoe;
            yt.yt_benhTat = request.yt_benhTat;
            yt.yt_luuY = request.yt_luuY;
            yt.yt_khuyetTat = request.yt_khuyetTat;
            lsbt.lsbt_biBatDiTu = request.lsbt_biBatDiTu;
            lsbt.lsbt_thamGiaChinhTri = request.lsbt_thamGiaChinhTri;
            lsbt.lsbt_thanNhanNuocNgoai = request.lsbt_thanNhanNuocNgoai;
            lhkc.lhkc_hoTen = request.lhkc_hoTen;
            lhkc.lhkc_quanHe = request.lhkc_quanHe;
            lhkc.lhkc_dienThoai = request.lhkc_dienThoai;
            lhkc.lhkc_email = request.lhkc_email;
            lhkc.lhkc_diaChi = request.lhkc_diaChi;

            return await _context.SaveChangesAsync();
        }

        public async Task<List<NhanVienViewModel>> GetAll()
        {

            //select * from dbo.NhanVien nv  left join 
            //(select * from dbo.DieuChuyen dc where dc.trangThai = 1)
            //as a on nv.maNhanVien = a.maNhanVien


            //Phòng Ban
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new {dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens
                        
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                        //join q in queryPb on nv.maNhanVien equals q.dc.maNhanVien

                        select new { nv, tc,dt,  hn, tg, ncc, x, xx };

            var data = await query.Select(x => new NhanVienViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                quocTich = x.nv.quocTich,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ?"Nam": "Nữ",
                dienThoai = x.nv.dienThoai,
                dienThoaiKhac = x.nv.dienThoaiKhac,
                diDong = x.nv.diDong,
                email = x.nv.email,
                facebook = x.nv.facebook,
                skype = x.nv.skype,
                maSoThue = x.nv.maSoThue,
                cccd = x.nv.cccd,
                noiCapCCCD = x.nv.noiCapCCCD,
                ngayCapCCCD = x.nv.ngayCapCCCD,
                ngayHetHanCCCD = x.nv.ngayHetHanCCCD,
                hoChieu = x.nv.hoChieu,
                noiCapHoChieu = x.nv.noiCapHoChieu,
                ngayCapHoChieu = x.nv.ngayCapHoChieu,
                ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                noiSinh = x.nv.noiSinh,
                queQuan = x.nv.queQuan,
                thuongTru = x.nv.thuongTru,
                tamTru = x.nv.tamTru,
                ngheNghiep = x.nv.ngheNghiep,
                chucVuHienTai = x.nv.chucVuHienTai,
                ngayTuyenDung = x.nv.ngayTuyenDung,
                ngayThuViec = x.nv.ngayThuViec,
                congViecChinh = x.nv.congViecChinh,
                ngayVaoBan = x.nv.ngayVaoBan,
                ngayChinhThuc = x.nv.ngayChinhThuc,
                coQuanTuyenDung = x.nv.coQuanTuyenDung,
                ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                ngayVaoDang = x.nv.ngayVaoDang,
                ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                ngayNhapNgu = x.nv.ngayNhapNgu,
                ngayXuatNgu = x.nv.ngayXuatNgu,
                quanHamCaoNhat = x.nv.quanHamCaoNhat,
                danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                ngayVaoDoan = x.nv.ngayVaoDoan,
                noiThamGia = x.nv.noiThamGia,
                laThuongBinh = x.nv.laThuongBinh,
                laConChinhSach = x.nv.laConChinhSach,
                bhxh = x.nv.bhxh,
                bhyt = x.nv.bhyt,
                atm = x.nv.atm,
                nganHang = x.nv.nganHang,
                trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc": "Đã nghỉ việc",
                ngayNghiViec = x.nv.ngayNghiViec,
                tinhChatLaoDong = x.tc.tenTinhChat,
                DanhMucHonNhan = x.hn.tenDanhMuc,
                DanToc= x.dt.tenDanhMuc,
                TonGiao = x.tg.tenDanhMuc,
                NgachCongChuc = x.ncc.tenNgach,
                lyDoNghiViec = x.nv.lyDoNghiViec,
                anh = x.nv.anh,
                phongBan = x.xx.phongBan ?? String.Empty
            }).ToListAsync();


            return data;
        }

        public async Task<List<NhanVienViewModel>> GetAllNVNghi()
        {
            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        where nv.trangThaiLaoDong == false
                        select new { nv, tc, dt, hn, tg, ncc };


            var data = await query.Select(x => new NhanVienViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                quocTich = x.nv.quocTich,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                dienThoai = x.nv.dienThoai,
                dienThoaiKhac = x.nv.dienThoaiKhac,
                diDong = x.nv.diDong,
                email = x.nv.email,
                facebook = x.nv.facebook,
                skype = x.nv.skype,
                maSoThue = x.nv.maSoThue,
                cccd = x.nv.cccd,
                noiCapCCCD = x.nv.noiCapCCCD,
                ngayCapCCCD = x.nv.ngayCapCCCD,
                ngayHetHanCCCD = x.nv.ngayHetHanCCCD,
                hoChieu = x.nv.hoChieu,
                noiCapHoChieu = x.nv.noiCapHoChieu,
                ngayCapHoChieu = x.nv.ngayCapHoChieu,
                ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                noiSinh = x.nv.noiSinh,
                queQuan = x.nv.queQuan,
                thuongTru = x.nv.thuongTru,
                tamTru = x.nv.tamTru,
                ngheNghiep = x.nv.ngheNghiep,
                chucVuHienTai = x.nv.chucVuHienTai,
                ngayTuyenDung = x.nv.ngayTuyenDung,
                ngayThuViec = x.nv.ngayThuViec,
                congViecChinh = x.nv.congViecChinh,
                ngayVaoBan = x.nv.ngayVaoBan,
                ngayChinhThuc = x.nv.ngayChinhThuc,
                coQuanTuyenDung = x.nv.coQuanTuyenDung,
                ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                ngayVaoDang = x.nv.ngayVaoDang,
                ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                ngayNhapNgu = x.nv.ngayNhapNgu,
                ngayXuatNgu = x.nv.ngayXuatNgu,
                quanHamCaoNhat = x.nv.quanHamCaoNhat,
                danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                ngayVaoDoan = x.nv.ngayVaoDoan,
                noiThamGia = x.nv.noiThamGia,
                laThuongBinh = x.nv.laThuongBinh,
                laConChinhSach = x.nv.laConChinhSach,
                bhxh = x.nv.bhxh,
                bhyt = x.nv.bhyt,
                atm = x.nv.atm,
                nganHang = x.nv.nganHang,
                trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                ngayNghiViec = x.nv.ngayNghiViec,
                anh = x.nv.anh,
                tinhChatLaoDong = x.tc.tenTinhChat,
                DanhMucHonNhan = x.hn.tenDanhMuc,
                DanToc = x.dt.tenDanhMuc,
                TonGiao = x.tg.tenDanhMuc,
                NgachCongChuc = x.ncc.tenNgach,
                lyDoNghiViec = x.nv.lyDoNghiViec

            }).ToListAsync();


            return data;
        }


        public async Task<NhanVienDetailViewModel> GetByMaNV(string maNhanVien)
        {
           

            //List Khen Thưởng
            var queryKt = from nv in _context.nhanViens
                            join ktkl in _context.khenThuongKyLuats on nv.maNhanVien equals ktkl.maNhanVien
                            join dmktkl in _context.danhMucKhenThuongKyLuats on ktkl.idDanhMucKhenThuong equals dmktkl.id
                            where ktkl.maNhanVien == maNhanVien && ktkl.loai == true
                            select new { ktkl, dmktkl };

            var dataKt = await queryKt.Select(x => new KhenThuongViewModel()
            {
                id = x.ktkl.id,
                ktklDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                ktklLyDo = x.ktkl.lyDo,
                ktklNoiDung = x.ktkl.noiDung,
                ktklloai = x.ktkl.loai == true ? "Khen Thưởng" : "Kỷ Luật"
            }).ToListAsync();

            //List Kỷ Luật
            var queryKl = from nv in _context.nhanViens
                            join ktkl in _context.khenThuongKyLuats on nv.maNhanVien equals ktkl.maNhanVien
                            join dmktkl in _context.danhMucKhenThuongKyLuats on ktkl.idDanhMucKhenThuong equals dmktkl.id
                            where ktkl.maNhanVien == maNhanVien && ktkl.loai == false
                            select new { ktkl, dmktkl };

            var dataKl = await queryKl.Select(x => new KyLuatViewModel()
            {
                id = x.ktkl.id,
                ktklDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                ktklLyDo = x.ktkl.lyDo,
                ktklNoiDung = x.ktkl.noiDung,
                ktklloai = x.ktkl.loai == true ? "Khen Thưởng" : "Kỷ Luật"
            }).ToListAsync();

            //List Điều Chuyển
            var queryDc = from nv in _context.nhanViens
                          join dc in _context.dieuChuyens on nv.maNhanVien equals dc.maNhanVien
                          join dmcv in _context.danhMucChucVus on dc.idChucVu equals dmcv.id
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          join to in _context.danhMucTos on dc.to equals to.idTo
                          where dc.maNhanVien == maNhanVien
                          select new { dc, dmcv, pb, to };

            var dataDc = await queryDc.Select(x => new DieuChuyenViewModel()
            {
                id = x.dc.id,
                dcNgayHieuLuc = x.dc.ngayHieuLuc,
                dcPhong = x.pb.tenPhongBan,
                dcTo = x.to.tenTo,
                dcChiTiet = x.dc.chiTiet,
                dcChucVu = x.dmcv.tenChucVu
            }).ToListAsync();

            //List Lương
            var queryL = from nv in _context.nhanViens
                         join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                         join l in _context.luongs on hd.maHopDong equals l.maHopDong
                         join dmnl in _context.danhMucNhomLuongs on l.idNhomLuong equals dmnl.id
                         where hd.maHopDong == l.maHopDong && nv.maNhanVien == maNhanVien
                          select new { hd, l, dmnl };

            var dataL = await queryL.Select(x => new LuongViewModel()
            {
                id = x.l.id,
                maHopDong = x.l.maHopDong,
                nhomLuong = x.dmnl.tenNhomLuong,
                heSoLuong = x.l.heSoLuong,
                bacLuong = x.l.bacLuong,
                luongCoBan = x.l.luongCoBan,
                phuCapTrachNhiem = x.l.phuCapTrachNhiem,
                phuCapKhac = x.l.phuCapKhac,
                tongLuong = x.l.tongLuong,
                thoiHanLenLuong = x.l.thoiHanLenLuong,
                ngayHieuLuc = x.l.ngayHieuLuc,
                ngayKetThuc = x.l.ngayKetThuc,
                trangThai = x.l.trangThai == true? "Kích hoạt" : "Vô hiệu"
            }).Distinct().ToListAsync();


            //List Hợp Đồng
            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          join lhd in _context.danhMucLoaiHopDongs on hd.idLoaiHopDong equals lhd.id
                          join dmcd in _context.danhMucChucDanhs on hd.idChucDanh equals dmcd.id              
                          where nv.maNhanVien == maNhanVien 
                          select new { hd, lhd, dmcd };

            var dataHd = await queryHd.Select(x => new HopDongViewModel()
            {
                id = x.hd.maHopDong,
                idLoaiHopDong = x.lhd.tenLoaiHopDong,
                idChucDanh = x.dmcd.tenChucDanh,
                hdHopDongTuNgay = x.hd.hopDongTuNgay,
                hdHopDongDenNgay = x.hd.hopDongDenNgay,
                hdGhiChu = x.hd.ghiChu,
                trangThai = x.hd.trangThai == true? "Kích hoạt": "Vô hiệu",
                
            }).Distinct().ToListAsync();

            //List Trình Độ Văn Hóa
            var queryTdvh = from nv in _context.nhanViens
                            join tdvh in _context.trinhDoVanHoas on nv.maNhanVien equals tdvh.maNhanVien
                            join dmcm in _context.danhMucChuyenMons on tdvh.idChuyenMon equals dmcm.id
                            join dmtd in _context.danhMucTrinhDos on tdvh.idTrinhDo equals dmtd.id
                            join htdt in _context.hinhThucDaoTaos on tdvh.idHinhThucDaoTao equals htdt.id
                            where tdvh.maNhanVien == maNhanVien
                            select new { tdvh, dmcm, dmtd, htdt };

            var dataTdvh = await queryTdvh.Select(x => new TrinhDoVanHoaViewModel()
            {
                id = x.tdvh.id,
                tdvhTenTruong = x.tdvh.tenTruong,
                tdvhChuyenMon = x.dmcm.tenChuyenMon,
                tdvhTrinhDo = x.dmtd.tenTrinhDo,
                tdvhtuThoiGian = x.tdvh.tuThoiGian,
                tdvhdenThoiGian = x.tdvh.denThoiGian,
                tdvhHinhThucDaoTao = x.htdt.tenHinhThuc
            }).ToListAsync();

            //List Ngoại Ngữ
            var queryNn = from nv in _context.nhanViens
                          join nn in _context.ngoaiNgus on nv.maNhanVien equals nn.maNhanVien
                          join dmnn in _context.danhMucNgoaiNgus on nn.idDanhMucNgoaiNgu equals dmnn.id
                          where nv.maNhanVien == maNhanVien
                          select new { nn, dmnn };

            var dataNn = await queryNn.Select(x => new NgoaiNguViewModel()
            {
                id = x.nn.id,
                nnDanhMucNgoaiNgu = x.dmnn.tenDanhMuc,
                nnNgayCap = x.nn.ngayCap,
                nnNoiCap = x.nn.noiCap,
                nnTrinhDo = x.nn.trinhDo
            }).ToListAsync();

            //List Người Thân
            var queryNt = from nv in _context.nhanViens
                          join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                          join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                          where nt.maNhanVien == maNhanVien
                          select new { nt, dmnt };

            var dataNt = await queryNt.Select(x => new NguoiThanViewModel()
            {
                id = x.nt.id,
                ntTenNguoiThan = x.nt.tenNguoiThan,
                ntGioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                ntNgaySinh = x.nt.ngaySinh,
                ntQuanHe = x.nt.quanHe,
                ntNgheNghiep = x.nt.ngheNghiep,
                ntDiaChi = x.nt.diaChi,
                ntDienThoai = x.nt.dienThoai,
                ntKhac = x.nt.khac
            }).ToListAsync();

            //List Detail Nhân Viên
            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join lhkc in _context.lienHeKhanCaps on nv.maNhanVien equals lhkc.lhkc_maNhanVien
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join yt in _context.yTes on nv.maNhanVien equals yt.yt_maNhanVien
                        join lsbt in _context.lichSuBanThans on nv.maNhanVien equals lsbt.lsbt_maNhanVien

                        where nv.maNhanVien == maNhanVien
                        select new
                        {
                            nv,
                            tc,
                            dt,
                            hn,
                            tg,
                            ncc,
                            lhkc,
                            yt, lsbt
                        };
            var data = await query.Select(x => new NhanVienDetailViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                quocTich = x.nv.quocTich,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                noiSinh = x.nv.noiSinh,
                queQuan = x.nv.queQuan,
                thuongTru = x.nv.thuongTru,
                tamTru = x.nv.tamTru,
                atm = x.nv.atm,
                nganHang = x.nv.nganHang,
                idDanToc = x.dt.id,
                danToc = x.dt.tenDanhMuc,
                idTonGiao = x.tg.id,
                tonGiao = x.tg.tenDanhMuc,
                maSoThue = x.nv.maSoThue,
                idHonNhan = x.hn.id,
                honNhan = x.hn.tenDanhMuc,
                cccd = x.nv.cccd,
                noiCapCCCD = x.nv.noiCapCCCD,
                ngayCapCCCD = x.nv.ngayCapCCCD,
                ngayHetHanCCCD = x.nv.ngayHetHanCCCD,
                hoChieu = x.nv.hoChieu,
                noiCapHoChieu = x.nv.noiCapHoChieu,
                ngayCapHoChieu = x.nv.ngayCapHoChieu,
                ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                dienThoai = x.nv.dienThoai,
                dienThoaiKhac = x.nv.dienThoaiKhac,
                diDong = x.nv.diDong,
                email = x.nv.email,
                facebook = x.nv.facebook,
                skype = x.nv.skype,
                idLhkt = x.lhkc.lhkc_id,
                lhkcHoTen = x.lhkc.lhkc_hoTen,
                lhkcQuanHe = x.lhkc.lhkc_quanHe,
                lhkcDienThoai = x.lhkc.lhkc_dienThoai,
                lhkcEmail = x.lhkc.lhkc_email,
                lhkcDiaChi = x.lhkc.lhkc_diaChi,
                ngheNghiep = x.nv.ngheNghiep,
                coQuanTuyenDung = x.nv.coQuanTuyenDung,
                chucVuHienTai = x.nv.chucVuHienTai,
                trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                idTinhChatLaoDong = x.tc.id,
                tinhChatLaoDong = x.tc.tenTinhChat,
                lyDoNghiViec = x.nv.lyDoNghiViec,
                ngayNghiViec = x.nv.ngayNghiViec,
                ngayTuyenDung = x.nv.ngayTuyenDung,
                ngayThuViec = x.nv.ngayThuViec,
                congViecChinh = x.nv.congViecChinh,
                ngayVaoBan = x.nv.ngayVaoBan,
                ngayChinhThuc = x.nv.ngayChinhThuc,
                bhxh = x.nv.bhxh,
                bhyt = x.nv.bhyt,
                idNgachCongChuc = x.ncc.id,
                ngachCongChuc = x.ncc.tenNgach,
                ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                vaoDang = x.nv.vaoDang == true ? "Có" : "Không",
                ngayVaoDang = x.nv.ngayVaoDang,
                ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                ngayVaoDoan = x.nv.ngayVaoDoan,
                noiThamGia = x.nv.noiThamGia,
                quanNhan = x.nv.quanNhan == true ? "Có" : "Không",
                ngayNhapNgu = x.nv.ngayNhapNgu,
                ngayXuatNgu = x.nv.ngayXuatNgu,
                quanHamCaoNhat = x.nv.quanHamCaoNhat,
                danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                thuongBinh = x.nv.thuongBinh,
                conChinhSach = x.nv.conChinhSach,
                idYte = x.yt.yt_id,
                ytNhomMau = x.yt.yt_nhomMau,
                ytChieuCao = x.yt.yt_chieuCao,
                ytCanNang = x.yt.yt_canNang,
                ytTinhTrangSucKhoe = x.yt.yt_tinhTrangSucKhoe,
                ytBenhTat = x.yt.yt_benhTat,
                ytLuuY = x.yt.yt_luuY,
                ytKhuyetTat = x.yt.yt_khuyetTat == true ? "Có" : "Không",
                idLichSuBanThan = x.lsbt.lsbt_id,
                biBatDitu = x.lsbt.lsbt_biBatDiTu,
                thamGiaChinhTri = x.lsbt.lsbt_thamGiaChinhTri,
                thanNhanNuocNgoai = x.lsbt.lsbt_thanNhanNuocNgoai,
                anh = x.nv.anh,
                trinhDoVanHoas = dataTdvh,
                hopDongs = dataHd,
                luongs = dataL,
                dieuChuyens = dataDc,
                khenThuongs = dataKt,
                ngoaiNgus = dataNn,
                nguoiThans = dataNt,
                kyLuats = dataKl

            }).Distinct().FirstAsync();


            return data;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<int> UpdateImage(string id, NhanVienUpdateImageRequest request)
        {
            var anh = await _context.nhanViens.FindAsync(id);
            if (anh == null) throw new HRMException($"Không tìm thấy danh mục chức danh có id: {id }");

            anh.anh = await this.SaveFile(request.anh);

            return await _context.SaveChangesAsync();
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
                        select new { nv, x,xx};

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
                        select new { nv, d};

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
                        select new { nv, x, xx};

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
                        select new { nv, d, v};

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
                        select new {nv, hd, l, lhd, x, xx };
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
                        select new { nv, hd, l, lhd,v};
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
                        select new {nv, x, xx };
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
                        select new {nv, v };
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

        public async Task<List<BaoCaoNhomLuongViewModel>> GetAllNhomLuong(int idNhomLuong)
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
                        where hd.trangThai == true && l.trangThai == true && l.idNhomLuong == idNhomLuong && nv.trangThaiLaoDong == true
                        select new { nv, hd, l, nl, x, xx};
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

        public async Task<List<BaoCaoNhomLuongViewModel>> GetAllNhomLuongPhongBan(int idPhongBan, int idNhomLuong)
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
                        where hd.trangThai == true && l.trangThai == true && l.idNhomLuong == idNhomLuong && nv.trangThaiLaoDong == true
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
                        select new { nv, v};
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
                        where nv.trangThaiLaoDong == true
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
                        where nv.trangThaiLaoDong == true
                        select new { nv,v };
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
    }
}
