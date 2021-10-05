using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class seedData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDang",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDang",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "getdate()",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "getdate()",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
