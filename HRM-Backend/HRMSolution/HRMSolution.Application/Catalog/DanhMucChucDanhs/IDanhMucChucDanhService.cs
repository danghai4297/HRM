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
        Task<int> Update(int id,DanhMucChucDanhUpdateRequest request);
        Task<int> Delete(int idDanhMucChucDanh);
        Task<List<DanhMucChucDanhViewModel>> GetAll();
        Task<DanhMucChucDanhViewModel> GetById(int id);
    }
}
