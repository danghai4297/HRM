using HRMSolution.Application.Catalog.DanhMucNhomLuongs.DnhomLuongs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNhomLuongs
{
    public interface ISalaryGroupCategoryService
    {
        Task<int> Create(DanhMucNhomLuongCreateRequest request);
        Task<int> Update(int id,DanhMucNhomLuongUpdateRequest request);
        Task<int> Delete(int idDanhMucNhomLuong);
        Task<List<DanhMucNhomLuongViewModel>> GetAll();
        Task<DanhMucNhomLuongViewModel> GetById(int id);
    }
}
