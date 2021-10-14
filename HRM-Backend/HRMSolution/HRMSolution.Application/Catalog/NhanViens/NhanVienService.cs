using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Application.Common;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
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
                    yt_nhomMau = request.YTe.yt_nhomMau,
                    yt_chieuCao = request.YTe.yt_chieuCao,
                    yt_canNang = request.YTe.yt_canNang,
                    yt_tinhTrangSucKhoe = request.YTe.yt_tinhTrangSucKhoe,
                    yt_benhTat = request.YTe.yt_benhTat,
                    yt_luuY = request.YTe.yt_luuY,
                    yt_khuyetTat = request.YTe.yt_khuyetTat,
                    yt_maNhanVien = request.YTe.yt_maNhanVien
                },
                LichSuBanThan = new LichSuBanThan()
                {
                    lsbt_biBatDiTu = request.LichSuBanThan.lsbt_biBatDiTu,
                    lsbt_thamGiaChinhTri = request.LichSuBanThan.lsbt_thamGiaChinhTri,
                    lsbt_thanNhanNuocNgoai = request.LichSuBanThan.lsbt_thanNhanNuocNgoai,
                    lsbt_maNhanVien = request.LichSuBanThan.lsbt_maNhanVien
                },
                LienHeKhanCap = new LienHeKhanCap()
                {
                    lhkc_hoTen = request.LienHeKhanCap.lhkc_hoTen,
                    lhkc_quanHe = request.LienHeKhanCap.lhkc_quanHe,
                    lhkc_dienThoai = request.LienHeKhanCap.lhkc_dienThoai,
                    lhkc_email = request.LienHeKhanCap.lhkc_email,
                    lhkc_diaChi = request.LienHeKhanCap.lhkc_diaChi,
                    lhkc_maNhanVien = request.LienHeKhanCap.lhkc_maNhanVien,
                }

            };
            //lưu ảnh
             if(request.anh != null)
             {
                nhanVien.anh = await this.SaveFile(request.anh);
             }
            _context.nhanViens.Add(nhanVien);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(int idDanhMucDanToc)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(NhanVienUpdateRequest request)
        {
            throw new NotImplementedException();
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
                          select new {dc, pb };

            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        //join q in queryPb on nv.maNhanVien equals q.dc.maNhanVien

                        select new { nv, tc,dt,  hn, tg, ncc };

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
                //phongBan = x.q.pb.tenPhongBan
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


            //List Hợp Đồng
            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          join lhd in _context.danhMucLoaiHopDongs on hd.idLoaiHopDong equals lhd.id
                          join dmcd in _context.danhMucChucDanhs on hd.idChucDanh equals dmcd.id
                          where hd.maNhanVien == maNhanVien
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
                //luongs = dataL
            }).ToListAsync();

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
                danToc = x.dt.tenDanhMuc,
                tonGiao = x.tg.tenDanhMuc,
                maSoThue = x.nv.maSoThue,
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
                lhkcHoTen = x.lhkc.lhkc_hoTen,
                lhkcQuanHe = x.lhkc.lhkc_quanHe,
                lhkcDienThoai = x.lhkc.lhkc_dienThoai,
                lhkcEmail = x.lhkc.lhkc_email,
                lhkcDiaChi = x.lhkc.lhkc_diaChi,
                ngheNghiep = x.nv.ngheNghiep,
                coQuanTuyenDung = x.nv.coQuanTuyenDung,
                chucVuHienTai = x.nv.chucVuHienTai,
                trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
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
                ytNhomMau = x.yt.yt_nhomMau,
                ytChieuCao = x.yt.yt_chieuCao,
                ytCanNang = x.yt.yt_canNang,
                ytTinhTrangSucKhoe = x.yt.yt_tinhTrangSucKhoe,
                ytBenhTat = x.yt.yt_benhTat,
                ytLuuY = x.yt.yt_luuY,
                ytKhuyetTat = x.yt.yt_khuyetTat == true ? "Có" : "Không",
                biBatDitu = x.lsbt.lsbt_biBatDiTu,
                thamGiaChinhTri = x.lsbt.lsbt_thamGiaChinhTri,
                thanNhanNuocNgoai = x.lsbt.lsbt_thanNhanNuocNgoai,
                trinhDoVanHoas = dataTdvh,
                hopDongs = dataHd,
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
    }
}
