using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucTinhChatLaoDongConfiguration : IEntityTypeConfiguration<DanhMucPhongBan>
    {
        public void Configure(EntityTypeBuilder<DanhMucPhongBan> builder)
        {
            builder.ToTable("DanhMucPhongBan");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maPhongBan).HasMaxLength(10).IsRequired();
            builder.Property(x => x.tenPhongBan).HasMaxLength(50).IsRequired();
        }
    }
}
