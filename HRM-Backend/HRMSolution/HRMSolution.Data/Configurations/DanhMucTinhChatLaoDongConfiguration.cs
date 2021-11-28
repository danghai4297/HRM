using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucTinhChatLaoDongConfiguration : IEntityTypeConfiguration<DanhMucTinhChatLaoDong>
    {
        public void Configure(EntityTypeBuilder<DanhMucTinhChatLaoDong> builder)
        {
            builder.ToTable("DanhMucTinhChatLaoDong");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenTinhChat).HasMaxLength(50).IsRequired();
        }
    }
}
