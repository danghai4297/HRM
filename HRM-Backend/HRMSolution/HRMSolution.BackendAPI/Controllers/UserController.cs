using HRMSolution.Application.System.Users;
using HRMSolution.Application.System.Users.Dtos;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        //[AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Authencate(request);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Tài khoản hoặc mật khẩu không đúng");
            }
            return Ok(new { token = result});
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);
            if (result == false)
            {
                return BadRequest("Tạo tài khoảng không thành công");
            }
            return Ok();
        }

        //PUT: http://localhost/api/users/id
        [HttpPut("change-password{id}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.ChangePassword(id, request);
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

            var result = await _userService.ResetPassword(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> SetRoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (result == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var user = await _userService.GetUsersPaging(request);
            return Ok(user);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllAccount()
        {
            var user = await _userService.GetAll();
            return Ok(user);
        }
    }
}
