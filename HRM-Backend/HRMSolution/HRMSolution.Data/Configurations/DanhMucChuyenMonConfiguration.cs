using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucChuyenMonConfiguration : IEntityTypeConfiguration<DanhMucChuyenMon>
    {
        public void Configure(EntityTypeBuilder<DanhMucChuyenMon> builder)
        {
            builder.ToTable("DanhMucChuyenMon");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maChuyenMon).HasMaxLength(10).IsRequired();
            builder.Property(x => x.tenChuyenMon).HasMaxLength(50).IsRequired();
        }
    }
}
