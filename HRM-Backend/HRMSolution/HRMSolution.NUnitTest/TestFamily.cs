using HRMSolution.Application.Catalog.NguoiThans.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestFamily : BaseTest
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
        public void Family_GetById_Success()
        {
            var result = NguoiThanService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Family_GetById_Failure()
        {
            var result = NguoiThanService.GetById(5);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Family_Create_Success()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = "Mai Trung Hiếu",
                idDanhMucNguoiThan = 1,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Family_Create_Failure1()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 1,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Family_Create_Failure2()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Family_Create_Failure3()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Family_Create_Failure4()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void Family_Create_Failure5()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Family_Create_Failure6()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = null,
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Family_Create_Failure7()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = null,
                dienThoai = null,
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Family_Create_Failure8()
        {
            NguoiThanCreateRequest create = new NguoiThanCreateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = null,
                dienThoai = null,
                khac = null,
                maNhanVien = null

            };
            var result = NguoiThanService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void Family_Update_Success()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = "Mai Trung Hiếu",
                idDanhMucNguoiThan = 1,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void Family_Update_Failure1()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = "Mai Trung Hiếu",
                idDanhMucNguoiThan = 1,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(9, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void Family_Update_Failure2()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 1,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void Family_Update_Failure3()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(16)]
        public void Family_Update_Failure4()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                quanHe = "Bạn",
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(17)]
        public void Family_Update_Failure5()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = "Sinh Viên",
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(18)]
        public void Family_Update_Failure6()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = "Hà Nội",
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(19)]
        public void Family_Update_Failure7()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = null,
                dienThoai = "0366738906",
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(20)]
        public void Family_Update_Failure8()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = null,
                dienThoai = null,
                khac = null,
                maNhanVien = "NV0001"

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(21)]
        public void Family_Update_Failure9()
        {
            NguoiThanUpdateRequest update = new NguoiThanUpdateRequest()
            {
                tenNguoiThan = null,
                idDanhMucNguoiThan = 0,
                gioiTinh = true,
                ngaySinh = new DateTime(1998, 9, 8),
                quanHe = null,
                ngheNghiep = null,
                diaChi = null,
                dienThoai = null,
                khac = null,
                maNhanVien = null

            };
            var result = NguoiThanService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(22)]
        public void Family_Delete_Success()
        {

            var result = NguoiThanService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(23)]
        public void Family_Delete_Failure()
        {

            var result = NguoiThanService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }

    }
}
