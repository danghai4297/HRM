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
            builder.HasKey(x => x.lhkc_id);
            builder.Property(x => x.lhkc_id).UseIdentityColumn();
            builder.Property(x => x.lhkc_hoTen).HasMaxLength(30).IsRequired();
            builder.Property(x => x.lhkc_quanHe).HasMaxLength(30).IsRequired();
            builder.Property(x => x.lhkc_dienThoai).HasMaxLength(30).IsRequired();
            builder.Property(x => x.lhkc_email).HasMaxLength(30);
            builder.Property(x => x.lhkc_diaChi).HasMaxLength(150).IsRequired();
            builder.Property(x => x.lhkc_maNhanVien).HasMaxLength(10).IsRequired();
        }
    }
}
