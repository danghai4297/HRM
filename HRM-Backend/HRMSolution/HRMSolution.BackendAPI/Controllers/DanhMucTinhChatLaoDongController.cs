using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs;
using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucTinhChatLaoDongController : ControllerBase
    {
        private readonly IDanhMucTinhChatLaoDongService _danhMucTinhChatLaoDongService;
        public DanhMucTinhChatLaoDongController(IDanhMucTinhChatLaoDongService danhMucTinhChatLaoDongService)
        {
            _danhMucTinhChatLaoDongService = danhMucTinhChatLaoDongService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucTinhChatLaoDong = await _danhMucTinhChatLaoDongService.GetAll();
            return Ok(danhMucTinhChatLaoDong);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucTinhChatLaoDongCreateRequest request)
        {
            var result = await _danhMucTinhChatLaoDongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
