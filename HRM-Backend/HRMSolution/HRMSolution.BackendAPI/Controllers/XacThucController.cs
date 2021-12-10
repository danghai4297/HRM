using HRMSolution.Application.Catalog.XacThuc;
using HRMSolution.Application.Catalog.XacThuc.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    public class XacThucController : ControllerBase
    {
        private readonly IXacThucService _xacThucService;
        public XacThucController(IXacThucService xacThucService)
        {
            _xacThucService = xacThucService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _xacThucService.Authenticate(request);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }
            return Ok(new { token = result });
        }
    }
}
