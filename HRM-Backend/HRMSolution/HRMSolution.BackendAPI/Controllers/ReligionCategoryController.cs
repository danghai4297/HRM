using HRMSolution.Application.Catalog.DanhMucTonGiaos;
using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
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
    public class ReligionCategoryController : ControllerBase
    {
        private readonly IReligionCategoryService _religionCategoryService;
        public ReligionCategoryController(IReligionCategoryService religionCategoryService)
        {
            _religionCategoryService = religionCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucTonGiao = await _religionCategoryService.GetAll();
            return Ok(danhMucTonGiao);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucTonGiaoCreateRequest request)
        {
            var result = await _religionCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _religionCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _religionCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucTonGiaoUpdateRequest request)
        {
            var result = await _religionCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
