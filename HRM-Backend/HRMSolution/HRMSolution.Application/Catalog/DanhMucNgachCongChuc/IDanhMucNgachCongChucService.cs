using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNgachCongChucs
{
    public interface IDanhMucNgachCongChucService
    {
        Task<int> Create(DanhMucNgachCongChucCreateRequest request);
        Task<int> Update(int id,DanhMucNgachCongChucUpdateRequest request);
        Task<int> Delete(int idDanhMucNgachCongChuc);
        Task<List<DanhMucNgachCongChucViewModel>> GetAll();
        Task<DanhMucNgachCongChucViewModel> GetById(int id);
    }
}
