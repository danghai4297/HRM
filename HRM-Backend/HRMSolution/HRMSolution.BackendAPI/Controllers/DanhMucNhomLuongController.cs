﻿using HRMSolution.Application.Catalog.DanhMucNhomLuongs;
using HRMSolution.Application.Catalog.DanhMucNhomLuongs.DnhomLuongs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucNhomLuongController:ControllerBase
    {
        private readonly IDanhMucNhomLuongService _danhMucNhomLuongService;
        public DanhMucNhomLuongController(IDanhMucNhomLuongService danhMucNhomLuongService)
        {
            _danhMucNhomLuongService = danhMucNhomLuongService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucNhomLuong = await _danhMucNhomLuongService.GetAll();
            return Ok(danhMucNhomLuong);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucNhomLuongCreateRequest request)
        {
            var result = await _danhMucNhomLuongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
