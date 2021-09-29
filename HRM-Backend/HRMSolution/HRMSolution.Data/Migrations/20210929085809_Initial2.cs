using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    tenDangNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    matKhau = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    vaiTro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.tenDangNhap);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_tinhChatLaoDong",
                table: "NhanVien",
                column: "tinhChatLaoDong");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_danhMucTinhChatLaoDongs_tinhChatLaoDong",
                table: "NhanVien",
                column: "tinhChatLaoDong",
                principalTable: "danhMucTinhChatLaoDongs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_danhMucTinhChatLaoDongs_tinhChatLaoDong",
                table: "NhanVien");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_tinhChatLaoDong",
                table: "NhanVien");
        }
    }
}
