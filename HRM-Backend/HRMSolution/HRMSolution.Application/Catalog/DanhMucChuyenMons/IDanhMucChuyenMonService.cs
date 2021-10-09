using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChuyenMons
{
    public interface IDanhMucChuyenMonService
    {
        Task<int> Create(DanhMucChuyenMonCreateRequest request);
        Task<List<DanhMucChuyenMonViewModel>> GetAll();
    }
}
