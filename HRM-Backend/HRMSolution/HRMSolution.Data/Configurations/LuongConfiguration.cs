using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class LuongConfiguration : IEntityTypeConfiguration<Luong>
    {
        public void Configure(EntityTypeBuilder<Luong> builder)
        {
            builder.ToTable("Luong");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maHopDong).HasMaxLength(30).IsRequired();
            builder.Property(x => x.bacLuong).HasMaxLength(10);
            builder.Property(x => x.thoiHanLenLuong).HasMaxLength(10);
            builder.Property(x => x.ngayHieuLuc).HasColumnType("datetime");
            builder.Property(x => x.ngayKetThuc).HasColumnType("datetime");
            builder.Property(x => x.ghiChu).HasMaxLength(100);
        }
    }
}
