using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class HinhThucDaoTaoConfiguration : IEntityTypeConfiguration<HinhThucDaoTao>
    {
        public void Configure(EntityTypeBuilder<HinhThucDaoTao> builder)
        {
            builder.ToTable("HinhThucDaoTao");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenHinhThuc).HasMaxLength(50).IsRequired();
        }
    }
}
