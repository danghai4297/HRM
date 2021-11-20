using HRMSolution.Application.Catalog.NgoaiNgus;
using HRMSolution.Application.Catalog.NgoaiNgus.Dtos;
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
    public class NgoaiNguController : ControllerBase
    {
        private readonly INgoaiNguService _ngoaiNguService;
        public NgoaiNguController(INgoaiNguService ngoaiNguService)
        {
            _ngoaiNguService = ngoaiNguService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            var ngoaiNgu = await _ngoaiNguService.GetById(id);
            return Ok(ngoaiNgu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLanguage([FromBody] NgoaiNguCreateRequest request)
        {
            var result = await _ngoaiNguService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var result = await _ngoaiNguService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, NgoaiNguUpdateRequest request)
        {
            var result = await _ngoaiNguService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
