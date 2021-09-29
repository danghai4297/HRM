using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucNgachCongChucConfiguration : IEntityTypeConfiguration<DanhMucNgachCongChuc>
    {
        public void Configure(EntityTypeBuilder<DanhMucNgachCongChuc> builder)
        {
            builder.ToTable("DanhMucNgachCongChuc");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenNgach).HasMaxLength(50).IsRequired();
        }
    }
}
