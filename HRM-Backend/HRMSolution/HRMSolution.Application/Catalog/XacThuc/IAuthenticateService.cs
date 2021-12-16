using HRMSolution.Application.Catalog.XacThuc.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.XacThuc
{
    public interface IAuthenticateService
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
