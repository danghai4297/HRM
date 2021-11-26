using HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos;
using HRMSolution.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestEducationLevel : BaseTest
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
        public void EducationLevel_GetById_Success()
        {
            var result = TrinhDoVanHoaService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void EducationLevel_GetById_Failure()
        {
            var result = TrinhDoVanHoaService.GetById(7);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(2)]
        public void EducationLevel_GetAll_Success()
        {
            var result = TrinhDoVanHoaService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void EducationLevel_Create_Success()
        {
            TrinhDoVanHoaCreateRequest create = new TrinhDoVanHoaCreateRequest()
            {
                tenTruong = "FPT",
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Create(create);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void EducationLevel_Create_Failure1()
        {
            TrinhDoVanHoaCreateRequest create = new TrinhDoVanHoaCreateRequest()
            {
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void EducationLevel_Create_Failure2()
        {
            TrinhDoVanHoaCreateRequest create = new TrinhDoVanHoaCreateRequest()
            {
                tenTruong = "FPT",
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void EducationLevel_Create_Failure3()
        {
            TrinhDoVanHoaCreateRequest create = new TrinhDoVanHoaCreateRequest()
            {
                tenTruong = "FPT",
                idChuyenMon = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void EducationLevel_Create_Failure4()
        {
            TrinhDoVanHoaCreateRequest create = new TrinhDoVanHoaCreateRequest()
            {
                tenTruong = "FPT",
                idChuyenMon = 1,
                idTrinhDo = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"
            };
            var result = TrinhDoVanHoaService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void EducationLevel_Create_Failure5()
        {
            TrinhDoVanHoaCreateRequest create = new TrinhDoVanHoaCreateRequest()
            {
                tenTruong = "FPT",
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
            };
            var result = TrinhDoVanHoaService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void EducationLevel_Update_Success()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = "Bách Khoa",
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(10)]
        public void EducationLevel_Update_Failure1()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = "Bách Khoa",
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Update(7, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void EducationLevel_Update_Failure2()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = null,
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void EducationLevel_Update_Failure3()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = null,
                idChuyenMon = 0,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(13)]
        public void EducationLevel_Update_Failure4()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = null,
                idChuyenMon = 1,
                idTrinhDo = 0,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void EducationLevel_Update_Failure5()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = null,
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 0,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = "NV0001"

            };
            var result = TrinhDoVanHoaService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void EducationLevel_Update_Failure6()
        {
            TrinhDoVanHoaUpdateRequest update = new TrinhDoVanHoaUpdateRequest()
            {
                tenTruong = null,
                idChuyenMon = 1,
                idTrinhDo = 1,
                idHinhThucDaoTao = 1,
                tuThoiGian = new DateTime(2014, 5, 1),
                denThoiGian = new DateTime(2017, 5, 1),
                maNhanVien = null

            };
            var result = TrinhDoVanHoaService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(16)]
        public void EducationLevel_Delete_Success()
        {

            var result = TrinhDoVanHoaService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(17)]
        public void EducationLevel_Delete_Failure()
        {

            var result = TrinhDoVanHoaService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }

    }
}
