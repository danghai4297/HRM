using HRMSolution.Application.Catalog.NhanViens.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestEmployee: BaseTest
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
        [Test, Order(1)]
        public void Employee_Create_Success()
        {
            NhanVienCreateRequest EmpCreating = new NhanVienCreateRequest()
            {
                 id = "NV0002",
                 hoTen = "Mai Trung Hiếu",
                 quocTich = "Việt Nam",
                 ngaySinh = new DateTime(1998,12,21),
                gioiTinh = true,
                dienThoai = "02466688661",
                 diDong = "0961321872",
                 cccd = "033098006441",
                 ngayCapCCCD = new DateTime(2016,12,21),
                 ngayHetHanCCCD = new DateTime(2022,12,21),
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
                email = "hieumt@gmail.com",
                facebook = "fb.com/thongtin",
                skype = "skype@skype.com",
                maSoThue = "1234567890",
                bhxh = "9876543210",
                bhyt = "HN2229876543210",
                atm = "16333",
                nganHang = "Vpbank"
            };
            var result = NhanVienService.Create(EmpCreating);
            Assert.That(result.Result, Is.EqualTo(1));
        }
    }
}
