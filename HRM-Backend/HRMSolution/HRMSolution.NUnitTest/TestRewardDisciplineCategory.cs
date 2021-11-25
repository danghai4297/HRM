using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestRewardDisciplineCategory : BaseTest
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
        public void RewardDiscipline_GetById_Success()
        {
            var result = danhMucKhenThuongKyLuatService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void RewardDiscipline_GetById_Failure()
        {
            var result = danhMucKhenThuongKyLuatService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }

        [Test, Order(3)]
        public void RewardDiscipline_Create_Success()
        {
            DanhMucKhenThuongKyLuatCreateRequest RewardDisciplineCreating = new DanhMucKhenThuongKyLuatCreateRequest()
            {

                tenDanhMuc = "Thưởng Nhân viên suất xác năm",
                tieuDe = "Khen thưởng"

            };
            var result = danhMucKhenThuongKyLuatService.Create(RewardDisciplineCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void RewardDiscipline_Create_Failure1()
        {
            DanhMucKhenThuongKyLuatCreateRequest RewardDisciplineCreating = new DanhMucKhenThuongKyLuatCreateRequest()
            {

                tenDanhMuc = null,
                tieuDe = "Khen thưởng"

            };
            var result = danhMucKhenThuongKyLuatService.Create(RewardDisciplineCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(5)]
        public void RewardDiscipline_Create_Failure3()
        {
            DanhMucKhenThuongKyLuatCreateRequest RewardDisciplineCreating = new DanhMucKhenThuongKyLuatCreateRequest()
            {

                tenDanhMuc = null,
                tieuDe = null

            };
            var result = danhMucKhenThuongKyLuatService.Create(RewardDisciplineCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void RewardDiscipline_Update_Success()
        {
            DanhMucKhenThuongKyLuatUpdateRequest RewardDisciplineUpdating = new DanhMucKhenThuongKyLuatUpdateRequest()
            {


                tenDanhMuc = "Thưởng Nhân viên suất xác năm"


            };
            var result = danhMucKhenThuongKyLuatService.Update(1, RewardDisciplineUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(7)]
        public void RewardDiscipline_Update_Failure1()
        {
            DanhMucKhenThuongKyLuatUpdateRequest RewardDisciplineUpdating = new DanhMucKhenThuongKyLuatUpdateRequest()
            {


                tenDanhMuc = null

            };
            var result = danhMucKhenThuongKyLuatService.Update(1, RewardDisciplineUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(8)]
        public void RewardDiscipline_Update_Failure2()
        {
            DanhMucKhenThuongKyLuatUpdateRequest RewardDisciplineUpdating = new DanhMucKhenThuongKyLuatUpdateRequest()
            {


                tenDanhMuc = "Thưởng Nhân viên suất xác năm"

            };
            var result = danhMucKhenThuongKyLuatService.Update(6, RewardDisciplineUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(9)]
        public void RewardDiscipline_Delete_Success()
        {

            var result = danhMucKhenThuongKyLuatService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(10)]
        public void RewardDiscipline_Delete_Failure()
        {

            var result = danhMucKhenThuongKyLuatService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
