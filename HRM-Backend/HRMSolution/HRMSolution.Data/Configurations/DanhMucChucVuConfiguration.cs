using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucChucVuConfiguration : IEntityTypeConfiguration<DanhMucChucVu>
    {
        public void Configure(EntityTypeBuilder<DanhMucChucVu> builder)
        {
            builder.ToTable("DanhMucChucVu");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maChucVu).HasMaxLength(10).IsRequired();
            builder.Property(x => x.tenChucVu).HasMaxLength(50).IsRequired();
            builder.Property(x => x.phuCap).HasDefaultValue(0);
        }
    }
}
