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
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllHistory()
        {
            var lichSu = await _historyService.GetAll();
            return Ok(lichSu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHistory([FromBody] LichSuCreateRequest request)
        {
            var result = await _historyService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
