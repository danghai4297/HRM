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
        Task<int> Delete(int idDanhMucDanToc);
        Task<List<NhanVienViewModel>> GetAll();
        Task<NhanVienDetailViewModel> GetByMaNV(string maNhanVien);
        Task<List<NhanVienViewModel>> GetAllNVNghi();
        Task<List<BaoCaoViewModel>> GetAllBaoCao();
        Task<List<BaoCaoViewModel>> GetAllByPhongBan(int id);
        Task<List<BaoCaoViewModel>> GetAllByGioiTinh(bool gioiTinh);
        Task<List<BaoCaoViewModel>> GetAllByTrangThai(bool trangThai);
        Task<List<BaoCaoViewModel>> GetAllByPhongBanVaGioiTinh(int id, bool gioiTinh);
        Task<List<BaoCaoViewModel>> GetAllByPhongBanVaTrangThai(int id, bool trangThai);
        Task<List<BaoCaoViewModel>> GetAllByTrangThaiVaGioiTinh(bool trangThai, bool gioiTinh);
        Task<List<BaoCaoViewModel>> GetAllByPhongBanVaTrangThaiVaGioiTinh(int id, bool trangThai, bool gioiTinh);
        Task<List<BaoCaoViewModel>> GetAllByHopDongHL(DateTime ngayBatDau, DateTime ngayKetThuc);
        Task<List<BaoCaoViewModel>> GetAllByHopDongHLVaTT(DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai);
        Task<List<BaoCaoViewModel>> GetAllByHopDongHLVaGT(DateTime ngayBatDau, DateTime ngayKetThuc, bool gioiTinh);
        Task<List<BaoCaoViewModel>> GetAllByHopDongHLVaTTVaGT(DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai, bool gioiTinh);
    }
}
