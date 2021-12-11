using HRMSolution.Application.Catalog.DanhMucNgachCongChucs;
using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
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
    public class CSRCategoryController : ControllerBase
    {
        private readonly ICSRCategoryService _danhMucNgachCongChucService;
        public CSRCategoryController(ICSRCategoryService danhMucNgachCongChucService)
        {
            _danhMucNgachCongChucService = danhMucNgachCongChucService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucNCC = await _danhMucNgachCongChucService.GetAll();
            return Ok(danhMucNCC);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucNgachCongChucCreateRequest request)
        {
            var result = await _danhMucNgachCongChucService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucNgachCongChucService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucNgachCongChucUpdateRequest request)
        {
            var result = await _danhMucNgachCongChucService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _danhMucNgachCongChucService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
