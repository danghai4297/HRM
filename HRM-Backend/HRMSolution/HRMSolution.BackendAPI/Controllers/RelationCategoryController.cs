﻿using HRMSolution.Application.Catalog.DanhMucNguoiThans;
using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class RelationCategoryController : ControllerBase
    {
        private readonly IRelationCategoryService _relationCategoryService;
        public RelationCategoryController(IRelationCategoryService relationCategoryService)
        {
            _relationCategoryService = relationCategoryService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucNguoiThan = await _relationCategoryService.GetAll();
            return Ok(danhMucNguoiThan);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucNguoiThanCreateRequest request)
        {
            var result = await _relationCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _relationCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucNguoiThanUpdateRequest request)
        {
            var result = await _relationCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _relationCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
