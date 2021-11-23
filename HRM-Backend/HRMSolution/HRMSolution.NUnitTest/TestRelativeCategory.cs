using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestRelativeCategory: BaseTest
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
        public void Relative_GetById_Success()
        {
            var result = danhMucNguoiThanService.GetById(1);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(true));
        }
        [Test, Order(2)]
        public void Relative_GetById_Failure()
        {
            var result = danhMucNguoiThanService.GetById(6);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(false));
        }

        [Test, Order(3)]
        public void Relative_Create_Success()
        {
            DanhMucNguoiThanCreateRequest RelativeCreating = new DanhMucNguoiThanCreateRequest()
            {

                tenDanhMuc = "Anh"

            };
            var result = danhMucNguoiThanService.Create(RelativeCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Relative_Create_Failure1()
        {
            DanhMucNguoiThanCreateRequest RelativeCreating = new DanhMucNguoiThanCreateRequest()
            {

                tenDanhMuc = null

            };
            var result = danhMucNguoiThanService.Create(RelativeCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Relative_Update_Success()
        {
            DanhMucNguoiThanUpdateRequest RelativeUpdating = new DanhMucNguoiThanUpdateRequest()
            {


                tenDanhMuc = "Anh"

            };
            var result = danhMucNguoiThanService.Update(1, RelativeUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Relative_Update_Failure1()
        {
            DanhMucNguoiThanUpdateRequest RelativeUpdating = new DanhMucNguoiThanUpdateRequest()
            {


                tenDanhMuc = null

            };
            var result = danhMucNguoiThanService.Update(1, RelativeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Relative_Update_Failure2()
        {
            DanhMucNguoiThanUpdateRequest RelativeUpdating = new DanhMucNguoiThanUpdateRequest()
            {


                tenDanhMuc = "Anh"

            };
            var result = danhMucNguoiThanService.Update(6, RelativeUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Relative_Delete_Success()
        {

            var result = danhMucNguoiThanService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Relative_Delete_Failure()
        {

            var result = danhMucNguoiThanService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
