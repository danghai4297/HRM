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
        public async Task<IActionResult> GetAllContract()
        {
            var nhanViens = await _hopDongService.GetAll();
            return Ok(nhanViens);
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> GetContractByEmployee(string maNhanVien)
        {
            var hopDong = await _hopDongService.GetAll(maNhanVien);
            if (hopDong == null)
                return BadRequest();
            return Ok(hopDong);
        }

        [HttpGet("detail/{maHopDong}")]
        public async Task<IActionResult> GetContractById(string maHopDong)
        {
            var hopDong = await _hopDongService.GetHopDong(maHopDong);
            if (hopDong == null)
                return BadRequest();
            return Ok(hopDong);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] HopDongCreateRequest request)
        {
            var result = await _hopDongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{maHopDong}")]
        public async Task<IActionResult> DeleteContract(string maHopDong)
        {
            var result = await _hopDongService.Delete(maHopDong);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("bangChung/{maHopDong}")]
        public async Task<IActionResult> DeleteAttachments(string maHopDong)
        {
            var result = await _hopDongService.DeleteBangChung(maHopDong);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{maHopDong}")]
        public async Task<IActionResult> UpdateContract(string maHopDong, HopDongUpdateRequest request)
        {
            var result = await _hopDongService.Update(maHopDong, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("bangChung/{maHopDong}")]
        public async Task<IActionResult> UpdateAttachments(string maHopDong, [FromForm] HopDongUpdateBangChungRequest request)
        {
            var result = await _hopDongService.UpdateBangChung(maHopDong, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
