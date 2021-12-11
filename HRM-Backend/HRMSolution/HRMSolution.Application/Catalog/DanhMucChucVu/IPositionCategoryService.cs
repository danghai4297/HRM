using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRMSolution.Data.Entities;

namespace HRMSolution.Application.Catalog.DanhMucChucVus
{
    public interface IPositionCategoryService
    {
        Task<int> Create(DanhMucChucVuCreateRequest request);
        Task<int> Update(int id, DanhMucChucVuUpdateRequest request);
        Task<int> Delete(int idDanhMucChucVu);
        Task<List<DanhMucChucVuViewModel>> GetAll();
        Task<DanhMucChucVuViewModel> GetById(int id);
    }
}
