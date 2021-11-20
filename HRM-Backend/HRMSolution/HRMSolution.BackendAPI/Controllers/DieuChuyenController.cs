using HRMSolution.Application.Catalog.DieuChuyens;
using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
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
    public class DieuChuyenController : ControllerBase
    {
        private readonly IDieuChuyenService _dieuChuyenService;
        public DieuChuyenController(IDieuChuyenService dieuChuyenService)
        {
            _dieuChuyenService = dieuChuyenService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllTransfer()
        {
            var danhMucChucDanh = await _dieuChuyenService.GetAll();
            return Ok(danhMucChucDanh);
        }

        [HttpGet("dieu-chuyen/{id}")]
        public async Task<IActionResult> GetTransferById(int id)
        {
            var danhMucChucDanh = await _dieuChuyenService.GetById(id);
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransfer([FromForm] DieuChuyenCreateRequest request)
        {
            var result = await _dieuChuyenService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            var result = await _dieuChuyenService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransfer(int id, [FromForm] DieuChuyenUpdateRequest request)
        {
            var result = await _dieuChuyenService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
