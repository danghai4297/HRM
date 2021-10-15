using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats
{
    public interface IDanhMucKhenThuongKyLuatService
    {
        Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKhenThuong();
        Task<List<DanhMucKhenThuongKyLuatViewModel>> GetAllKyLuat();
        Task<DanhMucKhenThuongKyLuatViewModel> GetById(int id);
        Task<int> Create(DanhMucKhenThuongKyLuatCreateRequest request);
        Task<int> Update(int id, DanhMucKhenThuongKyLuatUpdateRequest request);
        Task<int> Delete(int idDanhMucHonNhan);
    }
}
