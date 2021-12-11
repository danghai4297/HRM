using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTrinhDos
{
    public interface ILevelCategoryService
    {
        Task<int> Create(DanhMucTrinhDoCreateRequest request);
        Task<int> Update(int id,DanhMucTrinhDoUpdateRequest request);
        Task<int> Delete(int idDanhMucTrinhDo);
        Task<List<DanhMucTrinhDoViewModel>> GetAll();
        Task<DanhMucTrinhDoViewModel> GetById(int id);
    }
}
