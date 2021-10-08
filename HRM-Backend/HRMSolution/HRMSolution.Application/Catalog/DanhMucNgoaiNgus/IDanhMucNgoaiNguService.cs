
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNgoaiNgus
{
    public interface IDanhMucNgoaiNguService
    {
        Task<List<DanhMucNgoaiNguViewModel>> GetAll();
    }
}
