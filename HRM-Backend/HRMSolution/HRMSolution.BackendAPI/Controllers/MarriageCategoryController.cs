using HRMSolution.Application.Catalog.DanhMucHonNhans;
using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
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
    public class MarriageCategoryController : ControllerBase
    {
        private readonly IMarriageCategoryService _marriageCategoryService;
        public MarriageCategoryController(IMarriageCategoryService marriageCategoryService)
        {
            _marriageCategoryService = marriageCategoryService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucHonNhan = await _marriageCategoryService.GetALL();
            return Ok(danhMucHonNhan);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucHonNhanCreateRequest request)
        {
            var result = await _marriageCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _marriageCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _marriageCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucHonNhanUpdateRequest request)
        {
            var result = await _marriageCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
