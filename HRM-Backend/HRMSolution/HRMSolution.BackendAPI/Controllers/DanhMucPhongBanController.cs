using HRMSolution.Application.Catalog.DanhMucPhongBans;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucPhongBanController : ControllerBase
    {
        private readonly IDanhMucPhongBanService _danhMucPhongBanService;
        public DanhMucPhongBanController(IDanhMucPhongBanService danhMucPhongBanService)
        {
            _danhMucPhongBanService = danhMucPhongBanService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucPhongBan = await _danhMucPhongBanService.GetAll();
            return Ok(danhMucPhongBan);
        }

    }
}
