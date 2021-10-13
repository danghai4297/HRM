using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "anh",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "DieuChuyen",
                keyColumn: "id",
                keyValue: 1,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "DieuChuyen",
                keyColumn: "id",
                keyValue: 2,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "DieuChuyen",
                keyColumn: "id",
                keyValue: 3,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD01",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 802, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD02",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 805, DateTimeKind.Local).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD03",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 805, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD04",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 805, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD05",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 805, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD06",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 805, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 1,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 2,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 3,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 4,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 5,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 16, 13, 40, 806, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0002",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0003",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0004",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0005",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0006",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0007",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0008",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0009",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0010",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0011",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0012",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0013",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0014",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0015",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0016",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0017",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0018",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0019",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0020",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0021",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0022",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0023",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0024",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0025",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0026",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0027",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0028",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0029",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0030",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0031",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0032",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0033",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0034",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0035",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0036",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0037",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0038",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0039",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0040",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0041",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0042",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0043",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0044",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0045",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0046",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0047",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0048",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0049",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0050",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0051",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0052",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0053",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0054",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0055",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0056",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0057",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0058",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0059",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0060",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0061",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0062",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0063",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0064",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0065",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0066",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0067",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0068",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0069",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0070",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0071",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0072",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0073",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0074",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0075",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0076",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0077",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0078",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0079",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0080",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0081",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0082",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0083",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0084",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0085",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0086",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0087",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0088",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0089",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0090",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0091",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0092",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0093",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0094",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0095",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0096",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0097",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0098",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0099",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0100",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0101",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0102",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0103",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0104",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0105",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0106",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0107",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0108",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0109",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0110",
                column: "anh",
                value: null);

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0111",
                column: "anh",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "anh",
                table: "NhanVien",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DieuChuyen",
                keyColumn: "id",
                keyValue: 1,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "DieuChuyen",
                keyColumn: "id",
                keyValue: 2,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "DieuChuyen",
                keyColumn: "id",
                keyValue: 3,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD01",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 891, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD02",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 892, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD03",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 892, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD04",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 892, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD05",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 892, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "HopDong",
                keyColumn: "maHopDong",
                keyValue: "HD06",
                column: "hopDongTuNgay",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 892, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 1,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 2,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 3,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 4,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Luong",
                keyColumn: "id",
                keyValue: 5,
                column: "ngayHieuLuc",
                value: new DateTime(2021, 10, 13, 0, 0, 46, 893, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001",
                column: "anh",
                value: "1");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0002",
                column: "anh",
                value: "2");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0003",
                column: "anh",
                value: "3");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0004",
                column: "anh",
                value: "4");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0005",
                column: "anh",
                value: "5");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0006",
                column: "anh",
                value: "6");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0007",
                column: "anh",
                value: "7");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0008",
                column: "anh",
                value: "8");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0009",
                column: "anh",
                value: "9");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0010",
                column: "anh",
                value: "10");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0011",
                column: "anh",
                value: "11");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0012",
                column: "anh",
                value: "12");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0013",
                column: "anh",
                value: "13");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0014",
                column: "anh",
                value: "14");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0015",
                column: "anh",
                value: "15");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0016",
                column: "anh",
                value: "16");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0017",
                column: "anh",
                value: "17");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0018",
                column: "anh",
                value: "18");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0019",
                column: "anh",
                value: "19");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0020",
                column: "anh",
                value: "20");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0021",
                column: "anh",
                value: "21");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0022",
                column: "anh",
                value: "22");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0023",
                column: "anh",
                value: "23");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0024",
                column: "anh",
                value: "24");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0025",
                column: "anh",
                value: "25");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0026",
                column: "anh",
                value: "26");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0027",
                column: "anh",
                value: "27");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0028",
                column: "anh",
                value: "28");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0029",
                column: "anh",
                value: "29");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0030",
                column: "anh",
                value: "30");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0031",
                column: "anh",
                value: "31");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0032",
                column: "anh",
                value: "32");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0033",
                column: "anh",
                value: "33");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0034",
                column: "anh",
                value: "34");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0035",
                column: "anh",
                value: "35");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0036",
                column: "anh",
                value: "36");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0037",
                column: "anh",
                value: "37");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0038",
                column: "anh",
                value: "38");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0039",
                column: "anh",
                value: "39");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0040",
                column: "anh",
                value: "40");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0041",
                column: "anh",
                value: "41");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0042",
                column: "anh",
                value: "42");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0043",
                column: "anh",
                value: "43");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0044",
                column: "anh",
                value: "44");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0045",
                column: "anh",
                value: "45");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0046",
                column: "anh",
                value: "46");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0047",
                column: "anh",
                value: "47");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0048",
                column: "anh",
                value: "48");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0049",
                column: "anh",
                value: "49");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0050",
                column: "anh",
                value: "50");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0051",
                column: "anh",
                value: "51");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0052",
                column: "anh",
                value: "52");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0053",
                column: "anh",
                value: "53");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0054",
                column: "anh",
                value: "54");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0055",
                column: "anh",
                value: "55");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0056",
                column: "anh",
                value: "56");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0057",
                column: "anh",
                value: "57");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0058",
                column: "anh",
                value: "58");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0059",
                column: "anh",
                value: "59");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0060",
                column: "anh",
                value: "60");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0061",
                column: "anh",
                value: "61");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0062",
                column: "anh",
                value: "62");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0063",
                column: "anh",
                value: "63");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0064",
                column: "anh",
                value: "64");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0065",
                column: "anh",
                value: "65");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0066",
                column: "anh",
                value: "66");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0067",
                column: "anh",
                value: "67");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0068",
                column: "anh",
                value: "68");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0069",
                column: "anh",
                value: "69");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0070",
                column: "anh",
                value: "70");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0071",
                column: "anh",
                value: "71");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0072",
                column: "anh",
                value: "72");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0073",
                column: "anh",
                value: "73");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0074",
                column: "anh",
                value: "74");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0075",
                column: "anh",
                value: "75");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0076",
                column: "anh",
                value: "76");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0077",
                column: "anh",
                value: "77");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0078",
                column: "anh",
                value: "78");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0079",
                column: "anh",
                value: "79");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0080",
                column: "anh",
                value: "80");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0081",
                column: "anh",
                value: "81");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0082",
                column: "anh",
                value: "82");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0083",
                column: "anh",
                value: "83");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0084",
                column: "anh",
                value: "84");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0085",
                column: "anh",
                value: "85");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0086",
                column: "anh",
                value: "86");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0087",
                column: "anh",
                value: "87");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0088",
                column: "anh",
                value: "88");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0089",
                column: "anh",
                value: "89");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0090",
                column: "anh",
                value: "90");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0091",
                column: "anh",
                value: "91");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0092",
                column: "anh",
                value: "92");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0093",
                column: "anh",
                value: "93");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0094",
                column: "anh",
                value: "94");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0095",
                column: "anh",
                value: "95");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0096",
                column: "anh",
                value: "96");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0097",
                column: "anh",
                value: "97");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0098",
                column: "anh",
                value: "98");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0099",
                column: "anh",
                value: "99");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0100",
                column: "anh",
                value: "100");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0101",
                column: "anh",
                value: "101");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0102",
                column: "anh",
                value: "102");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0103",
                column: "anh",
                value: "103");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0104",
                column: "anh",
                value: "104");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0105",
                column: "anh",
                value: "105");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0106",
                column: "anh",
                value: "106");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0107",
                column: "anh",
                value: "107");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0108",
                column: "anh",
                value: "108");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0109",
                column: "anh",
                value: "109");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0110",
                column: "anh",
                value: "110");

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0111",
                column: "anh",
                value: "111");
        }
    }
}
