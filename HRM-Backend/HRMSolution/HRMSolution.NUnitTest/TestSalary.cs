using HRMSolution.Application.Catalog.Luongs.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestSalary : BaseTest
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
        public void Salary_GetById_Success()
        {
            var result = LuongService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Salary_GetById_Failure()
        {
            var result = LuongService.GetById(5);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Salary_Create_Success()
        {
            LuongCreateRequest create = new LuongCreateRequest()
            {
                maHopDong = "HD01",
                idNhomLuong = 1,
                heSoLuong = 12,
                bacLuong = "1",
                luongCoBan = 12,
                phuCapKhac = 123,
                phuCapTrachNhiem = 1234,
                tongLuong = 123123,
                thoiHanLenLuong = "1",
                ngayHieuLuc = "2021-12-12",
                ngayKetThuc = "2022-12-12",
                ghiChu = null,
                trangThai = true,
                bangChung = null
            };
            var result = LuongService.Create(create);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Salary_Create_Failure1()
        {
            LuongCreateRequest create = new LuongCreateRequest()
            {
                maHopDong = null,
                idNhomLuong = 1,
                heSoLuong = 12,
                bacLuong = "1",
                luongCoBan = 12,
                phuCapKhac = 123,
                phuCapTrachNhiem = 1234,
                tongLuong = 123123,
                thoiHanLenLuong = "1",
                ngayHieuLuc = "2021-12-12",
                ngayKetThuc = "2022-12-12",
                ghiChu = null,
                trangThai = true,
                bangChung = null
            };
            var result = LuongService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void Salary_Create_Failure2()
        {
            LuongCreateRequest create = new LuongCreateRequest()
            {
                maHopDong = "HD01",
                idNhomLuong = 0,
                heSoLuong = 12,
                bacLuong = "1",
                luongCoBan = 12,
                phuCapKhac = 123,
                phuCapTrachNhiem = 1234,
                tongLuong = 123123,
                thoiHanLenLuong = "1",
                ngayHieuLuc = "2021-12-12",
                ngayKetThuc = "2022-12-12",
                ghiChu = null,
                trangThai = true,
                bangChung = null
            };
            var result = LuongService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Salary_Create_Failure3()
        {
            LuongCreateRequest create = new LuongCreateRequest()
            {
                maHopDong = "HD01",
                idNhomLuong = 1,
                heSoLuong = 1,
                bacLuong = null,
                luongCoBan = 12,
                phuCapKhac = 123,
                phuCapTrachNhiem = 1234,
                tongLuong = 123123,
                thoiHanLenLuong = "1",
                ngayHieuLuc = "2021-12-12",
                ngayKetThuc = "2022-12-12",
                ghiChu = null,
                trangThai = true,
                bangChung = null
            };
            var result = LuongService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
