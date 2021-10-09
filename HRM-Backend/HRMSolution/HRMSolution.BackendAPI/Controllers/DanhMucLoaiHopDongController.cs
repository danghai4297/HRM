using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs;
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
    public class DanhMucLoaiHopDongController : ControllerBase
    {
        private readonly IDanhMucLoaiHopDongService _danhMucLoaiHopDongService;
        public DanhMucLoaiHopDongController(IDanhMucLoaiHopDongService danhMucLoaiHopDongService)
        {
            _danhMucLoaiHopDongService = danhMucLoaiHopDongService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucLHD = await _danhMucLoaiHopDongService.GetAll();
            return Ok(danhMucLHD);
        }
    }
}
