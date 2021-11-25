using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public static class SeedingData
    {
        public static void SeedData(HRMDbContext _context)
        {
            _context.AddRange(GetAllTitleCategory());
            _context.AddRange(GetAllPositionCategory());
            _context.AddRange(GetAllSpecializeCategory());
            _context.AddRange(GetAllNationCategory());
            _context.AddRange(GetAllMarriageCategory());
            _context.AddRange(GetAllEducateCategory());
            _context.AddRange(GetAllLanguageCategory());
            _context.AddRange(GetAllLevelCategory());
            _context.AddRange(GetAllNatureCategory());
            _context.AddRange(GetAllRankCategory());
            _context.AddRange(GetAllRelativeCategory());
            _context.AddRange(GetAllReligionCategory());
            _context.AddRange(GetAllContractCategory());
            _context.AddRange(GetAllSalaryCategory());
            _context.AddRange(GetAllTrinhDoVanHoas());
            _context.AddRange(GetAllNhanViens());
            _context.AddRange(GetAllLichSuBanThans());
            _context.AddRange(GetAllLienHeKhanCaps());
            _context.AddRange(GetAllYTes());
            _context.AddRange(GetAllNguoiThans());
            _context.AddRange(GetAllNgoaiNgus());
            _context.AddRange(GetAllLichSus());
            _context.AddRange(GetAllTransfer());
            _context.AddRange(GetAllDepartmentCategory());
            _context.AddRange(GetAllNestCategory());
            _context.AddRange(GetAllRewardDisciplineCategory());
            _context.AddRange(GetAllUsers());

            _context.AddRange(GetAllSalarys());
            _context.AddRange(GetRoleUser());
            _context.AddRange(GetAppRoles());
            _context.AddRange(GetAllContract());
            _context.AddRange(GetAllRewardDiscipline());
            _context.SaveChanges();
        }
        private static List<DanhMucKhenThuongKyLuat> GetAllRewardDisciplineCategory()
        {
            return new List<DanhMucKhenThuongKyLuat>
            {
                new DanhMucKhenThuongKyLuat() { id = 1, tenDanhMuc = "Thưởng Nhân viên suất xác tháng", tieuDe = "Khen thưởng" },
                new DanhMucKhenThuongKyLuat() { id = 2, tenDanhMuc = "Phạt Nhân viên kém nhất tháng", tieuDe = "Kỷ luật" }
            };
        }
        private static List<DieuChuyen> GetAllTransfer()
        {
            return new List<DieuChuyen>
            {
               new DieuChuyen() { id = 1, maNhanVien = "NV0001", ngayHieuLuc = DateTime.Now, idPhongBan = 1, to = 2, chiTiet = "Ahihi", trangThai = true, bangChung = "xxxx" }

            };
        }
        private static List<DanhMucTo> GetAllNestCategory()
        {
            return new List<DanhMucTo>
            {
                new DanhMucTo() { idTo = 1, maTo = "T01", tenTo = "Tổ hành chính", idPhongBan = 1 },
                new DanhMucTo() { idTo = 2, maTo = "T02", tenTo = "Tổ nhân sự", idPhongBan = 1 }
            };
        }
        private static List<DanhMucPhongBan> GetAllDepartmentCategory()
        {
            return new List<DanhMucPhongBan>
            {
                new DanhMucPhongBan() { id = 1, maPhongBan = "PB01", tenPhongBan = "Phòng hành chính-nhân sự" },
                new DanhMucPhongBan() { id = 2, maPhongBan = "PB02", tenPhongBan = "Phòng pháp chế" }
            };
        }
        private static List<DanhMucChucDanh> GetAllTitleCategory()
        {
            return new List<DanhMucChucDanh>
        {
            new DanhMucChucDanh() { id = 1, maChucDanh = "CD01", tenChucDanh = "Cử Nhân", phuCap = 100000 },
            new DanhMucChucDanh() { id = 2, maChucDanh = "CD02", tenChucDanh = "Thạc Sĩ", phuCap = 200000 },
            new DanhMucChucDanh() { id = 3, maChucDanh = "CD03", tenChucDanh = "Tiến Sĩ", phuCap = 300000 }
        };
        }
        private static List<DanhMucChucVu> GetAllPositionCategory()
        {
            return new List<DanhMucChucVu>
        {
            new DanhMucChucVu() { id = 1, maChucVu = "CV01", tenChucVu = "Nhân viên", phuCap = 100000 },
                new DanhMucChucVu() { id = 2, maChucVu = "CV02", tenChucVu = "Trưởng Phòng", phuCap = 200000 },
                new DanhMucChucVu() { id = 3, maChucVu = "CV03", tenChucVu = "Giám Đốc", phuCap = 300000 },
                new DanhMucChucVu() { id = 4, maChucVu = "CV04", tenChucVu = "Tổng Giám Đốc", phuCap = 100000 },
                new DanhMucChucVu() { id = 5, maChucVu = "CV05", tenChucVu = "Phó Tổng Giám Đốc", phuCap = 200000 },
                new DanhMucChucVu() { id = 6, maChucVu = "CV06", tenChucVu = "Phó Giám Đốc", phuCap = 250000 },
                new DanhMucChucVu() { id = 7, maChucVu = "CV07", tenChucVu = "Kế Toán Trưởng", phuCap = 100000 }
        };
        }
        private static List<DanhMucChuyenMon> GetAllSpecializeCategory()
        {
            return new List<DanhMucChuyenMon>
        {
            new DanhMucChuyenMon() { id = 1, maChuyenMon = "CM01", tenChuyenMon = "Tài chính – ngân hàng" },
                new DanhMucChuyenMon() { id = 2, maChuyenMon = "CM02", tenChuyenMon = "Hành chính văn phòng" },
                new DanhMucChuyenMon() { id = 3, maChuyenMon = "CM03", tenChuyenMon = "Quản tị kinh doanh" },
                new DanhMucChuyenMon() { id = 4, maChuyenMon = "CM04", tenChuyenMon = "Kế toán – kiểm toán" }

        };
        }
        private static List<DanhMucDanToc> GetAllNationCategory()
        {
            return new List<DanhMucDanToc>
        {
            new DanhMucDanToc() { id = 1, tenDanhMuc = "Kinh" },
                new DanhMucDanToc() { id = 2, tenDanhMuc = "Mông" },
                new DanhMucDanToc() { id = 3, tenDanhMuc = "Thái" },
                new DanhMucDanToc() { id = 4, tenDanhMuc = "Tày" }
        };
        }
        private static List<DanhMucHonNhan> GetAllMarriageCategory()
        {
            return new List<DanhMucHonNhan>
        {
            new DanhMucHonNhan() { id = 1, tenDanhMuc = "Độc Thân" },
                new DanhMucHonNhan() { id = 2, tenDanhMuc = "Đã ly hôn" }
        };
        }
        private static List<DanhMucNgachCongChuc> GetAllRankCategory()
        {
            return new List<DanhMucNgachCongChuc>
        {
            new DanhMucNgachCongChuc() { id = 1, tenNgach = "Loại A" },
                new DanhMucNgachCongChuc() { id = 2, tenNgach = "Loại B" }
        };
        }
        private static List<DanhMucNgoaiNgu> GetAllLanguageCategory()
        {
            return new List<DanhMucNgoaiNgu>
        {
            new DanhMucNgoaiNgu() { id = 1, tenDanhMuc = "Tiếng Anh" },
                new DanhMucNgoaiNgu() { id = 2, tenDanhMuc = "Tiếng Trung Quốc" }
        };
        }
        private static List<DanhMucNguoiThan> GetAllRelativeCategory()
        {
            return new List<DanhMucNguoiThan>
        {
            new DanhMucNguoiThan() { id = 1, tenDanhMuc = "Bố" },
                new DanhMucNguoiThan() { id = 2, tenDanhMuc = "Mẹ" }
        };
        }
        private static List<DanhMucTinhChatLaoDong> GetAllNatureCategory()
        {
            return new List<DanhMucTinhChatLaoDong>
        {
            new DanhMucTinhChatLaoDong() { id = 1, tenTinhChat = "Chính thức" },
                new DanhMucTinhChatLaoDong() { id = 2, tenTinhChat = "Thử việc" }
        };
        }
        private static List<DanhMucTonGiao> GetAllReligionCategory()
        {
            return new List<DanhMucTonGiao>
        {
            new DanhMucTonGiao() { id = 1, tenDanhMuc = "không" },
                new DanhMucTonGiao() { id = 2, tenDanhMuc = "Công giáo" }
        };
        }
        private static List<DanhMucTrinhDo> GetAllLevelCategory()
        {
            return new List<DanhMucTrinhDo>
        {
            new DanhMucTrinhDo() { id = 1, tenTrinhDo = "Giỏi" },
                new DanhMucTrinhDo() { id = 2, tenTrinhDo = "Khá" }
        };
        }
        private static List<HinhThucDaoTao> GetAllEducateCategory()
        {
            return new List<HinhThucDaoTao>
        {
            new HinhThucDaoTao() { id = 1, tenHinhThuc = "Đại học" },
                new HinhThucDaoTao() { id = 2, tenHinhThuc = "Cao đẳng" }
        };
        }
        private static List<DanhMucLoaiHopDong> GetAllContractCategory()
        {
            return new List<DanhMucLoaiHopDong>
        {
            new DanhMucLoaiHopDong() { id = 1, maLoaiHopDong = "MHD01", tenLoaiHopDong = "Hợp đồng một năm" },
                new DanhMucLoaiHopDong() { id = 2, maLoaiHopDong = "MHD02", tenLoaiHopDong = "Hợp đồng ba năm" }
        };
        }
        private static List<DanhMucNhomLuong> GetAllSalaryCategory()
        {
            return new List<DanhMucNhomLuong>
        {
            new DanhMucNhomLuong() { id = 1, maNhomLuong = "MNL01", tenNhomLuong = "Nhóm 1" },
                new DanhMucNhomLuong() { id = 2, maNhomLuong = "MNL02", tenNhomLuong = "Nhóm 2" }
        };
        }
        private static List<TrinhDoVanHoa> GetAllTrinhDoVanHoas()
        {
            return new List<TrinhDoVanHoa>
            {
                new TrinhDoVanHoa() { id = 1, tenTruong = "Đại Học Bách Khoa", idChuyenMon = 1, idHinhThucDaoTao = 1, idTrinhDo = 1, maNhanVien = "NV0001" ,tuThoiGian = DateTime.Now, denThoiGian = DateTime.Now }
            };
        }
        private static List<NhanVien> GetAllNhanViens()
        {
            return new List<NhanVien>
            {
                new NhanVien()
                {
                    maNhanVien = "NV0001",
                    hoTen = "Đào Ngọc Hưởng",
                    quocTich = "Việt Nam",
                    ngaySinh = new DateTime(1998,4,14),
                    gioiTinh = true,
                    dienThoai = "0246668866",
                    diDong = "0961441404",
                    cccd = "033098006441",
                    ngayCapCCCD =new DateTime(2016,4,14),
                    ngayHetHanCCCD = new DateTime(2022,4,14),
                    noiCapCCCD = "Điện Biên",
                    noiSinh = "Hưng Yên",
                    queQuan = "Hưng Yên",
                    thuongTru = "Điện Biên",
                    tamTru = "Hà Nội",
                    ngheNghiep = "Sinh viên",
                    chucVuHienTai = "Nhân Viên",
                    congViecChinh = "Nhân viên kinh doanh",
                    coQuanTuyenDung = "Phát Đạt",
                    trangThaiLaoDong = true,
                    vaoDang = false,
                    quanNhan = false,
                    laThuongBinh = false,
                    laConChinhSach = false,
                    tinhChatLaoDong = 1,
                    idDanhMucHonNhan = 1,
                    idDanToc = 1,
                    idTonGiao = 1,
                    idNgachCongChuc = 1,
                    anh = "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg",
                    email = "huongdn@gmail.com",
                    facebook = "fb.com/thongtin",
                    skype = "skype@skype.com",
                    maSoThue = "1234567890",
                    bhxh = "9876543210",
                    bhyt = "HN2229876543210",
                    atm = "16333",
                    nganHang = "Vpbank"
                }
            };
        }
        private static List<LichSuBanThan> GetAllLichSuBanThans()
        {
            return new List<LichSuBanThan>
            {
                new LichSuBanThan() { id = 1, biBatDiTu = "Không", thamGiaChinhTri = "Không", thanNhanNuocNgoai = "Không", maNhanVien = "NV0001" }
            };
        }
        private static List<YTe> GetAllYTes()
        {
            return new List<YTe>
            {
                new YTe() { id = 1, nhomMau = "O", chieuCao = (float)1.70, canNang = (float)50.1, maNhanVien = "NV0001" ,tinhTrangSucKhoe="Bình thường",benhTat="Không",luuY="Không"}
            };
        }
        private static List<LienHeKhanCap> GetAllLienHeKhanCaps()
        {
            return new List<LienHeKhanCap>
            {
                new LienHeKhanCap() { id = 1, hoTen = "Mai Trung Hiếu", quanHe = "Bạn", maNhanVien = "NV0001", diaChi = "Hà Nội", dienThoai = "0123434324" ,email="LienHeKhanCap@gmai.com"}
            };
        }
        private static List<NguoiThan> GetAllNguoiThans()
        {
            return new List<NguoiThan>
            {
                new NguoiThan() { id = 1, tenNguoiThan = "Nguyễn Đăng Hải", gioiTinh = true, ngaySinh = new DateTime(1965,03,21), quanHe = "Bố", ngheNghiep = "kinh doanh Tại Nhà", diaChi = "Hà Nội", dienThoai = "0914637668", maNhanVien = "NV0001", idDanhMucNguoiThan = 1 },
            };
        }
        private static List<NgoaiNgu> GetAllNgoaiNgus()
        {
            return new List<NgoaiNgu>
            {
                new NgoaiNgu() { id = 1, idDanhMucNgoaiNgu = 1, ngayCap = new DateTime(2017,03,21), trinhDo = "khá", noiCap = "Hà Nội", maNhanVien = "NV0001" },
            };
        }
        private static List<LichSu> GetAllLichSus()
        {
            return new List<LichSu>
            {
                new LichSu() { id = 1, tenTaiKhoan = "user1", tenNhanVien = "Đào Ngọc Hưởng", thaoTac = "Delete nhân viên NV0002", ngayThucHien = new DateTime(2017,03,21), maNhanVien = "NV0001" },
            };
        }

        private static List<AppUser> GetAllUsers()
        {
            var hasher = new PasswordHasher<AppUser>();
            return new List<AppUser>
            {

                new AppUser()
                {
                Id = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE"),
                UserName = "user1",
                NormalizedUserName = "user1",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                maNhanVien = "NV0001"
                }
            };
        }
        private static List<AppRole> GetAppRoles()
        {

            return new List<AppRole>
            {
                new AppRole
                {
                    Id = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                    Name = "user",
                    NormalizedName = "user",
                    ghiChu = "User role"
                }
            };
        }
        private static IdentityUserRole<Guid> GetRoleUser()
        {
            return new IdentityUserRole<Guid>
            {
                RoleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                UserId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE")
            };
        }

        private static List<Luong> GetAllSalarys()
        {
            return new List<Luong>
            {
                new Luong() { id = 1, maHopDong = "HD01",idNhomLuong=1, bacLuong = "1", thoiHanLenLuong = "1", ngayHieuLuc = DateTime.Now, ngayKetThuc = new DateTime(2023,11,17) , trangThai = true,heSoLuong = (float)1.0, luongCoBan= (float)1000000.0, phuCapKhac= (float)100000.0,phuCapTrachNhiem= (float)100000.0,tongLuong= (float)1200000.0 }
            };
        }
        private static List<HopDong> GetAllContract()
        {
            return new List<HopDong>
            {
                new HopDong() {id = 1, maHopDong = "HD01", idLoaiHopDong = 1, idChucDanh = 1, hopDongTuNgay = DateTime.Now, hopDongDenNgay = new DateTime(2022,03,21), maNhanVien = "NV0001", trangThai = true, idChucVu = 1 }
            };
        }
        private static List<KhenThuongKyLuat> GetAllRewardDiscipline()
        {
            return new List<KhenThuongKyLuat>
            {
                new KhenThuongKyLuat() { id = 1, idDanhMucKhenThuong = 1, noiDung = "Thưởng nhân viên suất sắc", loai = true, maNhanVien = "NV0001" },
                new KhenThuongKyLuat() { id = 2, idDanhMucKhenThuong = 2, noiDung = "Thưởng nhân viên suất sắc", loai = false, maNhanVien = "NV0001" }
            };
        }

    }
}
