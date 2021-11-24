using HRMSolution.Application.Catalog.DanhMucChuyenMons;
using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
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
    public class DanhMucChuyenMonController : ControllerBase
    {
        private readonly IDanhMucChuyenMonService _danhMucChuyenMonService;
        public DanhMucChuyenMonController(IDanhMucChuyenMonService danhMucChuyenMonService)
        {
            _danhMucChuyenMonService = danhMucChuyenMonService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucChuyenMon = await _danhMucChuyenMonService.GetAll();
            return Ok(danhMucChuyenMon);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucChuyenMonCreateRequest request)
        {
            var result = await _danhMucChuyenMonService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucChuyenMonService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _danhMucChuyenMonService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucChuyenMonUpdateRequest request)
        {
            var result = await _danhMucChuyenMonService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
