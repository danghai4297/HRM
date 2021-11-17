using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DieuChuyenConfiguration : IEntityTypeConfiguration<DieuChuyen>
    {
        public void Configure(EntityTypeBuilder<DieuChuyen> builder)
        {
            builder.ToTable("DieuChuyen");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.maNhanVien).HasMaxLength(10).IsRequired();
            builder.Property(x => x.idChucVu).IsRequired();
            builder.Property(x => x.ngayHieuLuc).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.chiTiet).HasMaxLength(300);
            builder.Property(x => x.idPhongBan).IsRequired();
            builder.Property(x => x.trangThai).IsRequired();
            builder.Property(x => x.bangChung).HasMaxLength(100);
        }
    }
}
