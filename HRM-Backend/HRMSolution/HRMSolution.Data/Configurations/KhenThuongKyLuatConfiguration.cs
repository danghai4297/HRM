using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class KhenThuongKyLuatConfiguration : IEntityTypeConfiguration<KhenThuongKyLuat>
    {
        public void Configure(EntityTypeBuilder<KhenThuongKyLuat> builder)
        {
            builder.ToTable("KhenThuongKyLuat");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.idDanhMucKhenThuong).IsRequired();
            builder.Property(x => x.noiDung).HasMaxLength(100);
            builder.Property(x => x.lyDo).HasMaxLength(150);
            builder.Property(x => x.maNhanVien).IsRequired().HasMaxLength(10);
            builder.Property(x => x.anh).HasMaxLength(100);

        }
    }
}
