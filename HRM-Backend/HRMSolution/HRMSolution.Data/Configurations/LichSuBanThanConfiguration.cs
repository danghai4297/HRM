using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class LichSuBanThanConfiguration : IEntityTypeConfiguration<LichSuBanThan>
    {
        public void Configure(EntityTypeBuilder<LichSuBanThan> builder)
        {
            builder.ToTable("LichSuBanThan");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.biBatDiTu).HasMaxLength(500);
            builder.Property(x => x.thamGiaChinhTri).HasMaxLength(500);
            builder.Property(x => x.thanNhanNuocNgoai).HasMaxLength(500);
            builder.Property(x => x.maNhanVien).IsRequired();
        }
    }
}
