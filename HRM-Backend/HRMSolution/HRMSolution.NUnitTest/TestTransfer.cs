using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
using HRMSolution.Application.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestTransfer : BaseTest
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
        public void Transfer_GetById_Success()
        {
            var result = DieuChuyenService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Transfer_GetById_Failure()
        {
            var result = DieuChuyenService.GetById(4);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Transfer_Create_Success()
        {
            DieuChuyenCreateRequest transferCreating = new DieuChuyenCreateRequest()
            {
                maNhanVien = "NV0002",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Create(transferCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Transfer_Create_Failure1()
        {
            DieuChuyenCreateRequest transferCreating = new DieuChuyenCreateRequest()
            {
                maNhanVien = null,
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Create(transferCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Transfer_Create_Failure2()
        {
            DieuChuyenCreateRequest transferCreating = new DieuChuyenCreateRequest()
            {
                maNhanVien = "NV0002",
                ngayHieuLuc = null,
                idPhongBan = 1,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Create(transferCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Transfer_Create_Failure3()
        {
            DieuChuyenCreateRequest transferCreating = new DieuChuyenCreateRequest()
            {
                maNhanVien = "NV0002",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 0,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Create(transferCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Transfer_Create_Failure4()
        {
            DieuChuyenCreateRequest transferCreating = new DieuChuyenCreateRequest()
            {
                maNhanVien = "NV0002",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 0,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Create(transferCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Transfer_Update_Success()
        {
            DieuChuyenUpdateRequest transferUpdating = new DieuChuyenUpdateRequest()
            {
                maNhanVien = "NV0001",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Update(1, transferUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(8)]
        public void Transfer_Update_Failure1()
        {
            DieuChuyenUpdateRequest transferUpdating = new DieuChuyenUpdateRequest()
            {
                maNhanVien = "NV0001",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Update(1, transferUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Transfer_Update_Failure2()
        {
            DieuChuyenUpdateRequest transferUpdating = new DieuChuyenUpdateRequest()
            {
                maNhanVien = "NV0001",
                ngayHieuLuc = null,
                idPhongBan = 1,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Update(1, transferUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Transfer_Update_Failure3()
        {
            DieuChuyenUpdateRequest transferUpdating = new DieuChuyenUpdateRequest()
            {
                maNhanVien = "NV0001",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 0,
                to = 2,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Update(1, transferUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Transfer_Update_Failure4()
        {
            DieuChuyenUpdateRequest transferUpdating = new DieuChuyenUpdateRequest()
            {
                maNhanVien = "NV0001",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 0,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Update(1, transferUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Transfer_Update_Failure5()
        {
            DieuChuyenUpdateRequest transferUpdating = new DieuChuyenUpdateRequest()
            {
                maNhanVien = "NV0001",
                ngayHieuLuc = "2022,4,14",
                idPhongBan = 1,
                to = 0,
                chiTiet = "Ahihi",
                trangThai = true
            };
            var result = DieuChuyenService.Update(6, transferUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        //[Test, Order(12)]
        //public void Transfer_Delete_Success()
        //{

        //    var result = DieuChuyenService.Delete(1);
        //    Assert.That(result.Result, Is.EqualTo(1));
        //}
        [Test, Order(13)]
        public void Transfer_Delete_Failure()
        {

            var result = DieuChuyenService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
