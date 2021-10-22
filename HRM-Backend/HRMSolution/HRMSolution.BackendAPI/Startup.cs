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
using HRMSolution.Application.Catalog.Luongs;
using HRMSolution.Application.Catalog.NgoaiNgus;
using HRMSolution.Application.Catalog.NguoiThans;
using HRMSolution.Application.Catalog.NhanViens;
using HRMSolution.Application.Catalog.TrinhDoVanHoas;
using HRMSolution.Application.Common;
using HRMSolution.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<HRMDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Data")));


            services.AddTransient<IDanhMucChucDanhService, DanhMucChucDanhService>();
            services.AddTransient<IDanhMucChucVuService, DanhMucChucVuService>();
            services.AddTransient<IDanhMucChuyenMonService, DanhMucChuyenMonService>();
            services.AddTransient<IDanhMucHonNhanService, DanhMucHonNhanService>();
            services.AddTransient<IKhenThuongKyLuatService, KhenThuongKyLuatService>();
            services.AddTransient<IDanhMucKhenThuongKyLuatService, DanhMucKhenThuongKyLuatService>();
            services.AddTransient<IDanhMucLoaiHopDongService, DanhMucLoaiHopDongService>();
            services.AddTransient<IDanhMucNgachCongChucService, DanhMucNgachCongChucService>();
            services.AddTransient<IDanhMucNguoiThanService, DanhMucNguoiThanService>();
            services.AddTransient<IDanhMucNgoaiNguService, DanhMucNgoaiNguService>();
            services.AddTransient<IDanhMucNhomLuongService, DanhMucNhomLuongService>();
            services.AddTransient<IDanhMucPhongBanService, DanhMucPhongBanService>();
            services.AddTransient<IDanhMucHinhThucDaoTaoService, DanhMucHinhThucDaoTaoService>();
            services.AddTransient<IDanhMucTinhChatLaoDongService, DanhMucTinhChatLaoDongService>();
            services.AddTransient<IDanhMucTonGiaoService, DanhMucTonGiaoService>();
            services.AddTransient<IDanhMucToService, DanhMucToService>();
            services.AddTransient<IDanhMucTrinhDoService, DanhMucTrinhDoService>();
            services.AddTransient<IHopDongService, HopDongService>();
            services.AddTransient<IDanhMucDanTocService, DanhMucDanTocService>();
            services.AddTransient<INhanVienService, NhanVienService>();
            services.AddTransient<ILuongService, LuongService>();
            services.AddTransient<INguoiThanService, NguoiThanService>();
            services.AddTransient<INgoaiNguService, NgoaiNguService>();
            services.AddTransient<ITrinhDoVanHoaService, TrinhDoVanHoaService>();
            services.AddTransient<IDieuChuyenService, DieuChuyenService>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddControllers();


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger HRM Sholution", Version = "v1" });
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x=> 
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger HRMSolution V1");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
