using HRMSolution.Application.Catalog.Anhs;
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
    public class AnhController : ControllerBase
    {
        private readonly IAnhService _anhService;
        public AnhController(IAnhService anhService)
        {
            _anhService = anhService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AnhRequest request)
        {
            var result = await _anhService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, [FromForm] AnhRequest request)
        {
            var result = await _anhService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
