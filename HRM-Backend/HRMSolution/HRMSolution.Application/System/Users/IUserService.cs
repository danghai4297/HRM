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
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        Task<List<UserVm>> GetAll();

    }
}
