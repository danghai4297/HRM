using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public interface INhanVienService
    {
        Task<int> Create(NhanVienCreateRequest request);
        Task<int> Update(string id, NhanVienUpdateRequest request);
        Task<int> UpdateImage(string id, NhanVienUpdateImageRequest request);
        Task<int> DeleteImage(string maNhanVien);
        Task<List<NhanVienViewModel>> GetAll();
        Task<List<MaTenViewModel>> GetAllMaVaTen();
        Task<List<MaTenViewModel>> GetAllNhanVienAccount();
        Task<NhanVienDetailViewModel> GetByMaNV(string maNhanVien);
        Task<List<NhanVienViewModel>> GetAllNVNghi();
    }
}
