using HRMSolution.Application.Catalog.DanhMucChuyenMons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucChuyenMonController:ControllerBase
    {
        private readonly IDanhMucChuyenMonService _danhMucChuyenMonService;
        public DanhMucChuyenMonController(IDanhMucChuyenMonService danhMucChuyenMonService)
        {
            _danhMucChuyenMonService = danhMucChuyenMonService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucChuyenMon = await _danhMucChuyenMonService.GetAll();
            return Ok(danhMucChuyenMon);
        }
    }
}
