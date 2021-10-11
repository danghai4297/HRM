using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs;
using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos;
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
    public class DanhMucLoaiHopDongController : ControllerBase
    {
        private readonly IDanhMucLoaiHopDongService _danhMucLoaiHopDongService;
        public DanhMucLoaiHopDongController(IDanhMucLoaiHopDongService danhMucLoaiHopDongService)
        {
            _danhMucLoaiHopDongService = danhMucLoaiHopDongService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucLHD = await _danhMucLoaiHopDongService.GetAll();
            return Ok(danhMucLHD);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucLoaiHopDongCreateRequest request)
        {
            var result = await _danhMucLoaiHopDongService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucLoaiHopDongService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucLoaiHopDongUpdateRequest request)
        {
            var result = await _danhMucLoaiHopDongService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
