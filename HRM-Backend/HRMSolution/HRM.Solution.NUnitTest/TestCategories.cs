using Gremlin.Net.Driver.Messages;
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Solution.NUnitTest
{
    public class TestCategories : BaseTest
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
        public void Cat_GetById_1()
        {
            var result = danhMucChucDanhService.GetById(1);
            Assert.That(result.Result, Is.Not.Null);
        }
        [Test, Order(2)]
        public void Cat_Create_1()
        {
            DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = "CD04",
                tenChucDanh = "Bác Học",
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Create(titleCreating);
            Assert.That(result.IsCompletedSuccessfully, Is.EqualTo(true));
        }
        [Test, Order(3)]
        public void Cat_Create_2()
        {
            DanhMucChucDanhCreateRequest titleCreating = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = null,
                tenChucDanh = null,
                phuCap = (float)100000.0
            };
            var result = danhMucChucDanhService.Create(titleCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        //[Test, Order(3)]
        //public void Cat_GetById_2()
        //{
        //    var result = danhMucChucDanhService.GetById(4);
        //    Assert.That(result.Result., Is.EqualTo(4));
        //}
    }
}
