
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HRMSolution.Data.Extentions
{
    public static class ModelBuilderExtentions
    {
        public static void seed(this ModelBuilder modelbulder)
        {
            modelbulder.Entity<TaiKhoan>().HasData(
                new TaiKhoan() { tenDangNhap = "admin", matKhau = "123" }
                );

            modelbulder.Entity<DanhMucChucDanh>().HasData(
                new DanhMucChucDanh() { id = 1, maChucDanh = "CD01", tenChucDanh = "Cử Nhân", phuCap = 100000 },
                new DanhMucChucDanh() { id = 2, maChucDanh = "CD02", tenChucDanh = "Thạc Sĩ", phuCap = 200000 },
                new DanhMucChucDanh() { id = 3, maChucDanh = "CD03", tenChucDanh = "Tiến Sĩ", phuCap = 300000 }
                );

            modelbulder.Entity<DanhMucChucVu>().HasData(
                new DanhMucChucVu() { id = 1, maChucVu = "CV01", tenChucVu = "Nhân viên", phuCap = 100000 },
                new DanhMucChucVu() { id = 2, maChucVu = "CV02", tenChucVu = "Trưởng Phòng", phuCap = 200000 },
                new DanhMucChucVu() { id = 3, maChucVu = "CV03", tenChucVu = "Giám Đốc", phuCap = 300000 }
                );
            modelbulder.Entity<DanhMucChuyenMon>().HasData(
                new DanhMucChuyenMon() { id = 1, maChuyenMon = "CM01", tenChuyenMon = "Tài chính – ngân hàng" },
                new DanhMucChuyenMon() { id = 2, maChuyenMon = "CM02", tenChuyenMon = "Hành chính văn phòng" },
                new DanhMucChuyenMon() { id = 3, maChuyenMon = "CM03", tenChuyenMon = "Quản tị kinh doanh" },
                new DanhMucChuyenMon() { id = 4, maChuyenMon = "CM04", tenChuyenMon = "Kế toán – kiểm toán" },
                new DanhMucChuyenMon() { id = 5, maChuyenMon = "CM05", tenChuyenMon = "Kinh Tế" }
                );
            modelbulder.Entity<DanhMucDanToc>().HasData(
                new DanhMucDanToc() { id = 1, tenDanhMuc = "kinh" },
                new DanhMucDanToc() { id = 2, tenDanhMuc = "Mông" },
                new DanhMucDanToc() { id = 3, tenDanhMuc = "Thái" }
                );
            modelbulder.Entity<DanhMucKhenThuongKyLuat>().HasData(
                new DanhMucKhenThuongKyLuat() { id = 1, tenDanhMuc = "Thưởng Nhân viên suất xác tháng" }
                );
            modelbulder.Entity<DanhMucLoaiHopDong>().HasData(
                new DanhMucLoaiHopDong() { id = 1, maLoaiHopDong = "MHD01", tenLoaiHopDong = "Hợp đồng một năm" },
                new DanhMucLoaiHopDong() { id = 2, maLoaiHopDong = "MHD02", tenLoaiHopDong = "Hợp đồng ba năm" },
                new DanhMucLoaiHopDong() { id = 3, maLoaiHopDong = "MHD03", tenLoaiHopDong = "Hợp đồng vô thời hạn" }
                );
            modelbulder.Entity<DanhMucNgachCongChuc>().HasData(
                new DanhMucNgachCongChuc() { id = 1, tenNgach = "Loại A" },
                new DanhMucNgachCongChuc() { id = 2, tenNgach = "Loại B" },
                new DanhMucNgachCongChuc() { id = 3, tenNgach = "Loại C" },
                new DanhMucNgachCongChuc() { id = 4, tenNgach = "Loại D" }
                );
            modelbulder.Entity<DanhMucNgoaiNgu>().HasData(
                new DanhMucNgoaiNgu() { id = 1, tenDanhMuc = "Tiếng Anh" },
                new DanhMucNgoaiNgu() { id = 2, tenDanhMuc = "Tiếng Trung Quốc" },
                new DanhMucNgoaiNgu() { id = 3, tenDanhMuc = "Tiếng pháp" }
                );
            modelbulder.Entity<DanhMucNguoiThan>().HasData(
                new DanhMucNguoiThan() { id = 1, tenDanhMuc = "Bố" },
                new DanhMucNguoiThan() { id = 2, tenDanhMuc = "Mẹ" }
                );
            modelbulder.Entity<DanhMucTo>().HasData(
                new DanhMucTo() { idTo = 1, maTo = "T01", tenTo = "Tổ 1", idPhongBan = 1 },
                new DanhMucTo() { idTo = 2, maTo = "T02", tenTo = "Tổ 1", idPhongBan = 1 },
                new DanhMucTo() { idTo = 3, maTo = "T03", tenTo = "Tổ 2", idPhongBan = 1 },
                new DanhMucTo() { idTo = 4, maTo = "T04", tenTo = "Tổ 3", idPhongBan = 1 },
                new DanhMucTo() { idTo = 5, maTo = "T05", tenTo = "Tổ 4", idPhongBan = 1 },
                new DanhMucTo() { idTo = 6, maTo = "T06", tenTo = "Tổ 5", idPhongBan = 2 },
                new DanhMucTo() { idTo = 7, maTo = "T06", tenTo = "Tổ 6", idPhongBan = 2 },
                new DanhMucTo() { idTo = 8, maTo = "T07", tenTo = "Tổ 7", idPhongBan = 2 },
                new DanhMucTo() { idTo = 9, maTo = "T08", tenTo = "Tổ 8", idPhongBan = 2 },
                new DanhMucTo() { idTo = 10, maTo = "T09", tenTo = "Tổ 9", idPhongBan = 3 },
                new DanhMucTo() { idTo = 11, maTo = "T010", tenTo = "Tổ 10", idPhongBan = 3 },
                new DanhMucTo() { idTo = 12, maTo = "T011", tenTo = "Tổ 11", idPhongBan = 3 },
                new DanhMucTo() { idTo = 13, maTo = "T012", tenTo = "Tổ 12", idPhongBan = 3 },
                new DanhMucTo() { idTo = 14, maTo = "T013", tenTo = "Tổ 13", idPhongBan = 4 },
                new DanhMucTo() { idTo = 15, maTo = "T014", tenTo = "Tổ 14", idPhongBan = 4 },
                new DanhMucTo() { idTo = 16, maTo = "T015", tenTo = "Tổ 15", idPhongBan = 4 },
                new DanhMucTo() { idTo = 17, maTo = "T016", tenTo = "Tổ 16", idPhongBan = 4 },
                new DanhMucTo() { idTo = 18, maTo = "T017", tenTo = "Tổ 17", idPhongBan = 5 },
                new DanhMucTo() { idTo = 19, maTo = "T018", tenTo = "Tổ 18", idPhongBan = 5 },
                new DanhMucTo() { idTo = 20, maTo = "T019", tenTo = "Tổ 19", idPhongBan = 5 },
                new DanhMucTo() { idTo = 21, maTo = "T020", tenTo = "Tổ 20", idPhongBan = 5 }
                );
            modelbulder.Entity<DanhMucPhongBan>().HasData(
                new DanhMucPhongBan() { id = 1, maPhongBan = "PB01", tenPhongBan = "1" },
                new DanhMucPhongBan() { id = 2, maPhongBan = "PB02", tenPhongBan = "2" },
                new DanhMucPhongBan() { id = 3, maPhongBan = "PB03", tenPhongBan = "3" },
                new DanhMucPhongBan() { id = 4, maPhongBan = "PB04", tenPhongBan = "4" },
                new DanhMucPhongBan() { id = 5, maPhongBan = "PB05", tenPhongBan = "5" }
                );
            modelbulder.Entity<DanhMucTinhChatLaoDong>().HasData(
                new DanhMucTinhChatLaoDong() { id = 1, tenTinhChat = "Chính thức" }
                );

            modelbulder.Entity<DanhMucTonGiao>().HasData(
                new DanhMucTonGiao() { id = 1, tenDanhMuc = "không" }
                );
            modelbulder.Entity<DanhMucTrinhDo>().HasData(
                new DanhMucTrinhDo() { id = 1, tenTrinhDo = "Giỏi" },
                new DanhMucTrinhDo() { id = 2, tenTrinhDo = "Khá" }
                );
            
            modelbulder.Entity<HinhThucDaoTao>().HasData(
                new HinhThucDaoTao() { id = 1, tenHinhThuc = "Đại học" },
                new HinhThucDaoTao() { id = 2, tenHinhThuc = "Cao đẳng" }
                );
            modelbulder.Entity<DanhMucHonNhan>().HasData(
                new DanhMucHonNhan() { id = 1, tenDanhMuc = "Độc Thân" }
                
                );
            DateTime dt = new DateTime(2021,04,14,16,5,7,123);
            modelbulder.Entity<NhanVien>().HasData(
                
                new NhanVien() { maNhanVien = "NV0001", hoTen = "Đào Ngọc Hưởng", quocTich = "Việt Nam",
                    ngaySinh = DateTime.ParseExact("1998-14-04","yyyy-MM-dd", CultureInfo.CurrentCulture), gioiTinh = true, dienThoai = "02466666", diDong = "0961441404", cccd = "040828462",
                    ngayCapCCCD = DateTime.ParseExact("1998-14-04", "yyyy-MM-dd", CultureInfo.CurrentCulture),
                    ngayHetHanCCCD = DateTime.ParseExact("1998-14-04", "yyyy-MM-dd", CultureInfo.CurrentCulture), noiCapCCCD = "Điện Biên", noiSinh = "Hưng Yên", queQuan = "Hưng Yên", thuongTru = "Điện Biên", tamTru = "Đại học FPT", ngheNghiep = "Sinh viên", chucVuHienTai = "Nhân Viên", congViecChinh = "code",
                    ngayChinhThuc = DateTime.ParseExact("1998-14-04", "yyyy-MM-dd", CultureInfo.CurrentCulture), coQuanTuyenDung = "Phát Đạt", anh = "1", tinhChatLaoDong = 1, idDanhMucHonNhan = 1, idDanToc = 1, idTonGiao = 1, idPhongBan = 1, to = 1, idNgachCongChuc = 1 }
                ) ;

        }
    }
}
