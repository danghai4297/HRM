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
        Task<int> Update(HopDongUpdateRequest request);
        Task<int> Delete(int idDanhMucDanToc);
        Task<List<HopDongViewModel>> GetAll();
        Task<List<HopDongViewModel>> GetAll(string maNhanVien);
    }
}
