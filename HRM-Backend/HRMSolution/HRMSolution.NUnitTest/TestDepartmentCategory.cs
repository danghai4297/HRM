using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestDepartmentCategory : BaseTest
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
        public void Department_GetById_Success()
        {
            var result = danhMucPhongBanService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Department_GetById_Failure()
        {
            var result = danhMucPhongBanService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }

        [Test, Order(3)]
        public void Department_Create_Success()
        {
            DanhMucPhongBanCreateRequest DepartmentCreating = new DanhMucPhongBanCreateRequest()
            {
                maPhongBan = "PB03",
                tenPhongBan = "Phòng tài chính kế toán"

            };
            var result = danhMucPhongBanService.Create(DepartmentCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Department_Create_Failure1()
        {
            DanhMucPhongBanCreateRequest DepartmentCreating = new DanhMucPhongBanCreateRequest()
            {
                maPhongBan = null,
                tenPhongBan = "Phòng tài chính kế toán"

            };
            var result = danhMucPhongBanService.Create(DepartmentCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Department_Create_Failure2()
        {
            DanhMucPhongBanCreateRequest DepartmentCreating = new DanhMucPhongBanCreateRequest()
            {
                maPhongBan = "PB03",
                tenPhongBan = null

            };
            var result = danhMucPhongBanService.Create(DepartmentCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Department_Create_Failure3()
        {
            DanhMucPhongBanCreateRequest DepartmentCreating = new DanhMucPhongBanCreateRequest()
            {
                maPhongBan = null,
                tenPhongBan = null

            };
            var result = danhMucPhongBanService.Create(DepartmentCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Department_Update_Success()
        {
            DanhMucPhongBanUpdateRequest DepartmentUpdating = new DanhMucPhongBanUpdateRequest()
            {

                maPhongBan = "PB01",
                tenPhongBan = "Phòng tài chính kế toán"

            };
            var result = danhMucPhongBanService.Update(1, DepartmentUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void Department_Update_Failure1()
        {
            DanhMucPhongBanUpdateRequest DepartmentUpdating = new DanhMucPhongBanUpdateRequest()
            {

                maPhongBan = null,
                tenPhongBan = "Phòng tài chính kế toán"

            };
            var result = danhMucPhongBanService.Update(1, DepartmentUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Department_Update_Failure2()
        {
            DanhMucPhongBanUpdateRequest DepartmentUpdating = new DanhMucPhongBanUpdateRequest()
            {

                maPhongBan = "PB01",
                tenPhongBan = null

            };
            var result = danhMucPhongBanService.Update(1, DepartmentUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Department_Update_Failure3()
        {
            DanhMucPhongBanUpdateRequest DepartmentUpdating = new DanhMucPhongBanUpdateRequest()
            {

                maPhongBan = null,
                tenPhongBan = null

            };
            var result = danhMucPhongBanService.Update(1, DepartmentUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Department_Update_Failure4()
        {
            DanhMucPhongBanUpdateRequest DepartmentUpdating = new DanhMucPhongBanUpdateRequest()
            {

                maPhongBan = "PB06",
                tenPhongBan = "Phòng tài chính kế toán"

            };
            var result = danhMucPhongBanService.Update(6, DepartmentUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(12)]
        public void Department_Delete_Success()
        {

            var result = danhMucPhongBanService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void Department_Delete_Failure()
        {

            var result = danhMucPhongBanService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
