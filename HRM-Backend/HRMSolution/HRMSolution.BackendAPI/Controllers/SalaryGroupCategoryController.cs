using HRMSolution.Application.Catalog.DanhMucNhomLuongs;
using HRMSolution.Application.Catalog.DanhMucNhomLuongs.DnhomLuongs;
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
    public class SalaryGroupCategoryController : ControllerBase
    {
        private readonly ISalaryGroupCategoryService _salaryGroupCategoryService;
        public SalaryGroupCategoryController(ISalaryGroupCategoryService salaryGroupCategoryService)
        {
            _salaryGroupCategoryService = salaryGroupCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucNhomLuong = await _salaryGroupCategoryService.GetAll();
            return Ok(danhMucNhomLuong);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucNhomLuongCreateRequest request)
        {
            var result = await _salaryGroupCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _salaryGroupCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _salaryGroupCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucNhomLuongUpdateRequest request)
        {
            var result = await _salaryGroupCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
