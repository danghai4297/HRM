using HRMSolution.Application.Catalog.HopDongs;
using HRMSolution.Application.Catalog.HopDongs.Dtos;
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
    public class HopDongController : ControllerBase
    {
        private readonly IHopDongService _hopDongService;
        public HopDongController(IHopDongService hopDongService)
        {
            _hopDongService = hopDongService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
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
        public async Task<IActionResult> Create([FromBody] HopDongCreateRequest request)
        {
            var result = await _hopDongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{maHopDong}")]
        public async Task<IActionResult> Delete(string maHopDong)
        {
            var result = await _hopDongService.Delete(maHopDong);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{maHopDong}")]
        public async Task<IActionResult> Update(string maHopDong, HopDongUpdateRequest request)
        {
            var result = await _hopDongService.Update(maHopDong, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
