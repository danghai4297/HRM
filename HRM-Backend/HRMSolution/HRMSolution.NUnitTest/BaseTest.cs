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
        protected Application.Catalog.DanhMucChucDanhs.ITitleCategoryService danhMucChucDanhService;
        protected Application.Catalog.DanhMucChucVus.IPositionCategoryService danhMucChucVuService;
        protected ISpecializeCategoryService danhMucChuyenMonService;
        protected INationCategoryService danhMucDanTocService;
        protected IEducateCategoryService danhMucHinhThucDaoTaoService;
        protected IMarriageCategoryService danhMucHonNhanService;
        protected IRewardDisciplineCategoryService danhMucKhenThuongKyLuatService;
        protected ITypeOfContractCategoryService danhMucLoaiHopDongService;
        protected ICSRCategoryService danhMucNgachCongChucService;
        protected ILanguageCategoryService danhMucNgoaiNguService;
        protected IRelationCategoryService danhMucNguoiThanService;
        protected ISalaryGroupCategoryService danhMucNhomLuongService;
        protected IDepartmentCategoryService danhMucPhongBanService;
        protected ILaborCategoryService danhMucTinhChatLaoDongService;
        protected IReligionCategoryService danhMucTonGiaoService;
        protected INestCategoryService danhMucToService;
        protected ILevelCategoryService danhMucTrinhDoService;
        //IService Tranfer
        protected IWorkingProcessService DieuChuyenService;
        //IService Contract
        protected ILaborContractService HopDongService;
        //IService Reward
        protected IRewardDisciplineService KhenThuongKyLuatService;
        //IService History
        protected IHistoryService LichSuService;
        //IService Salary
        protected ISalaryService LuongService;
        //IService Language
        protected ILanguageService NgoaiNguService;
        //IService Family
        protected IFamilyRelationshipService NguoiThanService;
        //IService Employee
        protected IEmployeeService NhanVienService;
        //IService EducationLevel
        protected IEducationLevelService TrinhDoVanHoaService;

        protected IStorageService storageService;
        protected IWebHostEnvironment webHostEnvironment;
        protected string _userContentFolder;
        public BaseTest()
        {
            DbContextOptions<HRMDbContext> dbContextOptions = new DbContextOptionsBuilder<HRMDbContext>()
                                    .UseInMemoryDatabase(databaseName: "HRM")
                                    .Options;
            _context = new HRMDbContext(dbContextOptions);
            danhMucChucDanhService = new TitleCategoryService(_context);
            danhMucChucVuService = new PositionCategoryService(_context);
            danhMucChuyenMonService = new SpecializeCategoryService(_context);
            danhMucDanTocService = new NationCategoryService(_context);
            danhMucHinhThucDaoTaoService = new EducateCategoryService(_context);
            danhMucHonNhanService = new MarriageCategoryService(_context);
            danhMucKhenThuongKyLuatService = new RewardDisciplineCategoryService(_context);
            danhMucLoaiHopDongService = new TypeOfContractCategoryService(_context);
            danhMucNgachCongChucService = new CSRCategoryService(_context);
            danhMucNgoaiNguService = new LanguageCategoryService(_context);
            danhMucNguoiThanService = new RelationCategoryService(_context);
            danhMucNhomLuongService = new SalaryGroupCategoryService(_context);
            danhMucPhongBanService = new DepartmentCategoryService(_context);
            danhMucTinhChatLaoDongService = new DanhMucTinhChatLaoDongService(_context);
            danhMucTonGiaoService = new ReligionCategoryService(_context);
            danhMucToService = new NestCategoryService(_context);
            danhMucTrinhDoService = new LevelCategoryService(_context);
            TrinhDoVanHoaService = new EducationLevelService(_context);
            NguoiThanService = new FamilyRelationshipService(_context);
            NgoaiNguService = new LanguageService(_context);
            LichSuService = new HistoryService(_context);
            LuongService = new SalaryService(_context, storageService);
            DieuChuyenService = new WorkingProcessService(_context, storageService);
            KhenThuongKyLuatService = new RewardDisciplineService(_context, storageService);
            HopDongService = new LaborContractService(_context, storageService);
            NhanVienService = new EmployeeService(_context, storageService);
        }
    }
}
