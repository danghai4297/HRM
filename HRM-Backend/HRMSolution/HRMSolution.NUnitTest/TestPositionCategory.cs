﻿using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    class TestPositionCategory : BaseTest
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
        public void Position_GetById_Success()
        {
            var result = danhMucChucVuService.GetById(1);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(true));
        }
        [Test, Order(2)]
        public void Position_GetById_Failure()
        {
            var result = danhMucChucVuService.GetById(8);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(false));
        }

        [Test, Order(3)]
        public void Position_Create_Success()
        {
            DanhMucChucVuCreateRequest PositionCreating = new DanhMucChucVuCreateRequest()
            {
                maChucVu = "CV08",
                tenChucVu = "Chuyên Viên",
                phuCap = (float)100000.0
            };
            var result = danhMucChucVuService.Create(PositionCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Position_Update_Success()
        {
            DanhMucChucVuUpdateRequest PositionUpdating = new DanhMucChucVuUpdateRequest()
            {

                maChucVu = "CV01",
                tenChucVu = "Giám đốc",
                phuCap = (float)100000.0
            };
            var result = danhMucChucVuService.Update(1, PositionUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(5)]
        public void Position_Update_Failure()
        {
            DanhMucChucVuUpdateRequest PositionUpdating = new DanhMucChucVuUpdateRequest()
            {

                maChucVu = "CV09",
                tenChucVu = "Bảo vệ",
                phuCap = (float)100000.0
            };
            var result = danhMucChucVuService.Update(9, PositionUpdating);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(false));
        }
        [Test, Order(6)]
        public void Position_Delete_Success()
        {

            var result = danhMucChucVuService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(7)]
        public void Position_Delete_Failure()
        {

            var result = danhMucChucVuService.Delete(10);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(false));
        }
    }
}
