using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucHonNhans
{
    public interface IDanhMucHonNhanService
    {
        Task<int> Create(DanhMucHonNhanCreateRequest request);
        Task<int> Update(DanhMucHonNhanUpdateRequest request);
        Task<int> Delete(int idDanhMucHonNhan);
        Task<List<DanhMucHonNhanViewModel>> GetALL();
    }
}
