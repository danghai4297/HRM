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
        DanhMucChucDanhCreateRequest danhMucChucDanh1;
        DanhMucChucDanhCreateRequest danhMucChucDanh2;
        [OneTimeSetUp]
        public void Setup()
        {
            danhMucChucDanh1 = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = "CD04",
                tenChucDanh = "Bác Học",
                phuCap = (float)100000.0
            };
            danhMucChucDanh2 = new DanhMucChucDanhCreateRequest()
            {
                maChucDanh = null,
                tenChucDanh = null,
                phuCap = (float)100000.0
            };
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
            
            var result = danhMucChucDanhService.Create(danhMucChucDanh1);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(3)]
        public void Cat_Create_2()
        {
            
            var result = danhMucChucDanhService.Create(danhMucChucDanh2);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        //[Test, Order(3)]
        //public void Cat_GetById_2()
        //{
        //    var result = danhMucChucDanhService.GetById(4);
        //    Assert.That(result.Result., Is.EqualTo(4));
        //}
    }
}
