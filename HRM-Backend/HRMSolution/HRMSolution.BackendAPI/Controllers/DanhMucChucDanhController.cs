﻿using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DanhMucChucDanhController: ControllerBase
    {
        private readonly IDanhMucChucDanhService _danhMucChucDanhService;
        public DanhMucChucDanhController(IDanhMucChucDanhService danhMucChucDanhService)
        {
            _danhMucChucDanhService = danhMucChucDanhService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucChucDanh = await _danhMucChucDanhService.GetAll();
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]DanhMucChucDanhCreateRequest request)
        {
            var result = await _danhMucChucDanhService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucChucDanhService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucChucDanhUpdateRequest request)
        {
            var result = await _danhMucChucDanhService.Update(id,request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var danhMucChucDanh = await _danhMucChucDanhService.GetById(id);
            if (danhMucChucDanh == null)
                return BadRequest("Không tìm thấy Danh mục chức danh");
            return Ok(danhMucChucDanh);
        }
    }
}
