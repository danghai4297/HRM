using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestTContractCategory : BaseTest
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
        public void TyContract_GetById_Success()
        {
            var result = danhMucLoaiHopDongService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void TyContract_GetById_Failure()
        {
            var result = danhMucLoaiHopDongService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void TyContract_GetAll_Success()
        {
            var result = danhMucLoaiHopDongService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void TyContract_Create_Success()
        {
            DanhMucLoaiHopDongCreateRequest TyContractCreating = new DanhMucLoaiHopDongCreateRequest()
            {
                maLoaiHopDong = "MHD03",
                tenLoaiHopDong = "Hợp đồng vô thời hạn"

            };
            var result = danhMucLoaiHopDongService.Create(TyContractCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void TyContract_Create_Failure1()
        {
            DanhMucLoaiHopDongCreateRequest TyContractCreating = new DanhMucLoaiHopDongCreateRequest()
            {
                maLoaiHopDong = null,
                tenLoaiHopDong = "Hợp đồng vô thời hạn"

            };
            var result = danhMucLoaiHopDongService.Create(TyContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void TyContract_Create_Failure2()
        {
            DanhMucLoaiHopDongCreateRequest TyContractCreating = new DanhMucLoaiHopDongCreateRequest()
            {
                maLoaiHopDong = "MHD03",
                tenLoaiHopDong = null

            };
            var result = danhMucLoaiHopDongService.Create(TyContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void TyContract_Create_Failure3()
        {
            DanhMucLoaiHopDongCreateRequest TyContractCreating = new DanhMucLoaiHopDongCreateRequest()
            {
                maLoaiHopDong = null,
                tenLoaiHopDong = null

            };
            var result = danhMucLoaiHopDongService.Create(TyContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void TyContract_Update_Success()
        {
            DanhMucLoaiHopDongUpdateRequest TyContractUpdating = new DanhMucLoaiHopDongUpdateRequest()
            {

                maLoaiHopDong = "MHD01",
                tenLoaiHopDong = "Hợp đồng 5 năm"

            };
            var result = danhMucLoaiHopDongService.Update(1, TyContractUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void TyContract_Update_Failure1()
        {
            DanhMucLoaiHopDongUpdateRequest TyContractUpdating = new DanhMucLoaiHopDongUpdateRequest()
            {

                maLoaiHopDong = null,
                tenLoaiHopDong = "Hợp đồng vô thời hạn"

            };
            var result = danhMucLoaiHopDongService.Update(1, TyContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void TyContract_Update_Failure2()
        {
            DanhMucLoaiHopDongUpdateRequest TyContractUpdating = new DanhMucLoaiHopDongUpdateRequest()
            {

                maLoaiHopDong = "MHD01",
                tenLoaiHopDong = null

            };
            var result = danhMucLoaiHopDongService.Update(1, TyContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void TyContract_Update_Failure3()
        {
            DanhMucLoaiHopDongUpdateRequest TyContractUpdating = new DanhMucLoaiHopDongUpdateRequest()
            {

                maLoaiHopDong = null,
                tenLoaiHopDong = null

            };
            var result = danhMucLoaiHopDongService.Update(1, TyContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void TyContract_Update_Failure4()
        {
            DanhMucLoaiHopDongUpdateRequest TyContractUpdating = new DanhMucLoaiHopDongUpdateRequest()
            {

                maLoaiHopDong = "MHD06",
                tenLoaiHopDong = "Hợp đồng vô thời hạn"

            };
            var result = danhMucLoaiHopDongService.Update(6, TyContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(12)]
        public void TyContract_Delete_Success()
        {

            var result = danhMucLoaiHopDongService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(13)]
        public void TyContract_Delete_Failure()
        {

            var result = danhMucLoaiHopDongService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
