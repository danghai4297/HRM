using HRMSolution.Application.Catalog.Luongs;
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
    }
}
