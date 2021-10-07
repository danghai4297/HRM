using HRMSolution.Application.Catalog.DanhMucHonNhans;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucHonNhanController : ControllerBase
    {
        private readonly IDanhMucHonNhanService _danhMucHonNhanService;
        public DanhMucHonNhanController(IDanhMucHonNhanService danhMucHonNhanService)
        {
            _danhMucHonNhanService = danhMucHonNhanService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucHonNhan = await _danhMucHonNhanService.GetALL();
            return Ok(danhMucHonNhan);
        }
    }
}
