using HRMSolution.Application.Catalog.DanhMucTos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTos
{
    public interface IDanhMucToService
    {
        Task<List<DanhMucToViewModel>> GetAll();
        Task<int> Create(DanhMucToCreateRequest request);
    }
}
