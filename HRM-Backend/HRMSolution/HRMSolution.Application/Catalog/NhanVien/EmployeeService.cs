﻿using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Application.Common;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public EmployeeService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(NhanVienCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var hoTen = request.hoTen.Trim(charsToTrim);
            var quocTich = request.quocTich.Trim(charsToTrim);

            var email = request.email;
            if (email != null)
            {
                email = email.Trim(charsToTrim);
            }

            var facebook = request.facebook;
            if (facebook != null)
            {
                facebook = facebook.Trim(charsToTrim);
            }

            var skype = request.skype;
            if (skype != null)
            {
                skype = skype.Trim(charsToTrim);
            }

            var maSoThue = request.maSoThue;
            if (maSoThue != null)
            {
                maSoThue = maSoThue.Trim(charsToTrim);
            }
            var cccd = request.cccd.Trim(charsToTrim);
            var noiCapCCCD = request.noiCapCCCD.Trim(charsToTrim);

            var hoChieu = request.hoChieu;
            if (hoChieu != null)
            {
                hoChieu = hoChieu.Trim(charsToTrim);
            }
            var noiCapHoChieu = request.noiCapHoChieu;
            if (noiCapHoChieu != null)
            {
                noiCapHoChieu = noiCapHoChieu.Trim(charsToTrim);
            }
            var noiSinh = request.noiSinh.Trim(charsToTrim);
            var queQuan = request.queQuan.Trim(charsToTrim);
            var thuongTru = request.thuongTru.Trim(charsToTrim);

            var tamTru = request.tamTru;
            if (tamTru != null)
            {
                tamTru = noiCapHoChieu.Trim(charsToTrim);
            }

            var ngheNghiep = request.ngheNghiep.Trim(charsToTrim);
            var chucVuHienTai = request.chucVuHienTai.Trim(charsToTrim);
            var congViecChinh = request.congViecChinh.Trim(charsToTrim);
            var coQuanTuyenDung = request.coQuanTuyenDung.Trim(charsToTrim);

            var ngachCongChucNoiDung = request.ngachCongChucNoiDung;
            if (ngachCongChucNoiDung != null)
            {
                ngachCongChucNoiDung = ngachCongChucNoiDung.Trim(charsToTrim);
            }

            var quanHamCaoNhat = request.quanHamCaoNhat;
            if (quanHamCaoNhat != null)
            {
                quanHamCaoNhat = quanHamCaoNhat.Trim(charsToTrim);
            }

            var danhHieuCaoNhat = request.danhHieuCaoNhat;
            if (danhHieuCaoNhat != null)
            {
                danhHieuCaoNhat = danhHieuCaoNhat.Trim(charsToTrim);
            }

            var noiThamGia = request.noiThamGia;
            if (noiThamGia != null)
            {
                noiThamGia = noiThamGia.Trim(charsToTrim);
            }

            var thuongBinh = request.thuongBinh;
            if (thuongBinh != null)
            {
                thuongBinh = thuongBinh.Trim(charsToTrim);
            }

            var conChinhSach = request.conChinhSach;
            if (conChinhSach != null)
            {
                conChinhSach = conChinhSach.Trim(charsToTrim);
            }

            var bhxh = request.bhxh;
            if (bhxh != null)
            {
                bhxh = bhxh.Trim(charsToTrim);
            }

            var bhyt = request.bhyt;
            if (bhyt != null)
            {
                bhyt = bhyt.Trim(charsToTrim);
            }

            var atm = request.atm;
            if (atm != null)
            {
                atm = atm.Trim(charsToTrim);
            }

            var nganHang = request.nganHang;
            if (nganHang != null)
            {
                nganHang = nganHang.Trim(charsToTrim);
            }

            var lyDoNghiViec = request.lyDoNghiViec;
            if (lyDoNghiViec != null)
            {
                lyDoNghiViec = lyDoNghiViec.Trim(charsToTrim);
            }

            var yt_nhomMau = request.yt_nhomMau;
            if (yt_nhomMau != null)
            {
                yt_nhomMau = yt_nhomMau.Trim(charsToTrim);
            }

            var yt_tinhTrangSucKhoe = request.yt_tinhTrangSucKhoe;
            if (yt_tinhTrangSucKhoe != null)
            {
                yt_tinhTrangSucKhoe = yt_tinhTrangSucKhoe.Trim(charsToTrim);
            }

            var yt_benhTat = request.yt_benhTat;
            if (yt_benhTat != null)
            {
                yt_benhTat = yt_benhTat.Trim(charsToTrim);
            }

            var yt_luuY = request.yt_luuY;
            if (yt_luuY != null)
            {
                yt_luuY = yt_luuY.Trim(charsToTrim);
            }

            var lhkc_hoTen = request.lhkc_hoTen.Trim(charsToTrim);
            var lhkc_quanHe = request.lhkc_quanHe.Trim(charsToTrim);

            var lhkc_email = request.lhkc_email;
            if (lhkc_email != null)
            {
                lhkc_email = lhkc_email.Trim(charsToTrim);
            }

            var lhkc_diaChi = request.lhkc_diaChi.Trim(charsToTrim);
            var lsbt_biBatDiTu = request.lsbt_biBatDiTu;
            if (lsbt_biBatDiTu != null)
            {
                lsbt_biBatDiTu = lsbt_biBatDiTu.Trim(charsToTrim);
            }

            var lsbt_thamGiaChinhTri = request.lsbt_thamGiaChinhTri;
            if (lsbt_thamGiaChinhTri != null)
            {
                lsbt_thamGiaChinhTri = lsbt_thamGiaChinhTri.Trim(charsToTrim);
            }

            var lsbt_thanNhanNuocNgoai = request.lsbt_thanNhanNuocNgoai;
            if (lsbt_thanNhanNuocNgoai != null)
            {
                lsbt_thanNhanNuocNgoai = lsbt_thanNhanNuocNgoai.Trim(charsToTrim);
            }
            Nullable<DateTime> d = null;
            if (request.id == null || request.hoTen == null || request.quocTich == null || request.ngaySinh == null || request.diDong == null || request.cccd == null || request.noiCapCCCD == null
                || request.ngayCapCCCD == null || request.ngayHetHanCCCD == null || request.noiSinh == null || request.queQuan == null || request.thuongTru == null || request.ngheNghiep == null
                || request.chucVuHienTai == null || request.congViecChinh == null || request.coQuanTuyenDung == null || request.idDanhMucHonNhan == 0 || request.idDanToc <= 0 || request.idNgachCongChuc <= 0
                || request.idTonGiao <= 0 || request.lhkc_hoTen == null || request.lhkc_quanHe == null || request.lhkc_dienThoai == null || request.lhkc_diaChi == null || request.lhkc_maNhanVien == null
                || request.yt_maNhanVien == null || request.lsbt_maNhanVien == null)
            {
                return 0;
            }
            else
            {

                var nhanVien = new NhanVien()
                {
                    maNhanVien = request.id,
                    hoTen = hoTen,
                    quocTich = quocTich,
                    ngaySinh = request.ngaySinh.AddHours(1),
                    gioiTinh = request.gioiTinh,
                    dienThoai = request.dienThoai,
                    dienThoaiKhac = request.dienThoaiKhac,
                    diDong = request.diDong,
                    email = email,
                    facebook = facebook,
                    skype = skype,
                    maSoThue = maSoThue,
                    cccd = cccd,
                    noiCapCCCD = noiCapCCCD,
                    ngayCapCCCD = request.ngayCapCCCD,
                    ngayHetHanCCCD = request.ngayHetHanCCCD,
                    hoChieu = hoChieu,
                    noiCapHoChieu = noiCapHoChieu,
                    ngayCapHoChieu = request.ngayCapHoChieu,
                    ngayHetHanHoChieu = request.ngayHetHanHoChieu,
                    noiSinh = noiSinh,
                    queQuan = queQuan,
                    thuongTru = thuongTru,
                    tamTru = tamTru,
                    ngheNghiep = ngheNghiep,
                    chucVuHienTai = chucVuHienTai,
                    ngayTuyenDung = request.ngayTuyenDung,
                    ngayThuViec = request.ngayThuViec,
                    congViecChinh = congViecChinh,
                    ngayVaoBan = request.ngayVaoBan,
                    ngayChinhThuc = request.ngayChinhThuc,
                    coQuanTuyenDung = coQuanTuyenDung,
                    ngachCongChucNoiDung = ngachCongChucNoiDung,
                    vaoDang = request.vaoDang,
                    ngayVaoDang = request.ngayVaoDang,
                    ngayVaoDangChinhThuc = request.ngayVaoDangChinhThuc,
                    quanNhan = request.quanNhan,
                    ngayNhapNgu = request.ngayNhapNgu,
                    ngayXuatNgu = request.ngayXuatNgu,
                    quanHamCaoNhat = quanHamCaoNhat,
                    danhHieuCaoNhat = danhHieuCaoNhat,
                    ngayVaoDoan = request.ngayVaoDoan,
                    noiThamGia = noiThamGia,
                    laThuongBinh = request.laThuongBinh,
                    laConChinhSach = request.laConChinhSach,
                    thuongBinh = thuongBinh,
                    conChinhSach = conChinhSach,
                    bhxh = bhxh,
                    bhyt = bhyt,
                    atm = atm,
                    nganHang = nganHang,
                    trangThaiLaoDong = request.trangThaiLaoDong,
                    ngayNghiViec = request.ngayNghiViec,
                    lyDoNghiViec = lyDoNghiViec,
                    tinhChatLaoDong = request.tinhChatLaoDong,
                    idDanhMucHonNhan = request.idDanhMucHonNhan,
                    idDanToc = request.idDanToc,
                    idTonGiao = request.idTonGiao,
                    idNgachCongChuc = request.idNgachCongChuc,
                    YTe = new YTe()
                    {
                        nhomMau = yt_nhomMau,
                        chieuCao = request.yt_chieuCao,
                        canNang = request.yt_canNang,
                        tinhTrangSucKhoe = yt_tinhTrangSucKhoe,
                        benhTat = yt_benhTat,
                        luuY = yt_luuY,
                        khuyetTat = request.yt_khuyetTat,
                        maNhanVien = request.yt_maNhanVien
                    },
                    LichSuBanThan = new LichSuBanThan()
                    {
                        biBatDiTu = lsbt_biBatDiTu,
                        thamGiaChinhTri = lsbt_thamGiaChinhTri,
                        thanNhanNuocNgoai = lsbt_thanNhanNuocNgoai,
                        maNhanVien = request.lsbt_maNhanVien
                    },
                    LienHeKhanCap = new LienHeKhanCap()
                    {
                        hoTen = lhkc_hoTen,
                        quanHe = lhkc_quanHe,
                        dienThoai = request.lhkc_dienThoai,
                        email = lhkc_email,
                        diaChi = lhkc_diaChi,
                        maNhanVien = request.lhkc_maNhanVien,
                    }

                };

                _context.nhanViens.Add(nhanVien);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }

        }

        public async Task<int> DeleteImage(string maNhanVien)
        {
            var nhanVien = await _context.nhanViens.FindAsync(maNhanVien);
            if (nhanVien == null)
            {
                return 0;
            }
            else
            {
                await _storageService.DeleteFileAsync(nhanVien.anh);

                nhanVien.anh = null;
                _context.nhanViens.Update(nhanVien);

                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }


        }

        public async Task<int> Update(string id, NhanVienUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var hoTen = request.hoTen.Trim(charsToTrim);
            var quocTich = request.quocTich.Trim(charsToTrim);

            var email = request.email;
            if (email != null)
            {
                email = email.Trim(charsToTrim);
            }

            var facebook = request.facebook;
            if (facebook != null)
            {
                facebook = facebook.Trim(charsToTrim);
            }

            var skype = request.skype;
            if (skype != null)
            {
                skype = skype.Trim(charsToTrim);
            }

            var maSoThue = request.maSoThue;
            if (maSoThue != null)
            {
                maSoThue = maSoThue.Trim(charsToTrim);
            }
            var cccd = request.cccd.Trim(charsToTrim);
            var noiCapCCCD = request.noiCapCCCD.Trim(charsToTrim);

            var hoChieu = request.hoChieu;
            if (hoChieu != null)
            {
                hoChieu = hoChieu.Trim(charsToTrim);
            }
            var noiCapHoChieu = request.noiCapHoChieu;
            if (noiCapHoChieu != null)
            {
                noiCapHoChieu = noiCapHoChieu.Trim(charsToTrim);
            }
            var noiSinh = request.noiSinh.Trim(charsToTrim);
            var queQuan = request.queQuan.Trim(charsToTrim);
            var thuongTru = request.thuongTru.Trim(charsToTrim);

            var tamTru = request.tamTru;
            if (tamTru != null)
            {
                tamTru = noiCapHoChieu.Trim(charsToTrim);
            }

            var ngheNghiep = request.ngheNghiep.Trim(charsToTrim);
            var chucVuHienTai = request.chucVuHienTai.Trim(charsToTrim);
            var congViecChinh = request.congViecChinh.Trim(charsToTrim);
            var coQuanTuyenDung = request.coQuanTuyenDung.Trim(charsToTrim);

            var ngachCongChucNoiDung = request.ngachCongChucNoiDung;
            if (ngachCongChucNoiDung != null)
            {
                ngachCongChucNoiDung = ngachCongChucNoiDung.Trim(charsToTrim);
            }

            var quanHamCaoNhat = request.quanHamCaoNhat;
            if (quanHamCaoNhat != null)
            {
                quanHamCaoNhat = quanHamCaoNhat.Trim(charsToTrim);
            }

            var danhHieuCaoNhat = request.danhHieuCaoNhat;
            if (danhHieuCaoNhat != null)
            {
                danhHieuCaoNhat = danhHieuCaoNhat.Trim(charsToTrim);
            }

            var noiThamGia = request.noiThamGia;
            if (noiThamGia != null)
            {
                noiThamGia = noiThamGia.Trim(charsToTrim);
            }

            var thuongBinh = request.thuongBinh;
            if (thuongBinh != null)
            {
                thuongBinh = thuongBinh.Trim(charsToTrim);
            }

            var conChinhSach = request.conChinhSach;
            if (conChinhSach != null)
            {
                conChinhSach = conChinhSach.Trim(charsToTrim);
            }

            var bhxh = request.bhxh;
            if (bhxh != null)
            {
                bhxh = bhxh.Trim(charsToTrim);
            }

            var bhyt = request.bhyt;
            if (bhyt != null)
            {
                bhyt = bhyt.Trim(charsToTrim);
            }

            var atm = request.atm;
            if (atm != null)
            {
                atm = atm.Trim(charsToTrim);
            }

            var nganHang = request.nganHang;
            if (nganHang != null)
            {
                nganHang = nganHang.Trim(charsToTrim);
            }

            var lyDoNghiViec = request.lyDoNghiViec;
            if (lyDoNghiViec != null)
            {
                lyDoNghiViec = lyDoNghiViec.Trim(charsToTrim);
            }

            var yt_nhomMau = request.yt_nhomMau;
            if (yt_nhomMau != null)
            {
                yt_nhomMau = yt_nhomMau.Trim(charsToTrim);
            }

            var yt_tinhTrangSucKhoe = request.yt_tinhTrangSucKhoe;
            if (yt_tinhTrangSucKhoe != null)
            {
                yt_tinhTrangSucKhoe = yt_tinhTrangSucKhoe.Trim(charsToTrim);
            }

            var yt_benhTat = request.yt_benhTat;
            if (yt_benhTat != null)
            {
                yt_benhTat = yt_benhTat.Trim(charsToTrim);
            }

            var yt_luuY = request.yt_luuY;
            if (yt_luuY != null)
            {
                yt_luuY = yt_luuY.Trim(charsToTrim);
            }

            var lhkc_hoTen = request.lhkc_hoTen.Trim(charsToTrim);
            var lhkc_quanHe = request.lhkc_quanHe.Trim(charsToTrim);

            var lhkc_email = request.lhkc_email;
            if (lhkc_email != null)
            {
                lhkc_email = lhkc_email.Trim(charsToTrim);
            }

            var lhkc_diaChi = request.lhkc_diaChi.Trim(charsToTrim);
            var lsbt_biBatDiTu = request.lsbt_biBatDiTu;
            if (lsbt_biBatDiTu != null)
            {
                lsbt_biBatDiTu = lsbt_biBatDiTu.Trim(charsToTrim);
            }

            var lsbt_thamGiaChinhTri = request.lsbt_thamGiaChinhTri;
            if (lsbt_thamGiaChinhTri != null)
            {
                lsbt_thamGiaChinhTri = lsbt_thamGiaChinhTri.Trim(charsToTrim);
            }

            var lsbt_thanNhanNuocNgoai = request.lsbt_thanNhanNuocNgoai;
            if (lsbt_thanNhanNuocNgoai != null)
            {
                lsbt_thanNhanNuocNgoai = lsbt_thanNhanNuocNgoai.Trim(charsToTrim);
            }

            var nhanVien = await _context.nhanViens.FindAsync(id);

            if (nhanVien == null || request.hoTen == null || request.quocTich == null || request.ngaySinh == null || request.diDong == null || request.cccd == null || request.noiCapCCCD == null
                || request.ngayCapCCCD == null || request.ngayHetHanCCCD == null || request.noiSinh == null || request.queQuan == null || request.thuongTru == null || request.ngheNghiep == null
                || request.chucVuHienTai == null || request.congViecChinh == null || request.coQuanTuyenDung == null || request.idDanhMucHonNhan == 0 || request.idDanToc <= 0 || request.idNgachCongChuc <= 0
                || request.idTonGiao <= 0 || request.lhkc_hoTen == null || request.lhkc_quanHe == null || request.lhkc_dienThoai == null || request.lhkc_diaChi == null)
            {
                return 0;
            }
            else
            {
                if (request.trangThaiLaoDong == false)
                {
                    var id_lhkc = await _context.lienHeKhanCaps.Where(x => x.maNhanVien == id).FirstOrDefaultAsync();
                    var lhkc = await _context.lienHeKhanCaps.FindAsync(id_lhkc.id);

                    var id_yt = await _context.yTes.Where(x => x.maNhanVien == id).FirstOrDefaultAsync();
                    var yt = await _context.yTes.FindAsync(id_yt.id);

                    var id_lsbt = await _context.lichSuBanThans.Where(x => x.maNhanVien == id).FirstOrDefaultAsync();
                    var lsbt = await _context.lichSuBanThans.FindAsync(id_lsbt.id);
                    nhanVien.hoTen = hoTen;
                    nhanVien.quocTich = quocTich;
                    nhanVien.ngaySinh = request.ngaySinh;
                    nhanVien.gioiTinh = request.gioiTinh;
                    nhanVien.dienThoai = request.dienThoai;
                    nhanVien.dienThoaiKhac = request.dienThoaiKhac;
                    nhanVien.diDong = request.diDong;
                    nhanVien.email = email;
                    nhanVien.facebook = facebook;
                    nhanVien.skype = skype;
                    nhanVien.maSoThue = maSoThue;
                    nhanVien.cccd = cccd;
                    nhanVien.noiCapCCCD = noiCapCCCD;
                    nhanVien.ngayCapCCCD = request.ngayCapCCCD;
                    nhanVien.ngayHetHanCCCD = request.ngayHetHanCCCD;
                    nhanVien.hoChieu = hoChieu;
                    nhanVien.noiCapHoChieu = noiCapHoChieu;
                    nhanVien.ngayCapHoChieu = request.ngayCapHoChieu;
                    nhanVien.ngayHetHanHoChieu = request.ngayHetHanHoChieu;
                    nhanVien.noiSinh = noiSinh;
                    nhanVien.queQuan = queQuan;
                    nhanVien.thuongTru = thuongTru;
                    nhanVien.tamTru = tamTru;
                    nhanVien.ngheNghiep = ngheNghiep;
                    nhanVien.chucVuHienTai = chucVuHienTai;
                    nhanVien.ngayTuyenDung = request.ngayTuyenDung;
                    nhanVien.ngayThuViec = request.ngayThuViec;
                    nhanVien.congViecChinh = congViecChinh;
                    nhanVien.ngayVaoBan = request.ngayVaoBan;
                    nhanVien.ngayChinhThuc = request.ngayChinhThuc;
                    nhanVien.coQuanTuyenDung = request.coQuanTuyenDung;
                    nhanVien.ngachCongChucNoiDung = ngachCongChucNoiDung;
                    nhanVien.vaoDang = request.vaoDang;
                    nhanVien.ngayVaoDang = request.ngayVaoDang;
                    nhanVien.ngayVaoDangChinhThuc = request.ngayVaoDangChinhThuc;
                    nhanVien.quanNhan = request.quanNhan;
                    nhanVien.ngayNhapNgu = request.ngayNhapNgu;
                    nhanVien.ngayXuatNgu = request.ngayXuatNgu;
                    nhanVien.quanHamCaoNhat = quanHamCaoNhat;
                    nhanVien.danhHieuCaoNhat = danhHieuCaoNhat;
                    nhanVien.ngayVaoDoan = request.ngayVaoDoan;
                    nhanVien.noiThamGia = noiThamGia;
                    nhanVien.laThuongBinh = request.laThuongBinh;
                    nhanVien.laConChinhSach = request.laConChinhSach;
                    nhanVien.thuongBinh = thuongBinh;
                    nhanVien.conChinhSach = conChinhSach;
                    nhanVien.bhxh = bhxh;
                    nhanVien.bhyt = bhyt;
                    nhanVien.atm = atm;
                    nhanVien.nganHang = nganHang;
                    nhanVien.trangThaiLaoDong = request.trangThaiLaoDong;
                    nhanVien.ngayNghiViec = request.ngayNghiViec;
                    nhanVien.lyDoNghiViec = lyDoNghiViec;
                    nhanVien.tinhChatLaoDong = request.tinhChatLaoDong;
                    nhanVien.idDanhMucHonNhan = request.idDanhMucHonNhan;
                    nhanVien.idDanToc = request.idDanToc;
                    nhanVien.idTonGiao = request.idTonGiao;
                    nhanVien.idNgachCongChuc = request.idNgachCongChuc;
                    yt.nhomMau = yt_nhomMau;
                    yt.chieuCao = request.yt_chieuCao;
                    yt.canNang = request.yt_canNang;
                    yt.tinhTrangSucKhoe = yt_tinhTrangSucKhoe;
                    yt.benhTat = yt_benhTat;
                    yt.luuY = yt_luuY;
                    yt.khuyetTat = request.yt_khuyetTat;
                    lsbt.biBatDiTu = lsbt_biBatDiTu;
                    lsbt.thamGiaChinhTri = lsbt_thamGiaChinhTri;
                    lsbt.thanNhanNuocNgoai = lsbt_thanNhanNuocNgoai;
                    lhkc.hoTen = hoTen;
                    lhkc.quanHe = lhkc_quanHe;
                    lhkc.dienThoai = request.lhkc_dienThoai;
                    lhkc.email = lhkc_email;
                    lhkc.diaChi = lhkc_diaChi;


                    var dieuChuyen = await _context.dieuChuyens.Where(x => x.maNhanVien == nhanVien.maNhanVien && x.trangThai == true).FirstOrDefaultAsync();
                    if (dieuChuyen != null)
                    {
                        dieuChuyen.trangThai = false;
                    }

                    var hopDong = await _context.hopDongs.Where(x => x.maNhanVien == nhanVien.maNhanVien && x.trangThai == true).FirstOrDefaultAsync();
                    if (hopDong != null)
                    {
                        hopDong.trangThai = false;
                        var luong = await _context.luongs.Where(x => x.maHopDong == hopDong.maHopDong && x.trangThai == true).FirstOrDefaultAsync();
                        if (luong != null)
                        {
                            luong.trangThai = false;
                        }

                    }

                    var result = await _context.SaveChangesAsync();
                    if (result == 0)
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    var id_lhkc = await _context.lienHeKhanCaps.Where(x => x.maNhanVien == id).FirstOrDefaultAsync();
                    var lhkc = await _context.lienHeKhanCaps.FindAsync(id_lhkc.id);

                    var id_yt = await _context.yTes.Where(x => x.maNhanVien == id).FirstOrDefaultAsync();
                    var yt = await _context.yTes.FindAsync(id_yt.id);

                    var id_lsbt = await _context.lichSuBanThans.Where(x => x.maNhanVien == id).FirstOrDefaultAsync();
                    var lsbt = await _context.lichSuBanThans.FindAsync(id_lsbt.id);
                    nhanVien.hoTen = hoTen;
                    nhanVien.quocTich = quocTich;
                    nhanVien.ngaySinh = request.ngaySinh;
                    nhanVien.gioiTinh = request.gioiTinh;
                    nhanVien.dienThoai = request.dienThoai;
                    nhanVien.dienThoaiKhac = request.dienThoaiKhac;
                    nhanVien.diDong = request.diDong;
                    nhanVien.email = email;
                    nhanVien.facebook = facebook;
                    nhanVien.skype = skype;
                    nhanVien.maSoThue = maSoThue;
                    nhanVien.cccd = cccd;
                    nhanVien.noiCapCCCD = noiCapCCCD;
                    nhanVien.ngayCapCCCD = request.ngayCapCCCD;
                    nhanVien.ngayHetHanCCCD = request.ngayHetHanCCCD;
                    nhanVien.hoChieu = hoChieu;
                    nhanVien.noiCapHoChieu = noiCapHoChieu;
                    nhanVien.ngayCapHoChieu = request.ngayCapHoChieu;
                    nhanVien.ngayHetHanHoChieu = request.ngayHetHanHoChieu;
                    nhanVien.noiSinh = noiSinh;
                    nhanVien.queQuan = queQuan;
                    nhanVien.thuongTru = thuongTru;
                    nhanVien.tamTru = tamTru;
                    nhanVien.ngheNghiep = ngheNghiep;
                    nhanVien.chucVuHienTai = chucVuHienTai;
                    nhanVien.ngayTuyenDung = request.ngayTuyenDung;
                    nhanVien.ngayThuViec = request.ngayThuViec;
                    nhanVien.congViecChinh = congViecChinh;
                    nhanVien.ngayVaoBan = request.ngayVaoBan;
                    nhanVien.ngayChinhThuc = request.ngayChinhThuc;
                    nhanVien.coQuanTuyenDung = coQuanTuyenDung;
                    nhanVien.ngachCongChucNoiDung = ngachCongChucNoiDung;
                    nhanVien.vaoDang = request.vaoDang;
                    nhanVien.ngayVaoDang = request.ngayVaoDang;
                    nhanVien.ngayVaoDangChinhThuc = request.ngayVaoDangChinhThuc;
                    nhanVien.quanNhan = request.quanNhan;
                    nhanVien.ngayNhapNgu = request.ngayNhapNgu;
                    nhanVien.ngayXuatNgu = request.ngayXuatNgu;
                    nhanVien.quanHamCaoNhat = quanHamCaoNhat;
                    nhanVien.danhHieuCaoNhat = danhHieuCaoNhat;
                    nhanVien.ngayVaoDoan = request.ngayVaoDoan;
                    nhanVien.noiThamGia = noiThamGia;
                    nhanVien.laThuongBinh = request.laThuongBinh;
                    nhanVien.laConChinhSach = request.laConChinhSach;
                    nhanVien.thuongBinh = thuongBinh;
                    nhanVien.conChinhSach = conChinhSach;
                    nhanVien.bhxh = bhxh;
                    nhanVien.bhyt = bhyt;
                    nhanVien.atm = atm;
                    nhanVien.nganHang = nganHang;
                    nhanVien.trangThaiLaoDong = request.trangThaiLaoDong;
                    nhanVien.ngayNghiViec = request.ngayNghiViec;
                    nhanVien.lyDoNghiViec = lyDoNghiViec;
                    nhanVien.tinhChatLaoDong = request.tinhChatLaoDong;
                    nhanVien.idDanhMucHonNhan = request.idDanhMucHonNhan;
                    nhanVien.idDanToc = request.idDanToc;
                    nhanVien.idTonGiao = request.idTonGiao;
                    nhanVien.idNgachCongChuc = request.idNgachCongChuc;
                    yt.nhomMau = yt_nhomMau;
                    yt.chieuCao = request.yt_chieuCao;
                    yt.canNang = request.yt_canNang;
                    yt.tinhTrangSucKhoe = yt_tinhTrangSucKhoe;
                    yt.benhTat = yt_benhTat;
                    yt.luuY = yt_luuY;
                    yt.khuyetTat = request.yt_khuyetTat;
                    lsbt.biBatDiTu = lsbt_biBatDiTu;
                    lsbt.thamGiaChinhTri = lsbt_thamGiaChinhTri;
                    lsbt.thanNhanNuocNgoai = lsbt_thanNhanNuocNgoai;
                    lhkc.hoTen = hoTen;
                    lhkc.quanHe = lhkc_quanHe;
                    lhkc.dienThoai = request.lhkc_dienThoai;
                    lhkc.email = lhkc_email;
                    lhkc.diaChi = lhkc_diaChi;

                    var result = await _context.SaveChangesAsync();
                    if (result == 0)
                        return 0;
                    else
                        return 1;
                }
            }
        }

        public async Task<List<NhanVienViewModel>> GetAll()
        {
            //Phòng Ban
            var queryPb = from dc in _context.dieuChuyens
                          join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                          where dc.trangThai == true
                          select new { dc, pb, phongBan = pb.tenPhongBan };

            var query = from nv in _context.nhanViens

                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join d in queryPb on nv.maNhanVien equals d.dc.maNhanVien into x
                        from xx in x.DefaultIfEmpty()
                            //join q in queryPb on nv.maNhanVien equals q.dc.maNhanVien

                        select new { nv, tc, dt, hn, tg, ncc, x, xx };
            if (query == null)
            {
                return null;
            }
            else
            {
                //var size = query.ToList();
                //var list = new List<NhanVienViewModel>();

                //foreach (var item in query)
                //{
                //    var ngayVaoDang = checkDate(item.nv.ngayVaoDang);
                //    list.Add(new NhanVienViewModel { ngayVaoDang = ngayVaoDang });
                //}

                var data = await query.Select(x => new NhanVienViewModel()
                {
                    id = x.nv.maNhanVien,
                    hoTen = x.nv.hoTen,
                    quocTich = x.nv.quocTich,
                    ngaySinh = DateTime.SpecifyKind(x.nv.ngaySinh, DateTimeKind.Utc),
                    gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                    dienThoai = x.nv.dienThoai,
                    dienThoaiKhac = x.nv.dienThoaiKhac,
                    diDong = x.nv.diDong,
                    email = x.nv.email,
                    facebook = x.nv.facebook,
                    skype = x.nv.skype,
                    maSoThue = x.nv.maSoThue,
                    cccd = x.nv.cccd,
                    noiCapCCCD = x.nv.noiCapCCCD,
                    ngayCapCCCD = DateTime.SpecifyKind(x.nv.ngayCapCCCD, DateTimeKind.Utc),
                    ngayHetHanCCCD = DateTime.SpecifyKind(x.nv.ngayHetHanCCCD, DateTimeKind.Utc),
                    hoChieu = x.nv.hoChieu,
                    noiCapHoChieu = x.nv.noiCapHoChieu,
                    ngayCapHoChieu = x.nv.ngayCapHoChieu,
                    ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                    noiSinh = x.nv.noiSinh,
                    queQuan = x.nv.queQuan,
                    thuongTru = x.nv.thuongTru,
                    tamTru = x.nv.tamTru,
                    ngheNghiep = x.nv.ngheNghiep,
                    chucVuHienTai = x.nv.chucVuHienTai,
                    ngayTuyenDung = x.nv.ngayTuyenDung,
                    ngayThuViec = x.nv.ngayThuViec,
                    congViecChinh = x.nv.congViecChinh,
                    ngayVaoBan = x.nv.ngayVaoBan,
                    ngayChinhThuc = x.nv.ngayChinhThuc,
                    coQuanTuyenDung = x.nv.coQuanTuyenDung,
                    ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                    ngayVaoDang = x.nv.ngayVaoDang,
                    ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                    ngayNhapNgu = x.nv.ngayNhapNgu,
                    ngayXuatNgu = x.nv.ngayXuatNgu,
                    quanHamCaoNhat = x.nv.quanHamCaoNhat,
                    danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                    ngayVaoDoan = x.nv.ngayVaoDoan.Value,
                    noiThamGia = x.nv.noiThamGia,
                    laThuongBinh = x.nv.laThuongBinh,
                    laConChinhSach = x.nv.laConChinhSach,
                    bhxh = x.nv.bhxh,
                    bhyt = x.nv.bhyt,
                    atm = x.nv.atm,
                    nganHang = x.nv.nganHang,
                    trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                    ngayNghiViec = x.nv.ngayNghiViec,
                    tinhChatLaoDong = x.tc.tenTinhChat,
                    DanhMucHonNhan = x.hn.tenDanhMuc,
                    DanToc = x.dt.tenDanhMuc,
                    TonGiao = x.tg.tenDanhMuc,
                    NgachCongChuc = x.ncc.tenNgach,
                    lyDoNghiViec = x.nv.lyDoNghiViec,
                    anh = x.nv.anh,
                    tenPhongBan = x.xx.phongBan ?? String.Empty
                }).ToListAsync();
                foreach (var item in data)
                {
                    DateTime temp = item.ngayVaoDang.Value;
                    if (temp != null)
                    {
                        item.ngayVaoDang = DateTime.SpecifyKind(temp, DateTimeKind.Utc);

                    }
                    DateTime temp2 = item.ngayVaoDoan.Value;
                    if (temp2 != null)
                    {
                        item.ngayVaoDoan = DateTime.SpecifyKind(temp2, DateTimeKind.Utc);

                    }
                    DateTime temp3 = item.ngayNhapNgu.Value;
                    if (temp3 != null)
                    {
                        item.ngayNhapNgu = DateTime.SpecifyKind(temp3, DateTimeKind.Utc);

                    }
                    DateTime temp4 = item.ngayXuatNgu.Value;
                    if (temp4 != null)
                    {
                        item.ngayXuatNgu = DateTime.SpecifyKind(temp4, DateTimeKind.Utc);

                    }
                    DateTime temp5 = item.ngayNghiViec.Value;
                    if (temp5 != null)
                    {
                        item.ngayNghiViec = DateTime.SpecifyKind(temp5, DateTimeKind.Utc);

                    }
                    DateTime temp6 = item.ngayVaoDangChinhThuc.Value;
                    if (temp6 != null)
                    {
                        item.ngayVaoDangChinhThuc = DateTime.SpecifyKind(temp6, DateTimeKind.Utc);

                    }
                }
                return data;
            }
        }

        public DateTime? checkDate(DateTime? date)
        {
            if (date == null)
                return null;
            var x = DateTime.SpecifyKind(date.Value, DateTimeKind.Utc);
            return x;
        }


        public async Task<List<MaTenViewModel>> GetAllMaVaTen()
        {
            var query = from nv in _context.nhanViens
                        join dc in _context.dieuChuyens on nv.maNhanVien equals dc.maNhanVien
                        where dc.trangThai == true
                        select new { nv, dc };
            var data = await query.Select(x => new MaTenViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen
            }).ToListAsync();
            return data;
        }
        public async Task<List<MaTenViewModel>> GetAllNhanVienAccount()
        {
            var query = from nv in _context.nhanViens
                        join dc in _context.dieuChuyens on nv.maNhanVien equals dc.maNhanVien
                        where dc.trangThai == true && dc.idPhongBan == 1
                        select new { nv, dc };
            var data = await query.Select(x => new MaTenViewModel()
            {
                id = x.nv.maNhanVien,
                hoTen = x.nv.hoTen
            }).ToListAsync();
            return data;
        }

        public async Task<List<NhanVienViewModel>> GetAllNVNghi()
        {
            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        where nv.trangThaiLaoDong == false
                        select new { nv, tc, dt, hn, tg, ncc };
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new NhanVienViewModel()
                {
                    id = x.nv.maNhanVien,
                    hoTen = x.nv.hoTen,
                    quocTich = x.nv.quocTich,
                    ngaySinh = x.nv.ngaySinh,
                    gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                    dienThoai = x.nv.dienThoai,
                    dienThoaiKhac = x.nv.dienThoaiKhac,
                    diDong = x.nv.diDong,
                    email = x.nv.email,
                    facebook = x.nv.facebook,
                    skype = x.nv.skype,
                    maSoThue = x.nv.maSoThue,
                    cccd = x.nv.cccd,
                    noiCapCCCD = x.nv.noiCapCCCD,
                    ngayCapCCCD = x.nv.ngayCapCCCD,
                    ngayHetHanCCCD = x.nv.ngayHetHanCCCD,
                    hoChieu = x.nv.hoChieu,
                    noiCapHoChieu = x.nv.noiCapHoChieu,
                    ngayCapHoChieu = x.nv.ngayCapHoChieu,
                    ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                    noiSinh = x.nv.noiSinh,
                    queQuan = x.nv.queQuan,
                    thuongTru = x.nv.thuongTru,
                    tamTru = x.nv.tamTru,
                    ngheNghiep = x.nv.ngheNghiep,
                    chucVuHienTai = x.nv.chucVuHienTai,
                    ngayTuyenDung = x.nv.ngayTuyenDung,
                    ngayThuViec = x.nv.ngayThuViec,
                    congViecChinh = x.nv.congViecChinh,
                    ngayVaoBan = x.nv.ngayVaoBan,
                    ngayChinhThuc = x.nv.ngayChinhThuc,
                    coQuanTuyenDung = x.nv.coQuanTuyenDung,
                    ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                    ngayVaoDang = x.nv.ngayVaoDang,
                    ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                    ngayNhapNgu = x.nv.ngayNhapNgu,
                    ngayXuatNgu = x.nv.ngayXuatNgu,
                    quanHamCaoNhat = x.nv.quanHamCaoNhat,
                    danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                    ngayVaoDoan = x.nv.ngayVaoDoan,
                    noiThamGia = x.nv.noiThamGia,
                    laThuongBinh = x.nv.laThuongBinh,
                    laConChinhSach = x.nv.laConChinhSach,
                    bhxh = x.nv.bhxh,
                    bhyt = x.nv.bhyt,
                    atm = x.nv.atm,
                    nganHang = x.nv.nganHang,
                    trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                    ngayNghiViec = x.nv.ngayNghiViec,
                    anh = x.nv.anh,
                    tinhChatLaoDong = x.tc.tenTinhChat,
                    DanhMucHonNhan = x.hn.tenDanhMuc,
                    DanToc = x.dt.tenDanhMuc,
                    TonGiao = x.tg.tenDanhMuc,
                    NgachCongChuc = x.ncc.tenNgach,
                    lyDoNghiViec = x.nv.lyDoNghiViec

                }).ToListAsync();
                return data;
            }
        }


        public async Task<NhanVienDetailViewModel> GetByMaNV(string maNhanVien)
        {
            var nhanVien = await _context.nhanViens.FindAsync(maNhanVien);
            if (nhanVien == null)
            {
                return null;
            }
            else
            {
                //List Khen Thưởng
                var queryKt = from nv in _context.nhanViens
                              join ktkl in _context.khenThuongKyLuats on nv.maNhanVien equals ktkl.maNhanVien
                              join dmktkl in _context.danhMucKhenThuongKyLuats on ktkl.idDanhMucKhenThuong equals dmktkl.id
                              where ktkl.maNhanVien == maNhanVien && ktkl.loai == true
                              select new { ktkl, dmktkl };

                var dataKt = await queryKt.Select(x => new KhenThuongViewModel()
                {
                    id = x.ktkl.id,
                    ktklDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                    ktklLyDo = x.ktkl.lyDo,
                    ktklNoiDung = x.ktkl.noiDung,
                    ktklloai = x.ktkl.loai == true ? "Khen Thưởng" : "Kỷ Luật"
                }).ToListAsync();

                //List Kỷ Luật
                var queryKl = from nv in _context.nhanViens
                              join ktkl in _context.khenThuongKyLuats on nv.maNhanVien equals ktkl.maNhanVien
                              join dmktkl in _context.danhMucKhenThuongKyLuats on ktkl.idDanhMucKhenThuong equals dmktkl.id
                              where ktkl.maNhanVien == maNhanVien && ktkl.loai == false
                              select new { ktkl, dmktkl };

                var dataKl = await queryKl.Select(x => new KyLuatViewModel()
                {
                    id = x.ktkl.id,
                    ktklDanhMucKhenThuong = x.dmktkl.tenDanhMuc,
                    ktklLyDo = x.ktkl.lyDo,
                    ktklNoiDung = x.ktkl.noiDung,
                    ktklloai = x.ktkl.loai == true ? "Khen Thưởng" : "Kỷ Luật"
                }).ToListAsync();

                //List Điều Chuyển
                var queryDc = from nv in _context.nhanViens
                              join dc in _context.dieuChuyens on nv.maNhanVien equals dc.maNhanVien

                              join pb in _context.danhMucPhongBans on dc.idPhongBan equals pb.id
                              join to in _context.danhMucTos on dc.to equals to.idTo
                              where dc.maNhanVien == maNhanVien
                              select new { dc, pb, to };

                var dataDc = await queryDc.Select(x => new DieuChuyenViewModel()
                {
                    id = x.dc.id,
                    dcNgayHieuLuc = x.dc.ngayHieuLuc,
                    dcPhong = x.pb.tenPhongBan,
                    dcTo = x.to.tenTo,
                    dcChiTiet = x.dc.chiTiet,
                    trangThai = x.dc.trangThai == true ? "Kích hoạt" : "Vô hiệu"
                }).ToListAsync();

                //List Lương
                var queryL = from nv in _context.nhanViens
                             join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                             join l in _context.luongs on hd.maHopDong equals l.maHopDong
                             join dmnl in _context.danhMucNhomLuongs on l.idNhomLuong equals dmnl.id
                             where hd.maHopDong == l.maHopDong && nv.maNhanVien == maNhanVien
                             select new { hd, l, dmnl };

                var dataL = await queryL.Select(x => new LuongViewModel()
                {
                    id = x.l.id,
                    maHopDong = x.l.maHopDong,
                    nhomLuong = x.dmnl.tenNhomLuong,
                    heSoLuong = x.l.heSoLuong,
                    bacLuong = x.l.bacLuong,
                    luongCoBan = x.l.luongCoBan,
                    phuCapTrachNhiem = x.l.phuCapTrachNhiem,
                    phuCapKhac = x.l.phuCapKhac,
                    tongLuong = x.l.tongLuong,
                    thoiHanLenLuong = x.l.thoiHanLenLuong,
                    ngayHieuLuc = x.l.ngayHieuLuc,
                    ngayKetThuc = x.l.ngayKetThuc,
                    trangThai = x.l.trangThai == true ? "Kích hoạt" : "Vô hiệu"
                }).Distinct().ToListAsync();


                //List Hợp Đồng
                var queryHd = from nv in _context.nhanViens
                              join hd in _context.hopDongs on nv.maNhanVien equals hd.maNhanVien
                              join lhd in _context.danhMucLoaiHopDongs on hd.idLoaiHopDong equals lhd.id
                              join dmcd in _context.danhMucChucDanhs on hd.idChucDanh equals dmcd.id
                              join dmcv in _context.danhMucChucVus on hd.idChucVu equals dmcv.id
                              where nv.maNhanVien == maNhanVien
                              select new { hd, lhd, dmcd, dmcv };

                var dataHd = await queryHd.Select(x => new HopDongViewModel()
                {
                    id = x.hd.maHopDong,
                    idLoaiHopDong = x.lhd.tenLoaiHopDong,
                    idChucDanh = x.dmcd.tenChucDanh,
                    idChucVu = x.dmcv.tenChucVu,
                    hdHopDongTuNgay = x.hd.hopDongTuNgay,
                    hdHopDongDenNgay = x.hd.hopDongDenNgay,
                    hdGhiChu = x.hd.ghiChu,
                    trangThai = x.hd.trangThai == true ? "Kích hoạt" : "Vô hiệu",

                }).Distinct().ToListAsync();

                //List Trình Độ Văn Hóa
                var queryTdvh = from nv in _context.nhanViens
                                join tdvh in _context.trinhDoVanHoas on nv.maNhanVien equals tdvh.maNhanVien
                                join dmcm in _context.danhMucChuyenMons on tdvh.idChuyenMon equals dmcm.id
                                join dmtd in _context.danhMucTrinhDos on tdvh.idTrinhDo equals dmtd.id
                                join htdt in _context.hinhThucDaoTaos on tdvh.idHinhThucDaoTao equals htdt.id
                                where tdvh.maNhanVien == maNhanVien
                                select new { tdvh, dmcm, dmtd, htdt };

                var dataTdvh = await queryTdvh.Select(x => new TrinhDoVanHoaViewModel()
                {
                    id = x.tdvh.id,
                    tdvhTenTruong = x.tdvh.tenTruong,
                    tdvhChuyenMon = x.dmcm.tenChuyenMon,
                    tdvhTrinhDo = x.dmtd.tenTrinhDo,
                    tdvhtuThoiGian = x.tdvh.tuThoiGian,
                    tdvhdenThoiGian = x.tdvh.denThoiGian,
                    tdvhHinhThucDaoTao = x.htdt.tenHinhThuc
                }).ToListAsync();

                //List Ngoại Ngữ
                var queryNn = from nv in _context.nhanViens
                              join nn in _context.ngoaiNgus on nv.maNhanVien equals nn.maNhanVien
                              join dmnn in _context.danhMucNgoaiNgus on nn.idDanhMucNgoaiNgu equals dmnn.id
                              where nv.maNhanVien == maNhanVien
                              select new { nn, dmnn };

                var dataNn = await queryNn.Select(x => new NgoaiNguViewModel()
                {
                    id = x.nn.id,
                    nnDanhMucNgoaiNgu = x.dmnn.tenDanhMuc,
                    nnNgayCap = x.nn.ngayCap,
                    nnNoiCap = x.nn.noiCap,
                    nnTrinhDo = x.nn.trinhDo
                }).ToListAsync();

                //List Người Thân
                var queryNt = from nv in _context.nhanViens
                              join nt in _context.nguoiThans on nv.maNhanVien equals nt.maNhanVien
                              join dmnt in _context.danhMucNguoiThans on nt.idDanhMucNguoiThan equals dmnt.id
                              where nt.maNhanVien == maNhanVien
                              select new { nt, dmnt };

                var dataNt = await queryNt.Select(x => new NguoiThanViewModel()
                {
                    id = x.nt.id,
                    ntTenNguoiThan = x.nt.tenNguoiThan,
                    ntGioiTinh = x.nt.gioiTinh == true ? "Nam" : "Nữ",
                    ntNgaySinh = x.nt.ngaySinh,
                    ntQuanHe = x.nt.quanHe,
                    ntNgheNghiep = x.nt.ngheNghiep,
                    ntDiaChi = x.nt.diaChi,
                    ntDienThoai = x.nt.dienThoai,
                    ntKhac = x.nt.khac
                }).ToListAsync();
                //List Detail Nhân Viên
                var query = from nv in _context.nhanViens
                            join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                            join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                            join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                            join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                            join lhkc in _context.lienHeKhanCaps on nv.maNhanVien equals lhkc.maNhanVien
                            join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                            join yt in _context.yTes on nv.maNhanVien equals yt.maNhanVien
                            join lsbt in _context.lichSuBanThans on nv.maNhanVien equals lsbt.maNhanVien

                            where nv.maNhanVien == maNhanVien
                            select new
                            {
                                nv,
                                tc,
                                dt,
                                hn,
                                tg,
                                ncc,
                                lhkc,
                                yt,
                                lsbt
                            };
                var data = await query.Select(x => new NhanVienDetailViewModel()
                {
                    id = x.nv.maNhanVien,
                    hoTen = x.nv.hoTen,
                    quocTich = x.nv.quocTich,
                    ngaySinh = x.nv.ngaySinh,
                    gioiTinh = x.nv.gioiTinh == true ? "Nam" : "Nữ",
                    noiSinh = x.nv.noiSinh,
                    queQuan = x.nv.queQuan,
                    thuongTru = x.nv.thuongTru,
                    tamTru = x.nv.tamTru,
                    atm = x.nv.atm,
                    nganHang = x.nv.nganHang,
                    idDanToc = x.dt.id,
                    danToc = x.dt.tenDanhMuc,
                    idTonGiao = x.tg.id,
                    tonGiao = x.tg.tenDanhMuc,
                    maSoThue = x.nv.maSoThue,
                    idHonNhan = x.hn.id,
                    honNhan = x.hn.tenDanhMuc,
                    cccd = x.nv.cccd,
                    noiCapCCCD = x.nv.noiCapCCCD,
                    ngayCapCCCD = x.nv.ngayCapCCCD,
                    ngayHetHanCCCD = x.nv.ngayHetHanCCCD,
                    hoChieu = x.nv.hoChieu,
                    noiCapHoChieu = x.nv.noiCapHoChieu,
                    ngayCapHoChieu = x.nv.ngayCapHoChieu,
                    ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                    dienThoai = x.nv.dienThoai,
                    dienThoaiKhac = x.nv.dienThoaiKhac,
                    diDong = x.nv.diDong,
                    email = x.nv.email,
                    facebook = x.nv.facebook,
                    skype = x.nv.skype,
                    idLhkt = x.lhkc.id,
                    lhkcHoTen = x.lhkc.hoTen,
                    lhkcQuanHe = x.lhkc.quanHe,
                    lhkcDienThoai = x.lhkc.dienThoai,
                    lhkcEmail = x.lhkc.email,
                    lhkcDiaChi = x.lhkc.diaChi,
                    ngheNghiep = x.nv.ngheNghiep,
                    coQuanTuyenDung = x.nv.coQuanTuyenDung,
                    chucVuHienTai = x.nv.chucVuHienTai,
                    trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc" : "Đã nghỉ việc",
                    idTinhChatLaoDong = x.tc.id,
                    tinhChatLaoDong = x.tc.tenTinhChat,
                    lyDoNghiViec = x.nv.lyDoNghiViec,
                    ngayNghiViec = x.nv.ngayNghiViec,
                    ngayTuyenDung = x.nv.ngayTuyenDung,
                    ngayThuViec = x.nv.ngayThuViec,
                    congViecChinh = x.nv.congViecChinh,
                    ngayVaoBan = x.nv.ngayVaoBan,
                    ngayChinhThuc = x.nv.ngayChinhThuc,
                    bhxh = x.nv.bhxh,
                    bhyt = x.nv.bhyt,
                    idNgachCongChuc = x.ncc.id,
                    ngachCongChuc = x.ncc.tenNgach,
                    ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                    vaoDang = x.nv.vaoDang == true ? "Có" : "Không",
                    ngayVaoDang = x.nv.ngayVaoDang,
                    ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                    ngayVaoDoan = x.nv.ngayVaoDoan,
                    noiThamGia = x.nv.noiThamGia,
                    quanNhan = x.nv.quanNhan == true ? "Có" : "Không",
                    ngayNhapNgu = x.nv.ngayNhapNgu,
                    ngayXuatNgu = x.nv.ngayXuatNgu,
                    quanHamCaoNhat = x.nv.quanHamCaoNhat,
                    danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                    thuongBinh = x.nv.thuongBinh,
                    conChinhSach = x.nv.conChinhSach,
                    idYte = x.yt.id,
                    ytNhomMau = x.yt.nhomMau,
                    ytChieuCao = x.yt.chieuCao,
                    ytCanNang = x.yt.canNang,
                    ytTinhTrangSucKhoe = x.yt.tinhTrangSucKhoe,
                    ytBenhTat = x.yt.benhTat,
                    ytLuuY = x.yt.luuY,
                    ytKhuyetTat = x.yt.khuyetTat == true ? "Có" : "Không",
                    idLichSuBanThan = x.lsbt.id,
                    biBatDitu = x.lsbt.biBatDiTu,
                    thamGiaChinhTri = x.lsbt.thamGiaChinhTri,
                    thanNhanNuocNgoai = x.lsbt.thanNhanNuocNgoai,
                    anh = x.nv.anh,
                    laConChinhSach = x.nv.laConChinhSach,
                    laThuongBinh = x.nv.laThuongBinh,
                    trinhDoVanHoas = dataTdvh,
                    hopDongs = dataHd,
                    luongs = dataL,
                    dieuChuyens = dataDc,
                    khenThuongs = dataKt,
                    ngoaiNgus = dataNn,
                    nguoiThans = dataNt,
                    kyLuats = dataKl

                }).Distinct().FirstAsync();


                return data;
            }

        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<int> UpdateImage(string id, NhanVienUpdateImageRequest request)
        {
            var anh = await _context.nhanViens.FindAsync(id);
            if (anh == null)
            {
                return 0;
            }
            else
            {
                anh.anh = await this.SaveFile(request.anh);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }


        }


    }
}
