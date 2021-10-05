using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMSolution.Data.Configurations
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {

        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            
            builder.ToTable("NhanVien");
            builder.HasKey(x => x.maNhanVien);
            builder.Property(x => x.maNhanVien).HasMaxLength(10);
            builder.Property(x => x.hoTen).HasMaxLength(50).IsRequired();
            
            builder.Property(x => x.quocTich).IsRequired();

            builder.Property(x => x.ngaySinh).HasColumnType("datetime").HasDefaultValueSql("GetDate()").IsRequired();

            builder.Property(x => x.gioiTinh).IsRequired();
            builder.Property(x => x.dienThoai).HasMaxLength(16).IsRequired();
            builder.Property(x => x.dienThoaiKhac).HasMaxLength(16);
            builder.Property(x => x.diDong).HasMaxLength(16).IsRequired();
            builder.Property(x => x.facebook).HasMaxLength(25);
            builder.Property(x => x.skype).HasMaxLength(25);
            
            builder.Property(x => x.cccd).HasMaxLength(15).IsRequired();
            builder.Property(x => x.noiCapCCCD).HasMaxLength(25).IsRequired();
            builder.Property(x => x.ngayCapCCCD).HasColumnType("datetime").HasDefaultValueSql("GetDate()").IsRequired();
            builder.Property(x => x.ngayHetHanCCCD).HasColumnType("datetime").HasDefaultValueSql("GetDate()").IsRequired();

            builder.Property(x => x.hoChieu).HasMaxLength(25);
            builder.Property(x => x.noiCapHoChieu).HasMaxLength(25);
            builder.Property(x => x.ngayCapHoChieu).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.ngayHetHanHoChieu).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            
            builder.Property(x => x.noiSinh).HasMaxLength(150).IsRequired();
            builder.Property(x => x.queQuan).HasMaxLength(150).IsRequired();
            builder.Property(x => x.thuongTru).HasMaxLength(150).IsRequired();
            builder.Property(x => x.tamTru).HasMaxLength(150);
            builder.Property(x => x.ngheNghiep).HasMaxLength(50).IsRequired();
            builder.Property(x => x.chucVuHienTai).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ngayTuyenDung).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.ngayThuViec).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.congViecChinh).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ngayVaoBan).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.ngayChinhThuc).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.coQuanTuyenDung).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ngachCongChucNoiDung).HasMaxLength(50);
            builder.Property(x => x.ngayVaoDang).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.ngayVaoDangChinhThuc).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.ngayNhapNgu).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.ngayXuatNgu).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.quanHamCaoNhat).HasMaxLength(50);
            builder.Property(x => x.danhHieuCaoNhat).HasMaxLength(50);
            builder.Property(x => x.ngayVaoDoan).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            
            builder.Property(x => x.noiThamGia).HasMaxLength(50);
            builder.Property(x => x.thuongBinh).HasMaxLength(50);
            builder.Property(x => x.conChinhSach).HasMaxLength(50);
            builder.Property(x => x.bhxh).HasMaxLength(10);
            builder.Property(x => x.bhyt).HasMaxLength(10);
            builder.Property(x => x.atm).HasMaxLength(20);
            builder.Property(x => x.nganHang).HasMaxLength(50);
            builder.Property(x => x.ngayNghiViec).HasColumnType("datetime").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.lyDoNghiViec).HasMaxLength(50);
            builder.Property(x => x.anh).HasMaxLength(50).IsRequired();
            builder.Property(x => x.idDanhMucHonNhan).IsRequired();
            builder.Property(x => x.idDanToc).IsRequired();
            builder.Property(x => x.idNgachCongChuc).IsRequired();
            builder.Property(x => x.idTonGiao).IsRequired();
            builder.Property(x => x.idPhongBan).IsRequired();




        }
    }
}
