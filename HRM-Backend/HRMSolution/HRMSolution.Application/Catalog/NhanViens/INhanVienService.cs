using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public interface INhanVienService
    {
        List<NhanVien> GetAll();
    }
}
