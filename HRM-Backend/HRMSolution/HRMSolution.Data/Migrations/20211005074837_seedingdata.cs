using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "tuThoiGian",
                table: "TrinhDoVanHoa",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "denThoiGian",
                table: "TrinhDoVanHoa",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDang",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NguoiThan",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCap",
                table: "NgoaiNgu",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayKetThuc",
                table: "Luong",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHieuLuc",
                table: "Luong",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "hopDongTuNgay",
                table: "HopDong",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "hopDongDenNgay",
                table: "HopDong",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHieuLuc",
                table: "DieuChuyen",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DanhMucChucDanh",
                columns: new[] { "id", "maChucDanh", "phuCap", "tenChucDanh" },
                values: new object[,]
                {
                    { 1, "CD01", 100000f, "Cử Nhân" },
                    { 2, "CD02", 200000f, "Thạc Sĩ" },
                    { 3, "CD03", 300000f, "Tiến Sĩ" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucChucVu",
                columns: new[] { "id", "maChucVu", "phuCap", "tenChucVu" },
                values: new object[,]
                {
                    { 1, "CV01", 100000f, "Nhân viên" },
                    { 2, "CV02", 200000f, "Trưởng Phòng" },
                    { 3, "CV03", 300000f, "Giám Đốc" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucChuyenMon",
                columns: new[] { "id", "maChuyenMon", "tenChuyenMon" },
                values: new object[,]
                {
                    { 4, "CM04", "Kế toán – kiểm toán" },
                    { 3, "CM03", "Quản tị kinh doanh" },
                    { 5, "CM05", "Kinh Tế" },
                    { 1, "CM01", "Tài chính – ngân hàng" },
                    { 2, "CM02", "Hành chính văn phòng" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucDanToc",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[,]
                {
                    { 1, "kinh" },
                    { 2, "Mông" },
                    { 3, "Thái" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucHonNhan",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[] { 1, "Độc Thân" });

            migrationBuilder.InsertData(
                table: "DanhMucKhenThuongKyLuat",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[] { 1, "Thưởng Nhân viên suất xác tháng" });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiHopDong",
                columns: new[] { "id", "maLoaiHopDong", "tenLoaiHopDong" },
                values: new object[,]
                {
                    { 1, "MHD01", "Hợp đồng một năm" },
                    { 2, "MHD02", "Hợp đồng ba năm" },
                    { 3, "MHD03", "Hợp đồng vô thời hạn" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNgachCongChuc",
                columns: new[] { "id", "tenNgach" },
                values: new object[,]
                {
                    { 4, "Loại D" },
                    { 3, "Loại C" },
                    { 1, "Loại A" },
                    { 2, "Loại B" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNgoaiNgu",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[,]
                {
                    { 1, "Tiếng Anh" },
                    { 2, "Tiếng Trung Quốc" },
                    { 3, "Tiếng pháp" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNguoiThan",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[,]
                {
                    { 1, "Bố" },
                    { 2, "Mẹ" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucPhongBan",
                columns: new[] { "id", "maPhongBan", "tenPhongBan" },
                values: new object[,]
                {
                    { 3, "PB03", "3" },
                    { 1, "PB01", "1" },
                    { 2, "PB02", "2" },
                    { 4, "PB04", "4" },
                    { 5, "PB05", "5" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTonGiao",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[] { 1, "không" });

            migrationBuilder.InsertData(
                table: "DanhMucTrinhDo",
                columns: new[] { "id", "tenTrinhDo" },
                values: new object[,]
                {
                    { 1, "Giỏi" },
                    { 2, "Khá" }
                });

            migrationBuilder.InsertData(
                table: "HinhThucDaoTao",
                columns: new[] { "id", "tenHinhThuc" },
                values: new object[,]
                {
                    { 1, "Đại học" },
                    { 2, "Cao đẳng" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "tenDangNhap", "matKhau", "vaiTro" },
                values: new object[] { "admin", "123", 1 });

            migrationBuilder.InsertData(
                table: "danhMucTinhChatLaoDongs",
                columns: new[] { "id", "tenTinhChat" },
                values: new object[] { 1, "Chính thức" });

            migrationBuilder.InsertData(
                table: "DanhMucTo",
                columns: new[] { "idTo", "idPhongBan", "maTo", "tenTo" },
                values: new object[,]
                {
                    { 1, 1, "T01", "Tổ 1" },
                    { 20, 5, "T019", "Tổ 19" },
                    { 19, 5, "T018", "Tổ 18" },
                    { 18, 5, "T017", "Tổ 17" },
                    { 17, 4, "T016", "Tổ 16" },
                    { 16, 4, "T015", "Tổ 15" },
                    { 15, 4, "T014", "Tổ 14" },
                    { 14, 4, "T013", "Tổ 13" },
                    { 13, 3, "T012", "Tổ 12" },
                    { 12, 3, "T011", "Tổ 11" },
                    { 11, 3, "T010", "Tổ 10" },
                    { 10, 3, "T09", "Tổ 9" },
                    { 9, 2, "T08", "Tổ 8" },
                    { 8, 2, "T07", "Tổ 7" },
                    { 7, 2, "T06", "Tổ 6" },
                    { 6, 2, "T06", "Tổ 5" },
                    { 5, 1, "T05", "Tổ 4" },
                    { 4, 1, "T04", "Tổ 3" },
                    { 3, 1, "T03", "Tổ 2" },
                    { 2, 1, "T02", "Tổ 1" },
                    { 21, 5, "T020", "Tổ 20" }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idPhongBan", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayHetHanCCCD", "ngaySinh", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "to", "trangThaiLaoDong" },
                values: new object[] { "NV0001", "1", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "code", null, "0961441404", "02466666", null, null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, 1, null, null, null, null, null, null, new DateTime(2021, 10, 5, 14, 48, 36, 649, DateTimeKind.Local).AddTicks(7636), new DateTime(2021, 10, 5, 14, 48, 36, 649, DateTimeKind.Local).AddTicks(7970), new DateTime(2021, 10, 5, 14, 48, 36, 648, DateTimeKind.Local).AddTicks(4942), "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, "Hưng Yên", "Việt Nam", null, "Đại học FPT", null, "Điện Biên", 1, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DanhMucChucDanh",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucChucDanh",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucChucDanh",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucChucVu",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucChucVu",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucChucVu",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucChuyenMon",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucChuyenMon",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucChuyenMon",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucChuyenMon",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DanhMucChuyenMon",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DanhMucDanToc",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucDanToc",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucKhenThuongKyLuat",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucLoaiHopDong",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucLoaiHopDong",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucLoaiHopDong",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucNgachCongChuc",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucNgachCongChuc",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucNgachCongChuc",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DanhMucNgoaiNgu",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucNgoaiNgu",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucNgoaiNgu",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucNguoiThan",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucNguoiThan",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DanhMucTo",
                keyColumn: "idTo",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DanhMucTrinhDo",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucTrinhDo",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HinhThucDaoTao",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HinhThucDaoTao",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "maNhanVien",
                keyValue: "NV0001");

            migrationBuilder.DeleteData(
                table: "TaiKhoan",
                keyColumn: "tenDangNhap",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "DanhMucDanToc",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucHonNhan",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucNgachCongChuc",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucPhongBan",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMucPhongBan",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMucPhongBan",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DanhMucPhongBan",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DanhMucPhongBan",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DanhMucTonGiao",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "danhMucTinhChatLaoDongs",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tuThoiGian",
                table: "TrinhDoVanHoa",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "denThoiGian",
                table: "TrinhDoVanHoa",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayXuatNgu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDoan",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDangChinhThuc",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoDang",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayVaoBan",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayTuyenDung",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayThuViec",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNhapNgu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayNghiViec",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanHoChieu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHetHanCCCD",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayChinhThuc",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapHoChieu",
                table: "NhanVien",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCapCCCD",
                table: "NhanVien",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngaySinh",
                table: "NguoiThan",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayCap",
                table: "NgoaiNgu",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayKetThuc",
                table: "Luong",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHieuLuc",
                table: "Luong",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "hopDongTuNgay",
                table: "HopDong",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "hopDongDenNgay",
                table: "HopDong",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ngayHieuLuc",
                table: "DieuChuyen",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
