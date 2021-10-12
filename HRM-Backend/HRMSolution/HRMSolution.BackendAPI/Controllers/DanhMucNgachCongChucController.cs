using HRMSolution.Application.Catalog.DanhMucNgachCongChucs;
using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
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
    public class DanhMucNgachCongChucController : ControllerBase
    {
        private readonly IDanhMucNgachCongChucService _danhMucNgachCongChucService;
        public DanhMucNgachCongChucController(IDanhMucNgachCongChucService danhMucNgachCongChucService)
        {
            _danhMucNgachCongChucService = danhMucNgachCongChucService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucNCC = await _danhMucNgachCongChucService.GetAll();
            return Ok(danhMucNCC);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucNgachCongChucCreateRequest request)
        {
            var result = await _danhMucNgachCongChucService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucNgachCongChucService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucNgachCongChucUpdateRequest request)
        {
            var result = await _danhMucNgachCongChucService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _danhMucNgachCongChucService.GetById(id);
            if (result == null)
                return BadRequest("Không tìm thấy Danh mục ngạch công chức");
            return Ok(result);
        }
    }
}
