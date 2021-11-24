﻿using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs;
using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos;
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
    public class DanhMucLoaiHopDongController : ControllerBase
    {
        private readonly IDanhMucLoaiHopDongService _danhMucLoaiHopDongService;
        public DanhMucLoaiHopDongController(IDanhMucLoaiHopDongService danhMucLoaiHopDongService)
        {
            _danhMucLoaiHopDongService = danhMucLoaiHopDongService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucLHD = await _danhMucLoaiHopDongService.GetAll();
            return Ok(danhMucLHD);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucLoaiHopDongCreateRequest request)
        {
            var result = await _danhMucLoaiHopDongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucLoaiHopDongService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _danhMucLoaiHopDongService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucLoaiHopDongUpdateRequest request)
        {
            var result = await _danhMucLoaiHopDongService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
