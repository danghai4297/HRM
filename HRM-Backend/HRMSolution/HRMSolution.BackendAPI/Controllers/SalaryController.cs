using HRMSolution.Application.Catalog.Luongs;
using HRMSolution.Application.Catalog.Luongs.Dtos;
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
    //[Authorize]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllSalary()
        {
            var luong = await _salaryService.GetAll();
            return Ok(luong);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var luong = await _salaryService.GetById(id);
            if (luong == null)
                return BadRequest();
            return Ok(luong);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSalary([FromForm] LuongCreateRequest request)
        {
            var result = await _salaryService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var result = await _salaryService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, [FromForm] LuongUpdateRequest request)
        {
            var result = await _salaryService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
