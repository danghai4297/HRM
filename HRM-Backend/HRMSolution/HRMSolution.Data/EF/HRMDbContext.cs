
using HRMSolution.Data.Configurations;
using HRMSolution.Data.Entities;
using HRMSolution.Data.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.EF
{
    public class HRMDbContext : DbContext
    {
        public HRMDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<DanhMucChucDanh> danhMucChucDanhs { get; set; }
        public DbSet<DanhMucChucVu> danhMucChucVus { get; set; }
        public DbSet<DanhMucChuyenMon> danhMucChuyenMons { get; set; }
        public DbSet<DanhMucDanToc> danhMucDanTocs { get; set; }
        public DbSet<DanhMucHonNhan> danhMucHonNhans { get; set; }
        public DbSet<DanhMucKhenThuongKyLuat> danhMucKhenThuongKyLuats { get; set; }
        public DbSet<DanhMucNgachCongChuc> danhMucNgachCongChucs { get; set; }
        public DbSet<DanhMucLoaiHopDong> danhMucLoaiHopDongs { get; set; }
        public DbSet<DanhMucNgoaiNgu> danhMucNgoaiNgus { get; set; }
        public DbSet<DanhMucNguoiThan> danhMucNguoiThans { get; set; }
        public DbSet<DanhMucPhongBan> danhMucPhongBans { get; set; }
        public DbSet<DanhMucTinhChatLaoDong> danhMucTinhChatLaoDongs { get; set; }
        public DbSet<DanhMucTo> danhMucTos { get; set; }
        public DbSet<DanhMucTonGiao> danhMucTonGiaos { get; set; }
        public DbSet<DanhMucTrinhDo> danhMucTrinhDos { get; set; }
        public DbSet<DieuChuyen> dieuChuyens { get; set; }
        public DbSet<HinhThucDaoTao> hinhThucDaoTaos { get; set; }
        public DbSet<HopDong> hopDongs { get; set; }
        public DbSet<LichSuBanThan> lichSuBanThans { get; set; }
        public DbSet<LienHeKhanCap> lienHeKhanCaps { get; set; }
        public DbSet<Luong> luongs { get; set; }
        public DbSet<NgoaiNgu> ngoaiNgus { get; set; }
        public DbSet<NguoiThan> nguoiThans { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<TrinhDoVanHoa> trinhDoVanHoas { get; set; }
        public DbSet<YTe> yTes { get; set; }
        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<KhenThuongKyLuat> khenThuongKyLuats {get; set; }
        public DbSet<LichSu> lichSus { get; set; }
        public DbSet<DanhMucNhomLuong> danhMucNhomLuongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration using Fluent API
            modelBuilder.ApplyConfiguration(new DanhMucChucDanhConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucChuyenMonConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucDanTocConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucHonNhanConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucKhenThuongKyLuatConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucLoaiHopDongConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucNgachCongChucConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucNgoaiNguConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucNguoiThanConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucPhongBanConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucTinhChatLaoDongConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucToConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucTonGiaoConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucTrinhDoConfiguration());
            modelBuilder.ApplyConfiguration(new DieuChuyenConfiguration());
            modelBuilder.ApplyConfiguration(new HinhThucDaoTaoConfiguration());
            modelBuilder.ApplyConfiguration(new HopDongConfiguration());
            modelBuilder.ApplyConfiguration(new LienHeKhanCapConfiguration());
            modelBuilder.ApplyConfiguration(new LuongConfiguration());
            modelBuilder.ApplyConfiguration(new NgoaiNguConfiguration());
            modelBuilder.ApplyConfiguration(new NguoiThanConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new TrinhDoVanHoaConfiguration());
            modelBuilder.ApplyConfiguration(new YTeConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoanConfiguration());
            modelBuilder.ApplyConfiguration(new KhenThuongKyLuatConfiguration());
            modelBuilder.ApplyConfiguration(new LichSuBanThanConfiguration());
            modelBuilder.ApplyConfiguration(new LichSuConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucNhomLuongConfiguration());

            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.LichSuBanThan)
                .WithOne(p => p.NhanVien)
                .HasForeignKey<LichSuBanThan>(x => x.lsbt_maNhanVien);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.LienHeKhanCap)
                .WithOne(p => p.NhanVien)
                .HasForeignKey<LienHeKhanCap>(x => x.lhkc_maNhanVien);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.YTe)
                .WithOne(p => p.NhanVien)
                .HasForeignKey<YTe>(x => x.yt_maNhanVien);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.DanhMucNgachCongChuc)
                .WithMany(x => x.NhanViens)
                .HasForeignKey(x => x.idNgachCongChuc);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.DanhMucDanToc)
                .WithMany(x => x.NhanViens)
                .HasForeignKey(x => x.idDanToc);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.DanhMucTonGiao)
                .WithMany(x => x.NhanViens)
                .HasForeignKey(x => x.idTonGiao);
            modelBuilder.Entity<DieuChuyen>()
                .HasOne(x => x.DanhMucPhongBan)
                .WithMany(x => x.DieuChuyens)
                .HasForeignKey(x => x.idPhongBan);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.DanhMucTinhChatLaoDong)
                .WithMany(x => x.NhanViens)
                .HasForeignKey(x => x.tinhChatLaoDong);
            modelBuilder.Entity<TrinhDoVanHoa>()
                .HasOne(x => x.HinhThucDaoTao)
                .WithMany(x => x.TrinhDoVanHoas)
                .HasForeignKey(x => x.idHinhThucDaoTao);
            modelBuilder.Entity<TrinhDoVanHoa>()
                .HasOne(x => x.DanhMucTrinhDo)
                .WithMany(x => x.TrinhDoVanHoas)
                .HasForeignKey(x => x.idTrinhDo);
            modelBuilder.Entity<TrinhDoVanHoa>()
                .HasOne(x => x.DanhMucChuyenMon)
                .WithMany(x => x.TrinhDoVanHoas)
                .HasForeignKey(x => x.idChuyenMon);
            modelBuilder.Entity<TrinhDoVanHoa>()
                .HasOne(x => x.NhanVien)
                .WithMany(b => b.TrinhDoVanHoas)
                .HasForeignKey(x=>x.maNhanVien);
            modelBuilder.Entity<DanhMucTo>()
                .HasOne(x => x.DanhMucPhongBan)
                .WithMany(x => x.DanhMucTos)
                .HasForeignKey(x => x.idPhongBan);
            modelBuilder.Entity<Luong>()
                .HasOne(x => x.HopDong)
                .WithMany(x => x.Luongs)
                .HasForeignKey(x => x.maHopDong);
            modelBuilder.Entity<HopDong>()
                .HasOne(x => x.DanhMucLoaiHopDong)
                .WithMany(x => x.HopDongs)
                .HasForeignKey(x => x.idLoaiHopDong);
            modelBuilder.Entity<HopDong>()
                .HasOne(x => x.DanhMucChucDanh)
                .WithMany(x => x.HopDongs)
                .HasForeignKey(x => x.idChucDanh);
            modelBuilder.Entity<HopDong>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.HopDongs)
                .HasForeignKey(x => x.maNhanVien);
            modelBuilder.Entity<NgoaiNgu>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.NgoaiNgus)
                .HasForeignKey(x => x.maNhanVien);
            modelBuilder.Entity<NgoaiNgu>()
                .HasOne(x => x.DanhMucNgoaiNgu)
                .WithMany(x => x.NgoaiNgus)
                .HasForeignKey(x => x.idDanhMucNgoaiNgu);
            modelBuilder.Entity<NguoiThan>()
                .HasOne(x => x.DanhMucNguoiThan)
                .WithMany(x => x.NguoiThans)
                .HasForeignKey(x => x.idDanhMucNguoiThan);
            modelBuilder.Entity<NguoiThan>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.NguoiThans)
                .HasForeignKey(x => x.maNhanVien);
            modelBuilder.Entity<DieuChuyen>()
                .HasOne(x => x.DanhMucChucVu)
                .WithMany(x => x.DieuChuyens)
                .HasForeignKey(x => x.idChucVu);
            modelBuilder.Entity<DieuChuyen>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.DieuChuyens)
                .HasForeignKey(x => x.maNhanVien);
            modelBuilder.Entity<KhenThuongKyLuat>()
                .HasOne(x => x.DanhMucKhenThuongKyLuat)
                .WithMany(x => x.KhenThuongKyLuats)
                .HasForeignKey(x => x.idDanhMucKhenThuong);
            modelBuilder.Entity<KhenThuongKyLuat>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.KhenThuongKyLuats)
                .HasForeignKey(x => x.maNhanVien);
            modelBuilder.Entity<NhanVien>()
                .HasOne(x => x.DanhMucHonNhan)
                .WithMany(x => x.NhanViens)
                .HasForeignKey(x => x.idDanhMucHonNhan);
            modelBuilder.Entity<Luong>()
                .HasOne(x => x.DanhMucNhomLuong)
                .WithMany(x => x.Luongs)
                .HasForeignKey(x => x.idNhomLuong);

            //DataSeedinng
            modelBuilder.seed();


            //base.OnModelCreating(modelBuilder);
        }
    }
}
