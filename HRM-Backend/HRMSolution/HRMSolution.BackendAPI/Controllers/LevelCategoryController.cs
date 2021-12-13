using HRMSolution.Application.Catalog.DanhMucTrinhDos;
using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
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
    public class LevelCategoryController : ControllerBase
    {
        private readonly ILevelCategoryService _levelCategoryService;
        public LevelCategoryController(ILevelCategoryService levelCategoryService)
        {
            _levelCategoryService = levelCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var danhMucTrinhDo = await _levelCategoryService.GetAll();
            return Ok(danhMucTrinhDo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucTrinhDoCreateRequest request)
        {
            var result = await _levelCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _levelCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _levelCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucTrinhDoUpdateRequest request)
        {
            var result = await _levelCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }

}
