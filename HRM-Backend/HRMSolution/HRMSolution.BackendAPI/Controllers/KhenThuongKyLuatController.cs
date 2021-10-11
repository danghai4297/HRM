using HRMSolution.Application.Catalog.KhenThuongKyLuats;
using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
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
    public class KhenThuongKyLuatController : ControllerBase
    {
        private readonly IKhenThuongKyLuatService _khenThuongKyLuatService;
        public KhenThuongKyLuatController(IKhenThuongKyLuatService khenThuongKyLuatService)
        {
            _khenThuongKyLuatService = khenThuongKyLuatService;
        }

        [HttpGet("khen-thuong")]
        public async Task<IActionResult> GetKhenThuong()
        {
            var khenThuongKyLuats = await _khenThuongKyLuatService.GetAllKhenThuong();
            return Ok(khenThuongKyLuats);
        }

        [HttpGet("khen-thuong/{maNhanVien}/{id}")]
        public async Task<IActionResult> GetKhenThuongDetail(string maNhanVien, int id)
        {
            var khenThuongKyLuats = await _khenThuongKyLuatService.GetAllKhenThuongDetail(maNhanVien, id);
            return Ok(khenThuongKyLuats);
        }

        [HttpGet("ky-luat")]
        public async Task<IActionResult> GetKyLuat()
        {
            var khenThuongKyLuats = await _khenThuongKyLuatService.GetAllKyLuat();
            return Ok(khenThuongKyLuats);
        }

        [HttpGet("ky-luat/{maNhanVien}/{id}")]
        public async Task<IActionResult> GetKyLuatDetail(string maNhanVien, int id)
        {
            var khenThuongKyLuats = await _khenThuongKyLuatService.GetAllKyLuatDetail(maNhanVien, id);
            return Ok(khenThuongKyLuats);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] KhenThuongKyLuatCreateRequest request)
        {
            var result = await _khenThuongKyLuatService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
