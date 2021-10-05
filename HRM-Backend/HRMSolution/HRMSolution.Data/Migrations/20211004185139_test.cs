using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "Date",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");
        }
    }
}
