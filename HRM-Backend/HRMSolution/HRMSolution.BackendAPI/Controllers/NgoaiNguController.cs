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
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var ngoaiNgu = await _ngoaiNguService.GetAll();
            return Ok(ngoaiNgu);
        }
    }
}
