using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucNhomLuongConfiguration : IEntityTypeConfiguration<DanhMucNhomLuong>
    {
        public void Configure(EntityTypeBuilder<DanhMucNhomLuong> builder)
        {
            builder.ToTable("DanhMucNhomLuong");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maNhomLuong).HasMaxLength(50).IsRequired();
            builder.Property(x => x.tenNhomLuong).HasMaxLength(50).IsRequired();
        }
    }
}
