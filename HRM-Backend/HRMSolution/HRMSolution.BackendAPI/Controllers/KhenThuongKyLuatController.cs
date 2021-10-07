using HRMSolution.Application.Catalog.KhenThuongKyLuats;
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
    public class KhenThuongKyLuatController : ControllerBase
    {
        private readonly IKhenThuongKyLuatService _khenThuongKyLuatService;
        public KhenThuongKyLuatController(IKhenThuongKyLuatService khenThuongKyLuatService)
        {
            _khenThuongKyLuatService = khenThuongKyLuatService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var khenThuongKyLuats = await _khenThuongKyLuatService.GetAll();
            return Ok(khenThuongKyLuats);
        }
    }
}
