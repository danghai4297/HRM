using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucChucDanhConfiguration : IEntityTypeConfiguration<DanhMucChucDanh>
    {
        public void Configure(EntityTypeBuilder<DanhMucChucDanh> builder)
        {
            builder.ToTable("DanhMucChucDanh");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maChucDanh).HasMaxLength(10).IsRequired();
            builder.Property(x => x.tenChucDanh).HasMaxLength(50).IsRequired();
            builder.Property(x => x.phuCap).HasDefaultValue(0);
        }
    }
}
