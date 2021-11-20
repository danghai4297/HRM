using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using HRMSolution.BackendAPI.Controllers;
using HRMSolution.Data.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace HRMSolution.UnitTest
{
    public class UnitTest1
    {
        private readonly HRMDbContext _context;
        private readonly DanhMucChucDanhController _controller;
        private readonly IDanhMucChucDanhService _danhMucChucDanhService;
        public UnitTest1()
        {
            _danhMucChucDanhService = new DanhMucChucDanhService(_context);
            _controller = new DanhMucChucDanhController(_danhMucChucDanhService);
        }
        //[Fact]
        //public void Get()
        //{
        //    // Act
        //    var okResult = _controller.Get();
        //    // Assert
        //    Assert.IsType<OkObjectResult>(okResult);
        //}
        //[Fact]
        //public async void Get_WhenCalled_ReturnsAllItems()
        //{
        //    // Act
        //    var result = await _controller.Get();
        //    var okResult = result as OkObjectResult;
            
        //    // Assert
        //    var items = Assert.IsType<List<DanhMucChucDanhViewModel>>(okResult.Value);
        //    Assert.Equal(3, items.Count);
        //}
    }
}
