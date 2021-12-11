﻿using HRMSolution.Application.Catalog.DanhMucNgoaiNgus;
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
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
    public class LanguageCategoryController : ControllerBase
    {
        private readonly ILanguageCategoryService _danhMucNgoaiNguService;
        public LanguageCategoryController(ILanguageCategoryService danhMucNgoaiNguService)
        {
            _danhMucNgoaiNguService = danhMucNgoaiNguService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucNgoaiNgu = await _danhMucNgoaiNguService.GetAll();
            return Ok(danhMucNgoaiNgu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucNgoaiNguCreateRequest request)
        {
            var result = await _danhMucNgoaiNguService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucNgoaiNguService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucNgoaiNguUpdateRequest request)
        {
            var result = await _danhMucNgoaiNguService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _danhMucNgoaiNguService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
