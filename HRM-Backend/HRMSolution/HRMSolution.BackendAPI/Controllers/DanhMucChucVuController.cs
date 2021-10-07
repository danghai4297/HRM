using HRMSolution.Application.Catalog.DanhMucChucVus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DanhMucChucVuController:ControllerBase
    {
        private readonly IDanhMucChucVuService _danhMucChucVuService;
        public DanhMucChucVuController(IDanhMucChucVuService danhMucChucVuService)
        {
            _danhMucChucVuService = danhMucChucVuService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucChucVu = await _danhMucChucVuService.GetAll();
            return Ok(danhMucChucVu);
        }
    }
}
