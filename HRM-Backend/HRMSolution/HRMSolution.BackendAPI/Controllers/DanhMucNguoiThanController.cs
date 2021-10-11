using HRMSolution.Application.Catalog.DanhMucNguoiThans;
using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
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
    public class DanhMucNguoiThanController : ControllerBase
    {
        private readonly IDanhMucNguoiThanService _danhMucNguoiThanService;
        public DanhMucNguoiThanController(IDanhMucNguoiThanService danhMucNguoiThanService)
        {
            _danhMucNguoiThanService = danhMucNguoiThanService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucNguoiThan = await _danhMucNguoiThanService.GetAll();
            return Ok(danhMucNguoiThan);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucNguoiThanCreateRequest request)
        {
            var result = await _danhMucNguoiThanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucNguoiThanService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucNguoiThanUpdateRequest request)
        {
            var result = await _danhMucNguoiThanService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
