using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                columns: new[] { "ngayCapCCCD", "ngayHetHanCCCD", "ngaySinh" },
                values: new object[] { new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                columns: new[] { "ngayCapCCCD", "ngayHetHanCCCD", "ngaySinh" },
                values: new object[] { new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
