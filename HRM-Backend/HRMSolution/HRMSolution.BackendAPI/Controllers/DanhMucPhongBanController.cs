using HRMSolution.Application.Catalog.DanhMucPhongBans;
using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucPhongBanController : ControllerBase
    {
        private readonly IDanhMucPhongBanService _danhMucPhongBanService;
        public DanhMucPhongBanController(IDanhMucPhongBanService danhMucPhongBanService)
        {
            _danhMucPhongBanService = danhMucPhongBanService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucPhongBan = await _danhMucPhongBanService.GetAll();
            return Ok(danhMucPhongBan);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucPhongBanCreateRequest request)
        {
            var result = await _danhMucPhongBanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucPhongBanService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _danhMucPhongBanService.GetById(id);
            if (result == null)
                return BadRequest("Không tìm thấy Danh mục phòng ban");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DanhMucPhongBanUpdateRequest request)
        {
            var result = await _danhMucPhongBanService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
