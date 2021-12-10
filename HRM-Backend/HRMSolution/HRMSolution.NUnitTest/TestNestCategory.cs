using HRMSolution.Application.Catalog.DanhMucTos.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestNestCategory : BaseTest
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
        public void Nest_GetById_Success()
        {
            var result = danhMucToService.GetDetail(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Nest_GetById_Failure()
        {
            var result = danhMucToService.GetDetail(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void Nest_GetAll_Success()
        {
            var result = danhMucToService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void Nest_Create_Success()
        {
            DanhMucToCreateRequest NestCreating = new DanhMucToCreateRequest()
            {
                maTo = "T03",
                tenTo = "Tổ giám sát",
                idPhongBan = 2
            };
            var result = danhMucToService.Create(NestCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Nest_Create_Failure1()
        {
            DanhMucToCreateRequest NestCreating = new DanhMucToCreateRequest()
            {
                maTo = null,
                tenTo = "Tổ giám sát",
                idPhongBan = 2

            };
            var result = danhMucToService.Create(NestCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Nest_Create_Failure2()
        {
            DanhMucToCreateRequest NestCreating = new DanhMucToCreateRequest()
            {
                maTo = "T03",
                tenTo = null,
                idPhongBan = 2

            };
            var result = danhMucToService.Create(NestCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Nest_Create_Failure3()
        {
            DanhMucToCreateRequest NestCreating = new DanhMucToCreateRequest()
            {
                maTo = null,
                tenTo = null,
                idPhongBan = 2

            };
            var result = danhMucToService.Create(NestCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Nest_Create_Failure4()
        {
            DanhMucToCreateRequest NestCreating = new DanhMucToCreateRequest()
            {
                maTo = "T03",
                tenTo = "Tổ giám sát",
                idPhongBan = 2
            };
            var result = danhMucToService.Create(NestCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Nest_Update_Success()
        {
            DanhMucToUpdateRequest NestUpdating = new DanhMucToUpdateRequest()
            {

                maTo = "T01",
                tenTo = "Tổ giám sát",
                idPhongBan = 1

            };
            var result = danhMucToService.Update(1, NestUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void Nest_Update_Failure1()
        {
            DanhMucToUpdateRequest NestUpdating = new DanhMucToUpdateRequest()
            {

                maTo = null,
                tenTo = "Tổ giám sát",
                idPhongBan = 1

            };
            var result = danhMucToService.Update(1, NestUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Nest_Update_Failure2()
        {
            DanhMucToUpdateRequest NestUpdating = new DanhMucToUpdateRequest()
            {

                maTo = "T01",
                tenTo = null,
                idPhongBan = 1

            };
            var result = danhMucToService.Update(1, NestUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Nest_Update_Failure3()
        {
            DanhMucToUpdateRequest NestUpdating = new DanhMucToUpdateRequest()
            {

                maTo = null,
                tenTo = null,
                idPhongBan = 1

            };
            var result = danhMucToService.Update(1, NestUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Nest_Update_Failure4()
        {
            DanhMucToUpdateRequest NestUpdating = new DanhMucToUpdateRequest()
            {

                maTo = "T06",
                tenTo = "Tổ giám sát",
                idPhongBan = 1

            };
            var result = danhMucToService.Update(6, NestUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(11)]
        public void Nest_Update_Failure5()
        {
            DanhMucToUpdateRequest NestUpdating = new DanhMucToUpdateRequest()
            {

                maTo = "T01",
                tenTo = "Tổ giám sát",
                idPhongBan = 1

            };
            var result = danhMucToService.Update(1, NestUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void Nest_Delete_Success()
        {

            var result = danhMucToService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void Nest_Delete_Failure()
        {

            var result = danhMucToService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
