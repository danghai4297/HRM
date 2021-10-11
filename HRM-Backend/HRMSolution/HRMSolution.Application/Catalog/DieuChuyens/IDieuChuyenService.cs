using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DieuChuyens
{
    public interface IDieuChuyenService
    {
        Task<DieuChuyenViewModel> GetDetail(int id);
        Task<int> Create(DieuChuyenCreateRequest request);
    }
}
