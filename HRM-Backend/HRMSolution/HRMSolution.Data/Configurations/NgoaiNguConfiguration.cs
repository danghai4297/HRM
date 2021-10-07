using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class NgoaiNguConfiguration : IEntityTypeConfiguration<NgoaiNgu>
    {
        public void Configure(EntityTypeBuilder<NgoaiNgu> builder)
        {
            builder.ToTable("NgoaiNgu");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.ngayCap).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.trinhDo).HasMaxLength(50).IsRequired();
            builder.Property(x => x.noiCap).HasMaxLength(50).IsRequired();
            builder.Property(x => x.idDanhMucNgoaiNgu).IsRequired().IsRequired();
            builder.Property(x => x.maNhanVien).HasMaxLength(10).IsRequired();
        }
    }
}
