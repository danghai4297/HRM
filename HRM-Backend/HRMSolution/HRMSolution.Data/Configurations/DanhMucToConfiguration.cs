using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucToConfiguration : IEntityTypeConfiguration<DanhMucTo>
    {
        public void Configure(EntityTypeBuilder<DanhMucTo> builder)
        {
            builder.ToTable("DanhMucTo");
            builder.HasKey(x => x.idTo);
            builder.Property(x => x.idTo).UseIdentityColumn();
            builder.Property(x => x.maTo).HasMaxLength(10).IsRequired();
            builder.Property(x => x.tenTo).HasMaxLength(50).IsRequired();
            builder.Property(x => x.idPhongBan).HasMaxLength(5).IsRequired();
        }
    }
}
