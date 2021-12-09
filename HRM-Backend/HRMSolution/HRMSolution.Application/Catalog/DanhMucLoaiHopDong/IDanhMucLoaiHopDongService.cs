using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucLoaiHopDongs
{
    public interface IDanhMucLoaiHopDongService
    {
        Task<int> Create(DanhMucLoaiHopDongCreateRequest request);
        Task<int> Update(int id,DanhMucLoaiHopDongUpdateRequest request);
        Task<int> Delete(int idDanhMucLoaiHopDong);
        Task<List<DanhMucLoaiHopDongViewModel>> GetAll();
        Task<DanhMucLoaiHopDongViewModel> GetById(int id);
    }
}
