﻿using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    class DanhMucNgoaiNguConfiguration : IEntityTypeConfiguration<DanhMucNgoaiNgu>
    {
        public void Configure(EntityTypeBuilder<DanhMucNgoaiNgu> builder)
        {
            builder.ToTable("DanhMucNgoaiNgu");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenDanhMuc).HasMaxLength(50).IsRequired();
        }
    }
}
