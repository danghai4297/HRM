using HRMSolution.Application.Catalog.NhanViens;
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
    public class NhanVienDetailController : ControllerBase
    {

            private readonly INhanVienService _nhanVienService;
            public NhanVienDetailController(INhanVienService nhanVienService)
            {
                _nhanVienService = nhanVienService;
            }
            [HttpGet("{maNhanVien}")]
            public async Task<IActionResult> Get(string maNhanVien)
            {
                var nhanViens = await _nhanVienService.GetAllDetail(maNhanVien);
                return Ok(nhanViens);
            }
    }
}
