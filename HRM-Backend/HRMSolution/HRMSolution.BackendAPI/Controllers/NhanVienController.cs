using HRMSolution.Application.Catalog.NhanViens;
using HRMSolution.Application.Catalog.NhanViens.Dtos;
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
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var nhanViens = await _nhanVienService.GetAll();
            return Ok(nhanViens);
        }
        [HttpGet("nghiviec")]
        public async Task<IActionResult> GetNVNghi()
        {
            var nhanViens = await _nhanVienService.GetAllNVNghi();
            return Ok(nhanViens);
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> GetByMaNV(string maNhanVien)
        {
            var nhanViens = await _nhanVienService.GetByMaNV(maNhanVien);
            return Ok(nhanViens);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NhanVienCreateRequest request)
        {
            var result = await _nhanVienService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{maNhanVien}")]
        public async Task<IActionResult> Update(string maNhanVien, NhanVienUpdateRequest request)
        {
            var result = await _nhanVienService.Update(maNhanVien, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
