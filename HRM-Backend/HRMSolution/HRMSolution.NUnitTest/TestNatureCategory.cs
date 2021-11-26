using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestNatureCategory : BaseTest
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
        public void Nature_GetById_Success()
        {
            var result = danhMucTinhChatLaoDongService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Nature_GetById_Failure()
        {
            var result = danhMucTinhChatLaoDongService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void Nature_GetAll_Success()
        {
            var result = danhMucTinhChatLaoDongService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void Nature_Create_Success()
        {
            DanhMucTinhChatLaoDongCreateRequest NatureCreating = new DanhMucTinhChatLaoDongCreateRequest()
            {

                tenLaoDong = "Cộng Tác Viên"

            };
            var result = danhMucTinhChatLaoDongService.Create(NatureCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Nature_Create_Failure1()
        {
            DanhMucTinhChatLaoDongCreateRequest NatureCreating = new DanhMucTinhChatLaoDongCreateRequest()
            {

                tenLaoDong = null

            };
            var result = danhMucTinhChatLaoDongService.Create(NatureCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Nature_Update_Success()
        {
            DanhMucTinhChatLaoDongUpdateRequest NatureUpdating = new DanhMucTinhChatLaoDongUpdateRequest()
            {


                tenLaoDong = "Cộng Tác Viên"

            };
            var result = danhMucTinhChatLaoDongService.Update(1, NatureUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Nature_Update_Failure1()
        {
            DanhMucTinhChatLaoDongUpdateRequest NatureUpdating = new DanhMucTinhChatLaoDongUpdateRequest()
            {


                tenLaoDong = null

            };
            var result = danhMucTinhChatLaoDongService.Update(1, NatureUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Nature_Update_Failure2()
        {
            DanhMucTinhChatLaoDongUpdateRequest NatureUpdating = new DanhMucTinhChatLaoDongUpdateRequest()
            {


                tenLaoDong = "Cộng Tác Viên"

            };
            var result = danhMucTinhChatLaoDongService.Update(6, NatureUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Nature_Delete_Success()
        {

            var result = danhMucTinhChatLaoDongService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Nature_Delete_Failure()
        {

            var result = danhMucTinhChatLaoDongService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
