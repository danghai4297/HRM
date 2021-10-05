using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                columns: new[] { "ngayCapCCCD", "ngayChinhThuc", "ngayHetHanCCCD", "ngaySinh" },
                values: new object[] { new DateTime(2021, 10, 5, 2, 2, 2, 621, DateTimeKind.Local).AddTicks(2236), new DateTime(2021, 10, 5, 2, 2, 2, 621, DateTimeKind.Local).AddTicks(5552), new DateTime(2021, 10, 5, 2, 2, 2, 621, DateTimeKind.Local).AddTicks(2909), new DateTime(2021, 10, 5, 2, 2, 2, 619, DateTimeKind.Local).AddTicks(5444) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                columns: new[] { "ngayCapCCCD", "ngayChinhThuc", "ngayHetHanCCCD", "ngaySinh" },
                values: new object[] { new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
