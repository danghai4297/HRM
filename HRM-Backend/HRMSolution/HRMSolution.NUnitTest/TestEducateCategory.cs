using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestEducateCategory: BaseTest
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
        public void Educate_GetById_Success()
        {
            var result = danhMucHinhThucDaoTaoService.GetById(1);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(true));
        }
        [Test, Order(2)]
        public void Educate_GetById_Failure()
        {
            var result = danhMucHinhThucDaoTaoService.GetById(6);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(false));
        }

        [Test, Order(3)]
        public void Educate_Create_Success()
        {
            DanhMucHinhThucDaoTaoCreateRequest EducateCreating = new DanhMucHinhThucDaoTaoCreateRequest()
            {

                tenHinhThuc = "Tại Chức"

            };
            var result = danhMucHinhThucDaoTaoService.Create(EducateCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Educate_Create_Failure1()
        {
            DanhMucHinhThucDaoTaoCreateRequest EducateCreating = new DanhMucHinhThucDaoTaoCreateRequest()
            {

                tenHinhThuc = null

            };
            var result = danhMucHinhThucDaoTaoService.Create(EducateCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Educate_Update_Success()
        {
            DanhMucHinhThucDaoTaoUpdateRequest EducateUpdating = new DanhMucHinhThucDaoTaoUpdateRequest()
            {


                tenHinhThuc = "Tại Chức"

            };
            var result = danhMucHinhThucDaoTaoService.Update(1, EducateUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Educate_Update_Failure1()
        {
            DanhMucHinhThucDaoTaoUpdateRequest EducateUpdating = new DanhMucHinhThucDaoTaoUpdateRequest()
            {


                tenHinhThuc = null

            };
            var result = danhMucHinhThucDaoTaoService.Update(1, EducateUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Educate_Update_Failure2()
        {
            DanhMucHinhThucDaoTaoUpdateRequest EducateUpdating = new DanhMucHinhThucDaoTaoUpdateRequest()
            {


                tenHinhThuc = "Tại Chức"

            };
            var result = danhMucHinhThucDaoTaoService.Update(6, EducateUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Educate_Delete_Success()
        {

            var result = danhMucHinhThucDaoTaoService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Educate_Delete_Failure()
        {

            var result = danhMucHinhThucDaoTaoService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
