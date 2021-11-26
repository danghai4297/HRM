using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestTitleCategories : BaseTest
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
        public void Title_GetById_Success()
        {
            var result = danhMucChucDanhService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Title_GetById_Failure()
        {
            var result = danhMucChucDanhService.GetById(4);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void Title_GetAll_Success()
        {
            var result = danhMucChucDanhService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(3));
        }
        [Test, Order(3)]
        public void Title_Create_Success()
        {
            DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = "CD04",
                tenChucDanh = "Bác Học",
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Create(titleCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Title_Create_Failure1()
        {
            DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = null,
                tenChucDanh = "Bác Học",
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Create(titleCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Title_Create_Failure2()
        {
            DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = "CD04",
                tenChucDanh = null,
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Create(titleCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Title_Create_Failure3()
        {
            DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = null,
                tenChucDanh = null,
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Create(titleCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Title_Update_Success()
        {
            DanhMucChucDanhUpdateRequest titleUpdating = new DanhMucChucDanhUpdateRequest()
            {

                maChucDanh = "CD01",
                tenChucDanh = "Thạc Sĩ nước ngoài",
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Update(1, titleUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void Title_Update_Failure1()
        {
            DanhMucChucDanhUpdateRequest titleUpdating = new DanhMucChucDanhUpdateRequest()
            {

                maChucDanh = null,
                tenChucDanh = "Bác Học 2",
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Update(1, titleUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Title_Update_Failure2()
        {
            DanhMucChucDanhUpdateRequest titleUpdating = new DanhMucChucDanhUpdateRequest()
            {

                maChucDanh = "CD01",
                tenChucDanh = null,
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Update(1, titleUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Title_Update_Failure3()
        {
            DanhMucChucDanhUpdateRequest titleUpdating = new DanhMucChucDanhUpdateRequest()
            {

                maChucDanh = null,
                tenChucDanh = null,
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Update(1, titleUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Title_Update_Failure4()
        {
            DanhMucChucDanhUpdateRequest titleUpdating = new DanhMucChucDanhUpdateRequest()
            {

                maChucDanh = "CD04",
                tenChucDanh = "Bác Học 2",
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Update(5, titleUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(12)]
        public void Title_Delete_Success()
        {

            var result = danhMucChucDanhService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void Title_Delete_Failure()
        {

            var result = danhMucChucDanhService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        //[Test, Order(4)]
        //public void Cat_Create_2()
        //{
        //    DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
        //    {
        //        maChucDanh = null,
        //        tenChucDanh = null,
        //        phuCap = (float)100000.0
        //    };
        //    var result = danhMucChucDanhService.Create(titleCreating);
        //    Assert.That(result.Result, Is.EqualTo(0));
        //}
        //[Test, Order(3)]
        //public void Cat_GetById_2()
        //{
        //    var result = danhMucChucDanhService.GetById(4);
        //    Assert.That(result.Result., Is.EqualTo(4));
        //}
    }
}
