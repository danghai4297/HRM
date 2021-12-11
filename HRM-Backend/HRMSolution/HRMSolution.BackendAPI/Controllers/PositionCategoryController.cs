using HRMSolution.Application.Catalog.DanhMucChucVus;
using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
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
    public class PositionCategoryController : ControllerBase
    {
        private readonly IPositionCategoryService _danhMucChucVuService;
        public PositionCategoryController(IPositionCategoryService danhMucChucVuService)
        {
            _danhMucChucVuService = danhMucChucVuService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucChucVu = await _danhMucChucVuService.GetAll();
            return Ok(danhMucChucVu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucChucVuCreateRequest request)
        {
            var result = await _danhMucChucVuService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucChucVuService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var danhMucChucVu = await _danhMucChucVuService.GetById(id);
            if (danhMucChucVu == null)
                return BadRequest();
            return Ok(danhMucChucVu);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucChucVuUpdateRequest request)
        {
            var result = await _danhMucChucVuService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
