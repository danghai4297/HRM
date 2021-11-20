﻿using HRMSolution.Application.Catalog.TrinhDoVanHoas;
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
    public class TrinhDoVanHoaController : ControllerBase
    {
        private readonly ITrinhDoVanHoaService _trinhDoVanHoaService;
        public TrinhDoVanHoaController(ITrinhDoVanHoaService trinhDoVanHoaService)
        {
            _trinhDoVanHoaService = trinhDoVanHoaService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllEducationLevel()
        {
            var trinhDoVanHoa = await _trinhDoVanHoaService.GetAll();
            return Ok(trinhDoVanHoa);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationLevelById(int id)
        {
            var trinhDoVanHoa = await _trinhDoVanHoaService.GetById(id);
            return Ok(trinhDoVanHoa);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEducationLevel([FromBody] TrinhDoVanHoaCreateRequest request)
        {
            var result = await _trinhDoVanHoaService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationLevel(int id)
        {
            var result = await _trinhDoVanHoaService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducationLevel(int id, TrinhDoVanHoaUpdateRequest request)
        {
            var result = await _trinhDoVanHoaService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
