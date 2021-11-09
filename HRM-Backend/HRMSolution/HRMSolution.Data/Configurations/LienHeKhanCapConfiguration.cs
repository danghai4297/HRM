using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class LienHeKhanCapConfiguration : IEntityTypeConfiguration<LienHeKhanCap>
    {
        public void Configure(EntityTypeBuilder<LienHeKhanCap> builder)
        {
            builder.ToTable("LienHeKhanCap");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.hoTen).HasMaxLength(30).IsRequired();
            builder.Property(x => x.quanHe).HasMaxLength(30).IsRequired();
            builder.Property(x => x.dienThoai).HasMaxLength(30).IsRequired();
            builder.Property(x => x.email).HasMaxLength(30);
            builder.Property(x => x.diaChi).HasMaxLength(150).IsRequired();
            builder.Property(x => x.maNhanVien).HasMaxLength(10).IsRequired();
        }
    }
}
