
using HRMSolution.Application.Catalog.BaoCaos.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.BaoCaos
{
    public interface IReportService
    {
        Task<List<BaoCaoViewModel>> GetAllBaoCao();
        Task<List<BaoCaoViewModel>> GetAllBaoCao(int id, DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai, bool gioiTinh);
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
        Task<List<BaoCaoViewModel>> GetAllByPhongBanVaHD(int id, DateTime ngayBatDau, DateTime ngayKetThuc);
        Task<List<BaoCaoViewModel>> GetAllByPhongBanVaHDVaTrangThai(int id, DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai);
        Task<List<BaoCaoViewModel>> GetAllByPhongBanVaHDVaGioiTinh(int id, DateTime ngayBatDau, DateTime ngayKetThuc, bool gioiTinh);
        Task<List<BaoCaoLenLuongViewModel>> GetAllLenLuong(DateTime tuNgay, DateTime denNgay);
        Task<List<BaoCaoLenLuongViewModel>> GetAllLenLuongPhongBan(int id, DateTime tuNgay, DateTime denNgay);
        Task<List<BaoCaoSinhNhatViewModel>> GetAllSinhNhat(int thang);
        Task<List<BaoCaoSinhNhatViewModel>> GetAllSinhNhatPhongBan(int id, int thang);
        Task<List<BaoCaoNhomLuongViewModel>> GetAllNhomLuong();
        Task<List<BaoCaoNhomLuongViewModel>> GetAllNhomLuongPhongBan(int idPhongBan);
        Task<List<BaoCaoChinhSachViewModel>> GetAllChinhSach();
        Task<List<BaoCaoChinhSachViewModel>> GetAllChinhSachPhongBan(int id);
        Task<List<BaoCaoBHXHViewModel>> GetAllBHXH();
        Task<List<BaoCaoBHXHViewModel>> GetAllBHXHPhongBan(int id);
        Task<List<BaoCaoDangVienViewModel>> GetAllDangVien();
        Task<List<BaoCaoDangVienViewModel>> GetAllDangVienPhongBan(int id);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThan(int tuoiTu, int den);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMuc(int tuoiTu, int den, int idDanhMuc);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBan(int tuoiTu, int den, int idPhongBan);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoMaNhanVien(int tuoiTu, int den, string maNhanVien);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoGioiTinh(int tuoiTu, int den, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoTrangThai(int tuoiTu, int den, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBan(int tuoiTu, int den, int idDanhMuc, int idPhongBan);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVien(int tuoiTu, int den, int idDanhMuc, string maNhanVien);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaGioiTinh(int tuoiTu, int den, int idDanhMuc, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaTrangThai(int tuoiTu, int den, int idDanhMuc, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaMaNhanVien(int tuoiTu, int den, int idPhongBan, string maNhanVien);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaGioiTinh(int tuoiTu, int den, int idPhongBan, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaTrangThai(int tuoiTu, int den, int idPhongBan, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoMaNhanVienVaGioiTinh(int tuoiTu, int den, string maNhanVien, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoMaNhanVienVaTrangThai(int tuoiTu, int den, string maNhanVien, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoGioiTinhVaTrangThai(int tuoiTu, int den, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVien(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaGioiTinh(int tuoiTu, int den, int idDanhMuc, int idPhongBan, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVienVaGioiTinh(int tuoiTu, int den, int idDanhMuc, string maNhanVien, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVienVaTrangThai(int tuoiTu, int den, int idDanhMuc, string maNhanVien, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaMaNhanVienVaGioiTinh(int tuoiTu, int den, int idPhongBan, string maNhanVien, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaMaNhanVienVaTrangThai(int tuoiTu, int den, int idPhongBan, string maNhanVien, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoPhongBanVaGioiTinhVaTrangThai(int tuoiTu, int den, int idPhongBan, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, string maNhanVien, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVienVaGioiTinh(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool gioiTinh);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVienVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaPhongBanVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanTheoDanhMucVaMaNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, string maNhanVien, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanPhongBanVaMaNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, int idPhongBan, string maNhanVien, bool gioiTinh, bool trangThai);
        Task<List<BaoCaoNguoiThanViewModel>> GetAllNguoiThanDanhMucVaPhongBanVaMaNhanVienVaGioiTinhVaTrangThai(int tuoiTu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool gioiTinh, bool trangThai);
        Task<BaoCaoLuongViewModel> GetAllBaoCaoLuong(string maNhanVien);
    }
}
