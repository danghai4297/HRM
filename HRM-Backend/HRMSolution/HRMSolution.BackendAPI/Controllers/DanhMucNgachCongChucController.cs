using HRMSolution.Application.Catalog.DanhMucNgachCongChucs;
using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
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
    public class DanhMucNgachCongChucController : ControllerBase
    {
        private readonly IDanhMucNgachCongChucService _danhMucNgachCongChucService;
        public DanhMucNgachCongChucController(IDanhMucNgachCongChucService danhMucNgachCongChucService)
        {
            _danhMucNgachCongChucService = danhMucNgachCongChucService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucNCC = await _danhMucNgachCongChucService.GetAll();
            return Ok(danhMucNCC);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucNgachCongChucCreateRequest request)
        {
            var result = await _danhMucNgachCongChucService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
