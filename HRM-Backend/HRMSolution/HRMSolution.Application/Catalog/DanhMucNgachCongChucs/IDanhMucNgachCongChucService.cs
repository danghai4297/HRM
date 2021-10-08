using HRMSolution.Application.Catalog.DanhMucNgachCongChucs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNgachCongChucs
{
    public interface IDanhMucNgachCongChucService
    {
        Task<List<DanhMucNgachCongChucViewModel>> GetAll();
    }
}
