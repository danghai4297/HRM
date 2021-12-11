using HRMSolution.Application.Catalog.TaiKhoan.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.TaiKhoan
{
    public interface IAccountService
    {
        Task<bool> Create(CreateAccountRequest request);

        Task<bool> ChangePassword(Guid id, AccountUpdateRequest request);

        Task<AccountViewModel> GetById(Guid id);

        Task<bool> Delete(Guid id);

        Task<bool> RoleAssign(Guid id, RoleAssignRequest request);
        Task<List<AccountViewModel>> GetAll();
        Task<string> ResetPassword(Guid id);
    }
}
