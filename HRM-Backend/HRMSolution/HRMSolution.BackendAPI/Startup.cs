using HRMSolution.Application.Catalog.BaoCaos;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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


            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<HRMDbContext>()
                .AddDefaultTokenProviders();

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
            services.AddTransient<IQuaTrinhCongTacService, QuaTrinhCongTacService>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILichSuService, LichSuService>();
            services.AddTransient<IBaoCaoService, BaoCaoService>();
            services.AddControllers();


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger HRM Solution", Version = "v1" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
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
            app.UseSwaggerUI(x =>
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
