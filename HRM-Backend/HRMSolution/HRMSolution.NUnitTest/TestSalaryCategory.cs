using HRMSolution.Application.Catalog.DanhMucNhomLuongs.DnhomLuongs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestSalaryCategory : BaseTest
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
        public void SalaryGr_GetById_Success()
        {
            var result = danhMucNhomLuongService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void SalaryGr_GetById_Failure()
        {
            var result = danhMucNhomLuongService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void SalaryGr_GetAll_Success()
        {
            var result = danhMucNhomLuongService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void SalaryGr_Create_Success()
        {
            DanhMucNhomLuongCreateRequest SalaryGrCreating = new DanhMucNhomLuongCreateRequest()
            {
                maNhomLuong = "MNL03",
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Create(SalaryGrCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void SalaryGr_Create_Failure4()
        {
            DanhMucNhomLuongCreateRequest SalaryGrCreating = new DanhMucNhomLuongCreateRequest()
            {
                maNhomLuong = "MNL03",
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Create(SalaryGrCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(4)]
        public void SalaryGr_Create_Failure1()
        {
            DanhMucNhomLuongCreateRequest SalaryGrCreating = new DanhMucNhomLuongCreateRequest()
            {
                maNhomLuong = null,
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Create(SalaryGrCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void SalaryGr_Create_Failure2()
        {
            DanhMucNhomLuongCreateRequest SalaryGrCreating = new DanhMucNhomLuongCreateRequest()
            {
                maNhomLuong = "MNL03",
                tenNhomLuong = null

            };
            var result = danhMucNhomLuongService.Create(SalaryGrCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void SalaryGr_Create_Failure3()
        {
            DanhMucNhomLuongCreateRequest SalaryGrCreating = new DanhMucNhomLuongCreateRequest()
            {
                maNhomLuong = null,
                tenNhomLuong = null

            };
            var result = danhMucNhomLuongService.Create(SalaryGrCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void SalaryGr_Update_Success()
        {
            DanhMucNhomLuongUpdateRequest SalaryGrUpdating = new DanhMucNhomLuongUpdateRequest()
            {

                maNhomLuong = "MNL01",
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Update(1, SalaryGrUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void SalaryGr_Update_Failure4()
        {
            DanhMucNhomLuongUpdateRequest SalaryGrUpdating = new DanhMucNhomLuongUpdateRequest()
            {

                maNhomLuong = "MNL01",
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Update(1, SalaryGrUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void SalaryGr_Update_Failure1()
        {
            DanhMucNhomLuongUpdateRequest SalaryGrUpdating = new DanhMucNhomLuongUpdateRequest()
            {

                maNhomLuong = null,
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Update(1, SalaryGrUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void SalaryGr_Update_Failure2()
        {
            DanhMucNhomLuongUpdateRequest SalaryGrUpdating = new DanhMucNhomLuongUpdateRequest()
            {

                maNhomLuong = "MNL01",
                tenNhomLuong = null

            };
            var result = danhMucNhomLuongService.Update(1, SalaryGrUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void SalaryGr_Update_Failure3()
        {
            DanhMucNhomLuongUpdateRequest SalaryGrUpdating = new DanhMucNhomLuongUpdateRequest()
            {

                maNhomLuong = null,
                tenNhomLuong = null

            };
            var result = danhMucNhomLuongService.Update(1, SalaryGrUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void SalaryGr_Update_Failure4()
        {
            DanhMucNhomLuongUpdateRequest SalaryGrUpdating = new DanhMucNhomLuongUpdateRequest()
            {

                maNhomLuong = "MNL06",
                tenNhomLuong = "Nhóm 3"

            };
            var result = danhMucNhomLuongService.Update(6, SalaryGrUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(12)]
        public void SalaryGr_Delete_Success()
        {

            var result = danhMucNhomLuongService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void SalaryGr_Delete_Failure()
        {

            var result = danhMucNhomLuongService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
