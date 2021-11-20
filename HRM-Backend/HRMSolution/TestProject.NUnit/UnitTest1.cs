using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.BackendAPI.Controllers;
using HRMSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestProject.NUnit
{
    public class Tests
    {
        //private HRMDbContext _context;
        private DanhMucChucDanhService danhMucChucDanhService;
        [SetUp]
        public void Setup()
        {
            var optionBuilder = new DbContextOptionsBuilder<HRMDbContext>();
            HRMDbContext _context = new HRMDbContext(optionBuilder.Options);
             danhMucChucDanhService = new DanhMucChucDanhService(_context);
        }

        [Test]
        public void Test1()
        {
            var result = danhMucChucDanhService.GetAll();
            Assert.AreEqual(3, result.Result.Count);
        }
    }
}