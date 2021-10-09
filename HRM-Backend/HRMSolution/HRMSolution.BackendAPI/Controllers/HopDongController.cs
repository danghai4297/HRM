using HRMSolution.Application.Catalog.HopDongs;
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
    public class HopDongController : ControllerBase
    {
        private readonly IHopDongService _hopDongService;
        public HopDongController(IHopDongService nhanVienService)
        {
            _hopDongService = nhanVienService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var nhanViens = await _hopDongService.GetAll();
            return Ok(nhanViens);
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> Get(string maNhanVien)
        {
            var nhanViens = await _hopDongService.GetAll(maNhanVien);
            return Ok(nhanViens);
        }
    }
}
