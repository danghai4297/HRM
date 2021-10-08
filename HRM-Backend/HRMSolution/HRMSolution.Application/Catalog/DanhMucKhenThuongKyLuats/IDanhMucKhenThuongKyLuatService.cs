using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats
{
    public interface IDanhMucKhenThuongKyLuatService
    {
        Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAll();
    }
}
