using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos;
using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos.Dtos;
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
    public class EducateCategoryController : ControllerBase
    {
        private readonly IEducateCategoryService _educateCategoryService;
        public EducateCategoryController(IEducateCategoryService educateCategoryService)
        {
            _educateCategoryService = educateCategoryService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucHinhThucDaoTao = await _educateCategoryService.GetAll();
            return Ok(danhMucHinhThucDaoTao);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucHinhThucDaoTaoCreateRequest request)
        {
            var dmhtdt = await _educateCategoryService.Create(request);
            if (dmhtdt == 0)
                return BadRequest();
            return Ok();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _educateCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _educateCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucHinhThucDaoTaoUpdateRequest request)
        {
            var result = await _educateCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
