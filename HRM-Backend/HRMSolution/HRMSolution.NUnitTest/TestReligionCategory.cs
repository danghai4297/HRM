using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestReligionCategory : BaseTest
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
        public void Religion_GetById_Success()
        {
            var result = danhMucTonGiaoService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Religion_GetById_Failure()
        {
            var result = danhMucTonGiaoService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void Religion_GetAll_Success()
        {
            var result = danhMucTonGiaoService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void Religion_Create_Success()
        {
            DanhMucTonGiaoCreateRequest ReligionCreating = new DanhMucTonGiaoCreateRequest()
            {

                tenDanhMuc = "Phật Giáo"

            };
            var result = danhMucTonGiaoService.Create(ReligionCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Religion_Create_Failure4()
        {
            DanhMucTonGiaoCreateRequest ReligionCreating = new DanhMucTonGiaoCreateRequest()
            {

                tenDanhMuc = "Phật Giáo"

            };
            var result = danhMucTonGiaoService.Create(ReligionCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(4)]
        public void Religion_Create_Failure1()
        {
            DanhMucTonGiaoCreateRequest ReligionCreating = new DanhMucTonGiaoCreateRequest()
            {

                tenDanhMuc = null

            };
            var result = danhMucTonGiaoService.Create(ReligionCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Religion_Update_Success()
        {
            DanhMucTonGiaoUpdateRequest ReligionUpdating = new DanhMucTonGiaoUpdateRequest()
            {


                tenDanhMuc = "Do Thái"

            };
            var result = danhMucTonGiaoService.Update(1, ReligionUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Religion_Update_Failure4()
        {
            DanhMucTonGiaoUpdateRequest ReligionUpdating = new DanhMucTonGiaoUpdateRequest()
            {


                tenDanhMuc = "Phật Giáo"

            };
            var result = danhMucTonGiaoService.Update(1, ReligionUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Religion_Update_Failure1()
        {
            DanhMucTonGiaoUpdateRequest ReligionUpdating = new DanhMucTonGiaoUpdateRequest()
            {


                tenDanhMuc = null

            };
            var result = danhMucTonGiaoService.Update(1, ReligionUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Religion_Update_Failure2()
        {
            DanhMucTonGiaoUpdateRequest ReligionUpdating = new DanhMucTonGiaoUpdateRequest()
            {


                tenDanhMuc = "Phật Giáo"

            };
            var result = danhMucTonGiaoService.Update(6, ReligionUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Religion_Delete_Success()
        {

            var result = danhMucTonGiaoService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Religion_Delete_Failure()
        {

            var result = danhMucTonGiaoService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
