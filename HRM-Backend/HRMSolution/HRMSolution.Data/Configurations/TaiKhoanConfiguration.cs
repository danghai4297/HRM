using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class TaiKhoanConfiguration : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.ToTable("TaiKhoan");
            builder.HasKey(x => x.tenDangNhap);
            builder.Property(x => x.tenDangNhap).HasMaxLength(20).IsRequired();
            builder.Property(x => x.matKhau).HasMaxLength(30).IsRequired();
            builder.Property(x => x.vaiTro).IsRequired();
        }
    }
}
