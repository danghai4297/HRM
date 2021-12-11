using HRMSolution.Application.Catalog.DanhMucNguoiThans;
using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
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
    public class RelationCategoryController : ControllerBase
    {
        private readonly IRelationCategoryService _danhMucNguoiThanService;
        public RelationCategoryController(IRelationCategoryService danhMucNguoiThanService)
        {
            _danhMucNguoiThanService = danhMucNguoiThanService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucNguoiThan = await _danhMucNguoiThanService.GetAll();
            return Ok(danhMucNguoiThan);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucNguoiThanCreateRequest request)
        {
            var result = await _danhMucNguoiThanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucNguoiThanService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucNguoiThanUpdateRequest request)
        {
            var result = await _danhMucNguoiThanService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _danhMucNguoiThanService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
