﻿using HRMSolution.Application.Catalog.NguoiThans;
using HRMSolution.Application.Catalog.NguoiThans.Dtos;
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
    public class NguoiThanController : ControllerBase
    {
        private readonly INguoiThanService _nguoiThanService;
        public NguoiThanController(INguoiThanService nguoiThanService)
        {
            _nguoiThanService = nguoiThanService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamilyById(int id)
        {
            var nguoiThan = await _nguoiThanService.GetById(id);
            if (nguoiThan == null)
                return BadRequest();
            return Ok(nguoiThan);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFamily([FromBody] NguoiThanCreateRequest request)
        {
            var result = await _nguoiThanService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            var result = await _nguoiThanService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFamily(int id, NguoiThanUpdateRequest request)
        {
            var result = await _nguoiThanService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
