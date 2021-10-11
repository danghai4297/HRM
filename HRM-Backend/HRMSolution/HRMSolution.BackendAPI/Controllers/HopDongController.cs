using HRMSolution.Application.Catalog.HopDongs;
using HRMSolution.Application.Catalog.HopDongs.Dtos;
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
    public class HopDongController : ControllerBase
    {
        private readonly IHopDongService _hopDongService;
        public HopDongController(IHopDongService nhanVienService)
        {
            _hopDongService = nhanVienService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var nhanViens = await _hopDongService.GetAll();
            return Ok(nhanViens);
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> Get(string maNhanVien)
        {
            var nhanViens = await _hopDongService.GetAll(maNhanVien);
            return Ok(nhanViens);
        }

        [HttpGet("detail/{maHopDong}")]
        public async Task<IActionResult> GetHopDong(string maHopDong)
        {
            var hopDong = await _hopDongService.GetHopDong(maHopDong);
            return Ok(hopDong);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] HopDongCreateRequest request)
        {
            var result = await _hopDongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
