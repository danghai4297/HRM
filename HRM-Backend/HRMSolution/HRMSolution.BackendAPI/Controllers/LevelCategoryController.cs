﻿using HRMSolution.Application.Catalog.DanhMucTrinhDos;
using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
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
    public class LevelCategoryController : ControllerBase
    {
        private readonly ILevelCategoryService _danhMucTrinhDoService;
        public LevelCategoryController(ILevelCategoryService danhMucTrinhDoService)
        {
            _danhMucTrinhDoService = danhMucTrinhDoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var danhMucTrinhDo = await _danhMucTrinhDoService.GetAll();
            return Ok(danhMucTrinhDo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucTrinhDoCreateRequest request)
        {
            var result = await _danhMucTrinhDoService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucTrinhDoService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _danhMucTrinhDoService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucTrinhDoUpdateRequest request)
        {
            var result = await _danhMucTrinhDoService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }

}
