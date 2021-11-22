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
    }
}
