using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.Application.Catalog.DanhMucChucVus;
using HRMSolution.Application.Catalog.DanhMucChuyenMons;
using HRMSolution.Application.Catalog.DanhMucDanTocs;
using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos;
using HRMSolution.Application.Catalog.DanhMucHonNhans;
using HRMSolution.Application.Catalog.DanhMucKhenThuongKyLuats;
using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs;
using HRMSolution.Application.Catalog.DanhMucNgachCongChucs;
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus;
using HRMSolution.Application.Catalog.DanhMucNguoiThans;
using HRMSolution.Application.Catalog.DanhMucNhomLuongs;
using HRMSolution.Application.Catalog.DanhMucPhongBans;
using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs;
using HRMSolution.Application.Catalog.DanhMucTonGiaos;
using HRMSolution.Application.Catalog.DanhMucTos;
using HRMSolution.Application.Catalog.DanhMucTrinhDos;
using HRMSolution.Application.Catalog.DieuChuyens;
using HRMSolution.Application.Catalog.HopDongs;
using HRMSolution.Application.Catalog.KhenThuongKyLuats;
using HRMSolution.Application.Catalog.LichSus;
using HRMSolution.Application.Catalog.Luongs;
using HRMSolution.Application.Catalog.NgoaiNgus;
using HRMSolution.Application.Catalog.NguoiThans;
using HRMSolution.Application.Catalog.NhanViens;
using HRMSolution.Application.Catalog.TrinhDoVanHoas;
using HRMSolution.Application.Common;
using HRMSolution.Application.System.Users;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class BaseTest
    {
        protected HRMDbContext _context;
        protected UserManager<AppUser> _userManager;
        protected SignInManager<AppUser> _signInManager;
        protected IConfiguration _config;
        //IService Category
        protected IDanhMucChucDanhService danhMucChucDanhService;
        protected IDanhMucChucVuService danhMucChucVuService;
        protected IDanhMucChuyenMonService danhMucChuyenMonService;
        protected IDanhMucDanTocService danhMucDanTocService;
        protected IDanhMucHinhThucDaoTaoService danhMucHinhThucDaoTaoService;
        protected IDanhMucHonNhanService danhMucHonNhanService;
        protected IDanhMucKhenThuongKyLuatService danhMucKhenThuongKyLuatService;
        protected IDanhMucLoaiHopDongService danhMucLoaiHopDongService;
        protected IDanhMucNgachCongChucService danhMucNgachCongChucService;
        protected IDanhMucNgoaiNguService danhMucNgoaiNguService;
        protected IDanhMucNguoiThanService danhMucNguoiThanService;
        protected IDanhMucNhomLuongService danhMucNhomLuongService;
        protected IDanhMucPhongBanService danhMucPhongBanService;
        protected IDanhMucTinhChatLaoDongService danhMucTinhChatLaoDongService;
        protected IDanhMucTonGiaoService danhMucTonGiaoService;
        protected IDanhMucToService danhMucToService;
        protected IDanhMucTrinhDoService danhMucTrinhDoService;
        //IService Tranfer
        protected IDieuChuyenService DieuChuyenService;
        //IService Contract
        protected IHopDongService HopDongService;
        //IService Reward
        protected IKhenThuongKyLuatService KhenThuongKyLuatService;
        //IService History
        protected ILichSuService LichSuService;
        //IService Salary
        protected ILuongService LuongService;
        //IService Language
        protected INgoaiNguService NgoaiNguService;
        //IService Family
        protected INguoiThanService NguoiThanService;
        //IService Employee
        protected INhanVienService NhanVienService;
        //IService EducationLevel
        protected ITrinhDoVanHoaService TrinhDoVanHoaService;
        //IService User
        protected IUserService UserService;
        protected IStorageService storageService;
        protected IWebHostEnvironment webHostEnvironment;
        protected string _userContentFolder;
        public BaseTest()
        {
            DbContextOptions<HRMDbContext> dbContextOptions = new DbContextOptionsBuilder<HRMDbContext>()
                                    .UseInMemoryDatabase(databaseName: "HRM")
                                    .Options;
            _context = new HRMDbContext(dbContextOptions);
            storageService = new FileStorageService(webHostEnvironment);
            danhMucChucDanhService = new DanhMucChucDanhService(_context);
            danhMucChucVuService = new DanhMucChucVuService(_context);
            danhMucChuyenMonService = new DanhMucChuyenMonService(_context);
            danhMucDanTocService = new DanhMucDanTocService(_context);
            danhMucHinhThucDaoTaoService = new DanhMucHinhThucDaoTaoService(_context);
            danhMucHonNhanService = new DanhMucHonNhanService(_context);
            danhMucKhenThuongKyLuatService = new DanhMucKhenThuongKyLuatService(_context);
            danhMucLoaiHopDongService = new DanhMucLoaiHopDongService(_context);
            danhMucNgachCongChucService = new DanhMucNgachCongChucService(_context);
            danhMucNgoaiNguService = new DanhMucNgoaiNguService(_context);
            danhMucNguoiThanService = new DanhMucNguoiThanService(_context);
            danhMucNhomLuongService = new DanhMucNhomLuongService(_context);
            danhMucPhongBanService = new DanhMucPhongBanService(_context);
            danhMucTinhChatLaoDongService = new DanhMucTinhChatLaoDongService(_context);
            danhMucTonGiaoService = new DanhMucTonGiaoService(_context);
            danhMucToService = new DanhMucToService(_context);
            danhMucTrinhDoService = new DanhMucTrinhDoService(_context);
            TrinhDoVanHoaService = new TrinhDoVanHoaService(_context);
            NguoiThanService = new NguoiThanService(_context);
            NgoaiNguService = new NgoaiNguService(_context);
            LichSuService = new LichSuService(_context);
            UserService = new UserService(_userManager, _signInManager, _config, _context);
            LuongService = new LuongService(_context, storageService);
            DieuChuyenService = new DieuChuyenService(_context, storageService);
            KhenThuongKyLuatService = new KhenThuongKyLuatService(_context, storageService);
            HopDongService = new HopDongService(_context, storageService);
            NhanVienService = new NhanVienService(_context, storageService);
        }
    }
}
