using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats;
using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
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
    public class RewardDisciplineCategoryController : ControllerBase
    {
        private readonly IRewardDisciplineCategoryService _rewardDisciplineCategoryService;
        public RewardDisciplineCategoryController(IRewardDisciplineCategoryService rewardDisciplineCategoryService)
        {
            _rewardDisciplineCategoryService = rewardDisciplineCategoryService;
        }
        [HttpGet("khen-thuong")]
        public async Task<IActionResult> GetKhenThuongAll()
        {
            var danhMucKTKL = await _rewardDisciplineCategoryService.GetAllKhenThuong();
            return Ok(danhMucKTKL);
        }
        [HttpGet("ky-luat")]
        public async Task<IActionResult> GetKyLuatAll()
        {
            var danhMucKTKL = await _rewardDisciplineCategoryService.GetAllKyLuat();
            return Ok(danhMucKTKL);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _rewardDisciplineCategoryService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] DanhMucKhenThuongKyLuatCreateRequest request)
        {
            var result = await _rewardDisciplineCategoryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _rewardDisciplineCategoryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, DanhMucKhenThuongKyLuatUpdateRequest request)
        {
            var result = await _rewardDisciplineCategoryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
