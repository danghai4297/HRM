using HRMSolution.Application.Catalog.TaiKhoan;
using HRMSolution.Application.Catalog.TaiKhoan.Dtos;
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
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanService _taiKhoanService;
        public TaiKhoanController(ITaiKhoanService taiKhoanService)
        {
            _taiKhoanService = taiKhoanService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _taiKhoanService.Create(request);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("change-password{id}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] AccountUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _taiKhoanService.ChangePassword(id, request);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("reset-password/{id}")]
        public async Task<IActionResult> ResetPassword(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _taiKhoanService.ResetPassword(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> SetRole(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _taiKhoanService.RoleAssign(id, request);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var result = await _taiKhoanService.Delete(id);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var user = await _taiKhoanService.GetById(id);
            return Ok(user);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllAccount()
        {
            var user = await _taiKhoanService.GetAll();
            return Ok(user);
        }
    }
}
