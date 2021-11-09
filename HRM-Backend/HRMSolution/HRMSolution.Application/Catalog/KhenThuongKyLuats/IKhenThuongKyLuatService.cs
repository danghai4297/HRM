using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats
{
    public interface IKhenThuongKyLuatService
    {
        Task<int> Create(KhenThuongKyLuatCreateRequest request);
        Task<int> Update(int id, KhenThuongKyLuatUpdateRequest request);
        Task<int> UpdateImage(int id, KhenThuongKyLuatUpdateRequest request);
        Task<int> Delete(int idDanhMucKTKL);
        Task<List<KhenThuongKyLuatViewModel>> GetAllKhenThuong();
        Task<KhenThuongKyLuatViewModel> GetById(int id);
        Task<List<KhenThuongKyLuatViewModel>> GetAllKyLuat();
    }
}
