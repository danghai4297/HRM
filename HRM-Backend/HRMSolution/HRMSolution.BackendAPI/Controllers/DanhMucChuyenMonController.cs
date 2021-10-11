using HRMSolution.Application.Catalog.DanhMucChuyenMons;
using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucChuyenMonController:ControllerBase
    {
        private readonly IDanhMucChuyenMonService _danhMucChuyenMonService;
        public DanhMucChuyenMonController(IDanhMucChuyenMonService danhMucChuyenMonService)
        {
            _danhMucChuyenMonService = danhMucChuyenMonService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucChuyenMon = await _danhMucChuyenMonService.GetAll();
            return Ok(danhMucChuyenMon);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucChuyenMonCreateRequest request)
        {
            var result = await _danhMucChuyenMonService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucChuyenMonService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucChuyenMonUpdateRequest request)
        {
            var result = await _danhMucChuyenMonService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
