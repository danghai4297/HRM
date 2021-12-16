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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            var ngoaiNgu = await _languageService.GetById(id);
            if (ngoaiNgu == null)
                return BadRequest();
            return Ok(ngoaiNgu);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLanguage([FromBody] NgoaiNguCreateRequest request)
        {
            var result = await _languageService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var result = await _languageService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, NgoaiNguUpdateRequest request)
        {
            var result = await _languageService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
