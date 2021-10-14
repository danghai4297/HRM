﻿using HRMSolution.Application.Catalog.DanhMucTos;
using HRMSolution.Application.Catalog.DanhMucTos.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class DanhMucToController : ControllerBase
        {
            private readonly IDanhMucToService _danhMucToService;
            public DanhMucToController(IDanhMucToService danhMucToService)
            {
                _danhMucToService = danhMucToService;
            }
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var danhMucTo = await _danhMucToService.GetAll();
                return Ok(danhMucTo);
            }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var danhMucTo = await _danhMucToService.GetDetail(id);
            return Ok(danhMucTo);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DanhMucToCreateRequest request)
        {
             var result = await _danhMucToService.Create(request);
             if (result == 0)
                 return BadRequest();
             return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucToService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DanhMucToUpdateRequest request)
        {
            var result = await _danhMucToService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
