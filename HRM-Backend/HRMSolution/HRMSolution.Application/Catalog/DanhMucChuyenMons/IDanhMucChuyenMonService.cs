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
        Task<int> Update(DanhMucChuyenMonUpdateRequest request);
        Task<int> Delete(int idDanhMucChuyenMon);
        Task<List<DanhMucChuyenMonViewModel>> GetAll();
    }
}
