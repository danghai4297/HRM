using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class YTeConfiguration : IEntityTypeConfiguration<YTe>
    {
        public void Configure(EntityTypeBuilder<YTe> builder)
        {
            builder.ToTable("YTe");
            builder.HasKey(x => x.yt_id);
            builder.Property(x => x.yt_id).UseIdentityColumn();
            builder.Property(x => x.yt_nhomMau).HasMaxLength(5);
            builder.Property(x => x.yt_tinhTrangSucKhoe).HasMaxLength(50);
            builder.Property(x => x.yt_benhTat).HasMaxLength(50);
            builder.Property(x => x.yt_luuY).HasMaxLength(50);
            builder.Property(x => x.yt_maNhanVien).HasMaxLength(10).IsRequired();
        }
    }
}
