using HRMSolution.Application.Catalog.DanhMucTos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTos
{
    public interface IDanhMucToService
    {
        Task<List<DanhMucToViewModel>> GetAll();
        Task<DanhMucToViewModel> GetDetail(int id);
        Task<int> Create(DanhMucToCreateRequest request);
        Task<int> Update(int id,DanhMucToUpdateRequest request);
        Task<int> Delete(int idDanhMucTo);
    }
}
