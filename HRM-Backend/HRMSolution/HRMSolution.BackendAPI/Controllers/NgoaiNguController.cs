using HRMSolution.Application.Catalog.NgoaiNgus;
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
    public class NgoaiNguController : ControllerBase
    {
        private readonly INgoaiNguService _ngoaiNguService;
        public NgoaiNguController(INgoaiNguService ngoaiNguService)
        {
            _ngoaiNguService = ngoaiNguService;
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> Get(string maNhanVien)
        {
            var ngoaiNgu = await _ngoaiNguService.GetAll(maNhanVien);
            return Ok(ngoaiNgu);
        }

        [HttpGet("ngoai-ngu/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var ngoaiNgu = await _ngoaiNguService.GetNgoaiNgu(id);
            return Ok(ngoaiNgu);
        }
    }
}
