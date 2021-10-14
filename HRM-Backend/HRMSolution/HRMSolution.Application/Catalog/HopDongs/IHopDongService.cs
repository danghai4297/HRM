using HRMSolution.Application.Catalog.HopDongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.HopDongs
{
    public interface IHopDongService
    {
        Task<int> Create(HopDongCreateRequest request);
        Task<int> Update(string maHopDong, HopDongUpdateRequest request);
        Task<int> Delete(string maHopDong);
        Task<List<HopDongViewModel>> GetAll();
        Task<List<HopDongViewModel>> GetAll(string maNhanVien);
        Task<HopDongViewModel> GetHopDong(string maHopDong);
    }
}
