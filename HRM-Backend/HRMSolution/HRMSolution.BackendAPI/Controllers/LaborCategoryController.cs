using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs;
using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
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
    public class LaborCategoryController : ControllerBase
    {
        private readonly ILaborCategoryService _laborCategoryService;
        public LaborCategoryController(ILaborCategoryService laborCategoryService)
        {
            _laborCategoryService = laborCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucTinhChatLaoDong = await _laborCategoryService.GetAll();
            return Ok(danhMucTinhChatLaoDong);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucTinhChatLaoDongCreateRequest request)
        {
            var result = await _laborCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _laborCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucTinhChatLaoDongUpdateRequest request)
        {
            var result = await _laborCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var result = await _laborCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
