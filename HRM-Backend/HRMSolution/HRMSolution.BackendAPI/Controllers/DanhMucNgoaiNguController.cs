using HRMSolution.Application.Catalog.DanhMucNgoaiNgus;
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
    public class DanhMucNgoaiNguController : ControllerBase
    {
        private readonly IDanhMucNgoaiNguService _danhMucNgoaiNguService;
        public DanhMucNgoaiNguController(IDanhMucNgoaiNguService danhMucNgoaiNguService)
        {
            _danhMucNgoaiNguService = danhMucNgoaiNguService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucNgoaiNgu = await _danhMucNgoaiNguService.GetAll();
            return Ok(danhMucNgoaiNgu);
        }
    }
}
