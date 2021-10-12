using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucPhongBans
{
    public interface IDanhMucPhongBanService
    {
        Task<int> Create(DanhMucPhongBanCreateRequest request);
        Task<int> Update(DanhMucPhongBanUpdateRequest request);
        Task<int> Delete(int idDanhMucPhongBan);
        Task<List<DanhMucPhongBanViewModel>> GetAll();
        Task<DanhMucPhongBanViewModel> GetById(int id);
    }
}
