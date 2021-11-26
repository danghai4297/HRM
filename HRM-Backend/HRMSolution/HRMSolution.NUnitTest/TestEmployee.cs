using HRMSolution.Application.Catalog.NhanViens.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestEmployee : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            SeedingData.SeedData(_context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }
        [Test, Order(1)]
        public void Employee_GetById_Success()
        {
            var result = NhanVienService.GetByMaNV("NV0001");
            Assert.That(result.Result.id, Is.EqualTo("NV0001"));
        }
        [Test, Order(2)]
        public void Employee_GetById_Failure1()
        {
            var result = NhanVienService.GetByMaNV(null);
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Employee_GetById_Failure2()
        {
            var result = NhanVienService.GetByMaNV("NV0007");
            Assert.That(result.Result, Is.EqualTo(null));
        }
        [Test, Order(3)]
        public void Employee_GetAll_Success1()
        {
            var result = NhanVienService.GetAll();
            Assert.That(result.Result.Count, Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void Employee_GetAll_Success2()
        {
            var result = NhanVienService.GetAllMaVaTen();
            Assert.That(result.Result.Count, Is.EqualTo(1));
        }
        [Test, Order(3)]
        public void Employee_GetAll_Success3()
        {
            var result = NhanVienService.GetAllNVNghi();
            Assert.That(result.Result.Count, Is.EqualTo(1));
        }
        [Test, Order(4)]
        public void Employee_Create_Success()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(5)]
        public void Employee_Create_Failure1()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = null,
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Employee_Create_Failure2()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = null,
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Employee_Create_Failure3()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = null,
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void Employee_Create_Failure4()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = null,
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Employee_Create_Failure5()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = null,
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Employee_Create_Failure6()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = null,
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Employee_Create_Failure7()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = null,
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void Employee_Create_Failure8()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = null,
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(13)]
        public void Employee_Create_Failure9()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = null,
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void Employee_Create_Failure10()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = null,
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void Employee_Create_Failure11()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = null,
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(16)]
        public void Employee_Create_Failure12()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = null,
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(17)]
        public void Employee_Create_Failure13()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = null,
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(19)]
        public void Employee_Create_Failure15()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 0,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(20)]
        public void Employee_Create_Failure16()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 0,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(21)]
        public void Employee_Create_Failure17()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 0,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(22)]
        public void Employee_Create_Failure18()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 0,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(23)]
        public void Employee_Create_Failure19()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = null,
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(24)]
        public void Employee_Create_Failure20()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = null,
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(25)]
        public void Employee_Create_Failure21()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = null,
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(26)]
        public void Employee_Create_Failure22()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = null,
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(27)]
        public void Employee_Create_Failure23()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = null,
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(28)]
        public void Employee_Create_Failure24()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = null,
                lsbt_maNhanVien = "NV0002",
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(29)]
        public void Employee_Create_Failure25()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = "NV0002",
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
                lhkc_maNhanVien = "NV0002",
                yt_maNhanVien = "NV0002",
                lsbt_maNhanVien = null,
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(30)]
        public void Employee_Create_Failure26()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                id = null,
                hoTen = null,
                quocTich = null,
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = null,
                diDong = null,
                cccd = null,
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = null,
                noiSinh = null,
                queQuan = null,
                thuongTru = null,
                tamTru = null,
                ngheNghiep = null,
                chucVuHienTai = null,
                congViecChinh = null,
                coQuanTuyenDung = null,
                trangThaiLaoDong = true,
                tinhChatLaoDong = 0,
                idDanhMucHonNhan = 0,
                idDanToc = 0,
                idTonGiao = 0,
                idNgachCongChuc = 0,
                lhkc_hoTen = null,
                lhkc_quanHe = null,
                lhkc_dienThoai = null,
                lhkc_diaChi = null,
                lhkc_maNhanVien = null,
                yt_maNhanVien = null,
                lsbt_maNhanVien = null,
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(4)]
        public void Employee_Update_Success()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
        [Test, Order(5)]
        public void Employee_Update_Failure1()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {
                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",
            };
            var result = NhanVienService.Update("NV0006", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(6)]
        public void Employee_Update_Failure2()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = null,
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(7)]
        public void Employee_Update_Failure3()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = null,
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(8)]
        public void Employee_Update_Failure4()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = null,
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(9)]
        public void Employee_Update_Failure5()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = null,
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(10)]
        public void Employee_Update_Failure6()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = null,
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(11)]
        public void Employee_Update_Failure7()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = null,
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(12)]
        public void Employee_Update_Failure8()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = null,
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(13)]
        public void Employee_Update_Failure9()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = null,
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(14)]
        public void Employee_Update_Failure10()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = null,
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(15)]
        public void Employee_Update_Failure11()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = null,
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(16)]
        public void Employee_Update_Failure12()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = null,
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(17)]
        public void Employee_Update_Failure13()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = null,
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(19)]
        public void Employee_Update_Failure15()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 0,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(20)]
        public void Employee_Update_Failure16()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 0,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(21)]
        public void Employee_Update_Failure17()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 0,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(22)]
        public void Employee_Update_Failure18()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 0,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(23)]
        public void Employee_Update_Failure19()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = null,
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(24)]
        public void Employee_Update_Failure20()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = null,
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(25)]
        public void Employee_Update_Failure21()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = null,
                lhkc_diaChi = "Hà Nội",

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }
        [Test, Order(26)]
        public void Employee_Update_Failure22()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = "Mai Trung Hiếu",
                quocTich = "Việt Nam",
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = "02466688661",
                diDong = "0961321872",
                cccd = "033098006441",
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = "Hà Nội",
                noiSinh = "Hà Nội",
                queQuan = "Hà Nội",
                thuongTru = "Hà Nội",
                tamTru = "Hà Nội",
                ngheNghiep = "Sinh viên",
                chucVuHienTai = "Nhân Viên",
                congViecChinh = "Nhân viên kinh doanh",
                coQuanTuyenDung = "Phát Đạt",
                trangThaiLaoDong = true,
                tinhChatLaoDong = 1,
                idDanhMucHonNhan = 1,
                idDanToc = 1,
                idTonGiao = 1,
                idNgachCongChuc = 1,
                lhkc_hoTen = "Mai Tiến Dũng",
                lhkc_quanHe = "Em",
                lhkc_dienThoai = "0912345678",
                lhkc_diaChi = null,

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

        [Test, Order(37)]
        public void Employee_Update_Failure26()
        {
            NhanVienUpdateRequest EmpUpdating = new NhanVienUpdateRequest()
            {

                hoTen = null,
                quocTich = null,
                ngaySinh = new DateTime(1998, 12, 21),
                gioiTinh = true,
                dienThoai = null,
                diDong = null,
                cccd = null,
                ngayCapCCCD = new DateTime(2016, 12, 21),
                ngayHetHanCCCD = new DateTime(2022, 12, 21),
                noiCapCCCD = null,
                noiSinh = null,
                queQuan = null,
                thuongTru = null,
                tamTru = null,
                ngheNghiep = null,
                chucVuHienTai = null,
                congViecChinh = null,
                coQuanTuyenDung = null,
                trangThaiLaoDong = true,
                tinhChatLaoDong = 0,
                idDanhMucHonNhan = 0,
                idDanToc = 0,
                idTonGiao = 0,
                idNgachCongChuc = 0,
                lhkc_hoTen = null,
                lhkc_quanHe = null,
                lhkc_dienThoai = null,
                lhkc_diaChi = null,

            };
            var result = NhanVienService.Update("NV0001", EmpUpdating);
            Assert.That(result.Result, Is.EqualTo(0));
        }

    }
}
