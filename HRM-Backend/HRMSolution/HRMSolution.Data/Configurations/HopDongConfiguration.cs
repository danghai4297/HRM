using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class HopDongConfiguration : IEntityTypeConfiguration<HopDong>
    {
        public void Configure(EntityTypeBuilder<HopDong> builder)
        {
            builder.ToTable("HopDong");
            builder.HasKey(x => x.maHopDong);
            builder.Property(x => x.maHopDong).HasMaxLength(30);
            builder.Property(x => x.idChucDanh).IsRequired();
            builder.Property(x => x.idLoaiHopDong).IsRequired();
            builder.Property(x => x.hopDongTuNgay).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.hopDongDenNgay).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ghiChu).HasMaxLength(300);
            builder.Property(x => x.maNhanVien).HasMaxLength(10).IsRequired();
        }
    }
}
