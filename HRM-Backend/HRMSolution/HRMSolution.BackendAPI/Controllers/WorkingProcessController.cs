using HRMSolution.Application.Catalog.DieuChuyens;
using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
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
    public class WorkingProcessController : ControllerBase
    {
        private readonly IWorkingProcessService _workingProcessService;
        public WorkingProcessController(IWorkingProcessService workingProcessService)
        {
            _workingProcessService = workingProcessService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllWorkingProcess()
        {
            var danhMucChucDanh = await _workingProcessService.GetAll();
            return Ok(danhMucChucDanh);
        }

        [HttpGet("qua-trinh-cong-tac/{id}")]
        public async Task<IActionResult> GetWorkingProcessById(int id)
        {
            var danhMucChucDanh = await _workingProcessService.GetById(id);
            if (danhMucChucDanh == null)
                return BadRequest();
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorkingProcess([FromForm] QuaTrinhCongTacCreateRequest request)
        {
            var result = await _workingProcessService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkingProcess(int id)
        {
            var result = await _workingProcessService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkingProcess(int id, [FromForm] QuaTrinhCongTacUpdateRequest request)
        {
            var result = await _workingProcessService.Update(id, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
