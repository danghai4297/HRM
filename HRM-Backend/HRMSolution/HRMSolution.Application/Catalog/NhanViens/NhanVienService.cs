using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Data.EF;
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

        public Task<int> Create(NhanVienCreateRequest request)
        {
            throw new NotImplementedException();
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
                        join pb in _context.danhMucPhongBans on nv.idPhongBan equals pb.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join to in _context.danhMucTos on nv.to equals to.idTo
                        select new { nv, tc,dt,  hn, tg,pb,ncc,to };


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
                PhongBan = x.pb.tenPhongBan,
                to = x.to.tenTo,
                NgachCongChuc = x.ncc.tenNgach,
                lyDoNghiViec = x.nv.lyDoNghiViec

            }).ToListAsync();


            return data;
        }

        public async Task<List<NhanVienDetailViewModel>> GetAllDetail(string maNhanVien)
        {
            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join lhkc in _context.lienHeKhanCaps on nv.maNhanVien equals lhkc.maNhanVien
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                        join l in _context.luongs on hd.maHopDong equals l.maHopDong
                        join dml in _context.danhMucNhomLuongs on l.idNhomLuong equals dml.id
                        join tdvh in _context.trinhDoVanHoas on nv.maNhanVien equals tdvh.maNhanVien
                        join dmcm in _context.danhMucChuyenMons on tdvh.idChuyenMon equals dmcm.id
                        join dmtd in _context.danhMucTrinhDos on tdvh.idTrinhDo equals dmtd.id
                        join htdt in _context.hinhThucDaoTaos on tdvh.idHinhThucDaoTao equals htdt.id
                        join nn in _context.ngoaiNgus on nv.maNhanVien equals nn.maNhanVien
                        join dmnn in _context.danhMucNgoaiNgus on nn.idDanhMucNgoaiNgu equals dmnn.id
                        join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                        join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                        join yt in _context.yTes on nv.maNhanVien equals yt.maNhanVien
                        join dmcd in _context.danhMucChucDanhs on hd.idChucDanh equals dmcd.id
                        join dmlhd in _context.danhMucLoaiHopDongs on hd.idLoaiHopDong equals dmlhd.id
                        join dc in _context.dieuChuyens on nv.maNhanVien equals dc.maNhanVien
                        join dmcv in _context.danhMucChucVus on dc.idChucVu equals dmcv.id
                        join pb in _context.danhMucPhongBans on dc.phong equals pb.id
                        join to in _context.danhMucTos on dc.to equals to.idTo
                        join ktkl in _context.khenThuongKyLuats on nv.maNhanVien equals ktkl.maNhanVien
                        join dmktkl in _context.danhMucKhenThuongKyLuats on ktkl.idDanhMucKhenThuong equals dmktkl.id
                        where nv.maNhanVien == maNhanVien
                        select new
                        {
                            nv,tc,dt,hn,tg,ncc,lhkc,hd,l,dml,tdvh,dmcm,dmtd,htdt,nn,dmnn,nt,dmnt,yt,dmcd,dmlhd,dc,dmcv,pb,to,ktkl, dmktkl
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
                bhxh = x.nv.bhxh,
                bhyt = x.nv.bhyt,
                tdvhTenTruong = x.tdvh.tenTruong,
                tdvhChuyenMon = x.dmcm.tenChuyenMon,
                tdvhTrinhDo = x.dmtd.tenTrinhDo,
                tdvhtuThoiGian = x.tdvh.tuThoiGian,
                tdvhdenThoiGian = x.tdvh.denThoiGian,
                tdvhHinhThucDaoTao = x.htdt.tenHinhThuc,
                nnDanhMucNgoaiNgu = x.dmnn.tenDanhMuc,
                nnNgayCap = x.nn.ngayCap,
                nnNoiCap = x.nn.noiCap,
                nnTrinhDo = x.nn.trinhDo,
                ntTenNguoiThan = x.nt.tenNguoiThan,
                ntGioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                ntNgaySinh = x.nt.ngaySinh,
                ntQuanHe = x.nt.quanHe,
                ntNgheNghiep = x.nt.ngheNghiep,
                ntDiaChi = x.nt.diaChi,
                ntDienThoai = x.nt.dienThoai,
                ntKhac = x.nt.khac,
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
                hdLoaiHopDong = x.dmlhd.tenLoaiHopDong,
                hdChucDanh = x.dmcd.tenChucDanh,
                hdHopDongTuNgay = x.hd.hopDongTuNgay,
                hdHopDongDenNgay = x.hd.hopDongDenNgay,
                hdGhiChu = x.hd.ghiChu,
                dcNgayHieuLuc = x.dc.ngayHieuLuc,
                dcPhong = x.pb.tenPhongBan,
                dcTo = x.to.tenTo,
                dcChiTiet = x.dc.chiTiet,
                dcChucVu = x.dmcv.tenChucVu,
                ktklDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                ktklLyDo = x.ktkl.lyDo,
                ktklNoiDung = x.ktkl.noiDung,
                ktklloai = x.ktkl.loai == true ? "Khen Thưởng" : "Kỷ Luật"

            }).ToListAsync();


            return data;
        }
    }
}
