using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Configurations
{
    public class TrinhDoVanHoaConfiguration : IEntityTypeConfiguration<TrinhDoVanHoa>
    {
        public void Configure(EntityTypeBuilder<TrinhDoVanHoa> builder)
        {
            builder.ToTable("TrinhDoVanHoa");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.tenTruong).HasMaxLength(50);
            builder.Property(x => x.tuThoiGian).HasColumnType("datetime");
            builder.Property(x => x.denThoiGian).HasColumnType("datetime");
            builder.Property(x => x.idHinhThucDaoTao).IsRequired();
            builder.Property(x => x.idChuyenMon).IsRequired();
            builder.Property(x => x.idTrinhDo).IsRequired();
            builder.Property(x => x.maNhanVien).HasMaxLength(10).IsRequired();
        }
    }
}
