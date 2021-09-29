using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucKhenThuongKyLuatConfiguration : IEntityTypeConfiguration<DanhMucKhenThuongKyLuat>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhenThuongKyLuat> builder)
        {
            builder.ToTable("DanhMucKhenThuongKyLuat");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenDanhMuc).HasMaxLength(50).IsRequired();
        }
    }
}
