using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChucVus
{
    public interface IDanhMucChucVuService
    {
        Task<List<DanhMucChucVuViewModel>> GetAll();
    }
}
