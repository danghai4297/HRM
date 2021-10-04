using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucChucDanh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maChucDanh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tenChucDanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phuCap = table.Column<float>(type: "real", nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChucDanh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChucVu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maChucVu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phuCap = table.Column<float>(type: "real", nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChucVu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChuyenMon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenChuyenMon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maChuyenMon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChuyenMon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucDanToc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucDanToc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucHonNhan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucHonNhan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhenThuongKyLuat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKhenThuongKyLuat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiHopDong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maLoaiHopDong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tenLoaiHopDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucLoaiHopDong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNgachCongChuc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNgach = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNgachCongChuc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNgoaiNgu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNgoaiNgu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNguoiThan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNguoiThan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucPhongBan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maPhongBan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tenPhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucPhongBan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "danhMucTinhChatLaoDongs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTinhChat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhMucTinhChatLaoDongs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucTonGiao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucTonGiao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucTrinhDo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTrinhDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucTrinhDo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucDaoTao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenHinhThuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucDaoTao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LichSu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    thaoTac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hanhDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayThucHien = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSu", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "DanhMucTo",
                columns: table => new
                {
                    idTo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maTo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tenTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idPhongBan = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucTo", x => x.idTo);
                    table.ForeignKey(
                        name: "FK_DanhMucTo_DanhMucPhongBan_idPhongBan",
                        column: x => x.idPhongBan,
                        principalTable: "DanhMucPhongBan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    quocTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    gioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    dienThoai = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    dienThoaiKhac = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    diDong = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    facebook = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    skype = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    maSoThue = table.Column<int>(type: "int", nullable: true),
                    hoChieu = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    noiCapHoChieu = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ngayCapHoChieu = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayHetHanHoChieu = table.Column<DateTime>(type: "datetime", nullable: true),
                    cccd = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ngayCapCCCD = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngayHetHanCCCD = table.Column<DateTime>(type: "datetime", nullable: false),
                    noiCapCCCD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    noiSinh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    queQuan = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    thuongTru = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    tamTru = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ngheNghiep = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    chucVuHienTai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayTuyenDung = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayThuViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    congViecChinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayVaoBan = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayChinhThuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    coQuanTuyenDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngachCongChucNoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngayVaoDang = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayVaoDangChinhThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayNhapNgu = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayXuatNgu = table.Column<DateTime>(type: "datetime", nullable: true),
                    quanHamCaoNhat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    danhHieuCaoNhat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngayVaoDoan = table.Column<DateTime>(type: "datetime", nullable: true),
                    noiThamGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    laThuongBinh = table.Column<bool>(type: "bit", nullable: true),
                    laConChinhSach = table.Column<bool>(type: "bit", nullable: true),
                    thuongBinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    conChinhSach = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bhxh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    bhyt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    atm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trangThaiLaoDong = table.Column<bool>(type: "bit", nullable: true),
                    ngayNghiViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    lyDoNghiViec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    anh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tinhChatLaoDong = table.Column<int>(type: "int", nullable: false),
                    idDanhMucHonNhan = table.Column<int>(type: "int", nullable: false),
                    idDanToc = table.Column<int>(type: "int", nullable: false),
                    idTonGiao = table.Column<int>(type: "int", nullable: false),
                    idPhongBan = table.Column<int>(type: "int", nullable: false),
                    to = table.Column<int>(type: "int", nullable: false),
                    idNgachCongChuc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.maNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_DanhMucDanToc_idDanToc",
                        column: x => x.idDanToc,
                        principalTable: "DanhMucDanToc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_DanhMucHonNhan_idDanhMucHonNhan",
                        column: x => x.idDanhMucHonNhan,
                        principalTable: "DanhMucHonNhan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_DanhMucNgachCongChuc_idNgachCongChuc",
                        column: x => x.idNgachCongChuc,
                        principalTable: "DanhMucNgachCongChuc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_DanhMucPhongBan_idPhongBan",
                        column: x => x.idPhongBan,
                        principalTable: "DanhMucPhongBan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_danhMucTinhChatLaoDongs_tinhChatLaoDong",
                        column: x => x.tinhChatLaoDong,
                        principalTable: "danhMucTinhChatLaoDongs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_DanhMucTonGiao_idTonGiao",
                        column: x => x.idTonGiao,
                        principalTable: "DanhMucTonGiao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DieuChuyen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ngayHieuLuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    phong = table.Column<int>(type: "int", nullable: false),
                    to = table.Column<int>(type: "int", nullable: false),
                    chiTiet = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    idChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieuChuyen", x => x.id);
                    table.ForeignKey(
                        name: "FK_DieuChuyen_DanhMucChucVu_idChucVu",
                        column: x => x.idChucVu,
                        principalTable: "DanhMucChucVu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DieuChuyen_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    maHopDong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    idLoaiHopDong = table.Column<int>(type: "int", nullable: false),
                    idChucDanh = table.Column<int>(type: "int", nullable: false),
                    hopDongTuNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    hopDongDenNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.maHopDong);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucChucDanh_idChucDanh",
                        column: x => x.idChucDanh,
                        principalTable: "DanhMucChucDanh",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucLoaiHopDong_idLoaiHopDong",
                        column: x => x.idLoaiHopDong,
                        principalTable: "DanhMucLoaiHopDong",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuongKyLuat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDanhMucKhenThuong = table.Column<int>(type: "int", nullable: false),
                    noiDung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lyDo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    loai = table.Column<bool>(type: "bit", nullable: true),
                    anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuongKyLuat", x => x.id);
                    table.ForeignKey(
                        name: "FK_KhenThuongKyLuat_DanhMucKhenThuongKyLuat_idDanhMucKhenThuong",
                        column: x => x.idDanhMucKhenThuong,
                        principalTable: "DanhMucKhenThuongKyLuat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhenThuongKyLuat_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuBanThan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biBatDiTu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    thamGiaChinhTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    thanNhanNuocNgoai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuBanThan", x => x.id);
                    table.ForeignKey(
                        name: "FK_LichSuBanThan_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LienHeKhanCap",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    quanHe = table.Column<int>(type: "int", nullable: true),
                    dienThoai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHeKhanCap", x => x.id);
                    table.ForeignKey(
                        name: "FK_LienHeKhanCap_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NgoaiNgu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDanhMucNgoaiNgu = table.Column<int>(type: "int", nullable: false),
                    ngayCap = table.Column<DateTime>(type: "datetime", nullable: true),
                    trinhDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    noiCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgoaiNgu", x => x.id);
                    table.ForeignKey(
                        name: "FK_NgoaiNgu_DanhMucNgoaiNgu_idDanhMucNgoaiNgu",
                        column: x => x.idDanhMucNgoaiNgu,
                        principalTable: "DanhMucNgoaiNgu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NgoaiNgu_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiThan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNguoiThan = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    gioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    ngaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    quanHe = table.Column<int>(type: "int", nullable: true),
                    ngheNghiep = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    dienThoai = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    khac = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    idDanhMucNguoiThan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiThan", x => x.id);
                    table.ForeignKey(
                        name: "FK_NguoiThan_DanhMucNguoiThan_idDanhMucNguoiThan",
                        column: x => x.idDanhMucNguoiThan,
                        principalTable: "DanhMucNguoiThan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiThan_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDoVanHoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTruong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idChuyenMon = table.Column<int>(type: "int", nullable: false),
                    tuThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    denThoiGian = table.Column<DateTime>(type: "datetime", nullable: true),
                    idHinhThucDaoTao = table.Column<int>(type: "int", nullable: false),
                    idTrinhDo = table.Column<int>(type: "int", nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinhDoVanHoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrinhDoVanHoa_DanhMucChuyenMon_idChuyenMon",
                        column: x => x.idChuyenMon,
                        principalTable: "DanhMucChuyenMon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrinhDoVanHoa_DanhMucTrinhDo_idTrinhDo",
                        column: x => x.idTrinhDo,
                        principalTable: "DanhMucTrinhDo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrinhDoVanHoa_HinhThucDaoTao_idHinhThucDaoTao",
                        column: x => x.idHinhThucDaoTao,
                        principalTable: "HinhThucDaoTao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrinhDoVanHoa_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YTe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhomMau = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    chieuCao = table.Column<float>(type: "real", nullable: true),
                    canNang = table.Column<float>(type: "real", nullable: true),
                    tinhTrangSucKhoe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    benhTat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    luuY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    khuyetTat = table.Column<bool>(type: "bit", nullable: true),
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTe", x => x.id);
                    table.ForeignKey(
                        name: "FK_YTe_NhanVien_maNhanVien",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maHopDong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nhomLuong = table.Column<int>(type: "int", nullable: true),
                    heSoLuong = table.Column<float>(type: "real", nullable: true),
                    bacLuong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    luongCoBan = table.Column<float>(type: "real", nullable: true),
                    phuCapTrachNhiem = table.Column<float>(type: "real", nullable: true),
                    phuCapKhac = table.Column<float>(type: "real", nullable: true),
                    tongLuong = table.Column<float>(type: "real", nullable: true),
                    thoiHanLenLuong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ngayHieuLuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayKetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.id);
                    table.ForeignKey(
                        name: "FK_Luong_HopDong_maHopDong",
                        column: x => x.maHopDong,
                        principalTable: "HopDong",
                        principalColumn: "maHopDong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTo_idPhongBan",
                table: "DanhMucTo",
                column: "idPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyen_idChucVu",
                table: "DieuChuyen",
                column: "idChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyen_maNhanVien",
                table: "DieuChuyen",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_idChucDanh",
                table: "HopDong",
                column: "idChucDanh");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_idLoaiHopDong",
                table: "HopDong",
                column: "idLoaiHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_maNhanVien",
                table: "HopDong",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_idDanhMucKhenThuong",
                table: "KhenThuongKyLuat",
                column: "idDanhMucKhenThuong");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_maNhanVien",
                table: "KhenThuongKyLuat",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuBanThan_maNhanVien",
                table: "LichSuBanThan",
                column: "maNhanVien",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LienHeKhanCap_maNhanVien",
                table: "LienHeKhanCap",
                column: "maNhanVien",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Luong_maHopDong",
                table: "Luong",
                column: "maHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_NgoaiNgu_idDanhMucNgoaiNgu",
                table: "NgoaiNgu",
                column: "idDanhMucNgoaiNgu");

            migrationBuilder.CreateIndex(
                name: "IX_NgoaiNgu_maNhanVien",
                table: "NgoaiNgu",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThan_idDanhMucNguoiThan",
                table: "NguoiThan",
                column: "idDanhMucNguoiThan");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThan_maNhanVien",
                table: "NguoiThan",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_idDanhMucHonNhan",
                table: "NhanVien",
                column: "idDanhMucHonNhan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_idDanToc",
                table: "NhanVien",
                column: "idDanToc");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_idNgachCongChuc",
                table: "NhanVien",
                column: "idNgachCongChuc");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_idPhongBan",
                table: "NhanVien",
                column: "idPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_idTonGiao",
                table: "NhanVien",
                column: "idTonGiao");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_tinhChatLaoDong",
                table: "NhanVien",
                column: "tinhChatLaoDong");

            migrationBuilder.CreateIndex(
                name: "IX_TrinhDoVanHoa_idChuyenMon",
                table: "TrinhDoVanHoa",
                column: "idChuyenMon");

            migrationBuilder.CreateIndex(
                name: "IX_TrinhDoVanHoa_idHinhThucDaoTao",
                table: "TrinhDoVanHoa",
                column: "idHinhThucDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_TrinhDoVanHoa_idTrinhDo",
                table: "TrinhDoVanHoa",
                column: "idTrinhDo");

            migrationBuilder.CreateIndex(
                name: "IX_TrinhDoVanHoa_maNhanVien",
                table: "TrinhDoVanHoa",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_YTe_maNhanVien",
                table: "YTe",
                column: "maNhanVien",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhMucTo");

            migrationBuilder.DropTable(
                name: "DieuChuyen");

            migrationBuilder.DropTable(
                name: "KhenThuongKyLuat");

            migrationBuilder.DropTable(
                name: "LichSu");

            migrationBuilder.DropTable(
                name: "LichSuBanThan");

            migrationBuilder.DropTable(
                name: "LienHeKhanCap");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NgoaiNgu");

            migrationBuilder.DropTable(
                name: "NguoiThan");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TrinhDoVanHoa");

            migrationBuilder.DropTable(
                name: "YTe");

            migrationBuilder.DropTable(
                name: "DanhMucChucVu");

            migrationBuilder.DropTable(
                name: "DanhMucKhenThuongKyLuat");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "DanhMucNgoaiNgu");

            migrationBuilder.DropTable(
                name: "DanhMucNguoiThan");

            migrationBuilder.DropTable(
                name: "DanhMucChuyenMon");

            migrationBuilder.DropTable(
                name: "DanhMucTrinhDo");

            migrationBuilder.DropTable(
                name: "HinhThucDaoTao");

            migrationBuilder.DropTable(
                name: "DanhMucChucDanh");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiHopDong");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "DanhMucDanToc");

            migrationBuilder.DropTable(
                name: "DanhMucHonNhan");

            migrationBuilder.DropTable(
                name: "DanhMucNgachCongChuc");

            migrationBuilder.DropTable(
                name: "DanhMucPhongBan");

            migrationBuilder.DropTable(
                name: "danhMucTinhChatLaoDongs");

            migrationBuilder.DropTable(
                name: "DanhMucTonGiao");
        }
    }
}
