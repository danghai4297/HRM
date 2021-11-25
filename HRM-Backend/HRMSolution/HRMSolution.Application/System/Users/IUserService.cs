using HRMSolution.Application.System.Users.Common;
using HRMSolution.Application.System.Users.Dtos;
using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<bool> ChangePassword(Guid id, UserUpdateRequest request);

        Task<UserVm> GetById(Guid id);

        Task<bool> Delete(Guid id);

        Task<bool> RoleAssign(Guid id, RoleAssignRequest request);
        Task<List<UserVm>> GetAll();
        Task<string> ResetPassword(Guid id);

    }
}
