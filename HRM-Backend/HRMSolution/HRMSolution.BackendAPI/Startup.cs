using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.Application.Catalog.DanhMucChucVus;
using HRMSolution.Application.Catalog.DanhMucChuyenMons;
using HRMSolution.Application.Catalog.DanhMucDanTocs;
<<<<<<< HEAD
using HRMSolution.Application.Catalog.DanhMucHonNhans;
=======
using HRMSolution.Application.Catalog.HopDongs;
>>>>>>> ed2453571acc5f83cc226705505ce55c964451b0
using HRMSolution.Application.Catalog.NhanViens;
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
<<<<<<< HEAD
            services.AddTransient<IDanhMucChucDanhService, DanhMucChucDanhService>();
            services.AddTransient<IDanhMucChucVuService, DanhMucChucVuService>();
            services.AddTransient<IDanhMucChuyenMonService, DanhMucChuyenMonService>();
            services.AddTransient<IDanhMucHonNhanService, DanhMucHonNhanService>();
=======

            services.AddTransient<IHopDongService, HopDongService>();
>>>>>>> ed2453571acc5f83cc226705505ce55c964451b0
            services.AddTransient<IDanhMucDanTocService, DanhMucDanTocService>();
            services.AddTransient<INhanVienService, NhanVienService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
