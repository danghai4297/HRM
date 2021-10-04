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
        Task<int> Update(DanhMucDanTocUpdateRequest request);
        Task<int> Delete(int idDanhMucDanToc);
        List<DanhMucDanToc> GetAll();
    }
}
