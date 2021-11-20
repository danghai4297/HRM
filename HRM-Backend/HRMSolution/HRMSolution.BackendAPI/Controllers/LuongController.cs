using HRMSolution.Application.Catalog.Luongs;
using HRMSolution.Application.Catalog.Luongs.Dtos;
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
    public class LuongController : ControllerBase
    {
        private readonly ILuongService _luongService;
        public LuongController(ILuongService luongService)
        {
            _luongService = luongService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllSalary()
        {
            var luong = await _luongService.GetAll();
            return Ok(luong);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var luong = await _luongService.GetById(id);
            return Ok(luong);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSalary([FromForm] LuongCreateRequest request)
        {
            var result = await _luongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var result = await _luongService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, [FromForm] LuongUpdateRequest request)
        {
            var result = await _luongService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
