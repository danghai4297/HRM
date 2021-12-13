using HRMSolution.Application.Catalog.DanhMucPhongBans;
using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
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
    public class DepartmentCategoryController : ControllerBase
    {
        private readonly IDepartmentCategoryService _departmentCategoryService;
        public DepartmentCategoryController(IDepartmentCategoryService departmentCategoryService)
        {
            _departmentCategoryService = departmentCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucPhongBan = await _departmentCategoryService.GetAll();
            return Ok(danhMucPhongBan);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucPhongBanCreateRequest request)
        {
            var result = await _departmentCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _departmentCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _departmentCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucPhongBanUpdateRequest request)
        {
            var result = await _departmentCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
