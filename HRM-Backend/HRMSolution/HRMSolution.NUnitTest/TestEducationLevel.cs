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
            var result = TrinhDoVanHoaService.GetById(2);
            Assert.That(result.Result, Is.EqualTo(null));
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
        public void EducationLevel_Delete_Success()
        {

            var result = TrinhDoVanHoaService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
    }
}
