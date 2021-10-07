using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucHonNhans
{
    public interface IDanhMucHonNhanService
    {
        Task<List<DanhMucHonNhanViewModel>> GetALL();
    }
}
