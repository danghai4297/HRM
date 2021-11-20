using HRMSolution.Application.Catalog.LichSus;
using HRMSolution.Application.Catalog.LichSus.Dtos;
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
    [Authorize]
    public class LichSuController : ControllerBase
    {
        private readonly ILichSuService _lichSuService;
        public LichSuController(ILichSuService lichSuService)
        {
            _lichSuService = lichSuService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllHistory()
        {
            var lichSu = await _lichSuService.GetAll();
            return Ok(lichSu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHistory([FromBody] LichSuCreateRequest request)
        {
            var result = await _lichSuService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
