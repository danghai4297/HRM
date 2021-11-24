using HRMSolution.Application.Catalog.NhanViens;
using HRMSolution.Application.Catalog.NhanViens.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllEmployee()
        {
            var nhanViens = await _nhanVienService.GetAll();
            return Ok(nhanViens);
        }
        [HttpGet("ma-ten")]
        public async Task<IActionResult> GetAllEmployeeByIdAndName()
        {
            var nhanViens = await _nhanVienService.GetAllMaVaTen();
            return Ok(nhanViens);
        }
        [HttpGet("nghiviec")]
        public async Task<IActionResult> GetEmployeeResignation()
        {
            var nhanViens = await _nhanVienService.GetAllNVNghi();
            return Ok(nhanViens);
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> GetEmployeeById(string maNhanVien)
        {
            var nhanViens = await _nhanVienService.GetByMaNV(maNhanVien);
            if (nhanViens == null)
                return BadRequest();
            return Ok(nhanViens);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] NhanVienCreateRequest request)
        {
            var result = await _nhanVienService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{maNhanVien}")]
        public async Task<IActionResult> UpdateEmployee(string maNhanVien, [FromBody] NhanVienUpdateRequest request)
        {
            var result = await _nhanVienService.Update(maNhanVien, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("image/{maNhanVien}")]
        public async Task<IActionResult> UpdateEmployeeImage(string maNhanVien, [FromForm] NhanVienUpdateImageRequest request)
        {
            var result = await _nhanVienService.UpdateImage(maNhanVien, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("image/{maNhanVien}")]
        public async Task<IActionResult> DeleteEmployeeImage(string maNhanVien)
        {
            var result = await _nhanVienService.DeleteImage(maNhanVien);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
