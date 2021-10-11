using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChucVus
{
    public interface IDanhMucChucVuService
    {
        Task<int> Create(DanhMucChucVuCreateRequest request);
        Task<int> Update(DanhMucChucVuUpdateRequest request);
        Task<int> Delete(int idDanhMucChucVu);
        Task<List<DanhMucChucVuViewModel>> GetAll();
    }
}
