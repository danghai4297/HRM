using HRMSolution.Application.Catalog.HopDongs.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestContract  : BaseTest
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
        public void Contract_GetById_Success()
        {
            var result = HopDongService.GetHopDong("HD01");
            Assert.That(result.Result.id, Is.EqualTo("HD01"));
        }
        [Test, Order(2)]
        public void Contract_GetById_Failure1()
        {
            var result = HopDongService.GetHopDong(null);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Contract_GetById_Failure2()
        {
            var result = HopDongService.GetHopDong("HD07");
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(4)]
        public void Contract_Create_Success()
        {
            HopDongCreateRequest ContractCreating = new HopDongCreateRequest()
            {
                maHopDong = "HD02",
                idLoaiHopDong = 1,
                idChucDanh=1,
                idChucVu=1,
                maNhanVien = "NV0002"
            };
            var result = HopDongService.Create(ContractCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(5)]
        public void Contract_Create_Failure1()
        {
            HopDongCreateRequest ContractCreating = new HopDongCreateRequest()
            {
                maHopDong = null,
                idLoaiHopDong = 1,
                idChucDanh = 1,
                idChucVu = 1,
                maNhanVien = "NV0002"
            };
            var result = HopDongService.Create(ContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Contract_Create_Failure2()
        {
            HopDongCreateRequest ContractCreating = new HopDongCreateRequest()
            {
                maHopDong = "HD02",
                idLoaiHopDong = 0,
                idChucDanh = 1,
                idChucVu = 1,
                maNhanVien = "NV0002"
            };
            var result = HopDongService.Create(ContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Contract_Create_Failure3()
        {
            HopDongCreateRequest ContractCreating = new HopDongCreateRequest()
            {
                maHopDong = "HD02",
                idLoaiHopDong = 1,
                idChucDanh = 0,
                idChucVu = 1,
                maNhanVien = "NV0002"
            };
            var result = HopDongService.Create(ContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void Contract_Create_Failure4()
        {
            HopDongCreateRequest ContractCreating = new HopDongCreateRequest()
            {
                maHopDong = "HD02",
                idLoaiHopDong = 1,
                idChucDanh = 1,
                idChucVu = 0,
                maNhanVien = "NV0002"
            };
            var result = HopDongService.Create(ContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Contract_Create_Failure5()
        {
            HopDongCreateRequest ContractCreating = new HopDongCreateRequest()
            {
                maHopDong = "HD02",
                idLoaiHopDong = 1,
                idChucDanh = 1,
                idChucVu = 0,
                maNhanVien = null
            };
            var result = HopDongService.Create(ContractCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Contract_Update_Success()
        {
            HopDongUpdateRequest ContractUpdating = new HopDongUpdateRequest()
            {
                
                idLoaiHopDong = 1,
                idChucDanh = 2,
                idChucVu = 1,
                hopDongTuNgay= new DateTime(2021,11,21),
                hopDongDenNgay = new DateTime(2022, 11, 21),
                maNhanVien = "NV0001",
                trangThai=true
            };
            var result = HopDongService.Update("HD01", ContractUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(11)]
        public void Contract_Update_Failure1()
        {
            HopDongUpdateRequest ContractUpdating = new HopDongUpdateRequest()
            {
                
                idLoaiHopDong = 0,
                idChucDanh = 1,
                idChucVu = 1,
                maNhanVien = "NV0002",
                trangThai = true
            };
            var result = HopDongService.Update("HD01", ContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void Contract_Update_Failure2()
        {
            HopDongUpdateRequest ContractUpdating = new HopDongUpdateRequest()
            {
                
                idLoaiHopDong = 1,
                idChucDanh = 0,
                idChucVu = 1,
                maNhanVien = "NV0002",
                trangThai = true
            };
            var result = HopDongService.Update("HD01", ContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(13)]
        public void Contract_Update_Failure3()
        {
            HopDongUpdateRequest ContractUpdating = new HopDongUpdateRequest()
            {
                
                idLoaiHopDong = 1,
                idChucDanh = 1,
                idChucVu = 0,
                maNhanVien = "NV0002",
                trangThai = true
            };
            var result = HopDongService.Update("HD01", ContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void Contract_Update_Failure4()
        {
            HopDongUpdateRequest ContractUpdating = new HopDongUpdateRequest()
            {
                
                idLoaiHopDong = 1,
                idChucDanh = 1,
                idChucVu = 1,
                maNhanVien = null,
                trangThai = true
            };
            var result = HopDongService.Update("HD01", ContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void Contract_Update_Failure5()
        {
            HopDongUpdateRequest ContractUpdating = new HopDongUpdateRequest()
            {
                
                idLoaiHopDong = 1,
                idChucDanh = 1,
                idChucVu = 1,
                maNhanVien = "NV0002",
                trangThai = true
            };
            var result = HopDongService.Update("HD08", ContractUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        //[Test, Order(16)]
        //public void Contract_Delete_Success()
        //{

        //    var result = HopDongService.Delete("HD01");
        //    Assert.That(result.Result, Is.EqualTo(1));
        //}
        [Test, Order(17)]
        public void Contract_Delete_Failure()
        {

            var result = HopDongService.Delete("HD09");
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
