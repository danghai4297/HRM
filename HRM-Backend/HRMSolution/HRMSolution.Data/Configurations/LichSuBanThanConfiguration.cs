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
            builder.HasKey(x => x.lsbt_id);
            builder.Property(x => x.lsbt_id).UseIdentityColumn();
            builder.Property(x => x.lsbt_biBatDiTu).HasMaxLength(500);
            builder.Property(x => x.lsbt_thamGiaChinhTri).HasMaxLength(500);
            builder.Property(x => x.lsbt_thanNhanNuocNgoai).HasMaxLength(500);
            builder.Property(x => x.lsbt_maNhanVien).IsRequired();
        }
    }
}
