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
        public async Task<IActionResult> GetAll()
        {
            var luong = await _luongService.GetAll();
            return Ok(luong);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var luong = await _luongService.GetById(id);
            return Ok(luong);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LuongCreateRequest request)
        {
            var result = await _luongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _luongService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("bangChung/{id}")]
        public async Task<IActionResult> DeleteBangChung(int id)
        {
            var result = await _luongService.DeleteBangChung(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LuongUpdateRequest request)
        {
            var result = await _luongService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("bangChung/{id}")]
        public async Task<IActionResult> UpdateBangChung(int id, [FromForm] LuongUpdateBangChungRequest request)
        {
            var result = await _luongService.UpdateBangChung(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
