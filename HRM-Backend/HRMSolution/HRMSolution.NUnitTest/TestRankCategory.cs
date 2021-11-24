using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestRankCategory : BaseTest
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
        public void Rank_GetById_Success()
        {
            var result = danhMucNgachCongChucService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Rank_GetById_Failure()
        {
            var result = danhMucNgachCongChucService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }

        [Test, Order(3)]
        public void Rank_Create_Success()
        {
            DanhMucNgachCongChucCreateRequest RankCreating = new DanhMucNgachCongChucCreateRequest()
            {

                tenNgach = "Loại C"

            };
            var result = danhMucNgachCongChucService.Create(RankCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Rank_Create_Failure1()
        {
            DanhMucNgachCongChucCreateRequest RankCreating = new DanhMucNgachCongChucCreateRequest()
            {

                tenNgach = null

            };
            var result = danhMucNgachCongChucService.Create(RankCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Rank_Update_Success()
        {
            DanhMucNgachCongChucUpdateRequest RankUpdating = new DanhMucNgachCongChucUpdateRequest()
            {


                tenNgach = "Loại C"

            };
            var result = danhMucNgachCongChucService.Update(1, RankUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Rank_Update_Failure1()
        {
            DanhMucNgachCongChucUpdateRequest RankUpdating = new DanhMucNgachCongChucUpdateRequest()
            {


                tenNgach = null

            };
            var result = danhMucNgachCongChucService.Update(1, RankUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Rank_Update_Failure2()
        {
            DanhMucNgachCongChucUpdateRequest RankUpdating = new DanhMucNgachCongChucUpdateRequest()
            {


                tenNgach = "Loại C"

            };
            var result = danhMucNgachCongChucService.Update(6, RankUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Rank_Delete_Success()
        {

            var result = danhMucNgachCongChucService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Rank_Delete_Failure()
        {

            var result = danhMucNgachCongChucService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
