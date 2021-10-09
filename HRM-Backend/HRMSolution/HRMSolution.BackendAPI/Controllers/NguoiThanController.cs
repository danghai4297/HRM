using HRMSolution.Application.Catalog.NguoiThans;
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
    public class NguoiThanController : ControllerBase
    {
        private readonly INguoiThanService _nguoiThanService;
        public NguoiThanController(INguoiThanService nguoiThanService)
        {
            _nguoiThanService = nguoiThanService;
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> Get(string maNhanVien)
        {
            var danhMucChucDanh = await _nguoiThanService.GetAll(maNhanVien);
            return Ok(danhMucChucDanh);
        }
    }
}
