using HRMSolution.Application.Catalog.DanhMucNgachCongChucs;
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
    public class DanhMucNgachCongChucController : ControllerBase
    {
        private readonly IDanhMucNgachCongChucService _danhMucNgachCongChucService;
        public DanhMucNgachCongChucController(IDanhMucNgachCongChucService danhMucNgachCongChucService)
        {
            _danhMucNgachCongChucService = danhMucNgachCongChucService;
        }
        public async Task<IActionResult> Get()
        {
            var danhMucNCC = await _danhMucNgachCongChucService.GetAll();
            return Ok(danhMucNCC);
        }
    }
}
