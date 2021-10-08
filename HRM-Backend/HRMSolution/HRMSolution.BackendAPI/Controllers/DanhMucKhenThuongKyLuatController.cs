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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucKTKL = await _danhMucKhenThuongKyLuatService.GetAll();
            return Ok(danhMucKTKL);
        }
    }
}
