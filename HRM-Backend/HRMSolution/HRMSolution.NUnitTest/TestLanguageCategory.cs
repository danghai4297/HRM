using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestLanguageCategory : BaseTest
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
        public void Language_GetById_Success()
        {
            var result = danhMucNgoaiNguService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Language_GetById_Failure()
        {
            var result = danhMucNgoaiNguService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(1)]
        public void Language_GetAll_Success()
        {
            var result = danhMucNgoaiNguService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void Language_Create_Success()
        {
            DanhMucNgoaiNguCreateRequest LanguageCreating = new DanhMucNgoaiNguCreateRequest()
            {

                tenDanhMuc = "Pháp"

            };
            var result = danhMucNgoaiNguService.Create(LanguageCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Language_Create_Failure1()
        {
            DanhMucNgoaiNguCreateRequest LanguageCreating = new DanhMucNgoaiNguCreateRequest()
            {

                tenDanhMuc = null

            };
            var result = danhMucNgoaiNguService.Create(LanguageCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(4)]
        public void Language_Create_Failure2()
        {
            DanhMucNgoaiNguCreateRequest LanguageCreating = new DanhMucNgoaiNguCreateRequest()
            {

                tenDanhMuc = "Pháp"

            };
            var result = danhMucNgoaiNguService.Create(LanguageCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(5)]
        public void Language_Update_Success()
        {
            DanhMucNgoaiNguUpdateRequest LanguageUpdating = new DanhMucNgoaiNguUpdateRequest()
            {


                tenDanhMuc = "Singapo"

            };
            var result = danhMucNgoaiNguService.Update(1, LanguageUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Language_Update_Failure1()
        {
            DanhMucNgoaiNguUpdateRequest LanguageUpdating = new DanhMucNgoaiNguUpdateRequest()
            {


                tenDanhMuc = null

            };
            var result = danhMucNgoaiNguService.Update(1, LanguageUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Language_Update_Failure2()
        {
            DanhMucNgoaiNguUpdateRequest LanguageUpdating = new DanhMucNgoaiNguUpdateRequest()
            {


                tenDanhMuc = "Singapo"

            };
            var result = danhMucNgoaiNguService.Update(6, LanguageUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Language_Delete_Success()
        {

            var result = danhMucNgoaiNguService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Language_Delete_Failure()
        {

            var result = danhMucNgoaiNguService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
