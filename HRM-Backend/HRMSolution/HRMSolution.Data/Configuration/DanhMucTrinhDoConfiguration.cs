using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucTrinhDoConfiguration : IEntityTypeConfiguration<DanhMucTrinhDo>
    {
        public void Configure(EntityTypeBuilder<DanhMucTrinhDo> builder)
        {
            builder.ToTable("DanhMucTrinhDo");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenTrinhDo).HasMaxLength(50);
        }
    }
}
