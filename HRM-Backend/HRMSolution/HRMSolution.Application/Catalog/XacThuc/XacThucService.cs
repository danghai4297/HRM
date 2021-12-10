using HRMSolution.Application.Catalog.XacThuc.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.XacThuc
{
    public class XacThucService : IXacThucService
    {
        private readonly HRMDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        public XacThucService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration config, HRMDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _context = context;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var nv = await _context.nhanViens.FindAsync(user.maNhanVien);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim("anh",nv.anh),
                new Claim("givenName",nv.hoTen),
                new Claim("role", string.Join(";",roles)),
                new Claim("userName", request.UserName),
                new Claim("id", user.maNhanVien),
                new Claim("idAccount", user.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
