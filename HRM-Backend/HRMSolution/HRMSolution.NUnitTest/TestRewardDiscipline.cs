using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestRewardDiscipline : BaseTest
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
            var result = LuongService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void RewardDiscipline_GetById_Failure()
        {
            var result = LuongService.GetById(5);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void RewardDiscipline_Create_Success()
        {
            KhenThuongKyLuatCreateRequest create = new KhenThuongKyLuatCreateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Create(create);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void RewardDiscipline_Create_Failure1()
        {
            KhenThuongKyLuatCreateRequest create = new KhenThuongKyLuatCreateRequest()
            {
                idDanhMucKhenThuong = 0,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(5)]
        public void RewardDiscipline_Create_Failure2()
        {
            KhenThuongKyLuatCreateRequest create = new KhenThuongKyLuatCreateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = null,
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void RewardDiscipline_Create_Failure3()
        {
            KhenThuongKyLuatCreateRequest create = new KhenThuongKyLuatCreateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = null,
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void RewardDiscipline_Create_Failure4()
        {
            KhenThuongKyLuatCreateRequest create = new KhenThuongKyLuatCreateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = null,
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Create(create);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void RewardDiscipline_Update_Success()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 2,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void RewardDiscipline_Update_Failure1()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 2,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(9, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void RewardDiscipline_Update_Failure2()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 0,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void RewardDiscipline_Update_Failure3()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = null,
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void RewardDiscipline_Update_Failure4()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = null,
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(13)]
        public void RewardDiscipline_Update_Failure5()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = null,
                maNhanVien = "NV0001",
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void RewardDiscipline_Update_Failure6()
        {
            KhenThuongKyLuatUpdateRequest update = new KhenThuongKyLuatUpdateRequest()
            {
                idDanhMucKhenThuong = 1,
                loai = true,
                lyDo = "Không đi làm muộn",
                noiDung = "Thưởng nhân viên tốt",
                maNhanVien = null,
                bangChung = null
            };
            var result = KhenThuongKyLuatService.Update(1, update);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void RewardDiscipline_Delete_Failure()
        {
            var result = KhenThuongKyLuatService.Delete(8);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(1)]
        public void RewardDiscipline_GetAllReward_Success()
        {
            var result = KhenThuongKyLuatService.GetAllKhenThuong();
            Assert.That(result.Result.Count, Is.EqualTo(1));
        }
        [Test, Order(1)]
        public void RewardDiscipline_GetAllDiscipline_Success()
        {
            var result = KhenThuongKyLuatService.GetAllKyLuat();
            Assert.That(result.Result.Count, Is.EqualTo(1));
        }
    }
}
