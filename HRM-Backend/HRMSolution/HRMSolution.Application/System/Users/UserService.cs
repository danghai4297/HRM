using HRMSolution.Application.System.Users.Common;
using HRMSolution.Application.System.Users.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly HRMDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager,
            IConfiguration config, HRMDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<string> Authencate(LoginRequest request)
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
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return false;
            }
            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return true;

            return false;
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                 || x.PhoneNumber.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName,
                    Id = x.Id,
                    
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<List<UserVm>> GetAll()
        {
            
            var query = from x in _userManager.Users
                        join nv in _context.nhanViens on x.maNhanVien equals nv.maNhanVien
                        select new {x, nv };
            var data = await query.Select(x => new UserVm()
            {
                Id = x.x.Id,
                FullName = x.nv.hoTen,
                PhoneNumber = x.nv.dienThoai,
                UserName = x.x.UserName,
                Email = x.nv.email,
                maNhanVien = x.x.maNhanVien,
                Dob = x.nv.ngaySinh
            }).ToListAsync();

            return data;
        }

        public async Task<UserVm> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            //if (user == null)
            //{
            //    return "User không tồn tại";
            //}
            var roles = await _userManager.GetRolesAsync(user);

            var query = from x in _userManager.Users
                        join nv in _context.nhanViens on x.maNhanVien equals nv.maNhanVien
                        where x.Id == id
                        select new { x, nv };
            var data = await query.Select(x => new UserVm()
            {
                Id = x.x.Id,
                FullName = x.nv.hoTen,
                PhoneNumber = x.nv.dienThoai,
                UserName = x.x.UserName,
                Email = x.nv.email,
                maNhanVien = x.x.maNhanVien,
                Dob = x.nv.ngaySinh,
                Roles = roles
            }).FirstOrDefaultAsync();

            return data;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var nhanVien = await _context.nhanViens.FindAsync(request.maNhanVien);
            if (user != null)
            {
                return false;
            }

            user = new AppUser()
            {
                UserName = request.UserName,
                maNhanVien = request.maNhanVien,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return true;
        }

        public async Task<bool> RoleAssign(Guid id, RoleAssignRequest request)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return false;
            }
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return true;
        }

        public async Task<bool> ChangePassword(Guid id, UserUpdateRequest request)
        {
            var hasher = new PasswordHasher<AppUser>();
            var user = await _userManager.FindByIdAsync(id.ToString());
            var changePassword = await _userManager.ChangePasswordAsync(user, request.oldPassword, request.newPassword);        
            if (changePassword.Succeeded)
            {
                user.PasswordHash = hasher.HashPassword(null, request.newPassword);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> ResetPassword(Guid id)
        {
            var pw = "o!eGa!4Q";
            var password = GenerateRandomPassword();
            var user = await _userManager.FindByIdAsync(id.ToString());
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken, password);
            if (passwordChangeResult.Succeeded)
            {
                return password;
            }
            else return null;
        }
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
