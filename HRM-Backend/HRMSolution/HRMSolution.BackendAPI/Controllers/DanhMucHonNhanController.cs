using HRMSolution.Application.Catalog.DanhMucHonNhans;
using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucHonNhanController : ControllerBase
    {
        private readonly IDanhMucHonNhanService _danhMucHonNhanService;
        public DanhMucHonNhanController(IDanhMucHonNhanService danhMucHonNhanService)
        {
            _danhMucHonNhanService = danhMucHonNhanService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucHonNhan = await _danhMucHonNhanService.GetALL();
            return Ok(danhMucHonNhan);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucHonNhanCreateRequest request)
        {
            var result = await _danhMucHonNhanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucHonNhanService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucHonNhanUpdateRequest request)
        {
            var result = await _danhMucHonNhanService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
