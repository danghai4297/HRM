using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs
{
    public interface IDanhMucTinhChatLaoDongService
    {
        Task<int> Create(DanhMucTinhChatLaoDongCreateRequest request);
        Task<int> Update(DanhMucTinhChatLaoDongUpdateRequest request);
        Task<int> Delete(int idDanhMucTinhChatLaoDong);
        Task<List<DanhMucTinhChatLaoDongViewModel>> GetAll();
        Task<DanhMucTinhChatLaoDongViewModel> GetById(int id);
    }
}
