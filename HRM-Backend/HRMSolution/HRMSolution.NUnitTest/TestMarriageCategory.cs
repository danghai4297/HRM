using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestMarriageCategory : BaseTest
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
        public void Marriage_GetById_Success()
        {
            var result = danhMucHonNhanService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Marriage_GetById_Failure()
        {
            var result = danhMucHonNhanService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }

        [Test, Order(3)]
        public void Marriage_Create_Success()
        {
            DanhMucHonNhanCreateRequest MarriageCreating = new DanhMucHonNhanCreateRequest()
            {

                tenDanhMuc = "Đã kết hôn"

            };
            var result = danhMucHonNhanService.Create(MarriageCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Marriage_Create_Failure1()
        {
            DanhMucHonNhanCreateRequest MarriageCreating = new DanhMucHonNhanCreateRequest()
            {

                tenDanhMuc = null

            };
            var result = danhMucHonNhanService.Create(MarriageCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Marriage_Update_Success()
        {
            DanhMucHonNhanUpdateRequest MarriageUpdating = new DanhMucHonNhanUpdateRequest()
            {


                tenDanhMuc = "Đã kết hôn"

            };
            var result = danhMucHonNhanService.Update(1, MarriageUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Marriage_Update_Failure1()
        {
            DanhMucHonNhanUpdateRequest MarriageUpdating = new DanhMucHonNhanUpdateRequest()
            {


                tenDanhMuc = null

            };
            var result = danhMucHonNhanService.Update(1, MarriageUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Marriage_Update_Failure2()
        {
            DanhMucHonNhanUpdateRequest MarriageUpdating = new DanhMucHonNhanUpdateRequest()
            {


                tenDanhMuc = "Đã kết hôn"

            };
            var result = danhMucHonNhanService.Update(6, MarriageUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Marriage_Delete_Success()
        {

            var result = danhMucHonNhanService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Marriage_Delete_Failure()
        {

            var result = danhMucHonNhanService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
