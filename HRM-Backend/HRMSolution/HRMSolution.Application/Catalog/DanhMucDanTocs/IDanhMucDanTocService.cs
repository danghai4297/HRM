using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucDanTocs
{
    public interface IDanhMucDanTocService
    {
        Task<int> Create(DanhMucDanTocCreateRequest request);
<<<<<<< HEAD
        Task<int> Update(int id, DanhMucDanTocUpdateRequest request);
=======
        Task<int> Update(int id,DanhMucDanTocUpdateRequest request);
>>>>>>> fec998c699e1da5c5acb2a969f82391a75a1b459
        Task<int> Delete(int idDanhMucDanToc);
        Task<List<DanhMucDanTocViewModel>> GetAll();
        Task<DanhMucDanTocViewModel> GetById(int id);
    }
}
