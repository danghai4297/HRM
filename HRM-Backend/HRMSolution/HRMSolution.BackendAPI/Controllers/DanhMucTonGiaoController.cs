﻿using HRMSolution.Application.Catalog.DanhMucTonGiaos;
using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucTonGiaoController : ControllerBase
    {
        private readonly IDanhMucTonGiaoService _danhMucTonGiaoService;
        public DanhMucTonGiaoController(IDanhMucTonGiaoService danhMucTonGiaoService)
        {
            _danhMucTonGiaoService = danhMucTonGiaoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucTonGiao = await _danhMucTonGiaoService.GetAll();
            return Ok(danhMucTonGiao);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucTonGiaoCreateRequest request)
        {
            var result = await _danhMucTonGiaoService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucTonGiaoService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _danhMucTonGiaoService.GetById(id);
            if (result == null)
                return BadRequest("Không tìm thấy Danh mục tôn giáo");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DanhMucTonGiaoUpdateRequest request)
        {
            var result = await _danhMucTonGiaoService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
