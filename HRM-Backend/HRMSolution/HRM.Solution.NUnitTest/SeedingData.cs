using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Solution.NUnitTest
{
    public static class SeedingData
    {
        public static void SeedData(HRMDbContext _context)
        {
            _context.AddRange(GetAllTitleCategory());

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
    }
}
