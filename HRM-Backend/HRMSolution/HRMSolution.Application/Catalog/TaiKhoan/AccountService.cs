using HRMSolution.Application.Catalog.TaiKhoan.Dtos;
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
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRMSolution.Application.Catalog.TaiKhoan
{
    public class AccountService : IAccountService
    {
        private readonly HRMDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AccountService(UserManager<AppUser> userManager, HRMDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> ChangePassword(Guid id, AccountUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return false;
            var hasher = new PasswordHasher<AppUser>();
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

        public async Task<bool> Create(CreateAccountRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

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
            await _userManager.AddToRoleAsync(user, "user");
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

        public async Task<List<AccountViewModel>> GetAll()
        {
            var query = from x in _userManager.Users
                        join nv in _context.nhanViens on x.maNhanVien equals nv.maNhanVien
                        orderby x.maNhanVien ascending
                        select new { x, nv };
            var data = await query.Select(x => new AccountViewModel()
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

        public async Task<AccountViewModel> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            var query = from x in _userManager.Users
                        join nv in _context.nhanViens on x.maNhanVien equals nv.maNhanVien
                        where x.Id == id
                        select new { x, nv };
            var data = await query.Select(x => new AccountViewModel()
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

        public async Task<string> ResetPassword(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            var password = GenerateRandomPassword();
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
            "!@$?"                        // non-alphanumeric
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
