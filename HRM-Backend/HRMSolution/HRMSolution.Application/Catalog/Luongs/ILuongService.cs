using HRMSolution.Application.Catalog.Luongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.Luongs
{
    public interface ILuongService
    {
        Task<List<LuongViewModel>> GetAll();
        Task<LuongViewModel> GetById(int id);
        Task<int> Create(LuongCreateRequest request);
        Task<int> Update(int id, LuongUpdateRequest request);
        Task<int> Delete(int id);
        Task<int> UpdateTrangThai(string maHopDong);
    }
}
