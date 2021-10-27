using HRMSolution.Application.Catalog.DanhMucNgoaiNgus;
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
    public class DanhMucNgoaiNguController : ControllerBase
    {
        private readonly IDanhMucNgoaiNguService _danhMucNgoaiNguService;
        public DanhMucNgoaiNguController(IDanhMucNgoaiNguService danhMucNgoaiNguService)
        {
            _danhMucNgoaiNguService = danhMucNgoaiNguService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucNgoaiNgu = await _danhMucNgoaiNguService.GetAll();
            return Ok(danhMucNgoaiNgu);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucNgoaiNguCreateRequest request)
        {
            var result = await _danhMucNgoaiNguService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucNgoaiNguService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DanhMucNgoaiNguUpdateRequest request)
        {
            var result = await _danhMucNgoaiNguService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _danhMucNgoaiNguService.GetById(id);
            if (result == null)
                return BadRequest("Không tìm thấy Danh mục ngoại ngữ");
            return Ok(result);
        }
    }
}
