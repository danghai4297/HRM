using HRMSolution.Application.Catalog.KhenThuongKyLuats;
using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
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
    public class RewardDisciplineController : ControllerBase
    {
        private readonly IRewardDisciplineService _rewardDisciplineService;
        public RewardDisciplineController(IRewardDisciplineService rewardDisciplineService)
        {
            _rewardDisciplineService = rewardDisciplineService;
        }

        [HttpGet("khen-thuong")]
        public async Task<IActionResult> GetAllReward()
        {
            var khenThuongKyLuats = await _rewardDisciplineService.GetAllKhenThuong();
            return Ok(khenThuongKyLuats);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetRewardDisciplineById(int id)
        {
            var khenThuongKyLuats = await _rewardDisciplineService.GetById(id);
            return Ok(khenThuongKyLuats);
        }

        [HttpGet("ky-luat")]
        public async Task<IActionResult> GetAllDiscipline()
        {
            var khenThuongKyLuats = await _rewardDisciplineService.GetAllKyLuat();
            if (khenThuongKyLuats == null)
                return BadRequest();
            return Ok(khenThuongKyLuats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRewardDiscipline([FromForm] KhenThuongKyLuatCreateRequest request)
        {
            var result = await _rewardDisciplineService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRewardDiscipline(int id)
        {
            var result = await _rewardDisciplineService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRewardDiscipline(int id, [FromForm] KhenThuongKyLuatUpdateRequest request)
        {
            var result = await _rewardDisciplineService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
