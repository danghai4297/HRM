using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestLevelCategory: BaseTest
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
        public void Level_GetById_Success()
        {
            var result = danhMucTrinhDoService.GetById(1);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(true));
        }
        [Test, Order(2)]
        public void Level_GetById_Failure()
        {
            var result = danhMucTrinhDoService.GetById(6);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(false));
        }

        [Test, Order(3)]
        public void Level_Create_Success()
        {
            DanhMucTrinhDoCreateRequest LevelCreating = new DanhMucTrinhDoCreateRequest()
            {

                tenTrinhDo = "Trung Bình"

            };
            var result = danhMucTrinhDoService.Create(LevelCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Level_Create_Failure1()
        {
            DanhMucTrinhDoCreateRequest LevelCreating = new DanhMucTrinhDoCreateRequest()
            {

                tenTrinhDo = null

            };
            var result = danhMucTrinhDoService.Create(LevelCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Level_Update_Success()
        {
            DanhMucTrinhDoUpdateRequest LevelUpdating = new DanhMucTrinhDoUpdateRequest()
            {


                tenTrinhDo = "Trung Bình"

            };
            var result = danhMucTrinhDoService.Update(1, LevelUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Level_Update_Failure1()
        {
            DanhMucTrinhDoUpdateRequest LevelUpdating = new DanhMucTrinhDoUpdateRequest()
            {


                tenTrinhDo = null

            };
            var result = danhMucTrinhDoService.Update(1, LevelUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Level_Update_Failure2()
        {
            DanhMucTrinhDoUpdateRequest LevelUpdating = new DanhMucTrinhDoUpdateRequest()
            {


                tenTrinhDo = "Trung Bình"

            };
            var result = danhMucTrinhDoService.Update(6, LevelUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Level_Delete_Success()
        {

            var result = danhMucTrinhDoService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Level_Delete_Failure()
        {

            var result = danhMucTrinhDoService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
