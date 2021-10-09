using HRMSolution.Application.Catalog.DanhMucTonGiaos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucTonGiaoController : ControllerBase
    {
        private readonly IDanhMucTonGiaoService _danhMucTonGiaoService;
        public DanhMucTonGiaoController(IDanhMucTonGiaoService danhMucTonGiaoService)
        {
            _danhMucTonGiaoService = danhMucTonGiaoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucTonGiao = await _danhMucTonGiaoService.GetAll();
            return Ok(danhMucTonGiao);
        }

    }
}
