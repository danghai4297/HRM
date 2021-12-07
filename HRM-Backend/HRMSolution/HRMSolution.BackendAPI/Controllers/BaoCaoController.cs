using HRMSolution.Application.Catalog.BaoCaos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaoCaoController : ControllerBase
    {
        private readonly IBaoCaoService _baoCaoService;
        public BaoCaoController(IBaoCaoService baoCaoService)
        {
            _baoCaoService = baoCaoService;
        }

        [HttpGet("bao-cao")]
        public async Task<IActionResult> GetByBaoCao()
        {
            var nhanViens = await _baoCaoService.GetAllBaoCao();
            return Ok(nhanViens);
        }
        [HttpGet("bao-cao-phong-ban/{id}")]
        public async Task<IActionResult> GetByPhongBan(int id)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBan(id);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-gioi-tinh/{gioiTinh}")]
        public async Task<IActionResult> GetByGioiTinh(bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByGioiTinh(gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-trang-thai/{trangthai}")]
        public async Task<IActionResult> GetByTrangThai(bool trangthai)
        {
            var nhanViens = await _baoCaoService.GetAllByTrangThai(trangthai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-phong-ban-trang-thai/{id}/{trangThai}")]
        public async Task<IActionResult> GetByPhongBanVaTrangThai(int id, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBanVaTrangThai(id, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-phong-ban-gioi-tinh/{id}/{gioiTinh}")]
        public async Task<IActionResult> GetByPhongBanVaGioiTinh(int id, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBanVaGioiTinh(id, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-trang-thai-gioi-tinh/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByTTVaGT(bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByTrangThaiVaGioiTinh(trangThai, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-phong-ban-trang-thai-gioi-tinh/{id}/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByPhongBanVaTTVaGT(int id, bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBanVaTrangThaiVaGioiTinh(id, trangThai, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-hop-dong/{tuNgay}/{denNgay}")]
        public async Task<IActionResult> GetByHanHD(DateTime tuNgay, DateTime denNgay)
        {
            var nhanViens = await _baoCaoService.GetAllByHopDongHL(tuNgay, denNgay);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-hop-dong-trang-thai/{tuNgay}/{denNgay}/{trangThai}")]
        public async Task<IActionResult> GetByHanHDVaTT(DateTime tuNgay, DateTime denNgay, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllByHopDongHLVaTT(tuNgay, denNgay, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-hop-dong-gioi-tinh/{tuNgay}/{denNgay}/{gioiTinh}")]
        public async Task<IActionResult> GetByHanHDVaGT(DateTime tuNgay, DateTime denNgay, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByHopDongHLVaGT(tuNgay, denNgay, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-hop-dong-trang-thai-gioi-tinh/{tuNgay}/{denNgay}/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByHanHDVaTTVaGT(DateTime tuNgay, DateTime denNgay, bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByHopDongHLVaTTVaGT(tuNgay, denNgay, trangThai, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-phong-ban-hop-dong-trang-thai-gioi-tinh/{id}/{tuNgay}/{denNgay}/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCao(int id, DateTime tuNgay, DateTime denNgay, bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllBaoCao(id, tuNgay, denNgay, trangThai, gioiTinh);
            return Ok(nhanViens);
        }


        [HttpGet("bao-cao-phong-ban-hop-dong/{id}/{tuNgay}/{denNgay}")]
        public async Task<IActionResult> GetByPBvaHD(int id, DateTime tuNgay, DateTime denNgay)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBanVaHD(id, tuNgay, denNgay);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-phong-ban-hop-dong-trang-thai/{id}/{tuNgay}/{denNgay}/{trangThai}")]
        public async Task<IActionResult> GetByPBvaHDvaTT(int id, DateTime tuNgay, DateTime denNgay, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBanVaHDVaTrangThai(id, tuNgay, denNgay, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-phong-ban-hop-dong-gioi-tinh/{id}/{tuNgay}/{denNgay}/{gioiTinh}")]
        public async Task<IActionResult> GetByPBvaHDvaGT(int id, DateTime tuNgay, DateTime denNgay, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllByPhongBanVaHDVaGioiTinh(id, tuNgay, denNgay, gioiTinh);
            return Ok(nhanViens);
        }


        [HttpGet("bao-cao-len-luong/{tuNgay}/{denNgay}")]
        public async Task<IActionResult> GetByAllBaoCaoLenLuong(DateTime tuNgay, DateTime denNgay)
        {
            var nhanViens = await _baoCaoService.GetAllLenLuong(tuNgay, denNgay);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-len-luong-phong-ban/{id}/{tuNgay}/{denNgay}")]
        public async Task<IActionResult> GetByAllBaoCaoLenLuongByPhongBan(int id, DateTime tuNgay, DateTime denNgay)
        {
            var nhanViens = await _baoCaoService.GetAllLenLuongPhongBan(id, tuNgay, denNgay);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-sinh-nhat/{thang}")]
        public async Task<IActionResult> GetByAllBaoCaoSinhNhat(int thang)
        {
            var nhanViens = await _baoCaoService.GetAllSinhNhat(thang);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-sinh-nhat-phong-ban/{id}/{thang}")]
        public async Task<IActionResult> GetByAllBaoCaoSinhNhatVaPhongBan(int id, int thang)
        {
            var nhanViens = await _baoCaoService.GetAllSinhNhatPhongBan(id, thang);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nhom-luong")]
        public async Task<IActionResult> GetByAllBaoCaoNhomLuong()
        {
            var nhanViens = await _baoCaoService.GetAllNhomLuong();
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nhom-luong-phong-ban/{idPhongBan}")]
        public async Task<IActionResult> GetByAllBaoCaoNhomLuong(int idPhongBan)
        {
            var nhanViens = await _baoCaoService.GetAllNhomLuongPhongBan(idPhongBan);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-chinh-sach")]
        public async Task<IActionResult> GetByAllBaoCaoChinhSach()
        {
            var nhanViens = await _baoCaoService.GetAllChinhSach();
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-chinh-sach-phong-ban/{id}")]
        public async Task<IActionResult> GetByAllBaoCaoChinhSachPhongBan(int id)
        {
            var nhanViens = await _baoCaoService.GetAllChinhSachPhongBan(id);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-bhxh")]
        public async Task<IActionResult> GetByAllBaoCaoBHXH()
        {
            var nhanViens = await _baoCaoService.GetAllBHXH();
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-bhxh-phong-ban/{id}")]
        public async Task<IActionResult> GetByAllBaoCaoBHXHPhongBan(int id)
        {
            var nhanViens = await _baoCaoService.GetAllBHXHPhongBan(id);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-dang-vien")]
        public async Task<IActionResult> GetByAllBaoCaoDangVien()
        {
            var nhanViens = await _baoCaoService.GetAllDangVien();
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-dang-vien-phong-ban/{id}")]
        public async Task<IActionResult> GetByAllBaoCaoDangVienPhongBan(int id)
        {
            var nhanViens = await _baoCaoService.GetAllDangVienPhongBan(id);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than/{tu}/{den}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThan(int tu, int den)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThan(tu, den);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc/{tu}/{den}/{idDanhMuc}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMuc(int tu, int den, int idDanhMuc)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMuc(tu, den, idDanhMuc);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban/{tu}/{den}/{idPhongBan}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBan(int tu, int den, int idPhongBan)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBan(tu, den, idPhongBan);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-nhan-vien/{tu}/{den}/{maNhanVien}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanNhanVien(int tu, int den, string maNhanVien)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoMaNhanVien(tu, den, maNhanVien);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-gioi-tinh/{tu}/{den}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanGioiTinh(int tu, int den, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoGioiTinh(tu, den, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-trang-thai/{tu}/{den}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanTrangThai(int tu, int den, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoTrangThai(tu, den, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban/{tu}/{den}/{idDanhMuc}/{idPhongBan}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBan(int tu, int den, int idDanhMuc, int idPhongBan)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBan(tu, den, idDanhMuc, idPhongBan);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-nhan-vien/{tu}/{den}/{idDanhMuc}/{maNhanVien}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaNhanVien(int tu, int den, int idDanhMuc, string maNhanVien)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaMaNhanVien(tu, den, idDanhMuc, maNhanVien);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-gioi-tinh/{tu}/{den}/{idDanhMuc}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaGioiTinh(int tu, int den, int idDanhMuc, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaGioiTinh(tu, den, idDanhMuc, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-trang-thai/{tu}/{den}/{idDanhMuc}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaTrangThai(int tu, int den, int idDanhMuc, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaTrangThai(tu, den, idDanhMuc, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-nhan-vien/{tu}/{den}/{idPhongBan}/{maNhanVien}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaMaNhanVien(int tu, int den, int idPhongBan, string maNhanVien)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBanVaMaNhanVien(tu, den, idPhongBan, maNhanVien);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-gioi-tinh/{tu}/{den}/{idPhongBan}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaGioiTinh(int tu, int den, int idPhongBan, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBanVaGioiTinh(tu, den, idPhongBan, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-trang-thai/{tu}/{den}/{idPhongBan}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaTrangThai(int tu, int den, int idPhongBan, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBanVaTrangThai(tu, den, idPhongBan, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-nhan-vien-gioi-tinh/{tu}/{den}/{maNhanVien}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanNhanVienVaGioiTinh(int tu, int den, string maNhanVien, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoMaNhanVienVaGioiTinh(tu, den, maNhanVien, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-nhan-vien-trang-thai/{tu}/{den}/{maNhanVien}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanNhanVienVaTrangThai(int tu, int den, string maNhanVien, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoMaNhanVienVaTrangThai(tu, den, maNhanVien, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-gioi-tinh-trang-thai/{tu}/{den}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanGioiTinhVaTrangThai(int tu, int den, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoGioiTinhVaTrangThai(tu, den, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-nhan-vien/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{maNhanVien}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVaMaNhanVien(int tu, int den, int idDanhMuc, int idPhongBan, string maNhanVien)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVien(tu, den, idDanhMuc, idPhongBan, maNhanVien);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-gioi-tinh/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVaGioiTinh(int tu, int den, int idDanhMuc, int idPhongBan, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBanVaGioiTinh(tu, den, idDanhMuc, idPhongBan, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-trang-thai/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVaTrangThai(int tu, int den, int idDanhMuc, int idPhongBan, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBanVaTrangThai(tu, den, idDanhMuc, idPhongBan, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-nhan-vien-gioi-tinh/{tu}/{den}/{idDanhMuc}/{maNhanVien}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaNhanVienVaGioiTinh(int tu, int den, int idDanhMuc, string maNhanVien, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaMaNhanVienVaGioiTinh(tu, den, idDanhMuc, maNhanVien, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-nhan-vien-trang-thai/{tu}/{den}/{idDanhMuc}/{maNhanVien}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaNhanVienVaTrangThai(int tu, int den, int idDanhMuc, string maNhanVien, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaMaNhanVienVaTrangThai(tu, den, idDanhMuc, maNhanVien, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-gioi-tinh-trang-thai/{tu}/{den}/{idDanhMuc}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaGioiTinhVaTrangThai(int tu, int den, int idDanhMuc, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaGioiTinhVaTrangThai(tu, den, idDanhMuc, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-nhan-vien-gioi-tinh/{tu}/{den}/{idPhongBan}/{maNhanVien}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaMaNhanVienVaGioiTinh(int tu, int den, int idPhongBan, string maNhanVien, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBanVaMaNhanVienVaGioiTinh(tu, den, idPhongBan, maNhanVien, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-nhan-vien-trang-thai/{tu}/{den}/{idPhongBan}/{maNhanVien}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaMaNhanVienVaTrangThai(int tu, int den, int idPhongBan, string maNhanVien, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBanVaMaNhanVienVaTrangThai(tu, den, idPhongBan, maNhanVien, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-gioi-tinh-trang-thai/{tu}/{den}/{idPhongBan}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaGioiTinhVaTrangThai(int tu, int den, int idPhongBan, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoPhongBanVaGioiTinhVaTrangThai(tu, den, idPhongBan, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-nhan-vien-gioi-tinh/{tu}/{den}/{maNhanVien}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanNhanVienVaGioiTinhVaTrangThai(int tu, int den, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoNhanVienVaGioiTinhVaTrangThai(tu, den, maNhanVien, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-nhan-vien-gioi-tinh/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{maNhanVien}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVaNhanVienVaGioiTinh(int tu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool gioiTinh)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVienVaGioiTinh(tu, den, idDanhMuc, idPhongBan, maNhanVien, gioiTinh);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-nhan-vien-trang-thai/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{maNhanVien}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVaNhanVienVaTrangThai(int tu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBanVaMaNhanVienVaTrangThai(tu, den, idDanhMuc, idPhongBan, maNhanVien, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-nhan-vien-gioi-tinh-trang-thai/{tu}/{den}/{idDanhMuc}/{maNhanVien}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaNhanVienVaGioiTinhVaTrangThai(int tu, int den, int idDanhMuc, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaMaNhanVienVaGioiTinhVaTrangThai(tu, den, idDanhMuc, maNhanVien, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-gioi-tinh-trang-thai/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVaGioiTinhVaTrangThai(int tu, int den, int idDanhMuc, int idPhongBan, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanTheoDanhMucVaPhongBanVaGioiTinhVaTrangThai(tu, den, idDanhMuc, idPhongBan, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-phong-ban-nhan-vien-gioi-tinh-trang-thai/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanPhongBanVaNhanVienVaGioiTinhVaTrangThai(int tu, int den, int idPhongBan, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanPhongBanVaMaNhanVienVaGioiTinhVaTrangThai(tu, den, idPhongBan, maNhanVien, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-nguoi-than-danh-muc-phong-ban-nhan-vien-gioi-tinh-trang-thai/{tu}/{den}/{idDanhMuc}/{idPhongBan}/{maNhanVien}/{gioiTinh}/{trangThai}")]
        public async Task<IActionResult> GetByAllBaoCaoNguoiThanDanhMucVaPhongBanVanNhanVienVaGioiTinhVaTrangThai(int tu, int den, int idDanhMuc, int idPhongBan, string maNhanVien, bool gioiTinh, bool trangThai)
        {
            var nhanViens = await _baoCaoService.GetAllNguoiThanDanhMucVaPhongBanVaMaNhanVienVaGioiTinhVaTrangThai(tu, den, idDanhMuc, idPhongBan, maNhanVien, gioiTinh, trangThai);
            return Ok(nhanViens);
        }

        [HttpGet("bao-cao-luong/{maNhanVien}")]
        public async Task<IActionResult> GetByAllBaoCaoLuongTheoMaNhanVie(string maNhanVien)
        {
            var nhanViens = await _baoCaoService.GetAllBaoCaoLuong(maNhanVien);
            return Ok(nhanViens);
        }
    }
}
