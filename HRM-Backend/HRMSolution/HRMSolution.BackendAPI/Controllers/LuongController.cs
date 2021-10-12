using HRMSolution.Application.Catalog.Luongs;
using HRMSolution.Application.Catalog.Luongs.Dtos;
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
    public class LuongController : ControllerBase
    {
        private readonly ILuongService _luongService;
        public LuongController(ILuongService luongService)
        {
            _luongService = luongService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var luong = await _luongService.GetAll();
            return Ok(luong);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLuong(int id)
        {
            var luong = await _luongService.GetLuong(id);
            return Ok(luong);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LuongCreateRequest request)
        {
            var result = await _luongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
