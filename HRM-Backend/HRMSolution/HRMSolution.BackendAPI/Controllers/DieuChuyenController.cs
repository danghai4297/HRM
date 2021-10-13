using HRMSolution.Application.Catalog.DieuChuyens;
using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
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
    public class DieuChuyenController : ControllerBase
    {
        private readonly IDieuChuyenService _dieuChuyenService;
        public DieuChuyenController(IDieuChuyenService dieuChuyenService)
        {
            _dieuChuyenService = dieuChuyenService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var danhMucChucDanh = await _dieuChuyenService.GetAll();
            return Ok(danhMucChucDanh);
        }

        [HttpGet("dieu-chuyen/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var danhMucChucDanh = await _dieuChuyenService.GetDetail(id);
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DieuChuyenCreateRequest request)
        {
            var result = await _dieuChuyenService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
