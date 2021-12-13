using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
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
    public class TitleCategoryController : ControllerBase
    {
        private readonly ITitleCategoryService _titleCategoryService;
        public TitleCategoryController(ITitleCategoryService titleCategoryService)
        {
            _titleCategoryService = titleCategoryService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucChucDanh = await _titleCategoryService.GetAll();
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucChucDanhCreateRequest request)
        {
            var result = await _titleCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _titleCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucChucDanhUpdateRequest request)
        {
            var result = await _titleCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var danhMucChucDanh = await _titleCategoryService.GetById(id);
            if (danhMucChucDanh == null)
                return BadRequest();
            return Ok(danhMucChucDanh);
        }
    }
}
