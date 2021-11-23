using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
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
            _context.SaveChanges();
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
    }
}
