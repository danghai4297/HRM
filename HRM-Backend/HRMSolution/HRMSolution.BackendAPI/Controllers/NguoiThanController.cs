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
        public async Task<IActionResult> Create([FromForm] NguoiThanCreateRequest request)
        {
            var result = await _nguoiThanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
