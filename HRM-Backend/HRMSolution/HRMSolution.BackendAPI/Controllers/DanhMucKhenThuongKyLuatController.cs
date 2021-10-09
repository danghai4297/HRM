using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats;
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
    public class DanhMucKhenThuongKyLuatController : ControllerBase
    {
        private readonly IDanhMucKhenThuongKyLuatService _danhMucKhenThuongKyLuatService;
        public DanhMucKhenThuongKyLuatController(IDanhMucKhenThuongKyLuatService danhMucKhenThuongKyLuatService)
        {
            _danhMucKhenThuongKyLuatService = danhMucKhenThuongKyLuatService;
        }
        [HttpGet("khen-thuong")]
        public async Task<IActionResult> GetKhenThuong()
        {
            var danhMucKTKL = await _danhMucKhenThuongKyLuatService.GetAllKhenThuong();
            return Ok(danhMucKTKL);
        }
        [HttpGet("ky-luat")]
        public async Task<IActionResult> GetKyLuat()
        {
            var danhMucKTKL = await _danhMucKhenThuongKyLuatService.GetAllKyLuat();
            return Ok(danhMucKTKL);
        }
    }
}
