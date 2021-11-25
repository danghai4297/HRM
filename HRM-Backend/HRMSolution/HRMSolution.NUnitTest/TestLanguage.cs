using HRMSolution.Application.Catalog.NgoaiNgus.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestLanguage : BaseTest
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
        public void Language_GetById_Success()
        {
            var result = NgoaiNguService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Language_GetById_Failure()
        {
            var result = NgoaiNguService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Language_Create_Success()
        {
            NgoaiNguCreateRequest create = new NgoaiNguCreateRequest()
            {
                idDanhMucNgoaiNgu = 1,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "TP HCM",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Create(create);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Language_Create_Failure1()
        {
            NgoaiNguCreateRequest create = new NgoaiNguCreateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "TP HCM",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Language_Create_Failure2()
        {
            NgoaiNguCreateRequest create = new NgoaiNguCreateRequest()
            {
                idDanhMucNgoaiNgu = 1,
                trinhDo = null,
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "TP HCM",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Language_Create_Failure3()
        {
            NgoaiNguCreateRequest create = new NgoaiNguCreateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = null,
                noiCap = "TP HCM",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Language_Create_Failure4()
        {
            NgoaiNguCreateRequest create = new NgoaiNguCreateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = null,
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void Language_Create_Failure5()
        {
            NgoaiNguCreateRequest create = new NgoaiNguCreateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = null,
                maNhanVien = null

            };
            var result = NgoaiNguService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Language_Update_Success()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 2,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "Đà Nẵng",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(10)]
        public void Language_Update_Failure1()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 2,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "Đà Nẵng",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Update(8, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Language_Update_Failure2()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "Đà Nẵng",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void Language_Update_Failure3()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = null,
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "Đà Nẵng",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(13)]
        public void Language_Update_Failure4()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = null,
                noiCap = "Đà Nẵng",
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void Language_Update_Failure5()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 0,
                trinhDo = null,
                noiCap = null,
                maNhanVien = "NV0001"

            };
            var result = NgoaiNguService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void Language_Update_Failure6()
        {
            NgoaiNguUpdateRequest update = new NgoaiNguUpdateRequest()
            {
                idDanhMucNgoaiNgu = 2,
                trinhDo = "Giỏi",
                ngayCap = new DateTime(2019, 8, 8),
                noiCap = "Đà Nẵng",
                maNhanVien = null

            };
            var result = NgoaiNguService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(16)]
        public void Language_Delete_Success()
        {
            var result = NgoaiNguService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(17)]
        public void Language_Delete_Failure()
        {
            var result = NgoaiNguService.Delete(9);
            Assert.That(result.Result, Is.EqualTo(0));
        }

    }
}
