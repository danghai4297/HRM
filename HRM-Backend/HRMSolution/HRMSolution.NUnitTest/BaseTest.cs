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
using HRMSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class BaseTest
    {
        protected HRMDbContext _context;
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
        //IService 
        protected INgoaiNguService NgoaiNguService;
        //IService 
        protected INguoiThanService NguoiThanService;

        protected INhanVienService NhanVienService;

        protected ITrinhDoVanHoaService TrinhDoVanHoaService;
        public BaseTest()
        {
            DbContextOptions<HRMDbContext> dbContextOptions = new DbContextOptionsBuilder<HRMDbContext>()
                                    .UseInMemoryDatabase(databaseName: "HRM")
                                    .Options;
            _context = new HRMDbContext(dbContextOptions);
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
        }
    }
}
