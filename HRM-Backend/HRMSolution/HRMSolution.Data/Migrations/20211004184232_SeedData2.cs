using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDang",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                columns: new[] { "ngayCapCCCD", "ngayChinhThuc", "ngayHetHanCCCD", "ngaySinh" },
                values: new object[] { new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDang",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                columns: new[] { "ngayCapCCCD", "ngayChinhThuc", "ngayHetHanCCCD", "ngaySinh" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(40), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(7), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(99) });
        }
    }
}
