using HRMSolution.Application.Catalog.DanhMucNguoiThans;
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
    public class DanhMucNguoiThanController : ControllerBase
    {
        private readonly IDanhMucNguoiThanService _danhMucNguoiThanService;
        public DanhMucNguoiThanController(IDanhMucNguoiThanService danhMucNguoiThanService)
        {
            _danhMucNguoiThanService = danhMucNguoiThanService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucNguoiThan = await _danhMucNguoiThanService.GetAll();
            return Ok(danhMucNguoiThan);
        }
    }
}
