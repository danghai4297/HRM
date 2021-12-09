
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNgoaiNgus
{
    public interface IDanhMucNgoaiNguService
    {
        Task<int> Create(DanhMucNgoaiNguCreateRequest request);
        Task<int> Update(int id,DanhMucNgoaiNguUpdateRequest request);
        Task<int> Delete(int idDanhMucNgoaiNgu);
        Task<List<DanhMucNgoaiNguViewModel>> GetAll();
        Task<DanhMucNgoaiNguViewModel> GetById(int id);
    }
}
