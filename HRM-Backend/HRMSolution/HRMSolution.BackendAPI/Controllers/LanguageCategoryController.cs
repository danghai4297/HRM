using HRMSolution.Application.Catalog.DanhMucNgoaiNgus;
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
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
    public class LanguageCategoryController : ControllerBase
    {
        private readonly ILanguageCategoryService _languageCategoryService;
        public LanguageCategoryController(ILanguageCategoryService languageCategoryService)
        {
            _languageCategoryService = languageCategoryService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucNgoaiNgu = await _languageCategoryService.GetAll();
            return Ok(danhMucNgoaiNgu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucNgoaiNguCreateRequest request)
        {
            var result = await _languageCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _languageCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucNgoaiNguUpdateRequest request)
        {
            var result = await _languageCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _languageCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
