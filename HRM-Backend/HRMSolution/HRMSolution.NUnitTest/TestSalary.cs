using HRMSolution.Application.Catalog.Luongs.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestSalary : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

            SeedingData.SeedData(_context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }
        //[Test, Order(1)]
        //public void Salary_GetById_Success()
        //{
        //    var result = NguoiThanService.GetById(1);
        //    Assert.That(result.Result.id, Is.EqualTo(1));
        //}
        //[Test, Order(2)]
        //public void Salary_GetById_Failure()
        //{
        //    var result = NguoiThanService.GetById(5);
        //    Assert.That(result.Result, Is.EqualTo(null));
        //}
        //[Test, Order(3)]
        //public void Salary_Create_Success()
        //{
        //    LuongCreateRequest create = new LuongCreateRequest()
        //    {
        //        tenNguoiThan = "Mai Trung Hiếu",
        //        idDanhMucNguoiThan = 1,
        //        gioiTinh = true,
        //        ngaySinh = new DateTime(1998, 9, 8),
        //        quanHe = "Bạn",
        //        ngheNghiep = "Sinh Viên",
        //        diaChi = "Hà Nội",
        //        dienThoai = "0366738906",
        //        khac = null,
        //        maNhanVien = "NV0001"

        //    };
        //    var result = NguoiThanService.Create(create);
        //    Assert.That(result.Result, Is.EqualTo(1));
        //}
    }
}
