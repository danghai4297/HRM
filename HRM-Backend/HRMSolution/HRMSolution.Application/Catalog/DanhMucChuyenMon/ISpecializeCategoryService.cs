using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChuyenMons
{
    public interface ISpecializeCategoryService
    {
        Task<int> Create(DanhMucChuyenMonCreateRequest request);
        Task<int> Update(int id, DanhMucChuyenMonUpdateRequest request);
        Task<int> Delete(int idDanhMucChuyenMon);
        Task<List<DanhMucChuyenMonViewModel>> GetAll();
        Task<DanhMucChuyenMonViewModel> GetById(int id);
    }
}
