using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucHonNhans
{
    public interface IMarriageCategoryService
    {
        Task<int> Create(DanhMucHonNhanCreateRequest request);
        Task<int> Update(int id,DanhMucHonNhanUpdateRequest request);
        Task<int> Delete(int idDanhMucHonNhan);
        Task<List<DanhMucHonNhanViewModel>> GetALL();
        Task<DanhMucHonNhanViewModel> GetById(int id);
    }
}
