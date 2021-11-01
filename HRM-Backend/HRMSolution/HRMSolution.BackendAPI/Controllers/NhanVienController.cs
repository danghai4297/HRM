﻿using HRMSolution.Application.Catalog.NhanViens;
using HRMSolution.Application.Catalog.NhanViens.Dtos;
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
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var nhanViens = await _nhanVienService.GetAll();
            return Ok(nhanViens);
        }
        [HttpGet("nghiviec")]
        public async Task<IActionResult> GetNVNghi()
        {
            var nhanViens = await _nhanVienService.GetAllNVNghi();
            return Ok(nhanViens);
        }
        [HttpGet("{maNhanVien}")]
        public async Task<IActionResult> GetByMaNV(string maNhanVien)
        {
            var nhanViens = await _nhanVienService.GetByMaNV(maNhanVien);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao")]
        public async Task<IActionResult> GetByBaoCao()
        {
            var nhanViens = await _nhanVienService.GetAllBaoCao();
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-phong-ban/{id}")]
        public async Task<IActionResult> GetByPhongBan(int id)
        {
            var nhanViens = await _nhanVienService.GetAllByPhongBan(id);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-gioi-tinh/{gioiTinh}")]
        public async Task<IActionResult> GetByGioiTinh(bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllByGioiTinh(gioiTinh);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-trang-thai/{trangthai}")]
        public async Task<IActionResult> GetByTrangThai(bool trangthai)
        {
            var nhanViens = await _nhanVienService.GetAllByTrangThai(trangthai);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-phong-ban-trang-thai/{id}/{trangThai}")]
        public async Task<IActionResult> GetByPhongBanVaTrangThai(int id, bool trangThai)
        {
            var nhanViens = await _nhanVienService.GetAllByPhongBanVaTrangThai(id, trangThai);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-phong-ban-gioi-tinh/{id}/{gioiTinh}")]
        public async Task<IActionResult> GetByPhongBanVaGioiTinh(int id,bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllByPhongBanVaGioiTinh(id,gioiTinh);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-trang-thai-gioi-tinh/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByTTVaGT(bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllByTrangThaiVaGioiTinh(trangThai, gioiTinh);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-phong-ban-trang-thai-gioi-tinh/{id}/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByPhongBanVaTTVaGT(int id, bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllByPhongBanVaTrangThaiVaGioiTinh(id,trangThai, gioiTinh);
            return Ok(nhanViens);
        }

        [AllowAnonymous]
        [HttpGet("bao-cao-hop-dong/{tuNgay}/{denNgay}")]
        public async Task<IActionResult> GetByHanHD(DateTime tuNgay, DateTime denNgay)
        {
            var nhanViens = await _nhanVienService.GetAllByHopDongHL(tuNgay, denNgay);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-hop-dong-trang-thai/{tuNgay}/{denNgay}/{trangThai}")]
        public async Task<IActionResult> GetByHanHDVaTT(DateTime tuNgay, DateTime denNgay, bool trangThai)
        {
            var nhanViens = await _nhanVienService.GetAllByHopDongHLVaTT(tuNgay, denNgay, trangThai);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-hop-dong-gioi-tinh/{tuNgay}/{denNgay}/{gioiTinh}")]
        public async Task<IActionResult> GetByHanHDVaGT(DateTime tuNgay, DateTime denNgay, bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllByHopDongHLVaGT(tuNgay, denNgay, gioiTinh);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-hop-dong-trang-thai-gioi-tinh/{tuNgay}/{denNgay}/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByHanHDVaTTVaGT(DateTime tuNgay, DateTime denNgay, bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllByHopDongHLVaTTVaGT(tuNgay, denNgay, trangThai, gioiTinh);
            return Ok(nhanViens);
        }
        [AllowAnonymous]
        [HttpGet("bao-cao-phong-ban-hop-dong-trang-thai-gioi-tinh/{id}/{tuNgay}/{denNgay}/{trangThai}/{gioiTinh}")]
        public async Task<IActionResult> GetByAllBaoCao(int id,DateTime tuNgay, DateTime denNgay, bool trangThai, bool gioiTinh)
        {
            var nhanViens = await _nhanVienService.GetAllBaoCao(id,tuNgay, denNgay, trangThai, gioiTinh);
            return Ok(nhanViens);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NhanVienCreateRequest request)
        {
            var result = await _nhanVienService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{maNhanVien}")]
        public async Task<IActionResult> Update(string maNhanVien, NhanVienUpdateRequest request)
        {
            var result = await _nhanVienService.Update(maNhanVien, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("image/{maNhanVien}")]
        public async Task<IActionResult> UpdateImage(string maNhanVien, [FromForm]NhanVienUpdateImageRequest request)
        {
            var result = await _nhanVienService.UpdateImage(maNhanVien, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
