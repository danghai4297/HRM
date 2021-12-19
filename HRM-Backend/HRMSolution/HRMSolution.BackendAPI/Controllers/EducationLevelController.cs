using HRMSolution.Application.Catalog.TrinhDoVanHoas;
using HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos;
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
    public class EducationLevelController : ControllerBase
    {
        private readonly IEducationLevelService _educationLevelService;
        public EducationLevelController(IEducationLevelService educationLevelService)
        {
            _educationLevelService = educationLevelService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllEducationLevel()
        {
            var trinhDoVanHoa = await _educationLevelService.GetAll();
            return Ok(trinhDoVanHoa);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationLevelById(int id)
        {
            var trinhDoVanHoa = await _educationLevelService.GetById(id);
            if (trinhDoVanHoa == null)
                return BadRequest();
            return Ok(trinhDoVanHoa);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEducationLevel([FromBody] TrinhDoVanHoaCreateRequest request)
        {
            var result = await _educationLevelService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationLevel(int id)
        {
            var result = await _educationLevelService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducationLevel(int id, [FromBody] TrinhDoVanHoaUpdateRequest request)
        {
            var result = await _educationLevelService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
