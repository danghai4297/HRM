using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucLoaiHopDongConfiguration : IEntityTypeConfiguration<DanhMucLoaiHopDong>
    {
        public void Configure(EntityTypeBuilder<DanhMucLoaiHopDong> builder)
        {
            builder.ToTable("DanhMucLoaiHopDong");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maLoaiHopDong).HasMaxLength(10);
            builder.Property(x => x.tenLoaiHopDong).HasMaxLength(50);
        }
    }
}
