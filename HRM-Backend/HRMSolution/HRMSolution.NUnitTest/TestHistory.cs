using HRMSolution.Application.Catalog.LichSus.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestHistory : BaseTest
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
        [Test, Order(1)]
        public void Language_Create_Success()
        {
            LichSuCreateRequest create = new LichSuCreateRequest()
            {
                tenTaiKhoan = "user2",
                tenNhanVien = "Mai Trung Hiếu",
                thaoTac = "Tạo danh mục dân tộc",
                maNhanVien = "NV0001"
            };
            var result = LichSuService.Create(create);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Language_Create_Failure1()
        {
            LichSuCreateRequest create = new LichSuCreateRequest()
            {
                tenTaiKhoan = null,
                tenNhanVien = "Mai Trung Hiếu",
                thaoTac = "Tạo danh mục dân tộc",
                maNhanVien = "NV0001"
            };
            var result = LichSuService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(3)]
        public void Language_Create_Failure2()
        {
            LichSuCreateRequest create = new LichSuCreateRequest()
            {
                tenTaiKhoan = "user2",
                tenNhanVien = null,
                thaoTac = "Tạo danh mục dân tộc",
                maNhanVien = "NV0001"
            };
            var result = LichSuService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(4)]
        public void Language_Create_Failure3()
        {
            LichSuCreateRequest create = new LichSuCreateRequest()
            {
                tenTaiKhoan = "user2",
                tenNhanVien = "Mai Trung Hiếu",
                thaoTac = null,
                maNhanVien = "NV0001"
            };
            var result = LichSuService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Language_Create_Failure4()
        {
            LichSuCreateRequest create = new LichSuCreateRequest()
            {
                tenTaiKhoan = "user2",
                tenNhanVien = "Mai Trung Hiếu",
                thaoTac = "Tạo danh mục dân tộc",
                maNhanVien = null
            };
            var result = LichSuService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
