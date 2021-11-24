using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestNationCategory : BaseTest
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
        public void Nation_GetById_Success()
        {
            var result = danhMucDanTocService.GetById(1);
            Assert.That(result.Result.id, Is.EqualTo(1));
        }
        [Test, Order(2)]
        public void Nation_GetById_Failure()
        {
            var result = danhMucDanTocService.GetById(6);
            Assert.That(result.Result, Is.EqualTo(null));
        }

        [Test, Order(3)]
        public void Nation_Create_Success()
        {
            DanhMucDanTocCreateRequest NationCreating = new DanhMucDanTocCreateRequest()
            {

                tenDanhMuc = "Mường"

            };
            var result = danhMucDanTocService.Create(NationCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Nation_Create_Failure1()
        {
            DanhMucDanTocCreateRequest NationCreating = new DanhMucDanTocCreateRequest()
            {

                tenDanhMuc = null

            };
            var result = danhMucDanTocService.Create(NationCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(5)]
        public void Nation_Update_Success()
        {
            DanhMucDanTocUpdateRequest NationUpdating = new DanhMucDanTocUpdateRequest()
            {


                tenDanhMuc = "Mường"

            };
            var result = danhMucDanTocService.Update(1, NationUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(6)]
        public void Nation_Update_Failure1()
        {
            DanhMucDanTocUpdateRequest NationUpdating = new DanhMucDanTocUpdateRequest()
            {


                tenDanhMuc = null

            };
            var result = danhMucDanTocService.Update(1, NationUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }


        [Test, Order(7)]
        public void Nation_Update_Failure2()
        {
            DanhMucDanTocUpdateRequest NationUpdating = new DanhMucDanTocUpdateRequest()
            {


                tenDanhMuc = "Dao"

            };
            var result = danhMucDanTocService.Update(6, NationUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(8)]
        public void Nation_Delete_Success()
        {

            var result = danhMucDanTocService.Delete(1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(9)]
        public void Nation_Delete_Failure()
        {

            var result = danhMucDanTocService.Delete(6);
            Assert.That(result.Result, Is.EqualTo(0));
        }
    }
}
