using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public class NhanVienService : INhanVienService
    {
        private readonly HRMDbContext _context;
        public NhanVienService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(NhanVienCreateRequest request)
        {
            var nhanVien = new NhanVien()
            {
                maNhanVien = request.maNhanVien,
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
                anh = request.anh,
                tinhChatLaoDong = request.tinhChatLaoDong,
                idDanhMucHonNhan = request.idDanhMucHonNhan,
                idDanToc = request.idDanToc,
                idTonGiao = request.idTonGiao,
                idNgachCongChuc = request.idNgachCongChuc,
                YTe = new YTe()
                {
                    nhomMau = request.YTe.nhomMau,
                    chieuCao = request.YTe.chieuCao,
                    canNang = request.YTe.canNang,
                    tinhTrangSucKhoe = request.YTe.tinhTrangSucKhoe,
                    benhTat = request.YTe.benhTat,
                    luuY = request.YTe.luuY,
                    khuyetTat = request.YTe.khuyetTat,
                    maNhanVien = request.YTe.maNhanVien
                },
                LichSuBanThan = new LichSuBanThan()
                {
                    biBatDiTu = request.LichSuBanThan.biBatDiTu,
                    thamGiaChinhTri = request.LichSuBanThan.thamGiaChinhTri,
                    thanNhanNuocNgoai = request.LichSuBanThan.thanNhanNuocNgoai,
                    maNhanVien = request.LichSuBanThan.maNhanVien
                },
                LienHeKhanCap = new LienHeKhanCap()
                {
                    hoTen = request.LienHeKhanCap.hoTen,
                    quanHe = request.LienHeKhanCap.quanHe,
                    dienThoai = request.LienHeKhanCap.dienThoai,
                    email = request.LienHeKhanCap.email,
                    diaChi = request.LienHeKhanCap.diaChi,
                    maNhanVien = request.LienHeKhanCap.maNhanVien,
                }

            };
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
            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        select new { nv, tc,dt,  hn, tg,ncc};


            var data = await query.Select(x => new NhanVienViewModel()
            {
                maNhanVien = x.nv.maNhanVien,
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
                anh = x.nv.anh,
                tinhChatLaoDong = x.tc.tenTinhChat,
                DanhMucHonNhan = x.hn.tenDanhMuc,
                DanToc= x.dt.tenDanhMuc,
                TonGiao = x.tg.tenDanhMuc,
                NgachCongChuc = x.ncc.tenNgach,
                lyDoNghiViec = x.nv.lyDoNghiViec

            }).ToListAsync();


            return data;
        }


        public async Task<NhanVienDetailViewModel> GetAllDetail(string maNhanVien)
        {
            //List Khen Thưởng Kỷ Luật
            var queryKtkl = from nv in _context.nhanViens
                            join ktkl in _context.khenThuongKyLuats on nv.maNhanVien equals ktkl.maNhanVien
                            join dmktkl in _context.danhMucKhenThuongKyLuats on ktkl.idDanhMucKhenThuong equals dmktkl.id
                            where nv.maNhanVien == maNhanVien
                            select new { ktkl, dmktkl };

            var dataKtkl = await queryKtkl.Select(x => new KhenThuongKyLuatViewModel()
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
                          where nv.maNhanVien == maNhanVien
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
                         join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                         where hd.maHopDong == l.maHopDong && nv.maNhanVien == maNhanVien
                         select new { hd, l, dml };

            var dataL = await queryL.Select(x => new LuongViewModel()
            {
                id = x.l.id,
                nhomLuong = x.dml.tenNhomLuong,
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
            }).ToListAsync();

            //List Hợp Đồng
            var queryHd = from nv in _context.nhanViens
                          join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                          join l in _context.luongs on hd.maHopDong equals l.maHopDong
                          where nv.maNhanVien == maNhanVien
                          select new { hd, l };

            var dataHd = await queryHd.Select(x => new HopDongViewModel()
            {
                maHopDong = x.hd.maHopDong,
                luongCoBan = x.l.luongCoBan,
                hdHopDongTuNgay = x.hd.hopDongTuNgay,
                hdHopDongDenNgay = x.hd.hopDongDenNgay,
                hdGhiChu = x.hd.ghiChu,
                trangThai = x.hd.trangThai == true? "Kích hoạt": "Vô hiệu",
                luongs = dataL
            }).Distinct().ToListAsync();

            //List Trình Độ Văn Hóa
            var queryTdvh = from nv in _context.nhanViens
                            join tdvh in _context.trinhDoVanHoas on nv.maNhanVien equals tdvh.maNhanVien
                            join dmcm in _context.danhMucChuyenMons on tdvh.idChuyenMon equals dmcm.id
                            join dmtd in _context.danhMucTrinhDos on tdvh.idTrinhDo equals dmtd.id
                            join htdt in _context.hinhThucDaoTaos on tdvh.idHinhThucDaoTao equals htdt.id
                            where nv.maNhanVien == maNhanVien
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
                          where nv.maNhanVien == maNhanVien
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
                        join lhkc in _context.lienHeKhanCaps on nv.maNhanVien equals lhkc.maNhanVien
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join yt in _context.yTes on nv.maNhanVien equals yt.maNhanVien
                        join lsbt in _context.lichSuBanThans on nv.maNhanVien equals lsbt.maNhanVien

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
                maNhanVien = x.nv.maNhanVien,
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
                lhkcHoTen = x.lhkc.hoTen,
                lhkcQuanHe = x.lhkc.quanHe,
                lhkcDienThoai = x.lhkc.dienThoai,
                lhkcEmail = x.lhkc.email,
                lhkcDiaChi = x.lhkc.diaChi,
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
                ytNhomMau = x.yt.nhomMau,
                ytChieuCao = x.yt.chieuCao,
                ytCanNang = x.yt.canNang,
                ytTinhTrangSucKhoe = x.yt.tinhTrangSucKhoe,
                ytBenhTat = x.yt.benhTat,
                ytLuuY = x.yt.luuY,
                ytKhuyetTat = x.yt.khuyetTat == true ? "Có" : "Không",
                biBatDitu = x.lsbt.biBatDiTu,
                thamGiaChinhTri = x.lsbt.thamGiaChinhTri,
                thanNhanNuocNgoai = x.lsbt.thanNhanNuocNgoai,
                trinhDoVanHoas = dataTdvh,
                hopDongs = dataHd,
                dieuChuyenViewModels = dataDc,
                khenThuongKyLuatViewModels = dataKtkl,
                ngoaiNgus = dataNn,
                nguoiThans = dataNt

            }).Distinct().FirstAsync();


            return data;
        }
    }
}
