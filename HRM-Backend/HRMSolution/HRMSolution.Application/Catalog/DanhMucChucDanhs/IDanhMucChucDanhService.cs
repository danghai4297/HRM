using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using System;
using System.Collections.Generic;
using HRMSolution.Data.Entities;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs
{
    public interface IDanhMucChucDanhService
    {
        Task<int> Create(DanhMucChucDanhCreateRequest request);
        Task<List<DanhMucChucDanhViewModel>> GetAll();
    }
}
