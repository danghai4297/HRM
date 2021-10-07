using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class NguoiThanConfiguration : IEntityTypeConfiguration<NguoiThan>
    {
        public void Configure(EntityTypeBuilder<NguoiThan> builder)
        {
            builder.ToTable("NguoiThan");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenNguoiThan).HasMaxLength(40).IsRequired();
            builder.Property(x => x.ngaySinh).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ngheNghiep).HasMaxLength(50).IsRequired();
            builder.Property(x => x.diaChi).HasMaxLength(150).IsRequired();
            builder.Property(x => x.dienThoai).HasMaxLength(16).IsRequired();
            builder.Property(x => x.khac).HasMaxLength(300);
            builder.Property(x => x.maNhanVien).HasMaxLength(10).IsRequired();
            builder.Property(x => x.idDanhMucNguoiThan).IsRequired();
        }
    }
}
