using HRMSolution.Application.Catalog.NguoiThans;
using HRMSolution.Application.Catalog.NguoiThans.Dtos;
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
    public class NguoiThanController : ControllerBase
    {
        private readonly INguoiThanService _nguoiThanService;
        public NguoiThanController(INguoiThanService nguoiThanService)
        {
            _nguoiThanService = nguoiThanService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var danhMucChucDanh = await _nguoiThanService.GetNguoiThan(id);
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NguoiThanCreateRequest request)
        {
            var result = await _nguoiThanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _nguoiThanService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NguoiThanUpdateRequest request)
        {
            var result = await _nguoiThanService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
