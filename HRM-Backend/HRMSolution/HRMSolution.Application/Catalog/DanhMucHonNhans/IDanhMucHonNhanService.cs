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
        Task<List<DanhMucHonNhanViewModel>> GetALL();
    }
}
