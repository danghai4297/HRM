using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class LichSuConfiguration : IEntityTypeConfiguration<LichSu>
    {
        public void Configure(EntityTypeBuilder<LichSu> builder)
        {
            builder.ToTable("LichSu");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenTaiKhoan).HasMaxLength(50).IsRequired();
            builder.Property(x => x.thaoTac).HasMaxLength(50).IsRequired();
            builder.Property(x => x.hanhDong).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ngayThucHien).HasColumnType("datetime");
            builder.Property(x => x.maNhanVien).HasMaxLength(50).IsRequired();
        }
    }
}
