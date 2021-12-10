using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestSpecializeCategory : BaseTest
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
        public void Specialize_GetById_Success()
        {
            var result = danhMucChuyenMonService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Specialize_GetById_Failure()
        {
            var result = danhMucChuyenMonService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void Specialize_GetAll_Success()
        {
            var result = danhMucChuyenMonService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(4));
        }
        [Test, Order(3)]
        public void Specialize_Create_Success()
        {
            DanhMucChuyenMonCreateRequest SpecializeCreating = new DanhMucChuyenMonCreateRequest()
            {
                maChuyenMon = "CM05",
                tenChuyenMon = "Kinh tế"

            };
            var result = danhMucChuyenMonService.Create(SpecializeCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Specialize_Create_Failure4()
        {
            DanhMucChuyenMonCreateRequest SpecializeCreating = new DanhMucChuyenMonCreateRequest()
            {
                maChuyenMon = "CM05",
                tenChuyenMon = "Kinh tế"

            };
            var result = danhMucChuyenMonService.Create(SpecializeCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(4)]
        public void Specialize_Create_Failure1()
        {
            DanhMucChuyenMonCreateRequest SpecializeCreating = new DanhMucChuyenMonCreateRequest()
            {
                maChuyenMon = null,
                tenChuyenMon = "Kinh tế"

            };
            var result = danhMucChuyenMonService.Create(SpecializeCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Specialize_Create_Failure2()
        {
            DanhMucChuyenMonCreateRequest SpecializeCreating = new DanhMucChuyenMonCreateRequest()
            {
                maChuyenMon = "CM05",
                tenChuyenMon = null

            };
            var result = danhMucChuyenMonService.Create(SpecializeCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Specialize_Create_Failure3()
        {
            DanhMucChuyenMonCreateRequest SpecializeCreating = new DanhMucChuyenMonCreateRequest()
            {
                maChuyenMon = null,
                tenChuyenMon = null

            };
            var result = danhMucChuyenMonService.Create(SpecializeCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Specialize_Update_Success()
        {
            DanhMucChuyenMonUpdateRequest SpecializeUpdating = new DanhMucChuyenMonUpdateRequest()
            {

                maChuyenMon = "CM01",
                tenChuyenMon = "Ngoại giao"

            };
            var result = danhMucChuyenMonService.Update(1, SpecializeUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void Specialize_Update_Failure4()
        {
            DanhMucChuyenMonUpdateRequest SpecializeUpdating = new DanhMucChuyenMonUpdateRequest()
            {

                maChuyenMon = "CM01",
                tenChuyenMon = "Kinh tế"

            };
            var result = danhMucChuyenMonService.Update(1, SpecializeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void Specialize_Update_Failure1()
        {
            DanhMucChuyenMonUpdateRequest SpecializeUpdating = new DanhMucChuyenMonUpdateRequest()
            {

                maChuyenMon = null,
                tenChuyenMon = "Kinh tế"

            };
            var result = danhMucChuyenMonService.Update(1, SpecializeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Specialize_Update_Failure2()
        {
            DanhMucChuyenMonUpdateRequest SpecializeUpdating = new DanhMucChuyenMonUpdateRequest()
            {

                maChuyenMon = "CM01",
                tenChuyenMon = null

            };
            var result = danhMucChuyenMonService.Update(1, SpecializeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Specialize_Update_Failure3()
        {
            DanhMucChuyenMonUpdateRequest SpecializeUpdating = new DanhMucChuyenMonUpdateRequest()
            {

                maChuyenMon = null,
                tenChuyenMon = null

            };
            var result = danhMucChuyenMonService.Update(1, SpecializeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Specialize_Update_Failure5()
        {
            DanhMucChuyenMonUpdateRequest SpecializeUpdating = new DanhMucChuyenMonUpdateRequest()
            {

                maChuyenMon = "CM06",
                tenChuyenMon = "Kinh tế"

            };
            var result = danhMucChuyenMonService.Update(6, SpecializeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(12)]
        public void Specialize_Delete_Success()
        {

            var result = danhMucChuyenMonService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void Specialize_Delete_Failure()
        {

            var result = danhMucChuyenMonService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
