using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

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
                name: "DanhMucHinhThucDaoTao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenHinhThuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucHinhThucDaoTao", x => x.id);
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
                    tenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tieuDe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                name: "DanhMucNhomLuong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNhomLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenNhomLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNhomLuong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucTinhChatLaoDong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maPhongBan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tenPhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucTinhChatLaoDong", x => x.id);
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
                name: "LichSu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    thaoTac = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayThucHien = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSu", x => x.id);
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
                        name: "FK_DanhMucTo_DanhMucTinhChatLaoDong_idPhongBan",
                        column: x => x.idPhongBan,
                        principalTable: "DanhMucTinhChatLaoDong",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    quocTich = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    gioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    dienThoai = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    dienThoaiKhac = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    diDong = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    facebook = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    skype = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    maSoThue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cccd = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    noiCapCCCD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ngayCapCCCD = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngayHetHanCCCD = table.Column<DateTime>(type: "datetime", nullable: false),
                    hoChieu = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    noiCapHoChieu = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ngayCapHoChieu = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayHetHanHoChieu = table.Column<DateTime>(type: "datetime", nullable: true),
                    noiSinh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    queQuan = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    thuongTru = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    tamTru = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ngheNghiep = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    chucVuHienTai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayTuyenDung = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayThuViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    congViecChinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayVaoBan = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayChinhThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    coQuanTuyenDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngachCongChucNoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vaoDang = table.Column<bool>(type: "bit", nullable: false),
                    ngayVaoDang = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayVaoDangChinhThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    quanNhan = table.Column<bool>(type: "bit", nullable: false),
                    ngayNhapNgu = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngayXuatNgu = table.Column<DateTime>(type: "datetime", nullable: true),
                    quanHamCaoNhat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    danhHieuCaoNhat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngayVaoDoan = table.Column<DateTime>(type: "datetime", nullable: true),
                    noiThamGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    laThuongBinh = table.Column<bool>(type: "bit", nullable: false),
                    laConChinhSach = table.Column<bool>(type: "bit", nullable: false),
                    thuongBinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    conChinhSach = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bhxh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    bhyt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    atm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trangThaiLaoDong = table.Column<bool>(type: "bit", nullable: false),
                    ngayNghiViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    lyDoNghiViec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    anh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tinhChatLaoDong = table.Column<int>(type: "int", nullable: false),
                    idDanhMucHonNhan = table.Column<int>(type: "int", nullable: false),
                    idDanToc = table.Column<int>(type: "int", nullable: false),
                    idTonGiao = table.Column<int>(type: "int", nullable: false),
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
                    ngayHieuLuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    idPhongBan = table.Column<int>(type: "int", nullable: false),
                    to = table.Column<int>(type: "int", nullable: false),
                    chiTiet = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    idChucVu = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_DieuChuyen_DanhMucTinhChatLaoDong_idPhongBan",
                        column: x => x.idPhongBan,
                        principalTable: "DanhMucTinhChatLaoDong",
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
                    id = table.Column<int>(type: "int", nullable: false),
                    idLoaiHopDong = table.Column<int>(type: "int", nullable: false),
                    idChucDanh = table.Column<int>(type: "int", nullable: false),
                    hopDongTuNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    hopDongDenNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    trangThai = table.Column<bool>(type: "bit", nullable: false),
                    bangChung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    loai = table.Column<bool>(type: "bit", nullable: false),
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
                    quanHe = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    ngayCap = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    ngaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    quanHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_TrinhDoVanHoa_DanhMucHinhThucDaoTao_idHinhThucDaoTao",
                        column: x => x.idHinhThucDaoTao,
                        principalTable: "DanhMucHinhThucDaoTao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrinhDoVanHoa_DanhMucTrinhDo_idTrinhDo",
                        column: x => x.idTrinhDo,
                        principalTable: "DanhMucTrinhDo",
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
                    chieuCao = table.Column<float>(type: "real", nullable: false),
                    canNang = table.Column<float>(type: "real", nullable: false),
                    tinhTrangSucKhoe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    benhTat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    luuY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    khuyetTat = table.Column<bool>(type: "bit", nullable: false),
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
                    idNhomLuong = table.Column<int>(type: "int", nullable: false),
                    heSoLuong = table.Column<float>(type: "real", nullable: true),
                    bacLuong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    luongCoBan = table.Column<float>(type: "real", nullable: true),
                    phuCapTrachNhiem = table.Column<float>(type: "real", nullable: true),
                    phuCapKhac = table.Column<float>(type: "real", nullable: true),
                    tongLuong = table.Column<float>(type: "real", nullable: true),
                    thoiHanLenLuong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ngayHieuLuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    ngayKetThuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<bool>(type: "bit", nullable: false),
                    bangChung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.id);
                    table.ForeignKey(
                        name: "FK_Luong_DanhMucNhomLuong_idNhomLuong",
                        column: x => x.idNhomLuong,
                        principalTable: "DanhMucNhomLuong",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Luong_HopDong_maHopDong",
                        column: x => x.maHopDong,
                        principalTable: "HopDong",
                        principalColumn: "maHopDong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "ghiChu" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "a737077f-a418-47bd-a9fa-45c27637a27c", "admin", "admin", "Administrator role" },
                    { new Guid("30c6f17d-e44f-4e5d-9bf9-1bd98c377cec"), "3f915df3-1641-4917-876d-a187527a04b2", "user", "user", "User role" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("30c6f17d-e44f-4e5d-9bf9-1bd98c377cec"), new Guid("1db26eb2-1870-4129-f60a-08d9978ff76b") },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") },
                    { new Guid("30c6f17d-e44f-4e5d-9bf9-1bd98c377cec"), new Guid("ccf28057-5be9-4405-957b-460e0ce106a7") },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("ccf28057-5be9-4405-957b-460e0ce106a7") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "maNhanVien" },
                values: new object[,]
                {
                    { new Guid("ccf28057-5be9-4405-957b-460e0ce106a7"), 0, "6dc92be5-803c-4796-aa18-7ae1a5d41540", null, true, false, null, null, "user3", "AQAAAAEAACcQAAAAECyuxzWfAET4ca7KUg2cYOzf3nBDSay1qco+E9dqPbX9M2tmB2sDkjNt7hfIBlpYhg==", null, false, "", false, "user3", "NV0003" },
                    { new Guid("1db26eb2-1870-4129-f60a-08d9978ff76b"), 0, "a4f78aa8-0bbe-4ac4-93ce-50ce717aeef5", null, true, false, null, null, "user1", "AQAAAAEAACcQAAAAEDcz79a5HHk1LyYQxvYkDQfZt5m8ZaB7xcu3qdTTUwdjKSk2wbThGuMubmgGm0oB9A==", null, false, "", false, "user1", "NV0002" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "3415ef8a-fc6e-4c9a-a33f-7af928d414d1", null, true, false, null, null, "admin", "AQAAAAEAACcQAAAAEMe6Ck3BN0VeciIVkwILbvWGnnWjxMcNhNgaFAoYeGnO+YIFw5WTLy8LRqsjRJpEbg==", null, false, "", false, "admin", "NV0001" }
                });

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
                    { 2, "CV02", 200000f, "Trưởng Phòng" },
                    { 1, "CV01", 100000f, "Nhân viên" },
                    { 3, "CV03", 300000f, "Giám Đốc" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucChuyenMon",
                columns: new[] { "id", "maChuyenMon", "tenChuyenMon" },
                values: new object[,]
                {
                    { 1, "CM01", "Tài chính – ngân hàng" },
                    { 2, "CM02", "Hành chính văn phòng" },
                    { 3, "CM03", "Quản tị kinh doanh" },
                    { 5, "CM05", "Kinh Tế" },
                    { 4, "CM04", "Kế toán – kiểm toán" }
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
                table: "DanhMucHinhThucDaoTao",
                columns: new[] { "id", "tenHinhThuc" },
                values: new object[,]
                {
                    { 1, "Đại học" },
                    { 2, "Cao đẳng" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucHonNhan",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[] { 1, "Độc Thân" });

            migrationBuilder.InsertData(
                table: "DanhMucKhenThuongKyLuat",
                columns: new[] { "id", "tenDanhMuc", "tieuDe" },
                values: new object[,]
                {
                    { 5, "Phạt Nhân viên kém nhất quý", "Kỷ luật" },
                    { 3, "Thưởng Nhân viên suất xác quý", "Khen thưởng" },
                    { 2, "Thưởng Nhân viên suất xác năm", "Khen thưởng" },
                    { 1, "Thưởng Nhân viên suất xác tháng", "Khen thưởng" },
                    { 4, "Phạt Nhân viên kém nhất tháng", "Kỷ luật" }
                });

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
                    { 1, "Loại A" },
                    { 2, "Loại B" },
                    { 3, "Loại C" }
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
                values: new object[] { 1, "Bố" });

            migrationBuilder.InsertData(
                table: "DanhMucNguoiThan",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[,]
                {
                    { 4, "Chị" },
                    { 3, "Anh" },
                    { 2, "Mẹ" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNhomLuong",
                columns: new[] { "id", "maNhomLuong", "tenNhomLuong" },
                values: new object[,]
                {
                    { 2, "MNL02", "Nhóm 2" },
                    { 1, "MNL01", "Nhóm 1" },
                    { 3, "MNL03", "Nhóm 3" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTinhChatLaoDong",
                columns: new[] { "id", "maPhongBan", "tenPhongBan" },
                values: new object[,]
                {
                    { 1, "PB01", "1" },
                    { 2, "PB02", "2" },
                    { 3, "PB03", "3" },
                    { 5, "PB05", "5" },
                    { 4, "PB04", "4" }
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
                table: "danhMucTinhChatLaoDongs",
                columns: new[] { "id", "tenTinhChat" },
                values: new object[] { 1, "Chính thức" });

            migrationBuilder.InsertData(
                table: "DanhMucTo",
                columns: new[] { "idTo", "idPhongBan", "maTo", "tenTo" },
                values: new object[,]
                {
                    { 1, 1, "T01", "Tổ 1" },
                    { 21, 5, "T020", "Tổ 20" },
                    { 20, 5, "T019", "Tổ 19" },
                    { 19, 5, "T018", "Tổ 18" },
                    { 18, 5, "T017", "Tổ 17" },
                    { 16, 4, "T015", "Tổ 15" },
                    { 15, 4, "T014", "Tổ 14" },
                    { 14, 4, "T013", "Tổ 13" },
                    { 13, 3, "T012", "Tổ 12" },
                    { 12, 3, "T011", "Tổ 11" },
                    { 17, 4, "T016", "Tổ 16" },
                    { 10, 3, "T09", "Tổ 9" },
                    { 9, 2, "T08", "Tổ 8" },
                    { 8, 2, "T07", "Tổ 7" },
                    { 7, 2, "T06", "Tổ 6" },
                    { 6, 2, "T06", "Tổ 5" },
                    { 5, 1, "T05", "Tổ 4" },
                    { 4, 1, "T04", "Tổ 3" },
                    { 3, 1, "T03", "Tổ 2" },
                    { 2, 1, "T02", "Tổ 1" },
                    { 11, 3, "T010", "Tổ 10" }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0332", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 6, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0333", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 6, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0334", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 9, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0335", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 6, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0336", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0341", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 7, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0338", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 5, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0339", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 4, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0340", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 10, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0342", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 6, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0331", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 6, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false },
                    { "NV0337", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0330", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 7, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0319", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 9, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0328", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Nguyễn Thị Bích Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 8, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0327", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trần Tuấn Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 10, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0326", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Phạm Thị Phương Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 10, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0325", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Quang Long", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 12, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0324", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hoàng Tùng Lâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 7, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0323", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 5, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0322", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 2, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0321", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 7, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0320", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Nam Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 11, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0343", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 6, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0318", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lê Nguyễn Diệu Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 1, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0317", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tiến Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 5, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0316", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 12, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0329", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 6, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0344", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0354", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 3, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0346", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 10, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0373", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Thiên Trường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 11, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0372", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Thành Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 4, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0371", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Huyền Thi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 10, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0370", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 9, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0369", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tô Diệu Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 8, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0368", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 5, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0367", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 7, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0366", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Thành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 12, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0365", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 6, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0364", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 1, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0363", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 10, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0362", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 11, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0361", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0360", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 2, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0359", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 6, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0358", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Mạnh Hùng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 5, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0357", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Hiệp Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 1, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0356", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Khoa Minh Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0355", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 2, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0315", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 6, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0353", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0352", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0351", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 3, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0350", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 1, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0349", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 4, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0348", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 9, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0347", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 5, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0345", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 2, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0314", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thu Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0303", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Điệp Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 4, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0312", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Phương Hoa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 2, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0279", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 9, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0278", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "	Đỗ Hải Nam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 6, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0277", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 3, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0276", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 10, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0275", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trọng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 11, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0274", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Nhật Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 8, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0273", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 8, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0272", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 11, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0271", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hà Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 9, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0270", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thùy Linh", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2005, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 1, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2008, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2008, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, false },
                    { "NV0269", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đinh Thùy Linh", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1990, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1972, 7, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2008, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1992, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0268", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Bảo Liên", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2005, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 7, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2008, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2008, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, false },
                    { "NV0267", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quốc Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 4, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0266", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Dương", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1980, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 7, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2008, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1985, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, false },
                    { "NV0265", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1980, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 11, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2008, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1982, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0264", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2005, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 1, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2008, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2008, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, false },
                    { "NV0263", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Thiên Trường", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2005, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 6, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2005, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2006, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2008, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0262", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Thành Trung", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2005, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2005, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2006, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2008, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, true },
                    { "NV0261", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Huyền Thi", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1971, 1, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, true },
                    { "NV0260", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 3, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2000, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, true },
                    { "NV0259", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tô Diệu Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 3, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0258", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hương Thảo", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1977, 1, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, true },
                    { "NV0257", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Phương Thảo", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1996, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 5, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, true },
                    { "NV0256", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Thành", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1972, 5, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, true },
                    { "NV0255", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 3, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, true },
                    { "NV0254", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 9, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0253", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 12, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0280", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0281", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Minh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 8, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0282", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Khánh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0283", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Uyên Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 10, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0311", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Sỹ Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 12, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0310", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Ngọc Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 8, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0309", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "	Lưu Ngọc Hiền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 8, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0308", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Gia Hân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 1, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0307", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phí Vũ Trí Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 2, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0306", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 6, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0305", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng An Đông", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 1, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0304", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Văn Đạt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 8, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0374", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0302", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trần Bình", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 4, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0301", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 1, 31, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0300", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Mai Tùng Bách", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 12, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0299", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Ngọc Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 3, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0313", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thanh Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 1, 31, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0298", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hùng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 7, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0296", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Hữu Minh Tường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 2, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0295", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Quốc Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0294", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Trung Minh Trí", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0293", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Minh Thư", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0292", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Dương Phúc Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 9, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0291", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trường Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 3, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0290", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Thanh Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 9, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0289", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Thành Tài", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 2, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0288", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Trần Trung Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 11, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0287", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phú Hải Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 2, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0286", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Đào Tuấn Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 8, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0285", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Lê Tất Hoàng Phát", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 11, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0284", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Đặng Gia Như", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 6, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0297", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Thị Phương Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0375", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 1, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0386", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 12, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0377", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quốc Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 5, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0467", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Hiệp Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 8, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0466", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Khoa Minh Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 1, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0465", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 4, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0464", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 6, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0463", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 8, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0462", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 9, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0461", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 1, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0460", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 1, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0459", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 4, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0458", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 10, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0457", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 1, 31, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0456", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 5, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0455", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0454", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 6, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0453", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 12, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0452", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 10, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0451", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 1, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0450", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 12, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0449", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 4, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0448", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 3, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0447", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 9, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0446", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0445", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0444", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 4, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0443", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 11, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0442", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 10, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0441", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false },
                    { "NV0468", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Mạnh Hùng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 11, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0469", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 3, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0470", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 9, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0471", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 4, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0499", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 11, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0498", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "	Đỗ Hải Nam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 9, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0497", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0496", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0495", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trọng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 1, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0494", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Nhật Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 10, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0493", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0492", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 6, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0491", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hà Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 11, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0490", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0489", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đinh Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0488", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Bảo Liên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 10, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0487", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quốc Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 1, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0440", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 2, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0486", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 10, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0484", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 6, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0483", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Thiên Trường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 2, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0482", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Thành Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 3, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0481", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Huyền Thi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 2, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0480", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 10, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0479", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tô Diệu Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 2, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0478", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 8, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0477", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 7, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0476", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Thành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 7, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0475", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 6, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0474", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 12, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0473", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0472", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 7, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0485", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 1, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0376", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 1, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0439", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0437", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trần Tuấn Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 5, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0404", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Trung Minh Trí", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 9, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0403", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Minh Thư", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 1, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0402", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Dương Phúc Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 7, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0401", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trường Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0400", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Thanh Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 8, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0399", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Thành Tài", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 3, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0398", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Trần Trung Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0397", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phú Hải Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 9, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0396", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Đào Tuấn Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 6, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0395", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Lê Tất Hoàng Phát", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 3, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0394", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Đặng Gia Như", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 10, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0393", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Uyên Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0392", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Khánh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 4, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0391", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Minh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 11, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0390", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 6, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0389", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 10, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0388", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "	Đỗ Hải Nam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 1, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0387", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 4, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0252", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 6, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0385", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trọng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 4, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0384", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Nhật Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0383", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0382", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 5, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0381", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hà Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 12, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0380", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 10, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0379", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đinh Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 12, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0378", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Bảo Liên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 9, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0405", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Quốc Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 12, 31, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0406", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Hữu Minh Tường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 2, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0407", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Thị Phương Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 7, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0408", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hùng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 8, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0436", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Phạm Thị Phương Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0435", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Quang Long", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 2, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0434", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hoàng Tùng Lâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 10, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0433", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 4, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0432", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0431", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 5, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0430", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Nam Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 7, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0429", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 8, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0428", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lê Nguyễn Diệu Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 6, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0427", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tiến Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 10, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0426", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 3, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0425", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 6, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0424", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thu Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 2, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0438", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Nguyễn Thị Bích Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 2, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0423", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thanh Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 4, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0421", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Sỹ Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 7, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0420", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Ngọc Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0419", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "	Lưu Ngọc Hiền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 2, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0418", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Gia Hân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 1, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0417", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phí Vũ Trí Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 10, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0416", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 4, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0415", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng An Đông", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 9, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0414", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Văn Đạt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 5, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0413", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Điệp Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 10, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0412", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trần Bình", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 5, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0411", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 2, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0410", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Mai Tùng Bách", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 10, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0409", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Ngọc Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 10, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0422", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Phương Hoa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 9, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0251", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0240", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 9, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0249", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0090", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Ngọc Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0089", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "	Lưu Ngọc Hiền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 7, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0088", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Gia Hân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0087", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phí Vũ Trí Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0086", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0085", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng An Đông", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0084", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Văn Đạt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0083", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Điệp Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 2, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0082", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trần Bình", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 1, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0081", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0080", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Mai Tùng Bách", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0079", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Ngọc Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0078", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hùng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 9, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0077", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Thị Phương Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 9, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0076", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Hữu Minh Tường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0075", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Quốc Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0074", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Trung Minh Trí", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 7, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0073", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Minh Thư", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0072", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Dương Phúc Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0071", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trường Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0070", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Thanh Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0069", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Thành Tài", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1984, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0068", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Trần Trung Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0067", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phú Hải Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 1, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0066", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Đào Tuấn Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 12, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0065", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Lê Tất Hoàng Phát", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0064", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Đặng Gia Như", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0091", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Sỹ Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0092", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Phương Hoa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0111", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Đức Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0093", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thanh Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0121", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hoài Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0120", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðức Tường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0119", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Thế Phương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0118", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hữu Canh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0117", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phước An", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0116", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðức Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0115", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hùng Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0114", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Kiến Ðức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0113", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quang Danh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0112", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðình Sang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0221", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phúc Tâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0110", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0109", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0063", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Uyên Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 10, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0108", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Nguyễn Thị Bích Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 8, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0106", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Phạm Thị Phương Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0105", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Quang Long", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0104", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hoàng Tùng Lâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0103", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0102", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0101", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0100", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Nam Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0099", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0098", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lê Nguyễn Diệu Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0097", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tiến Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0096", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0095", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0094", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thu Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0107", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trần Tuấn Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0122", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðại Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0062", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Khánh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 9, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0060", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 7, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0027", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Hiệp Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 1, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0026", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Khoa Minh Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0025", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 11, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0024", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0023", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0022", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 8, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0021", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0020", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 6, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, true },
                    { "NV0019", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 5, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0018", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2029, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1969, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0017", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Người bị địch bắt tù, đày", "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, true, false, null, null, null, null, new DateTime(2021, 3, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2039, 3, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 3, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0016", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, true, false, null, null, null, null, new DateTime(2021, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2036, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, true },
                    { "NV0015", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 2, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2033, 2, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 2, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0014", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441321", "02466777", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 1, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2033, 1, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 1, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0013", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961111111", "02466555", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2032, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0012", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961410000", "02476123", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2031, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0011", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "096182710", "02410297", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2041, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0010", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "096102186", "02407621", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2029, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0009", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961493761", "024423723", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2038, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0008", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961457891", "02406328", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0007", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961308520", "024012879", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 2, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2028, 2, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1968, 2, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0006", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961281563", "02464790", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2033, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0005", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961760123", "02466689", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Thái Bình", null, "Thái Bình", null, null, false, "Thái Bình", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0004", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961678934", "024666678", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0003", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0002", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961321872", "024666661", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0001", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, "huongdn@gmail.com", null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false },
                    { "NV0028", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Mạnh Hùng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 2, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0029", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 3, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0030", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 4, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0031", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, true },
                    { "NV0059", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0058", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "	Đỗ Hải Nam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 5, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0057", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0056", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 4, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0055", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trọng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0054", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Nhật Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0053", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 2, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0052", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 1, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0051", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hà Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 12, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0050", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 12, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0049", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đinh Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0048", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Bảo Liên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0047", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quốc Huy", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0061", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Minh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 8, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0046", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0044", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0043", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Thiên Trường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 5, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0042", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Thành Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 4, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0041", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Huyền Thi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0040", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0039", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tô Diệu Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0038", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0037", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0036", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Thành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 10, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0035", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 9, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0034", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 8, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0033", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 7, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0032", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0045", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0250", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1988, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 7, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, true },
                    { "NV0123", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hải Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0125", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quang Nhật", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0215", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Quang Long", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 4, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0214", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hoàng Tùng Lâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0213", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 3, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0212", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 8, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0211", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 11, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0210", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Nam Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 1, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0209", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 1, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0208", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lê Nguyễn Diệu Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 1, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0207", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tiến Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0206", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 12, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0205", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 6, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0204", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hạnh Vi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 12, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0203", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hồng Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 1, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0202", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Thảo Bội Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 9, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0201", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Việt Khoa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 9, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0200", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "024666661", null, null, null, true, null, "Hồ Việt Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0199", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "024666662", null, null, null, false, null, "Phạm Thanh Tâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0198", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "024666663", null, null, null, false, null, "Ngô Ngọc Quỳnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0197", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Kiều Ðông Nguyên", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1994, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 3, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1996, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0196", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Huy Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0195", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Dương Cao Sơn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0194", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Văn Đạt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0193", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Hồ Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0192", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Tống Tuấn Kiệt", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2000, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0191", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Hà Diễm Phúc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0190", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Chử Vạn Thắng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0189", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "An Ngọc Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0216", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Phạm Thị Phương Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 2, 3, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0217", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trần Tuấn Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 9, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0218", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Nguyễn Thị Bích Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 3, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0219", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 1, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0248", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Mạnh Hùng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 12, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0247", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Hiệp Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 2, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0246", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Khoa Minh Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 2, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0245", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 9, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0244", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 3, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0243", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 2, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0242", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1987, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 7, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, true },
                    { "NV0241", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0500", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 11, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0239", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 3, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0238", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 12, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0237", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 8, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0236", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0188", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phan Thiện Sinh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0235", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 11, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0233", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 1, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0232", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 1, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0231", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0230", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 1, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0229", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 3, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0228", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 8, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0227", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 11, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0226", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 2, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0225", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0224", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 8, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0223", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 12, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0222", "/user-content/068ba015-df62-4e5c-ae57-f267bc88b167.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 9, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0220", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0234", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 12, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0124", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đức Duy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0187", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Thạch Cẩm Nhi", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0185", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Võ Hải Thụy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0152", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phùng Danh Thành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0151", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hồng Vân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0150", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0149", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Ngô Phương Quyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0148", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Trúc Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0147", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Yến Trâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0146", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hữu Thiện", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0145", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Huỳnh Thái Sang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0144", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trầm Hồng Quế", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0143", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trí Hào", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 10, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0142", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tiêu Nguyệt Ánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0141", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Tôn Duy Luận", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0140", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Dương Thiên Lương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0139", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Thành Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0138", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Thạch Thắng Lợi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0137", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Vưu Gia Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0136", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hùng Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0135", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Ngô Khánh Duy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0134", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0133", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Quang Thủy Trang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0132", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Hà Hồng Quế", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0131", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "ồ Minh Tiế", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0130", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "09614414042", "024666665", null, null, null, false, null, "Nguyễn Nguyên Khôi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0129", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Việt Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0128", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Nam Nhật", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0127", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thanh Ðoàn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0126", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hoàng Ngôn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0153", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Dương Mai Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0154", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Úc Minh Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 5, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0155", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Huỳnh Thúy Hương", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 10, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0156", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Kim Nam Việt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 1, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0184", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Ðông Nguyên", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1998, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2000, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0183", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Sái Diễm Trang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0182", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Mạch Quý Vĩnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0181", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Tô Mạnh Tấn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0180", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Duy Uyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0179", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Thế Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0178", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Huỳnh Duy Hiền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0177", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Quyền Ðại Hành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0176", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Thiệu Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0175", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Thiệu Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0174", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thu Hường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0173", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Uất Hồng Ðào", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0172", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Dương Thanh Yến", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0186", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoài Việt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0171", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Hạnh Trang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0169", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Kiều Diệu Hằng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0168", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Việt Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0167", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Thiện Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0166", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Lương Chiêu Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0165", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Chung Ngọc Ẩn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0164", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Huỳnh Mộng Tuyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 1, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0163", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bành Ngọc Khanh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0162", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hồng Quế", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 7, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0161", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Bảo Trâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 6, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0160", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Mai Thanh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 5, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0159", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Mai Quyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 4, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0158", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trầm Thu Hường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0157", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Anh Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 2, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0170", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Quang Ánh Xuân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0501", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Minh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 1, "Không", 1, 1, "NV0001", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(1076), 1, false },
                    { 124, "Ahihi", 1, 2, "NV0122", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2915), 7, true },
                    { 123, "Ahihi", 1, 2, "NV0121", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2913), 7, true },
                    { 25, "Ahihi", 1, 1, "NV0023", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2717), 1, true },
                    { 122, "Ahihi", 1, 2, "NV0120", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2911), 7, true },
                    { 121, "Ahihi", 1, 2, "NV0119", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2910), 6, true },
                    { 120, "Ahihi", 1, 2, "NV0118", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2908), 6, true },
                    { 119, "Ahihi", 1, 2, "NV0117", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2906), 6, true },
                    { 26, "Ahihi", 1, 1, "NV0024", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2719), 1, true },
                    { 118, "Ahihi", 1, 2, "NV0116", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2904), 6, true },
                    { 117, "Ahihi", 1, 2, "NV0115", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2902), 6, true },
                    { 116, "Ahihi", 1, 2, "NV0114", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2900), 6, true },
                    { 115, "Ahihi", 1, 2, "NV0113", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2898), 6, true },
                    { 27, "Ahihi", 1, 1, "NV0025", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2721), 1, true },
                    { 114, "Ahihi", 1, 2, "NV0112", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2895), 6, true },
                    { 125, "Ahihi", 1, 2, "NV0123", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2917), 7, true },
                    { 112, "Ahihi", 1, 2, "NV0110", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2891), 6, true },
                    { 110, "Ahihi", 1, 2, "NV0108", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2887), 6, true },
                    { 28, "Ahihi", 1, 1, "NV0026", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2722), 1, true },
                    { 109, "Ahihi", 1, 2, "NV0107", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2885), 6, true },
                    { 108, "Ahihi", 1, 2, "NV0106", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2884), 6, true },
                    { 107, "Ahihi", 1, 2, "NV0105", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2882), 6, true },
                    { 106, "Ahihi", 1, 2, "NV0104", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2880), 6, true },
                    { 29, "Ahihi", 1, 1, "NV0027", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2724), 1, true },
                    { 105, "Ahihi", 1, 2, "NV0103", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2878), 6, true },
                    { 104, "Ahihi", 1, 2, "NV0102", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2876), 6, true },
                    { 103, "Ahihi", 1, 2, "NV0101", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2874), 6, true },
                    { 102, "Ahihi", 1, 2, "NV0100", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2872), 6, true },
                    { 30, "Ahihi", 1, 1, "NV0028", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2726), 1, true },
                    { 101, "Ahihi", 1, 2, "NV0099", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2870), 5, true },
                    { 100, "Ahihi", 1, 2, "NV0098", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2868), 5, true },
                    { 111, "Ahihi", 1, 2, "NV0109", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2889), 6, true },
                    { 126, "Ahihi", 1, 2, "NV0124", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2919), 7, true },
                    { 127, "Ahihi", 1, 2, "NV0125", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2921), 7, true },
                    { 24, "Ahihi", 1, 1, "NV0022", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2715), 1, true },
                    { 152, "Ahihi", 1, 2, "NV0150", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2974), 8, true },
                    { 18, "Ahihi", 1, 1, "NV0016", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2703), 3, true },
                    { 151, "Ahihi", 1, 2, "NV0149", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2972), 8, true },
                    { 150, "Ahihi", 1, 2, "NV0148", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2965), 8, true },
                    { 149, "Ahihi", 1, 2, "NV0147", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2963), 8, true },
                    { 148, "Ahihi", 1, 2, "NV0146", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2961), 8, true },
                    { 19, "Ahihi", 1, 1, "NV0017", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2705), 3, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 147, "Ahihi", 1, 2, "NV0145", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2959), 8, true },
                    { 146, "Ahihi", 1, 2, "NV0144", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2957), 8, true },
                    { 145, "Ahihi", 1, 2, "NV0143", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2955), 8, true },
                    { 144, "Ahihi", 1, 2, "NV0142", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2953), 8, true },
                    { 20, "Ahihi", 1, 1, "NV0018", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2706), 3, true },
                    { 143, "Ahihi", 1, 2, "NV0141", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2952), 8, true },
                    { 142, "Ahihi", 1, 2, "NV0140", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2950), 8, true },
                    { 141, "Ahihi", 1, 2, "NV0139", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2948), 7, true },
                    { 140, "Ahihi", 1, 2, "NV0138", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2946), 7, true },
                    { 21, "Ahihi", 1, 1, "NV0019", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2708), 3, true },
                    { 128, "Ahihi", 1, 2, "NV0126", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2923), 7, true },
                    { 129, "Ahihi", 1, 2, "NV0127", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2925), 7, true },
                    { 130, "Ahihi", 1, 2, "NV0128", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2927), 7, true },
                    { 131, "Ahihi", 1, 2, "NV0129", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2929), 7, true },
                    { 23, "Ahihi", 1, 1, "NV0021", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2713), 1, true },
                    { 132, "Ahihi", 1, 2, "NV0130", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2930), 7, true },
                    { 99, "Ahihi", 1, 2, "NV0097", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2866), 5, true },
                    { 133, "Ahihi", 1, 2, "NV0131", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2932), 7, true },
                    { 135, "Ahihi", 1, 2, "NV0133", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2936), 7, true },
                    { 22, "Ahihi", 1, 1, "NV0020", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2711), 1, true },
                    { 136, "Ahihi", 1, 2, "NV0134", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2938), 7, true },
                    { 137, "Ahihi", 1, 2, "NV0135", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2940), 7, true },
                    { 138, "Ahihi", 1, 2, "NV0136", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2941), 7, true },
                    { 139, "Ahihi", 1, 2, "NV0137", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2944), 7, true },
                    { 134, "Ahihi", 1, 2, "NV0132", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2934), 7, true },
                    { 153, "Ahihi", 1, 2, "NV0151", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2976), 8, true },
                    { 98, "Ahihi", 1, 2, "NV0096", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2865), 5, true },
                    { 97, "Ahihi", 1, 2, "NV0095", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2863), 5, true },
                    { 69, "Ahihi", 1, 1, "NV0067", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2809), 4, true },
                    { 68, "Ahihi", 1, 1, "NV0066", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2806), 4, true },
                    { 67, "Ahihi", 1, 1, "NV0065", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2804), 4, true },
                    { 66, "Ahihi", 1, 1, "NV0064", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2802), 4, true },
                    { 39, "Ahihi", 1, 1, "NV0037", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2743), 1, true },
                    { 65, "Ahihi", 1, 1, "NV0063", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2793), 4, true },
                    { 64, "Ahihi", 1, 1, "NV0062", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2792), 4, true },
                    { 63, "Ahihi", 1, 1, "NV0061", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2789), 4, true },
                    { 62, "Ahihi", 1, 1, "NV0060", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2787), 4, true },
                    { 40, "Ahihi", 1, 1, "NV0038", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2745), 1, true },
                    { 61, "Ahihi", 1, 1, "NV0059", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2785), 2, true },
                    { 60, "Ahihi", 1, 1, "NV0058", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2784), 2, true },
                    { 59, "Ahihi", 1, 1, "NV0057", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2782), 2, true },
                    { 58, "Ahihi", 1, 1, "NV0056", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2780), 2, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 38, "Ahihi", 1, 1, "NV0036", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2742), 1, true },
                    { 41, "Ahihi", 1, 1, "NV0039", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2747), 1, true },
                    { 56, "Ahihi", 1, 1, "NV0054", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2775), 2, true },
                    { 55, "Ahihi", 1, 1, "NV0053", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2774), 2, true },
                    { 54, "Ahihi", 1, 1, "NV0052", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2772), 2, true },
                    { 42, "Ahihi", 1, 1, "NV0040", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2749), 2, true },
                    { 53, "Ahihi", 1, 1, "NV0051", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2770), 2, true },
                    { 52, "Ahihi", 1, 1, "NV0050", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2768), 2, true },
                    { 51, "Ahihi", 1, 1, "NV0049", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2766), 2, true },
                    { 50, "Ahihi", 1, 1, "NV0048", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2764), 2, true },
                    { 43, "Ahihi", 1, 1, "NV0041", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2751), 2, true },
                    { 49, "Ahihi", 1, 1, "NV0047", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2762), 2, true },
                    { 48, "Ahihi", 1, 1, "NV0046", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2761), 2, true },
                    { 47, "Ahihi", 1, 1, "NV0045", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2759), 2, true },
                    { 44, "Ahihi", 1, 1, "NV0042", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2753), 2, true },
                    { 46, "Ahihi", 1, 1, "NV0044", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2757), 2, true },
                    { 57, "Ahihi", 1, 1, "NV0055", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2778), 2, true },
                    { 70, "Ahihi", 1, 1, "NV0068", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2810), 4, true },
                    { 71, "Ahihi", 1, 1, "NV0069", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2812), 4, true },
                    { 72, "Ahihi", 1, 1, "NV0070", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2814), 4, true },
                    { 96, "Ahihi", 1, 2, "NV0094", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2861), 5, true },
                    { 95, "Ahihi", 1, 2, "NV0093", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2859), 5, true },
                    { 113, "Ahihi", 1, 2, "NV0111", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2893), 6, true },
                    { 32, "Ahihi", 1, 1, "NV0030", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2730), 1, true },
                    { 94, "Ahihi", 1, 2, "NV0092", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2857), 5, true },
                    { 93, "Ahihi", 1, 2, "NV0091", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2855), 5, true },
                    { 92, "Ahihi", 1, 2, "NV0090", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2854), 5, true },
                    { 91, "Ahihi", 1, 2, "NV0089", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2851), 5, true },
                    { 33, "Ahihi", 1, 1, "NV0031", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2732), 1, true },
                    { 90, "Ahihi", 1, 2, "NV0088", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2849), 5, true },
                    { 89, "Ahihi", 1, 2, "NV0087", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2847), 5, true },
                    { 88, "Ahihi", 1, 2, "NV0086", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2845), 5, true },
                    { 87, "Ahihi", 1, 2, "NV0085", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2843), 5, true },
                    { 34, "Ahihi", 1, 1, "NV0032", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2734), 1, true },
                    { 86, "Ahihi", 1, 2, "NV0084", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2842), 5, true },
                    { 85, "Ahihi", 1, 2, "NV0083", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2840), 5, true },
                    { 84, "Ahihi", 1, 2, "NV0082", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2838), 5, true },
                    { 73, "Ahihi", 1, 1, "NV0071", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2816), 4, true },
                    { 74, "Ahihi", 1, 1, "NV0072", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2818), 4, true },
                    { 37, "Ahihi", 1, 1, "NV0035", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2740), 1, true },
                    { 75, "Ahihi", 1, 1, "NV0073", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2820), 4, true },
                    { 76, "Ahihi", 1, 1, "NV0074", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2822), 4, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 77, "Ahihi", 1, 1, "NV0075", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2824), 4, true },
                    { 31, "Ahihi", 1, 1, "NV0029", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2728), 1, true },
                    { 78, "Ahihi", 1, 1, "NV0076", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2826), 4, true },
                    { 79, "Ahihi", 1, 1, "NV0077", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2828), 4, true },
                    { 80, "Ahihi", 1, 1, "NV0078", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2831), 4, true },
                    { 81, "Ahihi", 1, 1, "NV0079", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2833), 4, true },
                    { 82, "Ahihi", 1, 2, "NV0080", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2834), 5, true },
                    { 35, "Ahihi", 1, 1, "NV0033", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2736), 1, true },
                    { 83, "Ahihi", 1, 2, "NV0081", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2836), 5, true },
                    { 36, "Ahihi", 1, 1, "NV0034", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2738), 1, true },
                    { 154, "Ahihi", 1, 2, "NV0152", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2977), 8, true },
                    { 45, "Ahihi", 1, 1, "NV0043", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2755), 2, true },
                    { 155, "Ahihi", 1, 2, "NV0153", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2979), 8, true },
                    { 199, "Ahihi", 1, 3, "NV0197", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3063), 10, true },
                    { 177, "Ahihi", 1, 2, "NV0175", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3021), 9, true },
                    { 200, "Ahihi", 1, 3, "NV0198", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3065), 10, true },
                    { 176, "Ahihi", 1, 2, "NV0174", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3019), 9, true },
                    { 6, "Ahihi", 1, 1, "NV0004", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2680), 3, true },
                    { 12, "Ahihi", 1, 1, "NV0010", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2692), 3, true },
                    { 175, "Ahihi", 1, 2, "NV0173", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3017), 9, true },
                    { 201, "Ahihi", 1, 3, "NV0199", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3067), 10, true },
                    { 174, "Ahihi", 1, 2, "NV0172", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3016), 9, true },
                    { 202, "Ahihi", 1, 3, "NV0200", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3069), 11, true },
                    { 173, "Ahihi", 1, 2, "NV0171", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3013), 9, true },
                    { 172, "Ahihi", 1, 2, "NV0170", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3011), 9, true },
                    { 13, "Ahihi", 1, 1, "NV0011", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2694), 3, true },
                    { 204, "Ahihi", 1, 3, "NV0202", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3072), 11, true },
                    { 171, "Ahihi", 1, 2, "NV0169", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3009), 9, true },
                    { 5, "Ahihi", 1, 1, "NV0003", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2678), 3, true },
                    { 170, "Ahihi", 1, 2, "NV0168", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3007), 9, true },
                    { 169, "Ahihi", 1, 2, "NV0167", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3006), 9, true },
                    { 205, "Ahihi", 1, 3, "NV0203", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3074), 11, true },
                    { 168, "Ahihi", 1, 2, "NV0166", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3004), 9, true },
                    { 206, "Ahihi", 1, 3, "NV0204", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3076), 11, true },
                    { 178, "Ahihi", 1, 2, "NV0176", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3023), 9, true },
                    { 14, "Ahihi", 1, 1, "NV0012", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2696), 3, true },
                    { 179, "Ahihi", 1, 2, "NV0177", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3025), 9, true },
                    { 11, "Ahihi", 1, 1, "NV0009", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2690), 3, true },
                    { 191, "Ahihi", 1, 3, "NV0189", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3048), 10, true },
                    { 189, "Ahihi", 1, 3, "NV0187", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3044), 10, true },
                    { 192, "Ahihi", 1, 3, "NV0190", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3049), 10, true },
                    { 9, "Ahihi", 1, 1, "NV0007", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2685), 3, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 188, "Ahihi", 1, 3, "NV0186", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3042), 10, true },
                    { 8, "Ahihi", 1, 1, "NV0006", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2683), 3, true },
                    { 187, "Ahihi", 1, 3, "NV0185", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3040), 10, true },
                    { 193, "Ahihi", 1, 3, "NV0191", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3051), 10, true },
                    { 186, "Ahihi", 1, 3, "NV0184", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3039), 10, true },
                    { 185, "Ahihi", 1, 3, "NV0183", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3037), 10, true },
                    { 194, "Ahihi", 1, 3, "NV0192", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3053), 10, true },
                    { 10, "Ahihi", 1, 1, "NV0008", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2688), 3, true },
                    { 195, "Ahihi", 1, 3, "NV0193", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3056), 10, true },
                    { 184, "Ahihi", 1, 3, "NV0182", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3034), 10, true },
                    { 183, "Ahihi", 1, 3, "NV0181", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3032), 10, true },
                    { 196, "Ahihi", 1, 3, "NV0194", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3058), 10, true },
                    { 182, "Ahihi", 1, 3, "NV0180", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3030), 10, true },
                    { 7, "Ahihi", 1, 1, "NV0005", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2682), 3, true },
                    { 181, "Ahihi", 1, 2, "NV0179", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3029), 9, true },
                    { 197, "Ahihi", 1, 3, "NV0195", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3060), 10, true },
                    { 180, "Ahihi", 1, 2, "NV0178", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3027), 9, true },
                    { 198, "Ahihi", 1, 3, "NV0196", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3061), 10, true },
                    { 167, "Ahihi", 1, 2, "NV0165", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3002), 9, true },
                    { 203, "Ahihi", 1, 3, "NV0201", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3071), 11, true },
                    { 190, "Ahihi", 1, 3, "NV0188", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3046), 10, true },
                    { 16, "Ahihi", 1, 1, "NV0014", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2699), 3, true },
                    { 161, "Ahihi", 1, 2, "NV0159", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2990), 8, true },
                    { 159, "Ahihi", 1, 2, "NV0157", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2987), 8, true },
                    { 162, "Ahihi", 1, 2, "NV0160", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2993), 9, true },
                    { 158, "Ahihi", 1, 2, "NV0156", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2985), 8, true },
                    { 163, "Ahihi", 1, 2, "NV0161", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2995), 9, true },
                    { 209, "Ahihi", 1, 3, "NV0207", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3082), 11, true },
                    { 15, "Ahihi", 1, 1, "NV0013", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2697), 3, true },
                    { 157, "Ahihi", 1, 2, "NV0155", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2983), 8, true },
                    { 164, "Ahihi", 1, 2, "NV0162", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2996), 9, true },
                    { 4, "Ahihi", 1, 1, "NV0002", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2675), 3, true },
                    { 165, "Ahihi", 1, 2, "NV0163", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2998), 9, true },
                    { 160, "Ahihi", 1, 2, "NV0158", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2988), 8, true },
                    { 207, "Ahihi", 1, 3, "NV0205", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3078), 11, true },
                    { 208, "Ahihi", 1, 3, "NV0206", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3080), 11, true },
                    { 166, "Ahihi", 1, 2, "NV0164", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(3000), 9, true },
                    { 2, "Ahihi", 1, 2, "NV0001", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2617), 2, false },
                    { 156, "Ahihi", 1, 2, "NV0154", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2981), 8, true },
                    { 17, "Ahihi", 1, 1, "NV0015", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2701), 3, true },
                    { 3, "Ahihi", 1, 1, "NV0001", new DateTime(2021, 11, 14, 23, 32, 48, 529, DateTimeKind.Local).AddTicks(2673), 3, true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[] { "HD213", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3325), 213, 1, 1, "NV0213", true });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD78", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1992), 78, 1, 1, "NV0078", true },
                    { "HD86", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2049), 86, 1, 1, "NV0086", true },
                    { "HD77", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1984), 77, 1, 1, "NV0077", true },
                    { "HD48", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1635), 48, 1, 1, "NV0048", true },
                    { "HD217", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3407), 217, 1, 1, "NV0217", true },
                    { "HD193", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3162), 193, 1, 1, "NV0193", true },
                    { "HD76", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1977), 76, 1, 1, "NV0076", true },
                    { "HD49", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1642), 49, 1, 1, "NV0049", true },
                    { "HD194", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3176), 194, 1, 1, "NV0194", true },
                    { "HD75", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1969), 75, 1, 1, "NV0075", true },
                    { "HD212", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3314), 212, 1, 1, "NV0212", true },
                    { "HD79", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1999), 79, 1, 1, "NV0079", true },
                    { "HD47", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1629), 47, 1, 1, "NV0047", true },
                    { "HD44", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1608), 44, 1, 1, "NV0044", true },
                    { "HD190", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3141), 190, 1, 1, "NV0190", true },
                    { "HD45", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1615), 45, 1, 1, "NV0045", true },
                    { "HD218", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3416), 218, 1, 1, "NV0218", true },
                    { "HD216", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3395), 216, 1, 1, "NV0216", true },
                    { "HD82", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2021), 82, 1, 1, "NV0082", true },
                    { "HD191", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3147), 191, 1, 1, "NV0191", true },
                    { "HD214", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3336), 214, 1, 1, "NV0214", true },
                    { "HD211", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3303), 211, 1, 1, "NV0211", true },
                    { "HD215", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3346), 215, 1, 1, "NV0215", true },
                    { "HD85", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2043), 85, 1, 1, "NV0085", true },
                    { "HD80", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2006), 80, 1, 1, "NV0080", true },
                    { "HD192", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3154), 192, 1, 1, "NV0192", true },
                    { "HD189", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3134), 189, 1, 1, "NV0189", true },
                    { "HD84", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2035), 84, 1, 1, "NV0084", true },
                    { "HD46", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1622), 46, 1, 1, "NV0046", true },
                    { "HD81", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2013), 81, 1, 1, "NV0081", true },
                    { "HD196", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3191), 196, 1, 1, "NV0196", true },
                    { "HD74", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1961), 74, 1, 1, "NV0074", true },
                    { "HD200", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3218), 200, 1, 1, "NV0200", true },
                    { "HD65", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1891), 65, 1, 1, "NV0065", true },
                    { "HD87", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2056), 87, 1, 1, "NV0087", true },
                    { "HD206", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3262), 206, 1, 1, "NV0206", true },
                    { "HD64", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1884), 64, 1, 1, "NV0064", true },
                    { "HD201", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3225), 201, 1, 1, "NV0201", true },
                    { "HD55", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1822), 55, 1, 1, "NV0055", true },
                    { "HD63", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1877), 63, 1, 1, "NV0063", true },
                    { "HD62", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1870), 62, 1, 1, "NV0062", true },
                    { "HD202", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3232), 202, 1, 1, "NV0202", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD61", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1864), 61, 1, 1, "NV0061", true },
                    { "HD56", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1829), 56, 1, 1, "NV0056", true },
                    { "HD205", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3255), 205, 1, 1, "NV0205", true },
                    { "HD60", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1857), 60, 1, 1, "NV0060", true },
                    { "HD203", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3240), 203, 1, 1, "NV0203", true },
                    { "HD57", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1836), 57, 1, 1, "NV0057", true },
                    { "HD59", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1850), 59, 1, 1, "NV0059", true },
                    { "HD66", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1898), 66, 1, 1, "NV0066", true },
                    { "HD195", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3184), 195, 1, 1, "NV0195", true },
                    { "HD54", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1816), 54, 1, 1, "NV0054", true },
                    { "HD199", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3212), 199, 1, 1, "NV0199", true },
                    { "HD50", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1787), 50, 1, 1, "NV0050", true },
                    { "HD210", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3291), 210, 1, 1, "NV0210", true },
                    { "HD73", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1954), 73, 1, 1, "NV0073", true },
                    { "HD58", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1843), 58, 1, 1, "NV0058", true },
                    { "HD72", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1948), 72, 1, 1, "NV0072", true },
                    { "HD51", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1795), 51, 1, 1, "NV0051", true },
                    { "HD197", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3198), 197, 1, 1, "NV0197", true },
                    { "HD71", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1941), 71, 1, 1, "NV0071", true },
                    { "HD209", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3284), 209, 1, 1, "NV0209", true },
                    { "HD208", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3276), 208, 1, 1, "NV0208", true },
                    { "HD70", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1934), 70, 1, 1, "NV0070", true },
                    { "HD52", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1802), 52, 1, 1, "NV0052", true },
                    { "HD207", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3269), 207, 1, 1, "NV0207", true },
                    { "HD69", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1927), 69, 1, 1, "NV0069", true },
                    { "HD198", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3205), 198, 1, 1, "NV0198", true },
                    { "HD68", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1920), 68, 1, 1, "NV0068", true },
                    { "HD53", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1809), 53, 1, 1, "NV0053", true },
                    { "HD67", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1912), 67, 1, 1, "NV0067", true },
                    { "HD204", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3247), 204, 1, 1, "NV0204", true },
                    { "HD96", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2133), 96, 1, 1, "NV0096", true },
                    { "HD88", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2063), 88, 1, 1, "NV0088", true },
                    { "HD134", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2574), 134, 1, 1, "NV0134", true },
                    { "HD162", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2851), 162, 1, 1, "NV0162", true },
                    { "HD133", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2567), 133, 1, 1, "NV0133", true },
                    { "HD163", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2877), 163, 1, 1, "NV0163", true },
                    { "HD132", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2560), 132, 1, 1, "NV0132", true },
                    { "HD131", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2552), 131, 1, 1, "NV0131", true },
                    { "HD164", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2900), 164, 1, 1, "NV0164", true },
                    { "HD130", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2537), 130, 1, 1, "NV0130", true },
                    { "HD165", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2916), 165, 1, 1, "NV0165", true },
                    { "HD129", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2531), 129, 1, 1, "NV0129", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD43", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1600), 43, 1, 1, "NV0043", true },
                    { "HD127", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2517), 127, 1, 1, "NV0127", true },
                    { "HD166", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2961), 166, 1, 1, "NV0166", true },
                    { "HD126", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2510), 126, 1, 1, "NV0126", true },
                    { "HD125", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2503), 125, 1, 1, "NV0125", true },
                    { "HD167", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2981), 167, 1, 1, "NV0167", true },
                    { "HD124", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2496), 124, 1, 1, "NV0124", true },
                    { "HD168", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2990), 168, 1, 1, "NV0168", true },
                    { "HD123", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2488), 123, 1, 1, "NV0123", true },
                    { "HD122", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2482), 122, 1, 1, "NV0122", true },
                    { "HD169", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2996), 169, 1, 1, "NV0169", true },
                    { "HD135", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2581), 135, 1, 1, "NV0135", true },
                    { "HD136", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2588), 136, 1, 1, "NV0136", true },
                    { "HD161", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2826), 161, 1, 1, "NV0161", true },
                    { "HD137", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2594), 137, 1, 1, "NV0137", true },
                    { "HD151", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2691), 151, 1, 1, "NV0151", true },
                    { "HD153", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2706), 153, 1, 1, "NV0153", true },
                    { "HD150", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2685), 150, 1, 1, "NV0150", true },
                    { "HD149", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2678), 149, 1, 1, "NV0149", true },
                    { "HD154", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2713), 154, 1, 1, "NV0154", true },
                    { "HD148", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2671), 148, 1, 1, "NV0148", true },
                    { "HD147", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2664), 147, 1, 1, "NV0147", true },
                    { "HD155", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2720), 155, 1, 1, "NV0155", true },
                    { "HD146", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2658), 146, 1, 1, "NV0146", true },
                    { "HD156", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2726), 156, 1, 1, "NV0156", true },
                    { "HD121", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2475), 121, 1, 1, "NV0121", true },
                    { "HD145", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2651), 145, 1, 1, "NV0145", true },
                    { "HD157", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2735), 157, 1, 1, "NV0157", true },
                    { "HD143", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2637), 143, 1, 1, "NV0143", true },
                    { "HD142", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2630), 142, 1, 1, "NV0142", true },
                    { "HD158", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2748), 158, 1, 1, "NV0158", true },
                    { "HD141", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2623), 141, 1, 1, "NV0141", true },
                    { "HD140", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2616), 140, 1, 1, "NV0140", true },
                    { "HD159", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2758), 159, 1, 1, "NV0159", true },
                    { "HD139", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2608), 139, 1, 1, "NV0139", true },
                    { "HD138", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2601), 138, 1, 1, "NV0138", true },
                    { "HD160", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2795), 160, 1, 1, "NV0160", true },
                    { "HD144", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2644), 144, 1, 1, "NV0144", true },
                    { "HD188", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3127), 188, 1, 1, "NV0188", true },
                    { "HD120", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2468), 120, 1, 1, "NV0120", true },
                    { "HD119", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2462), 119, 1, 1, "NV0119", true },
                    { "HD180", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3072), 180, 1, 1, "NV0180", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD100", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2194), 100, 1, 1, "NV0100", true },
                    { "HD99", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2165), 99, 1, 1, "NV0099", true },
                    { "HD181", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3079), 181, 1, 1, "NV0181", true },
                    { "HD98", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2155), 98, 1, 1, "NV0098", true },
                    { "HD97", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2143), 97, 1, 1, "NV0097", true },
                    { "HD182", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3085), 182, 1, 1, "NV0182", true },
                    { "HD152", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2699), 152, 1, 1, "NV0152", true },
                    { "HD95", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2123), 95, 1, 1, "NV0095", true },
                    { "HD183", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3092), 183, 1, 1, "NV0183", true },
                    { "HD94", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2113), 94, 1, 1, "NV0094", true },
                    { "HD184", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3099), 184, 1, 1, "NV0184", true },
                    { "HD93", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2102), 93, 1, 1, "NV0093", true },
                    { "HD111", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2406), 111, 1, 1, "NV0111", true },
                    { "HD185", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3106), 185, 1, 1, "NV0185", true },
                    { "HD92", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2091), 92, 1, 1, "NV0092", true },
                    { "HD91", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2084), 91, 1, 1, "NV0091", true },
                    { "HD186", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3113), 186, 1, 1, "NV0186", true },
                    { "HD90", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2077), 90, 1, 1, "NV0090", true },
                    { "HD89", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2070), 89, 1, 1, "NV0089", true },
                    { "HD187", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3120), 187, 1, 1, "NV0187", true },
                    { "HD101", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2224), 101, 1, 1, "NV0101", true },
                    { "HD102", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2249), 102, 1, 1, "NV0102", true },
                    { "HD179", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3065), 179, 1, 1, "NV0179", true },
                    { "HD103", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2270), 103, 1, 1, "NV0103", true },
                    { "HD118", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2455), 118, 1, 1, "NV0118", true },
                    { "HD171", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3010), 171, 1, 1, "NV0171", true },
                    { "HD117", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2448), 117, 1, 1, "NV0117", true },
                    { "HD116", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2441), 116, 1, 1, "NV0116", true },
                    { "HD172", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3017), 172, 1, 1, "NV0172", true },
                    { "HD115", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2433), 115, 1, 1, "NV0115", true },
                    { "HD173", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3024), 173, 1, 1, "NV0173", true },
                    { "HD114", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2427), 114, 1, 1, "NV0114", true },
                    { "HD113", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2419), 113, 1, 1, "NV0113", true },
                    { "HD112", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2413), 112, 1, 1, "NV0112", true },
                    { "HD170", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3003), 170, 1, 1, "NV0170", true },
                    { "HD174", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3031), 174, 1, 1, "NV0174", true },
                    { "HD175", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3037), 175, 1, 1, "NV0175", true },
                    { "HD109", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2392), 109, 1, 1, "NV0109", true },
                    { "HD108", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2385), 108, 1, 1, "NV0108", true },
                    { "HD176", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3044), 176, 1, 1, "NV0176", true },
                    { "HD107", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2378), 107, 1, 1, "NV0107", true },
                    { "HD177", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3051), 177, 1, 1, "NV0177", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD106", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2367), 106, 1, 1, "NV0106", true },
                    { "HD105", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2332), 105, 1, 1, "NV0105", true },
                    { "HD104", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2291), 104, 1, 1, "NV0104", true },
                    { "HD178", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3058), 178, 1, 1, "NV0178", true },
                    { "HD110", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2399), 110, 1, 1, "NV0110", true },
                    { "HD128", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2524), 128, 1, 1, "NV0128", true },
                    { "HD83", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(2028), 83, 1, 1, "NV0083", true },
                    { "HD219", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(3427), 219, 1, 1, "NV0219", true },
                    { "HD30", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1333), 30, 1, 1, "NV0030", true },
                    { "HD07", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1143), 7, 1, 1, "NV0007", true },
                    { "HD08", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1150), 8, 1, 1, "NV0008", true },
                    { "HD29", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1326), 29, 1, 1, "NV0029", true },
                    { "HD09", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1156), 9, 1, 1, "NV0008", true },
                    { "HD28", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1319), 28, 1, 1, "NV0028", true },
                    { "HD40", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1580), 40, 1, 1, "NV0040", true },
                    { "HD27", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1312), 27, 1, 1, "NV0027", true },
                    { "HD36", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1373), 36, 1, 1, "NV0036", true },
                    { "HD11", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1171), 11, 1, 1, "NV0011", true },
                    { "HD26", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1305), 26, 1, 1, "NV0026", true },
                    { "HD12", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1177), 12, 1, 1, "NV0012", true },
                    { "HD13", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1184), 13, 1, 1, "NV0013", true },
                    { "HD25", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1298), 25, 1, 1, "NV0025", true },
                    { "HD39", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1573), 39, 1, 1, "NV0039", true },
                    { "HD14", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1191), 14, 1, 1, "NV0014", true },
                    { "HD24", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1291), 24, 1, 1, "NV0024", true },
                    { "HD15", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1200), 15, 1, 1, "NV0015", true },
                    { "HD23", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1285), 23, 1, 1, "NV0023", true },
                    { "HD16", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1212), 16, 1, 1, "NV0016", true },
                    { "HD37", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1380), 37, 1, 1, "NV0037", true },
                    { "HD17", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1221), 17, 1, 1, "NV0017", true },
                    { "HD22", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1278), 22, 1, 1, "NV0022", true },
                    { "HD18", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1231), 18, 1, 1, "NV0018", true },
                    { "HD38", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1566), 38, 1, 1, "NV0038", true },
                    { "HD21", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1267), 21, 1, 1, "NV0021", true },
                    { "HD19", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1241), 19, 1, 1, "NV0019", true },
                    { "HD06", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1135), 6, 1, 1, "NV0006", true },
                    { "HD31", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1339), 31, 1, 1, "NV0031", true },
                    { "HD10", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1163), 10, 1, 1, "NV0010", true },
                    { "HD20", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1253), 20, 1, 1, "NV0020", true },
                    { "HD35", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1366), 35, 1, 1, "NV0035", true },
                    { "HD32", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1346), 32, 1, 1, "NV0032", true },
                    { "HD03", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1107), 3, 1, 1, "NV0003", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "bangChung", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "id", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD41", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1587), 41, 1, 1, "NV0041", true },
                    { "HD33", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1353), 33, 1, 1, "NV0033", true },
                    { "HD04", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1118), 4, 1, 1, "NV0004", true },
                    { "HD42", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1594), 42, 1, 1, "NV0042", true },
                    { "HD05", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1127), 5, 1, 1, "NV0005", true },
                    { "HD02", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1019), 2, 1, 1, "NV0001", true },
                    { "HD01", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 526, DateTimeKind.Local).AddTicks(9259), 1, 1, 1, "NV0001", false },
                    { "HD34", null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(1360), 34, 1, 1, "NV0034", true }
                });

            migrationBuilder.InsertData(
                table: "KhenThuongKyLuat",
                columns: new[] { "id", "anh", "idDanhMucKhenThuong", "loai", "lyDo", "maNhanVien", "noiDung" },
                values: new object[,]
                {
                    { 9, null, 1, true, null, "NV0022", "Thưởng nhân viên suất sắc" },
                    { 6, null, 1, true, null, "NV0078", "Thưởng nhân viên suất sắc" },
                    { 2, null, 1, false, null, "NV0001", "Thưởng nhân viên suất sắc" },
                    { 7, null, 1, true, null, "NV0023", "Thưởng nhân viên suất sắc" },
                    { 10, null, 1, false, null, "NV0056", "Thưởng nhân viên suất sắc" },
                    { 1, null, 1, true, null, "NV0001", "Thưởng nhân viên suất sắc" },
                    { 11, null, 1, true, null, "NV0081", "Thưởng nhân viên suất sắc" },
                    { 4, null, 1, true, null, "NV0021", "Thưởng nhân viên suất sắc" },
                    { 8, null, 1, false, null, "NV0099", "Thưởng nhân viên suất sắc" },
                    { 3, null, 1, true, null, "NV0009", "Thưởng nhân viên suất sắc" },
                    { 5, null, 1, false, null, "NV0035", "Thưởng nhân viên suất sắc" },
                    { 12, null, 1, false, null, "NV0091", "Thưởng nhân viên suất sắc" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "id", "biBatDiTu", "maNhanVien", "thamGiaChinhTri", "thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 98, "Không", "NV0098", "Không", "Không" },
                    { 22, "Không", "NV0022", "Không", "Không" },
                    { 123, "Không", "NV0123", "Không", "Không" },
                    { 77, "Không", "NV0077", "Không", "Không" },
                    { 122, "Không", "NV0122", "Không", "Không" },
                    { 31, "Không", "NV0031", "Không", "Không" },
                    { 121, "Không", "NV0121", "Không", "Không" },
                    { 120, "Không", "NV0120", "Không", "Không" },
                    { 92, "Không", "NV0092", "Không", "Không" },
                    { 119, "Không", "NV0119", "Không", "Không" },
                    { 111, "Không", "NV0111", "Không", "Không" },
                    { 78, "Không", "NV0078", "Không", "Không" },
                    { 23, "Không", "NV0023", "Không", "Không" },
                    { 118, "Không", "NV0118", "Không", "Không" },
                    { 86, "Không", "NV0086", "Không", "Không" },
                    { 91, "Không", "NV0091", "Không", "Không" },
                    { 76, "Không", "NV0076", "Không", "Không" },
                    { 124, "Không", "NV0124", "Không", "Không" },
                    { 132, "Không", "NV0132", "Không", "Không" },
                    { 131, "Không", "NV0131", "Không", "Không" },
                    { 130, "Không", "NV0130", "Không", "Không" },
                    { 87, "Không", "NV0087", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "id", "biBatDiTu", "maNhanVien", "thamGiaChinhTri", "thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 129, "Không", "NV0129", "Không", "Không" },
                    { 88, "Không", "NV0088", "Không", "Không" },
                    { 117, "Không", "NV0117", "Không", "Không" },
                    { 89, "Không", "NV0089", "Không", "Không" },
                    { 128, "Không", "NV0128", "Không", "Không" },
                    { 21, "Không", "NV0021", "Không", "Không" },
                    { 30, "Không", "NV0030", "Không", "Không" },
                    { 127, "Không", "NV0127", "Không", "Không" },
                    { 126, "Không", "NV0126", "Không", "Không" },
                    { 125, "Không", "NV0125", "Không", "Không" },
                    { 90, "Không", "NV0090", "Không", "Không" },
                    { 28, "Không", "NV0028", "Không", "Không" },
                    { 116, "Không", "NV0116", "Không", "Không" },
                    { 79, "Không", "NV0079", "Không", "Không" },
                    { 82, "Không", "NV0082", "Không", "Không" },
                    { 103, "Không", "NV0103", "Không", "Không" },
                    { 32, "Không", "NV0032", "Không", "Không" },
                    { 83, "Không", "NV0083", "Không", "Không" },
                    { 102, "Không", "NV0102", "Không", "Không" },
                    { 27, "Không", "NV0027", "Không", "Không" },
                    { 104, "Không", "NV0104", "Không", "Không" },
                    { 20, "Không", "NV0020", "Không", "Không" },
                    { 100, "Không", "NV0100", "Không", "Không" },
                    { 99, "Không", "NV0099", "Không", "Không" },
                    { 84, "Không", "NV0084", "Không", "Không" },
                    { 95, "Không", "NV0095", "Không", "Không" },
                    { 96, "Không", "NV0096", "Không", "Không" },
                    { 97, "Không", "NV0097", "Không", "Không" },
                    { 101, "Không", "NV0101", "Không", "Không" },
                    { 33, "Không", "NV0033", "Không", "Không" },
                    { 105, "Không", "NV0105", "Không", "Không" },
                    { 106, "Không", "NV0106", "Không", "Không" },
                    { 93, "Không", "NV0093", "Không", "Không" },
                    { 115, "Không", "NV0115", "Không", "Không" },
                    { 24, "Không", "NV0024", "Không", "Không" },
                    { 113, "Không", "NV0113", "Không", "Không" },
                    { 112, "Không", "NV0112", "Không", "Không" },
                    { 80, "Không", "NV0080", "Không", "Không" },
                    { 26, "Không", "NV0026", "Không", "Không" },
                    { 29, "Không", "NV0029", "Không", "Không" },
                    { 25, "Không", "NV0025", "Không", "Không" },
                    { 94, "Không", "NV0094", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "id", "biBatDiTu", "maNhanVien", "thamGiaChinhTri", "thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 108, "Không", "NV0108", "Không", "Không" },
                    { 107, "Không", "NV0107", "Không", "Không" },
                    { 85, "Không", "NV0085", "Không", "Không" },
                    { 81, "Không", "NV0081", "Không", "Không" },
                    { 110, "Không", "NV0110", "Không", "Không" },
                    { 109, "Không", "NV0109", "Không", "Không" },
                    { 141, "Không", "NV0141", "Không", "Không" },
                    { 134, "Không", "NV0134", "Không", "Không" },
                    { 189, "Không", "NV0189", "Không", "Không" },
                    { 6, "Không", "NV0006", "Không", "Không" },
                    { 188, "Không", "NV0188", "Không", "Không" },
                    { 187, "Không", "NV0187", "Không", "Không" },
                    { 186, "Không", "NV0186", "Không", "Không" },
                    { 185, "Không", "NV0185", "Không", "Không" },
                    { 7, "Không", "NV0007", "Không", "Không" },
                    { 184, "Không", "NV0184", "Không", "Không" },
                    { 183, "Không", "NV0183", "Không", "Không" },
                    { 190, "Không", "NV0190", "Không", "Không" },
                    { 182, "Không", "NV0182", "Không", "Không" },
                    { 8, "Không", "NV0008", "Không", "Không" },
                    { 180, "Không", "NV0180", "Không", "Không" },
                    { 179, "Không", "NV0179", "Không", "Không" },
                    { 178, "Không", "NV0178", "Không", "Không" },
                    { 177, "Không", "NV0177", "Không", "Không" },
                    { 9, "Không", "NV0009", "Không", "Không" },
                    { 176, "Không", "NV0176", "Không", "Không" },
                    { 175, "Không", "NV0175", "Không", "Không" },
                    { 174, "Không", "NV0174", "Không", "Không" },
                    { 181, "Không", "NV0181", "Không", "Không" },
                    { 191, "Không", "NV0191", "Không", "Không" },
                    { 192, "Không", "NV0192", "Không", "Không" },
                    { 5, "Không", "NV0005", "Không", "Không" },
                    { 1, "Không", "NV0001", "Không", "Không" },
                    { 209, "Không", "NV0209", "Không", "Không" },
                    { 208, "Không", "NV0208", "Không", "Không" },
                    { 207, "Không", "NV0207", "Không", "Không" },
                    { 206, "Không", "NV0206", "Không", "Không" },
                    { 2, "Không", "NV0002", "Không", "Không" },
                    { 205, "Không", "NV0205", "Không", "Không" },
                    { 204, "Không", "NV0204", "Không", "Không" },
                    { 203, "Không", "NV0203", "Không", "Không" },
                    { 202, "Không", "NV0202", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "id", "biBatDiTu", "maNhanVien", "thamGiaChinhTri", "thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 201, "Không", "NV0201", "Không", "Không" },
                    { 3, "Không", "NV0003", "Không", "Không" },
                    { 200, "Không", "NV0200", "Không", "Không" },
                    { 199, "Không", "NV0199", "Không", "Không" },
                    { 198, "Không", "NV0198", "Không", "Không" },
                    { 197, "Không", "NV0197", "Không", "Không" },
                    { 4, "Không", "NV0004", "Không", "Không" },
                    { 196, "Không", "NV0196", "Không", "Không" },
                    { 195, "Không", "NV0195", "Không", "Không" },
                    { 194, "Không", "NV0194", "Không", "Không" },
                    { 193, "Không", "NV0193", "Không", "Không" },
                    { 173, "Không", "NV0173", "Không", "Không" },
                    { 133, "Không", "NV0133", "Không", "Không" },
                    { 10, "Không", "NV0010", "Không", "Không" },
                    { 171, "Không", "NV0171", "Không", "Không" },
                    { 150, "Không", "NV0150", "Không", "Không" },
                    { 149, "Không", "NV0149", "Không", "Không" },
                    { 16, "Không", "NV0016", "Không", "Không" },
                    { 148, "Không", "NV0148", "Không", "Không" },
                    { 147, "Không", "NV0147", "Không", "Không" },
                    { 146, "Không", "NV0146", "Không", "Không" },
                    { 145, "Không", "NV0145", "Không", "Không" },
                    { 17, "Không", "NV0017", "Không", "Không" },
                    { 144, "Không", "NV0144", "Không", "Không" },
                    { 151, "Không", "NV0151", "Không", "Không" },
                    { 143, "Không", "NV0143", "Không", "Không" },
                    { 75, "Không", "NV0075", "Không", "Không" },
                    { 18, "Không", "NV0018", "Không", "Không" },
                    { 140, "Không", "NV0140", "Không", "Không" },
                    { 139, "Không", "NV0139", "Không", "Không" },
                    { 138, "Không", "NV0138", "Không", "Không" },
                    { 137, "Không", "NV0137", "Không", "Không" },
                    { 19, "Không", "NV0019", "Không", "Không" },
                    { 136, "Không", "NV0136", "Không", "Không" },
                    { 135, "Không", "NV0135", "Không", "Không" },
                    { 142, "Không", "NV0142", "Không", "Không" },
                    { 152, "Không", "NV0152", "Không", "Không" },
                    { 15, "Không", "NV0015", "Không", "Không" },
                    { 153, "Không", "NV0153", "Không", "Không" },
                    { 170, "Không", "NV0170", "Không", "Không" },
                    { 169, "Không", "NV0169", "Không", "Không" },
                    { 11, "Không", "NV0011", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "id", "biBatDiTu", "maNhanVien", "thamGiaChinhTri", "thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 168, "Không", "NV0168", "Không", "Không" },
                    { 167, "Không", "NV0167", "Không", "Không" },
                    { 166, "Không", "NV0166", "Không", "Không" },
                    { 165, "Không", "NV0165", "Không", "Không" },
                    { 12, "Không", "NV0012", "Không", "Không" },
                    { 164, "Không", "NV0164", "Không", "Không" },
                    { 163, "Không", "NV0163", "Không", "Không" },
                    { 162, "Không", "NV0162", "Không", "Không" },
                    { 161, "Không", "NV0161", "Không", "Không" },
                    { 13, "Không", "NV0013", "Không", "Không" },
                    { 160, "Không", "NV0160", "Không", "Không" },
                    { 159, "Không", "NV0159", "Không", "Không" },
                    { 158, "Không", "NV0158", "Không", "Không" },
                    { 157, "Không", "NV0157", "Không", "Không" },
                    { 14, "Không", "NV0014", "Không", "Không" },
                    { 156, "Không", "NV0156", "Không", "Không" },
                    { 155, "Không", "NV0155", "Không", "Không" },
                    { 154, "Không", "NV0154", "Không", "Không" },
                    { 172, "Không", "NV0172", "Không", "Không" },
                    { 34, "Không", "NV0034", "Không", "Không" },
                    { 114, "Không", "NV0114", "Không", "Không" },
                    { 56, "Không", "NV0056", "Không", "Không" },
                    { 59, "Không", "NV0059", "Không", "Không" },
                    { 51, "Không", "NV0051", "Không", "Không" },
                    { 55, "Không", "NV0055", "Không", "Không" },
                    { 39, "Không", "NV0039", "Không", "Không" },
                    { 60, "Không", "NV0060", "Không", "Không" },
                    { 72, "Không", "NV0072", "Không", "Không" },
                    { 42, "Không", "NV0042", "Không", "Không" },
                    { 61, "Không", "NV0061", "Không", "Không" },
                    { 49, "Không", "NV0049", "Không", "Không" },
                    { 47, "Không", "NV0047", "Không", "Không" },
                    { 41, "Không", "NV0041", "Không", "Không" },
                    { 50, "Không", "NV0050", "Không", "Không" },
                    { 62, "Không", "NV0062", "Không", "Không" },
                    { 71, "Không", "NV0071", "Không", "Không" },
                    { 38, "Không", "NV0038", "Không", "Không" },
                    { 44, "Không", "NV0044", "Không", "Không" },
                    { 37, "Không", "NV0037", "Không", "Không" },
                    { 63, "Không", "NV0063", "Không", "Không" },
                    { 54, "Không", "NV0054", "Không", "Không" },
                    { 64, "Không", "NV0064", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "id", "biBatDiTu", "maNhanVien", "thamGiaChinhTri", "thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 70, "Không", "NV0070", "Không", "Không" },
                    { 46, "Không", "NV0046", "Không", "Không" },
                    { 52, "Không", "NV0052", "Không", "Không" },
                    { 65, "Không", "NV0065", "Không", "Không" },
                    { 69, "Không", "NV0069", "Không", "Không" },
                    { 66, "Không", "NV0066", "Không", "Không" },
                    { 53, "Không", "NV0053", "Không", "Không" },
                    { 36, "Không", "NV0036", "Không", "Không" },
                    { 67, "Không", "NV0067", "Không", "Không" },
                    { 45, "Không", "NV0045", "Không", "Không" },
                    { 35, "Không", "NV0035", "Không", "Không" },
                    { 73, "Không", "NV0073", "Không", "Không" },
                    { 68, "Không", "NV0068", "Không", "Không" },
                    { 58, "Không", "NV0058", "Không", "Không" },
                    { 57, "Không", "NV0057", "Không", "Không" },
                    { 40, "Không", "NV0040", "Không", "Không" },
                    { 48, "Không", "NV0048", "Không", "Không" },
                    { 43, "Không", "NV0043", "Không", "Không" },
                    { 74, "Không", "NV0074", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "id", "diaChi", "dienThoai", "email", "hoTen", "maNhanVien", "quanHe" },
                values: new object[,]
                {
                    { 184, "Hà Nội", "0123434324", null, "Tán Bích Quyên", "NV0184", "Mẹ" },
                    { 24, "Hà Nội", "0123434324", null, "Nguyễn Hoàng Dương", "NV0024", "Bố" },
                    { 186, "Hà Nội", "0123434324", null, "Nhâm Hải Phượng", "NV0186", "Mẹ" },
                    { 114, "Hà Nội", "0123434324", null, "Xa Thu Phượng", "NV0114", "Mẹ" },
                    { 113, "Hà Nội", "0123434324", null, "Lường Quế Linh", "NV0113", "Mẹ" },
                    { 49, "Hà Nội", "0123434324", null, "Đinh Sơn Hải", "NV0049", "Bố" },
                    { 7, "Hà Nội", "0123434324", null, "Nguyễn Hưng Ðạo", "NV0007", "Bố" },
                    { 197, "Hà Nội", "0123434324", null, "Trang Cẩm Hiền", "NV0197", "Mẹ" },
                    { 112, "Hà Nội", "0123434324", null, "Vương Minh Thương", "NV0112", "Mẹ" },
                    { 150, "Hà Nội", "0123434324", null, "Sử Lệ Quyên", "NV0150", "Mẹ" },
                    { 163, "Hà Nội", "0123434324", null, "Duy Bích Thảo", "NV0163", "Mẹ" },
                    { 65, "Hà Nội", "0123434324", null, "Lê Hiếu Thông", "NV0065", "Bố" },
                    { 41, "Hà Nội", "0123434324", null, "Đặng Hữu Từ", "NV0041", "Bạn" },
                    { 4, "Hà Nội", "0123434324", null, "Nguyễn Hoàng Khang", "NV0004", "Bố" },
                    { 182, "Hà Nội", "0123434324", null, "Cam Bảo Quỳnh", "NV0182", "Mẹ" },
                    { 110, "Hà Nội", "0123434324", null, "Chiêm Bích Lam", "NV0110", "Mẹ" },
                    { 196, "Hà Nội", "0123434324", null, "Vưu Thu Phong", "NV0196", "Mẹ" },
                    { 116, "Hà Nội", "0123434324", null, "Liên Triệu Mẫn", "NV0116", "Mẹ" },
                    { 46, "Hà Nội", "0123434324", null, "Trần Quang Khải", "NV0046", "Bố" },
                    { 162, "Hà Nội", "0123434324", null, "Hi Bích San", "NV0162", "Mẹ" },
                    { 64, "Hà Nội", "0123434324", null, "Phạm Tường Lĩnh", "NV0064", "Bố" },
                    { 117, "Hà Nội", "0123434324", null, "Đăng An Bình", "NV0117", "Mẹ" },
                    { 149, "Hà Nội", "0123434324", null, "Cai Kim Yến", "NV0149", "Mẹ" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "id", "diaChi", "dienThoai", "email", "hoTen", "maNhanVien", "quanHe" },
                values: new object[,]
                {
                    { 118, "Hà Nội", "0123434324", null, "Đới Bảo Châu", "NV0118", "Mẹ" },
                    { 23, "Hà Nội", "0123434324", null, "Nguyễn Ðăng Minh", "NV0023", "Bố" },
                    { 119, "Hà Nội", "0123434324", null, "Duy Linh Trang", "NV0119", "Mẹ" },
                    { 195, "Hà Nội", "0123434324", null, "Vưu Thu Phong", "NV0195", "Mẹ" },
                    { 120, "Hà Nội", "0123434324", null, "Bá Minh Nguyệt", "NV0120", "Mẹ" },
                    { 177, "Hà Nội", "0123434324", null, "Phong Vy Lam", "NV0177", "Mẹ" },
                    { 115, "Hà Nội", "0123434324", null, "Luyện Thụy Nương", "NV0115", "Mẹ" },
                    { 25, "Hà Nội", "0123434324", null, "Phạm Minh Đạt", "NV0025", "Bố" },
                    { 109, "Hà Nội", "0123434324", null, "Phù Bảo Tiên", "NV0109", "Mẹ" },
                    { 161, "Hà Nội", "0123434324", null, "Đới Bích Hạnh", "NV0161", "Bạn" },
                    { 152, "Hà Nội", "0123434324", null, "Tạ Mai Thanh", "NV0152", "Mẹ" },
                    { 99, "Hà Nội", "0123434324", null, "Nguyễn Phi Cường", "NV0099", "Bố" },
                    { 45, "Hà Nội", "0123434324", null, "Phạm Duy Khiêm", "NV0045", "Bố" },
                    { 3, "Hà Nội", "0123434324", null, "Hà Thái Sơn", "NV0003", "Bố" },
                    { 100, "Hà Nội", "0123434324", null, "Bùi Đình Phong", "NV0100", "Bố" },
                    { 166, "Hà Nội", "0123434324", null, "Bế Hoài Trang", "NV0166", "Mẹ" },
                    { 101, "Hà Nội", "0123434324", null, "Cà Bảo Phương", "NV0101", "Bạn" },
                    { 200, "Hà Nội", "0123434324", null, "Phạm Diệu Ngà", "NV0200", "Mẹ" },
                    { 27, "Hà Nội", "0123434324", null, "Nguyễn Danh Sơn", "NV0027", "Bố" },
                    { 67, "Hà Nội", "0123434324", null, "Nguyễn Việt Thông", "NV0067", "Bố" },
                    { 102, "Hà Nội", "0123434324", null, "Cai Bích Lam", "NV0102", "Mẹ" },
                    { 56, "Hà Nội", "0123434324", null, "Ngô Quang Anh", "NV0056", "Bố" },
                    { 15, "Hà Nội", "0123434324", null, "Đỗ Việt Dương", "NV0015", "Bố" },
                    { 103, "Hà Nội", "0123434324", null, "Lý Hồng Mai", "NV0103", "Mẹ" },
                    { 12, "Hà Nội", "0123434324", null, "Phạm Đình Chiến", "NV0012", "Bố" },
                    { 181, "Hà Nội", "0123434324", null, "Lỗ Anh Phương", "NV0181", "Bạn" },
                    { 104, "Hà Nội", "0123434324", null, "Ca Lộc Uyên", "NV0104", "Mẹ" },
                    { 199, "Hà Nội", "0123434324", null, "Bì Diễm Trinh", "NV0199", "Mẹ" },
                    { 105, "Hà Nội", "0123434324", null, "Nông Mỹ Thuần", "NV0105", "Mẹ" },
                    { 53, "Hà Nội", "0123434324", null, "Đỗ Khánh Giang", "NV0053", "Bố" },
                    { 26, "Hà Nội", "0123434324", null, "Khoa Gia Hưng", "NV0026", "Bố" },
                    { 66, "Hà Nội", "0123434324", null, "Đào Lam Phương", "NV0066", "Bố" },
                    { 106, "Hà Nội", "0123434324", null, "Chu Thu Nhiên", "NV0106", "Mẹ" },
                    { 153, "Hà Nội", "0123434324", null, "Thân Minh Khuê", "NV0153", "Mẹ" },
                    { 185, "Hà Nội", "0123434324", null, "Liên Diệp Anh", "NV0185", "Mẹ" },
                    { 107, "Hà Nội", "0123434324", null, "Tuấn Thúy Loan", "NV0107", "Mẹ" },
                    { 164, "Hà Nội", "0123434324", null, "Quán Duyên Nương", "NV0164", "Mẹ" },
                    { 151, "Hà Nội", "0123434324", null, "Thân Lệ Quyên", "NV0151", "Bạn" },
                    { 108, "Hà Nội", "0123434324", null, "Trác Thy Oanh", "NV0108", "Mẹ" },
                    { 198, "Hà Nội", "0123434324", null, "Tinh Cẩm Vân", "NV0198", "Mẹ" },
                    { 165, "Hà Nội", "0123434324", null, "Đặng Hải My", "NV0165", "Mẹ" },
                    { 39, "Hà Nội", "0123434324", null, "Tô Ðức Khiêm", "NV0039", "Bố" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "id", "diaChi", "dienThoai", "email", "hoTen", "maNhanVien", "quanHe" },
                values: new object[,]
                {
                    { 154, "Hà Nội", "0123434324", null, "Khương Minh Phương", "NV0154", "Mẹ" },
                    { 121, "Hà Nội", "0123434324", null, "Lô Phương Châu", "NV0121", "Bạn" },
                    { 131, "Hà Nội", "0123434324", null, "Khiếu Thúy Liên", "NV0131", "Bạn" },
                    { 20, "Hà Nội", "0123434324", null, "Trần Thành Ðạt", "NV0020", "Bố" },
                    { 132, "Hà Nội", "0123434324", null, "Lư Tuyết Vân", "NV0132", "Mẹ" },
                    { 191, "Hà Nội", "0123434324", null, "Đồng Liên Như", "NV0191", "Bạn" },
                    { 60, "Hà Nội", "0123434324", null, "Trần Hữu Bình", "NV0060", "Bố" },
                    { 133, "Hà Nội", "0123434324", null, "Liễu Bạch Kim", "NV0133", "Mẹ" },
                    { 17, "Hà Nội", "0123434324", null, "Tăng Hữu Cường", "NV0017", "Bố" },
                    { 183, "Hà Nội", "0123434324", null, "Hướng Bích Hà", "NV0183", "Mẹ" },
                    { 134, "Hà Nội", "0123434324", null, "Khà Hồng Diễm", "NV0134", "Mẹ" },
                    { 158, "Hà Nội", "0123434324", null, "Tinh Thiên Lan", "NV0158", "Mẹ" },
                    { 135, "Hà Nội", "0123434324", null, "Trà Kim Loan", "NV0135", "Mẹ" },
                    { 19, "Hà Nội", "0123434324", null, "Nguyễn Chiêu Quân", "NV0019", "Bố" },
                    { 190, "Hà Nội", "0123434324", null, "Mục Kiều Mỹ", "NV0190", "Mẹ" },
                    { 136, "Hà Nội", "0123434324", null, "La Mộng Thu", "NV0136", "Mẹ" },
                    { 38, "Hà Nội", "0123434324", null, "Nguyễn Duy Hùng", "NV0038", "Bố" },
                    { 157, "Hà Nội", "0123434324", null, "Khà Thi Cầm", "NV0157", "Mẹ" },
                    { 143, "Hà Nội", "0123434324", null, "Doãn Hải Yến", "NV0143", "Mẹ" },
                    { 55, "Hà Nội", "0123434324", null, "Nguyễn Quốc Hiển", "NV0055", "Bố" },
                    { 59, "Hà Nội", "0123434324", null, "Trần Tân Phước", "NV0059", "Bố" },
                    { 138, "Hà Nội", "0123434324", null, "Dã Thanh Lâm", "NV0138", "Mẹ" },
                    { 188, "Hà Nội", "0123434324", null, "Đặng Hồng Linh", "NV0188", "Mẹ" },
                    { 139, "Hà Nội", "0123434324", null, "Đào Thùy Mi", "NV0139", "Mẹ" },
                    { 189, "Hà Nội", "0123434324", null, "Bảo Khả Ái", "NV0189", "Mẹ" },
                    { 18, "Hà Nội", "0123434324", null, "Phạm Huy Hoàng", "NV0018", "Bố" },
                    { 142, "Hà Nội", "0123434324", null, "Hứa Hải Uyên", "NV0142", "Mẹ" },
                    { 140, "Hà Nội", "0123434324", null, "Phong Xuân Lan", "NV0140", "Mẹ" },
                    { 156, "Hà Nội", "0123434324", null, "Mã Thanh Kiều", "NV0156", "Mẹ" },
                    { 14, "Hà Nội", "0123434324", null, "Phạm Ðức Hòa", "NV0014", "Bố" },
                    { 141, "Hà Nội", "0123434324", null, "Lãnh Hạ Phương", "NV0141", "Bạn" },
                    { 6, "Hà Nội", "0123434324", null, "Nguyễn Tiến Võ", "NV0006", "Bố" },
                    { 137, "Hà Nội", "0123434324", null, "Quàng Mỹ Hoàn", "NV0137", "Mẹ" },
                    { 130, "Hà Nội", "0123434324", null, "Tề Thiên Khánh", "NV0130", "Mẹ" },
                    { 47, "Hà Nội", "0123434324", null, "Nguyễn Công Sơn", "NV0047", "Bố" },
                    { 192, "Hà Nội", "0123434324", null, "Chiêm Ngọc Ðàn", "NV0192", "Mẹ" },
                    { 58, "Hà Nội", "0123434324", null, "Đỗ Lân Vũ", "NV0058", "Bố" },
                    { 148, "Hà Nội", "0123434324", null, "Hứa Kim Mai", "NV0148", "Mẹ" },
                    { 122, "Hà Nội", "0123434324", null, "Mâu Thảo My", "NV0122", "Mẹ" },
                    { 194, "Hà Nội", "0123434324", null, "Tăng Phương Trang", "NV0194", "Mẹ" },
                    { 22, "Hà Nội", "0123434324", null, "Vũ Tuấn Dũng", "NV0022", "Bố" },
                    { 123, "Hà Nội", "0123434324", null, "Điền Thiên Lan", "NV0123", "Mẹ" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "id", "diaChi", "dienThoai", "email", "hoTen", "maNhanVien", "quanHe" },
                values: new object[,]
                {
                    { 54, "Hà Nội", "0123434324", null, "Hoàng Quang Thạch", "NV0054", "Bố" },
                    { 160, "Hà Nội", "0123434324", null, "Liễu Trúc Vân", "NV0160", "Mẹ" },
                    { 16, "Hà Nội", "0123434324", null, "Trần Hiếu Liêm", "NV0016", "Bố" },
                    { 147, "Hà Nội", "0123434324", null, "Tinh Kim Chi", "NV0147", "Mẹ" },
                    { 124, "Hà Nội", "0123434324", null, "Trà Trang Nhã", "NV0124", "Mẹ" },
                    { 62, "Hà Nội", "0123434324", null, "Bùi Vĩnh Thụy", "NV0062", "Bố" },
                    { 13, "Hà Nội", "0123434324", null, "Phạm Ðức Kiên", "NV0013", "Bố" },
                    { 57, "Hà Nội", "0123434324", null, "Mai Trung Hoàng", "NV0057", "Bố" },
                    { 48, "Hà Nội", "0123434324", null, "Phạm Nhật Khương", "NV0048", "Bố" },
                    { 125, "Hà Nội", "0123434324", null, "Hạ Ánh Mai", "NV0125", "Mẹ" },
                    { 201, "Hà Nội", "0123434324", null, "Tiêu Hồng Liên", "NV0201", "Bạn" },
                    { 129, "Hà Nội", "0123434324", null, "Trang Quỳnh Thanh", "NV0129", "Mẹ" },
                    { 144, "Hà Nội", "0123434324", null, "Thi Hải Yến", "NV0144", "Mẹ" },
                    { 61, "Hà Nội", "0123434324", null, "Đỗ Xuân Quý", "NV0061", "Bạn" },
                    { 159, "Hà Nội", "0123434324", null, "Liễu Trúc Vân", "NV0159", "Mẹ" },
                    { 128, "Hà Nội", "0123434324", null, "Ông Minh Trang", "NV0128", "Mẹ" },
                    { 155, "Hà Nội", "0123434324", null, "Mạch Minh Phương", "NV0155", "Mẹ" },
                    { 63, "Hà Nội", "0123434324", null, "Trần Bảo Duy", "NV0063", "Bố" },
                    { 5, "Hà Nội", "0123434324", null, "Nguyễn Ðinh Lộc", "NV0005", "Bố" },
                    { 145, "Hà Nội", "0123434324", null, "Hồ Huyền Ngọc", "NV0145", "Mẹ" },
                    { 127, "Hà Nội", "0123434324", null, "Hứa Mai Thanh", "NV0127", "Mẹ" },
                    { 187, "Hà Nội", "0123434324", null, "Duy Hoài Giang", "NV0187", "Mẹ" },
                    { 126, "Hà Nội", "0123434324", null, "Từ Khánh Giao", "NV0126", "Mẹ" },
                    { 37, "Hà Nội", "0123434324", null, "Bùi Thiện Thanh", "NV0037", "Bố" },
                    { 146, "Hà Nội", "0123434324", null, "Tăng Khánh Quỳnh", "NV0146", "Mẹ" },
                    { 21, "Hà Nội", "0123434324", null, "Mạc Nam An", "NV0021", "Bạn" },
                    { 193, "Hà Nội", "0123434324", null, "Nghiêm Nguyên Thảo", "NV0193", "Mẹ" },
                    { 36, "Hà Nội", "0123434324", null, "Nguyễn Bình Quân", "NV0036", "Bố" },
                    { 206, "Hà Nội", "0123434324", null, "Tấn Mỹ Thuần", "NV0206", "Mẹ" },
                    { 88, "Hà Nội", "0123434324", null, "Đặng Hoàng Dũng", "NV0088", "Bố" },
                    { 10, "Hà Nội", "0123434324", null, "Hoàng Gia Bảo", "NV0010", "Bố" },
                    { 205, "Hà Nội", "0123434324", null, "Lèng Kim Hương", "NV0205", "Mẹ" },
                    { 78, "Hà Nội", "0123434324", null, "Nguyễn Công Hiếu", "NV0078", "Bố" },
                    { 89, "Hà Nội", "0123434324", null, "Lưu Hồng Đức", "NV0089", "Bố" },
                    { 171, "Hà Nội", "0123434324", null, "Từ Thái Lâm", "NV0171", "Bạn" },
                    { 176, "Hà Nội", "0123434324", null, "Cự Tuyết Vân", "NV0176", "Mẹ" },
                    { 90, "Hà Nội", "0123434324", null, "Phạm Tùng Quang", "NV0090", "Bố" },
                    { 2, "Hà Nội", "0123434324", null, "Mai Lân Thắng", "NV0002", "Bố" },
                    { 30, "Hà Nội", "0123434324", null, "Trần Ðức Bảo", "NV0030", "Bố" },
                    { 70, "Hà Nội", "0123434324", null, "Đặng Tấn Dũng", "NV0070", "Bố" },
                    { 35, "Hà Nội", "0123434324", null, "Đoàn Nam Phương", "NV0035", "Bố" },
                    { 91, "Hà Nội", "0123434324", null, "Phạm Ðình Chương", "NV0091", "Bạn" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "id", "diaChi", "dienThoai", "email", "hoTen", "maNhanVien", "quanHe" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "0123434324", null, "Mai Trung Hiếu", "NV0001", "Bạn" },
                    { 50, "Hà Nội", "0123434324", null, "Nguyễn Nguyên Bảo", "NV0050", "Bố" },
                    { 204, "Hà Nội", "0123434324", null, "Cống Hương Trang", "NV0204", "Mẹ" },
                    { 92, "Hà Nội", "0123434324", null, "Phạm Quang Ninh", "NV0092", "Bố" },
                    { 8, "Hà Nội", "0123434324", null, "Lý Gia Bình", "NV0008", "Bố" },
                    { 77, "Hà Nội", "0123434324", null, "Lê Thế Dũng", "NV0077", "Bố" },
                    { 170, "Hà Nội", "0123434324", null, "Điều Nhất Thương", "NV0170", "Mẹ" },
                    { 111, "Hà Nội", "0123434324", null, "Khai Kim Cương", "NV0111", "Bạn" },
                    { 93, "Hà Nội", "0123434324", null, "Vũ Quang Triệu", "NV0093", "Bố" },
                    { 43, "Hà Nội", "0123434324", null, "Trịnh Quang Huy", "NV0043", "Bố" },
                    { 44, "Hà Nội", "0123434324", null, "Lê Minh Đăng", "NV0044", "Bố" },
                    { 172, "Hà Nội", "0123434324", null, "Lô Thu Hà", "NV0172", "Mẹ" },
                    { 179, "Hà Nội", "0123434324", null, "Dương Xuân Thanh", "NV0179", "Mẹ" },
                    { 87, "Hà Nội", "0123434324", null, "Phí Ðình Thắng", "NV0087", "Bố" },
                    { 82, "Hà Nội", "0123434324", null, "Nguyễn Chí Bảo", "NV0082", "Bố" },
                    { 175, "Hà Nội", "0123434324", null, "Ty Trâm Oanh", "NV0175", "Mẹ" },
                    { 174, "Hà Nội", "0123434324", null, "Lãnh Thục Tâm", "NV0174", "Mẹ" },
                    { 208, "Hà Nội", "0123434324", null, "Khu Nhã Hồng", "NV0208", "Mẹ" },
                    { 32, "Hà Nội", "0123434324", null, "Đỗ Duy Thông", "NV0032", "Bố" },
                    { 72, "Hà Nội", "0123434324", null, "Dương Bảo Phúc", "NV0072", "Bố" },
                    { 209, "Hà Nội", "0123434324", null, "Ao Thương Nga", "NV0209", "Mẹ" },
                    { 83, "Hà Nội", "0123434324", null, "Vũ Sơn Quân", "NV0083", "Bố" },
                    { 178, "Hà Nội", "0123434324", null, "Dương Xuân Thanh", "NV0178", "Mẹ" },
                    { 51, "Hà Nội", "0123434324", null, "Đỗ Trung Ðức", "NV0051", "Bạn" },
                    { 80, "Hà Nội", "0123434324", null, "Mai Tùng Hiếu", "NV0080", "Bố" },
                    { 203, "Hà Nội", "0123434324", null, "Khoa Hương Giang", "NV0203", "Mẹ" },
                    { 207, "Hà Nội", "0123434324", null, "Ngọc Nguyệt Anh", "NV0207", "Mẹ" },
                    { 210, "Hà Nội", "0123434324", null, "Hoàng Trâm Anh", "NV0210", "Mẹ" },
                    { 9, "Hà Nội", "0123434324", null, "Đặng Gia Anh", "NV0009", "Bố" },
                    { 79, "Hà Nội", "0123434324", null, "Nguyễn Trung Kiên", "NV0079", "Bố" },
                    { 173, "Hà Nội", "0123434324", null, "Luyện Thu Hồng", "NV0173", "Mẹ" },
                    { 85, "Hà Nội", "0123434324", null, "Hoàng Minh Khôi", "NV0085", "Bố" },
                    { 73, "Hà Nội", "0123434324", null, "Nguyễn Ðình Hợp", "NV0073", "Bố" },
                    { 33, "Hà Nội", "0123434324", null, "Đỗ Ngọc Ẩn", "NV0033", "Bố" },
                    { 86, "Hà Nội", "0123434324", null, "Vũ Minh Kỳ", "NV0086", "Bố" },
                    { 167, "Hà Nội", "0123434324", null, "Văn Khánh Mai", "NV0167", "Mẹ" },
                    { 31, "Hà Nội", "0123434324", null, "Phạm Hoài Thanh", "NV0031", "Bạn" },
                    { 71, "Hà Nội", "0123434324", null, "Nguyễn Trí Hữu", "NV0071", "Bạn" },
                    { 84, "Hà Nội", "0123434324", null, "Phạm Hữu Long", "NV0084", "Bố" },
                    { 29, "Hà Nội", "0123434324", null, "Nguyễn Ðắc Thành", "NV0029", "Bố" },
                    { 81, "Hà Nội", "0123434324", null, "Lưu Duy Châu", "NV0081", "Bạn" },
                    { 69, "Hà Nội", "0123434324", null, "Bùi Nhật Duy", "NV0069", "Bố" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "id", "diaChi", "dienThoai", "email", "hoTen", "maNhanVien", "quanHe" },
                values: new object[,]
                {
                    { 180, "Hà Nội", "0123434324", null, "Trang Xuân Thu", "NV0180", "Mẹ" },
                    { 97, "Hà Nội", "0123434324", null, "Nguyễn Khắc Triệu", "NV0097", "Bố" },
                    { 76, "Hà Nội", "0123434324", null, "Vũ Quang Thiên", "NV0076", "Bố" },
                    { 74, "Hà Nội", "0123434324", null, "Bùi Ðại Thống", "NV0074", "Bố" },
                    { 75, "Hà Nội", "0123434324", null, "Hoàng Xuân Bình", "NV0075", "Bố" },
                    { 40, "Hà Nội", "0123434324", null, "Vũ Quốc Quân", "NV0040", "Bố" },
                    { 11, "Hà Nội", "0123434324", null, "Lưu Việt Thanh", "NV0011", "Bạn" },
                    { 28, "Hà Nội", "0123434324", null, "Nguyễn Kiến Ðức", "NV0028", "Bố" },
                    { 34, "Hà Nội", "0123434324", null, "Đàm Minh Quý", "NV0034", "Bố" },
                    { 52, "Hà Nội", "0123434324", null, "Vũ Cao Phong", "NV0052", "Bố" },
                    { 68, "Hà Nội", "0123434324", null, "Trần Minh Thông", "NV0068", "Bố" },
                    { 42, "Hà Nội", "0123434324", null, "Đặng Thống Nhất", "NV0042", "Bố" },
                    { 98, "Hà Nội", "0123434324", null, "Lê Công Luận", "NV0098", "Bố" },
                    { 168, "Hà Nội", "0123434324", null, "Điều Mai Linh", "NV0168", "Mẹ" },
                    { 96, "Hà Nội", "0123434324", null, "Trần Trung Nguyên", "NV0096", "Bố" },
                    { 95, "Hà Nội", "0123434324", null, "Nguyễn Hồng Thịnh", "NV0095", "Bố" },
                    { 94, "Hà Nội", "0123434324", null, "Phạm Tấn Nam", "NV0094", "Bố" },
                    { 202, "Hà Nội", "0123434324", null, "Nhan Hồng Thúy", "NV0202", "Mẹ" },
                    { 169, "Hà Nội", "0123434324", null, "Cống Minh Thu", "NV0169", "Mẹ" }
                });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 28, 1, "NV0027", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 86, 1, "NV0085", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 52, 1, "NV0051", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 62, 1, "NV0061", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 76, 1, "NV0075", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 57, 1, "NV0056", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 41, 1, "NV0040", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 1, 1, "NV0001", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 38, 1, "NV0037", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 22, 1, "NV0021", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 72, 1, "NV0071", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 29, 1, "NV0028", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 87, 1, "NV0086", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 14, 1, "NV0013", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 68, 1, "NV0067", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 46, 1, "NV0045", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 88, 1, "NV0087", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 55, 1, "NV0054", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 63, 1, "NV0062", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 4, 1, "NV0003", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 32, 1, "NV0031", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 15, 1, "NV0014", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 98, 1, "NV0097", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 85, 1, "NV0084", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 60, 1, "NV0059", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 8, 1, "NV0007", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 75, 1, "NV0074", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 33, 1, "NV0032", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 73, 1, "NV0072", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 99, 1, "NV0098", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 20, 1, "NV0019", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 83, 1, "NV0082", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 43, 1, "NV0042", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 69, 1, "NV0068", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 100, 1, "NV0099", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 48, 1, "NV0047", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 84, 1, "NV0083", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 61, 1, "NV0060", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 16, 1, "NV0015", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 81, 1, "NV0080", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 19, 1, "NV0018", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 12, 1, "NV0011", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 21, 1, "NV0020", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 10, 1, "NV0009", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 2, 1, "NV0001", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Đại học Bách Khoa", "khá" },
                    { 56, 1, "NV0055", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 6, 1, "NV0005", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 101, 1, "NV0100", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 59, 1, "NV0058", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 80, 1, "NV0079", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 37, 1, "NV0036", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 97, 1, "NV0096", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 89, 1, "NV0088", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 96, 1, "NV0095", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 35, 1, "NV0034", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 67, 1, "NV0066", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 65, 1, "NV0064", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 36, 1, "NV0035", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 78, 1, "NV0077", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 93, 1, "NV0092", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 58, 1, "NV0057", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 25, 1, "NV0024", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 54, 1, "NV0053", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 5, 1, "NV0004", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 44, 1, "NV0043", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 17, 1, "NV0016", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 30, 1, "NV0029", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 70, 1, "NV0069", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 42, 1, "NV0041", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 50, 1, "NV0049", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 66, 1, "NV0065", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 13, 1, "NV0012", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 94, 1, "NV0093", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 77, 1, "NV0076", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 26, 1, "NV0025", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 95, 1, "NV0094", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 39, 1, "NV0038", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 3, 1, "NV0002", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 24, 1, "NV0023", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 9, 1, "NV0008", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 90, 1, "NV0089", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 51, 1, "NV0050", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 27, 1, "NV0026", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 79, 1, "NV0078", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 53, 1, "NV0052", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 45, 1, "NV0044", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 18, 1, "NV0017", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 31, 1, "NV0030", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 64, 1, "NV0063", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 74, 1, "NV0073", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 23, 1, "NV0022", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 11, 1, "NV0010", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 71, 1, "NV0070", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 49, 1, "NV0048", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 34, 1, "NV0033", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 40, 1, "NV0039", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 91, 1, "NV0090", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 7, 1, "NV0006", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 47, 1, "NV0046", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NguoiThan",
                columns: new[] { "id", "diaChi", "dienThoai", "gioiTinh", "idDanhMucNguoiThan", "khac", "maNhanVien", "ngaySinh", "ngheNghiep", "quanHe", "tenNguoiThan" },
                values: new object[,]
                {
                    { 77, "điện biên", "0914637668", true, 1, null, "NV0038", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 32, "điện biên", "0914637668", false, 2, null, "NV0015", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Trần Hiểu Lam" },
                    { 82, "điện biên", "0914637668", false, 2, null, "NV0040", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 66, "điện biên", "0914637668", false, 2, null, "NV0032", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 30, "điện biên", "0914637668", false, 2, null, "NV0014", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Trần Cát Nhung" },
                    { 31, "điện biên", "0914637668", true, 1, null, "NV0015", new DateTime(1955, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Đào Minh Quang" },
                    { 81, "điện biên", "0914637668", true, 1, null, "NV0040", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 38, "điện biên", "0914637668", false, 2, null, "NV0018", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Hà Thị Thu" }
                });

            migrationBuilder.InsertData(
                table: "NguoiThan",
                columns: new[] { "id", "diaChi", "dienThoai", "gioiTinh", "idDanhMucNguoiThan", "khac", "maNhanVien", "ngaySinh", "ngheNghiep", "quanHe", "tenNguoiThan" },
                values: new object[,]
                {
                    { 33, "điện biên", "0914637668", true, 1, null, "NV0016", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Minh Quang" },
                    { 36, "điện biên", "0914637668", false, 2, null, "NV0017", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Trần Hương Thảo" },
                    { 14, "điện biên", "0914637668", false, 2, null, "NV0006", new DateTime(1977, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Nguyễn Khánh Huyền" },
                    { 68, "điện biên", "0914637668", false, 2, null, "NV0033", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 34, "điện biên", "0914637668", false, 2, null, "NV0016", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Đặng Thị Thảo" },
                    { 78, "điện biên", "0914637668", false, 2, null, "NV0038", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 29, "điện biên", "0914637668", true, 1, null, "NV0014", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Đức Hoàng" },
                    { 69, "điện biên", "0914637668", true, 1, null, "NV0034", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 70, "điện biên", "0914637668", false, 2, null, "NV0034", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 35, "điện biên", "0914637668", true, 1, null, "NV0017", new DateTime(1980, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Vũ Đại Hiệp" },
                    { 13, "điện biên", "0914637668", true, 1, null, "NV0006", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Quản Tiến An" },
                    { 67, "điện biên", "0914637668", true, 1, null, "NV0033", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 37, "điện biên", "0914637668", true, 1, null, "NV0018", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Trần Đại Nghĩa" },
                    { 19, "điện biên", "0914637668", true, 1, null, "NV0009", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Đào Quanh Linh" },
                    { 80, "điện biên", "0914637668", false, 2, null, "NV0039", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 1, "điện biên", "0914637668", true, 1, null, "NV0001", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Đăng Hải" },
                    { 48, "điện biên", "0914637668", false, 2, null, "NV0023", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 21, "điện biên", "0914637668", true, 1, null, "NV0010", new DateTime(1945, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Đào Phan Anh" },
                    { 20, "điện biên", "0914637668", false, 2, null, "NV0009", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Nguyễn Thị Phượng" },
                    { 22, "điện biên", "0914637668", false, 2, null, "NV0010", new DateTime(1955, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Nguyễn Thị Hồng Cẩm" },
                    { 74, "điện biên", "0914637668", false, 2, null, "NV0036", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 25, "điện biên", "0914637668", true, 1, null, "NV0012", new DateTime(1972, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Đức Bình" },
                    { 49, "điện biên", "0914637668", true, 1, null, "NV0024", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 3, "điện biên", "0914637668", true, 3, null, "NV0002", new DateTime(1995, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Anh", "Nguyễn Công Minh" },
                    { 73, "điện biên", "0914637668", true, 1, null, "NV0036", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 50, "điện biên", "0914637668", false, 2, null, "NV0024", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 60, "điện biên", "0914637668", false, 2, null, "NV0029", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 5, "điện biên", "0914637668", false, 4, null, "NV0002", new DateTime(2005, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Chị", "Tiêu Nguyệt Ảnh" },
                    { 59, "điện biên", "0914637668", true, 1, null, "NV0029", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 51, "điện biên", "0914637668", true, 1, null, "NV0025", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 52, "điện biên", "0914637668", false, 2, null, "NV0025", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 8, "điện biên", "0914637668", false, 2, null, "NV0003", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Đào Thị Huyền" },
                    { 71, "điện biên", "0914637668", true, 1, null, "NV0035", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 6, "điện biên", "0914637668", false, 4, null, "NV0002", new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Chị", "Quất Hồng Đào" },
                    { 72, "điện biên", "0914637668", false, 2, null, "NV0035", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 53, "điện biên", "0914637668", true, 1, null, "NV0026", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 58, "điện biên", "0914637668", false, 2, null, "NV0028", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 54, "điện biên", "0914637668", false, 2, null, "NV0026", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 7, "điện biên", "0914637668", true, 1, null, "NV0003", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 57, "điện biên", "0914637668", true, 1, null, "NV0028", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 55, "điện biên", "0914637668", true, 1, null, "NV0027", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 79, "điện biên", "0914637668", true, 1, null, "NV0039", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" }
                });

            migrationBuilder.InsertData(
                table: "NguoiThan",
                columns: new[] { "id", "diaChi", "dienThoai", "gioiTinh", "idDanhMucNguoiThan", "khac", "maNhanVien", "ngaySinh", "ngheNghiep", "quanHe", "tenNguoiThan" },
                values: new object[,]
                {
                    { 56, "điện biên", "0914637668", false, 2, null, "NV0027", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 24, "điện biên", "0914637668", false, 2, null, "NV0011", new DateTime(1977, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Đỗ Thị Lan" },
                    { 23, "điện biên", "0914637668", true, 1, null, "NV0011", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Minh Tâm" },
                    { 47, "điện biên", "0914637668", true, 1, null, "NV0023", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 9, "điện biên", "0914637668", true, 1, null, "NV0004", new DateTime(1955, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Văn Hiếu" },
                    { 26, "điện biên", "0914637668", false, 2, null, "NV0012", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Nguyễn Thị Ngọc" },
                    { 10, "điện biên", "0914637668", false, 2, null, "NV0004", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Nguyễn Thu Hà" },
                    { 27, "điện biên", "0914637668", true, 1, null, "NV0013", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Hoàng Trung" },
                    { 2, "điện biên", "0914637668", true, 3, null, "NV0001", new DateTime(1995, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Anh", "Mai Trung Hiếu" },
                    { 11, "điện biên", "0914637668", true, 1, null, "NV0005", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Phạm Hải Hoàng" },
                    { 76, "điện biên", "0914637668", false, 2, null, "NV0037", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 41, "điện biên", "0914637668", true, 1, null, "NV0020", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 42, "điện biên", "0914637668", false, 2, null, "NV0020", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 75, "điện biên", "0914637668", true, 1, null, "NV0037", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 12, "điện biên", "0914637668", false, 2, null, "NV0005", new DateTime(1995, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Phạm Thu Hoài" },
                    { 40, "điện biên", "0914637668", false, 2, null, "NV0019", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 39, "điện biên", "0914637668", true, 1, null, "NV0019", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 18, "điện biên", "0914637668", false, 2, null, "NV0008", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Lê Thị Hồng Nhung" },
                    { 4, "điện biên", "0914637668", false, 2, null, "NV0001", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 28, "điện biên", "0914637668", false, 2, null, "NV0013", new DateTime(1988, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Nguyễn Tú Oanh" },
                    { 64, "điện biên", "0914637668", false, 2, null, "NV0031", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 63, "điện biên", "0914637668", true, 1, null, "NV0031", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 43, "điện biên", "0914637668", true, 1, null, "NV0021", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 44, "điện biên", "0914637668", false, 2, null, "NV0021", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 16, "điện biên", "0914637668", false, 2, null, "NV0007", new DateTime(1979, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Trần Ngọc Kỳ" },
                    { 62, "điện biên", "0914637668", false, 2, null, "NV0030", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 15, "điện biên", "0914637668", true, 1, null, "NV0007", new DateTime(1977, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Tạ Thành Hưng" },
                    { 45, "điện biên", "0914637668", true, 1, null, "NV0022", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 46, "điện biên", "0914637668", false, 2, null, "NV0022", new DateTime(1985, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Mẹ", "Úc Minh Hương" },
                    { 61, "điện biên", "0914637668", true, 1, null, "NV0030", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 65, "điện biên", "0914637668", true, 1, null, "NV0032", new DateTime(1975, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Dương Tuấn Kiệt" },
                    { 17, "điện biên", "0914637668", true, 1, null, "NV0008", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Tiến Tùng" }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoVanHoa",
                columns: new[] { "id", "denThoiGian", "idChuyenMon", "idHinhThucDaoTao", "idTrinhDo", "maNhanVien", "tenTruong", "tuThoiGian" },
                values: new object[,]
                {
                    { 52, null, 2, 2, 2, "NV0052", "Đại Học Kinh Tế Quốc Dân", null },
                    { 49, null, 4, 1, 2, "NV0049", "Học Viện Tài Chính", null },
                    { 11, null, 1, 1, 1, "NV0011", "Đại Học Bách Khoa", null },
                    { 13, null, 3, 1, 1, "NV0013", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 54, null, 4, 2, 1, "NV0054", "Đại Học Mở", null },
                    { 14, null, 4, 2, 1, "NV0014", "Đại Học Mở", null },
                    { 12, null, 2, 2, 2, "NV0012", "Đại Học Kinh Tế Quốc Dân", null },
                    { 53, null, 3, 1, 1, "NV0053", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 50, null, 5, 2, 1, "NV0050", "Đại Học Thủy Lợi", null },
                    { 10, null, 5, 2, 1, "NV0010", "Đại Học Thủy Lợi", null }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoVanHoa",
                columns: new[] { "id", "denThoiGian", "idChuyenMon", "idHinhThucDaoTao", "idTrinhDo", "maNhanVien", "tenTruong", "tuThoiGian" },
                values: new object[,]
                {
                    { 8, null, 3, 2, 1, "NV0008", "Đại Học Thăng Long", null },
                    { 51, null, 1, 1, 1, "NV0051", "Đại Học Bách Khoa", null },
                    { 55, null, 5, 1, 1, "NV0055", "Học Viện Ngân Hàng", null },
                    { 7, null, 2, 1, 2, "NV0007", "Đại Học Ngoại Thương", null },
                    { 9, null, 4, 1, 2, "NV0009", "Học Viện Tài Chính", null },
                    { 39, null, 4, 1, 2, "NV0039", "Học Viện Tài Chính", null },
                    { 74, null, 4, 2, 1, "NV0074", "Đại Học Mở", null },
                    { 31, null, 1, 1, 1, "NV0031", "Đại Học Bách Khoa", null },
                    { 26, null, 1, 2, 2, "NV0026", "Học Viện Phụ Nữ", null },
                    { 88, null, 3, 2, 1, "NV0088", "Đại Học Thăng Long", null },
                    { 38, null, 3, 2, 1, "NV0038", "Đại Học Thăng Long", null },
                    { 66, null, 1, 2, 2, "NV0066", "Học Viện Phụ Nữ", null },
                    { 45, null, 5, 1, 1, "NV0045", "Học Viện Ngân Hàng", null },
                    { 3, null, 3, 1, 1, "NV0003", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 25, null, 5, 1, 1, "NV0025", "Học Viện Ngân Hàng", null },
                    { 87, null, 2, 1, 2, "NV0087", "Đại Học Ngoại Thương", null },
                    { 65, null, 5, 1, 1, "NV0065", "Học Viện Ngân Hàng", null },
                    { 86, null, 1, 2, 2, "NV0086", "Học Viện Phụ Nữ", null },
                    { 1, null, 1, 1, 1, "NV0001", "Đại Học Bách Khoa", null },
                    { 24, null, 4, 2, 1, "NV0024", "Đại Học Mở", null },
                    { 42, null, 2, 2, 2, "NV0042", "Đại Học Kinh Tế Quốc Dân", null },
                    { 85, null, 5, 1, 1, "NV0085", "Học Viện Ngân Hàng", null },
                    { 64, null, 4, 2, 1, "NV0064", "Đại Học Mở", null },
                    { 23, null, 3, 1, 1, "NV0023", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 36, null, 1, 2, 2, "NV0036", "Học Viện Phụ Nữ", null },
                    { 67, null, 2, 1, 2, "NV0067", "Đại Học Ngoại Thương", null },
                    { 30, null, 5, 2, 1, "NV0030", "Đại Học Thủy Lợi", null },
                    { 100, null, 5, 2, 1, "NV0100", "Đại Học Thủy Lợi", null },
                    { 27, null, 2, 1, 2, "NV0027", "Đại Học Ngoại Thương", null },
                    { 69, null, 4, 1, 2, "NV0069", "Học Viện Tài Chính", null },
                    { 93, null, 3, 1, 1, "NV0093", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 94, null, 4, 2, 1, "NV0094", "Đại Học Mở", null },
                    { 44, null, 4, 2, 1, "NV0044", "Đại Học Mở", null },
                    { 95, null, 5, 1, 1, "NV0095", "Học Viện Ngân Hàng", null },
                    { 2, null, 2, 2, 2, "NV0002", "Đại Học Kinh Tế Quốc Dân", null },
                    { 28, null, 3, 2, 1, "NV0028", "Đại Học Thăng Long", null },
                    { 96, null, 1, 2, 2, "NV0096", "Học Viện Phụ Nữ", null },
                    { 71, null, 1, 1, 1, "NV0071", "Đại Học Bách Khoa", null },
                    { 91, null, 1, 1, 1, "NV0091", "Đại Học Bách Khoa", null },
                    { 68, null, 3, 2, 1, "NV0068", "Đại Học Thăng Long", null },
                    { 97, null, 2, 1, 2, "NV0097", "Đại Học Ngoại Thương", null },
                    { 89, null, 4, 1, 2, "NV0089", "Học Viện Tài Chính", null }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoVanHoa",
                columns: new[] { "id", "denThoiGian", "idChuyenMon", "idHinhThucDaoTao", "idTrinhDo", "maNhanVien", "tenTruong", "tuThoiGian" },
                values: new object[,]
                {
                    { 70, null, 5, 2, 1, "NV0070", "Đại Học Thủy Lợi", null },
                    { 98, null, 3, 2, 1, "NV0098", "Đại Học Thăng Long", null },
                    { 41, null, 1, 1, 1, "NV0041", "Đại Học Bách Khoa", null },
                    { 35, null, 5, 1, 1, "NV0035", "Học Viện Ngân Hàng", null },
                    { 99, null, 4, 1, 2, "NV0099", "Học Viện Tài Chính", null },
                    { 90, null, 5, 2, 1, "NV0090", "Đại Học Thủy Lợi", null },
                    { 29, null, 4, 1, 2, "NV0029", "Học Viện Tài Chính", null },
                    { 92, null, 2, 2, 2, "NV0092", "Đại Học Kinh Tế Quốc Dân", null },
                    { 4, null, 4, 2, 1, "NV0004", "Đại Học Mở", null },
                    { 80, null, 5, 2, 1, "NV0080", "Đại Học Thủy Lợi", null },
                    { 18, null, 3, 2, 1, "NV0018", "Đại Học Thăng Long", null },
                    { 34, null, 4, 2, 1, "NV0034", "Đại Học Mở", null },
                    { 79, null, 4, 1, 2, "NV0079", "Học Viện Tài Chính", null },
                    { 40, null, 5, 2, 1, "NV0040", "Đại Học Thủy Lợi", null },
                    { 58, null, 3, 2, 1, "NV0058", "Đại Học Thăng Long", null },
                    { 78, null, 3, 2, 1, "NV0078", "Đại Học Thăng Long", null },
                    { 17, null, 2, 1, 2, "NV0017", "Đại Học Ngoại Thương", null },
                    { 57, null, 2, 1, 2, "NV0057", "Đại Học Ngoại Thương", null },
                    { 73, null, 3, 1, 1, "NV0073", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 16, null, 1, 2, 2, "NV0016", "Học Viện Phụ Nữ", null },
                    { 6, null, 1, 2, 2, "NV0006", "Học Viện Phụ Nữ", null },
                    { 77, null, 2, 1, 2, "NV0077", "Đại Học Ngoại Thương", null },
                    { 33, null, 3, 1, 1, "NV0033", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 15, null, 5, 1, 1, "NV0015", "Học Viện Ngân Hàng", null },
                    { 56, null, 1, 2, 2, "NV0056", "Học Viện Phụ Nữ", null },
                    { 76, null, 1, 2, 2, "NV0076", "Học Viện Phụ Nữ", null },
                    { 75, null, 5, 1, 1, "NV0075", "Học Viện Ngân Hàng", null },
                    { 48, null, 3, 2, 1, "NV0048", "Đại Học Thăng Long", null },
                    { 32, null, 2, 2, 2, "NV0032", "Đại Học Kinh Tế Quốc Dân", null },
                    { 63, null, 3, 1, 1, "NV0063", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 59, null, 4, 1, 2, "NV0059", "Học Viện Tài Chính", null },
                    { 43, null, 3, 1, 1, "NV0043", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 83, null, 3, 1, 1, "NV0083", "Đại Học Kinh Doanh và Công Nghệ", null },
                    { 82, null, 2, 2, 2, "NV0082", "Đại Học Kinh Tế Quốc Dân", null },
                    { 21, null, 1, 1, 1, "NV0021", "Đại Học Bách Khoa", null },
                    { 61, null, 1, 1, 1, "NV0061", "Đại Học Bách Khoa", null },
                    { 47, null, 2, 1, 2, "NV0047", "Đại Học Ngoại Thương", null },
                    { 20, null, 5, 2, 1, "NV0020", "Đại Học Thủy Lợi", null },
                    { 62, null, 2, 2, 2, "NV0062", "Đại Học Kinh Tế Quốc Dân", null },
                    { 84, null, 4, 2, 1, "NV0084", "Đại Học Mở", null },
                    { 22, null, 2, 2, 2, "NV0022", "Đại Học Kinh Tế Quốc Dân", null },
                    { 60, null, 5, 2, 1, "NV0060", "Đại Học Thủy Lợi", null }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoVanHoa",
                columns: new[] { "id", "denThoiGian", "idChuyenMon", "idHinhThucDaoTao", "idTrinhDo", "maNhanVien", "tenTruong", "tuThoiGian" },
                values: new object[,]
                {
                    { 19, null, 4, 1, 2, "NV0019", "Học Viện Tài Chính", null },
                    { 5, null, 5, 1, 1, "NV0005", "Học Viện Ngân Hàng", null },
                    { 72, null, 2, 2, 2, "NV0072", "Đại Học Kinh Tế Quốc Dân", null },
                    { 37, null, 2, 1, 2, "NV0037", "Đại Học Ngoại Thương", null },
                    { 81, null, 1, 1, 1, "NV0081", "Đại Học Bách Khoa", null },
                    { 46, null, 1, 2, 2, "NV0046", "Học Viện Phụ Nữ", null }
                });

            migrationBuilder.InsertData(
                table: "YTe",
                columns: new[] { "id", "benhTat", "canNang", "chieuCao", "khuyetTat", "luuY", "maNhanVien", "nhomMau", "tinhTrangSucKhoe" },
                values: new object[,]
                {
                    { 178, null, 61.1f, 1.77f, false, null, "NV0178", "B", null },
                    { 1, null, 50.1f, 1.7f, false, null, "NV0001", "O", null },
                    { 179, null, 57.1f, 1.78f, false, null, "NV0179", "AB", null },
                    { 43, null, 57.1f, 1.72f, false, null, "NV0043", "B", null },
                    { 185, null, 59.1f, 1.74f, false, null, "NV0185", "AB", null },
                    { 199, null, 57.1f, 1.78f, false, null, "NV0199", "AB", null },
                    { 180, null, 58.1f, 1.79f, false, null, "NV0180", "AB", null },
                    { 48, null, 61.1f, 1.77f, false, null, "NV0048", "B", null },
                    { 6, null, 56.1f, 1.75f, false, null, "NV0006", "O", null },
                    { 186, null, 56.1f, 1.75f, false, null, "NV0186", "O", null },
                    { 184, null, 58.1f, 1.73f, false, null, "NV0184", "AB", null },
                    { 187, null, 60.1f, 1.76f, false, null, "NV0187", "A", null },
                    { 188, null, 61.1f, 1.77f, false, null, "NV0188", "B", null },
                    { 40, null, 58.1f, 1.79f, false, null, "NV0040", "AB", null },
                    { 189, null, 57.1f, 1.78f, false, null, "NV0189", "AB", null },
                    { 47, null, 60.1f, 1.76f, false, null, "NV0047", "A", null },
                    { 5, null, 59.1f, 1.74f, false, null, "NV0005", "AB", null },
                    { 190, null, 58.1f, 1.79f, false, null, "NV0190", "AB", null },
                    { 183, null, 57.1f, 1.72f, false, null, "NV0183", "B", null },
                    { 191, null, 50.1f, 1.7f, false, null, "NV0191", "O", null },
                    { 192, null, 66.1f, 1.71f, false, null, "NV0192", "A", null },
                    { 193, null, 57.1f, 1.72f, false, null, "NV0193", "B", null },
                    { 46, null, 56.1f, 1.75f, false, null, "NV0046", "O", null },
                    { 4, null, 58.1f, 1.73f, false, null, "NV0004", "AB", null },
                    { 41, null, 50.1f, 1.7f, false, null, "NV0041", "O", null },
                    { 2, null, 66.1f, 1.71f, false, null, "NV0002", "A", null },
                    { 49, null, 57.1f, 1.78f, false, null, "NV0049", "AB", null },
                    { 200, null, 58.1f, 1.79f, false, null, "NV0200", "AB", null },
                    { 181, null, 50.1f, 1.7f, false, null, "NV0181", "O", null },
                    { 198, null, 61.1f, 1.77f, false, null, "NV0198", "B", null },
                    { 44, null, 58.1f, 1.73f, false, null, "NV0044", "AB", null },
                    { 45, null, 59.1f, 1.74f, false, null, "NV0045", "AB", null },
                    { 7, null, 60.1f, 1.76f, false, null, "NV0007", "A", null },
                    { 197, null, 60.1f, 1.76f, false, null, "NV0197", "A", null },
                    { 196, null, 56.1f, 1.75f, false, null, "NV0196", "O", null },
                    { 195, null, 59.1f, 1.74f, false, null, "NV0195", "AB", null }
                });

            migrationBuilder.InsertData(
                table: "YTe",
                columns: new[] { "id", "benhTat", "canNang", "chieuCao", "khuyetTat", "luuY", "maNhanVien", "nhomMau", "tinhTrangSucKhoe" },
                values: new object[,]
                {
                    { 182, null, 66.1f, 1.71f, false, null, "NV0182", "A", null },
                    { 194, null, 58.1f, 1.73f, false, null, "NV0194", "AB", null },
                    { 3, null, 57.1f, 1.72f, false, null, "NV0003", "B", null },
                    { 8, null, 61.1f, 1.77f, false, null, "NV0008", "B", null },
                    { 136, null, 56.1f, 1.75f, false, null, "NV0136", "O", null },
                    { 50, null, 58.1f, 1.79f, false, null, "NV0050", "AB", null },
                    { 65, null, 59.1f, 1.74f, false, null, "NV0065", "AB", null },
                    { 108, null, 61.1f, 1.77f, false, null, "NV0108", "B", null },
                    { 107, null, 60.1f, 1.76f, false, null, "NV0107", "A", null },
                    { 25, null, 59.1f, 1.74f, false, null, "NV0025", "AB", null },
                    { 106, null, 56.1f, 1.75f, false, null, "NV0106", "O", null },
                    { 105, null, 59.1f, 1.74f, false, null, "NV0105", "AB", null },
                    { 104, null, 58.1f, 1.73f, false, null, "NV0104", "AB", null },
                    { 109, null, 57.1f, 1.78f, false, null, "NV0109", "AB", null },
                    { 66, null, 56.1f, 1.75f, false, null, "NV0066", "O", null },
                    { 26, null, 56.1f, 1.75f, false, null, "NV0026", "O", null },
                    { 102, null, 66.1f, 1.71f, false, null, "NV0102", "A", null },
                    { 101, null, 50.1f, 1.7f, false, null, "NV0101", "O", null },
                    { 100, null, 58.1f, 1.79f, false, null, "NV0100", "AB", null },
                    { 67, null, 60.1f, 1.76f, false, null, "NV0067", "A", null },
                    { 99, null, 57.1f, 1.78f, false, null, "NV0099", "AB", null },
                    { 35, null, 59.1f, 1.74f, false, null, "NV0035", "AB", null },
                    { 103, null, 57.1f, 1.72f, false, null, "NV0103", "B", null },
                    { 27, null, 60.1f, 1.76f, false, null, "NV0027", "A", null },
                    { 110, null, 58.1f, 1.79f, false, null, "NV0110", "AB", null },
                    { 112, null, 66.1f, 1.71f, false, null, "NV0112", "A", null },
                    { 123, null, 57.1f, 1.72f, false, null, "NV0123", "B", null },
                    { 122, null, 66.1f, 1.71f, false, null, "NV0122", "A", null },
                    { 121, null, 50.1f, 1.7f, false, null, "NV0121", "O", null },
                    { 22, null, 66.1f, 1.71f, false, null, "NV0022", "A", null },
                    { 120, null, 58.1f, 1.79f, false, null, "NV0120", "AB", null },
                    { 63, null, 57.1f, 1.72f, false, null, "NV0063", "B", null },
                    { 119, null, 57.1f, 1.78f, false, null, "NV0119", "AB", null },
                    { 24, null, 58.1f, 1.73f, false, null, "NV0024", "AB", null },
                    { 36, null, 56.1f, 1.75f, false, null, "NV0036", "O", null },
                    { 117, null, 60.1f, 1.76f, false, null, "NV0117", "A", null },
                    { 116, null, 56.1f, 1.75f, false, null, "NV0116", "O", null },
                    { 23, null, 57.1f, 1.72f, false, null, "NV0023", "B", null },
                    { 115, null, 59.1f, 1.74f, false, null, "NV0115", "AB", null },
                    { 64, null, 58.1f, 1.73f, false, null, "NV0064", "AB", null },
                    { 114, null, 58.1f, 1.73f, false, null, "NV0114", "AB", null },
                    { 113, null, 57.1f, 1.72f, false, null, "NV0113", "B", null }
                });

            migrationBuilder.InsertData(
                table: "YTe",
                columns: new[] { "id", "benhTat", "canNang", "chieuCao", "khuyetTat", "luuY", "maNhanVien", "nhomMau", "tinhTrangSucKhoe" },
                values: new object[,]
                {
                    { 118, null, 61.1f, 1.77f, false, null, "NV0118", "B", null },
                    { 62, null, 66.1f, 1.71f, false, null, "NV0062", "A", null },
                    { 98, null, 61.1f, 1.77f, false, null, "NV0098", "B", null },
                    { 96, null, 56.1f, 1.75f, false, null, "NV0096", "O", null },
                    { 31, null, 50.1f, 1.7f, false, null, "NV0031", "O", null },
                    { 34, null, 58.1f, 1.73f, false, null, "NV0034", "AB", null },
                    { 83, null, 57.1f, 1.72f, false, null, "NV0083", "B", null },
                    { 82, null, 66.1f, 1.71f, false, null, "NV0082", "A", null },
                    { 81, null, 50.1f, 1.7f, false, null, "NV0081", "O", null },
                    { 72, null, 66.1f, 1.71f, false, null, "NV0072", "A", null },
                    { 80, null, 58.1f, 1.79f, false, null, "NV0080", "AB", null },
                    { 71, null, 50.1f, 1.7f, false, null, "NV0071", "O", null },
                    { 32, null, 66.1f, 1.71f, false, null, "NV0032", "A", null },
                    { 78, null, 61.1f, 1.77f, false, null, "NV0078", "B", null },
                    { 77, null, 60.1f, 1.76f, false, null, "NV0077", "A", null },
                    { 73, null, 57.1f, 1.72f, false, null, "NV0073", "B", null },
                    { 76, null, 56.1f, 1.75f, false, null, "NV0076", "O", null },
                    { 33, null, 57.1f, 1.72f, false, null, "NV0033", "B", null },
                    { 75, null, 59.1f, 1.74f, false, null, "NV0075", "AB", null },
                    { 74, null, 58.1f, 1.73f, false, null, "NV0074", "AB", null },
                    { 79, null, 57.1f, 1.78f, false, null, "NV0079", "AB", null },
                    { 97, null, 60.1f, 1.76f, false, null, "NV0097", "A", null },
                    { 84, null, 58.1f, 1.73f, false, null, "NV0084", "AB", null },
                    { 86, null, 56.1f, 1.75f, false, null, "NV0086", "O", null },
                    { 68, null, 61.1f, 1.77f, false, null, "NV0068", "B", null },
                    { 95, null, 59.1f, 1.74f, false, null, "NV0095", "AB", null },
                    { 28, null, 61.1f, 1.77f, false, null, "NV0028", "B", null },
                    { 94, null, 58.1f, 1.73f, false, null, "NV0094", "AB", null },
                    { 93, null, 57.1f, 1.72f, false, null, "NV0093", "B", null },
                    { 111, null, 50.1f, 1.7f, false, null, "NV0111", "O", null },
                    { 92, null, 66.1f, 1.71f, false, null, "NV0092", "A", null },
                    { 85, null, 59.1f, 1.74f, false, null, "NV0085", "AB", null },
                    { 69, null, 57.1f, 1.78f, false, null, "NV0069", "AB", null },
                    { 91, null, 50.1f, 1.7f, false, null, "NV0091", "O", null },
                    { 90, null, 58.1f, 1.79f, false, null, "NV0090", "AB", null },
                    { 89, null, 57.1f, 1.78f, false, null, "NV0089", "AB", null },
                    { 88, null, 61.1f, 1.77f, false, null, "NV0088", "B", null },
                    { 70, null, 58.1f, 1.79f, false, null, "NV0070", "AB", null },
                    { 30, null, 58.1f, 1.79f, false, null, "NV0030", "AB", null },
                    { 87, null, 60.1f, 1.76f, false, null, "NV0087", "A", null },
                    { 29, null, 57.1f, 1.78f, false, null, "NV0029", "AB", null },
                    { 177, null, 60.1f, 1.76f, false, null, "NV0177", "A", null }
                });

            migrationBuilder.InsertData(
                table: "YTe",
                columns: new[] { "id", "benhTat", "canNang", "chieuCao", "khuyetTat", "luuY", "maNhanVien", "nhomMau", "tinhTrangSucKhoe" },
                values: new object[,]
                {
                    { 124, null, 58.1f, 1.73f, false, null, "NV0124", "AB", null },
                    { 125, null, 59.1f, 1.74f, false, null, "NV0125", "AB", null },
                    { 53, null, 57.1f, 1.72f, false, null, "NV0053", "B", null },
                    { 162, null, 66.1f, 1.71f, false, null, "NV0162", "A", null },
                    { 12, null, 66.1f, 1.71f, false, null, "NV0012", "A", null },
                    { 161, null, 50.1f, 1.7f, false, null, "NV0161", "O", null },
                    { 160, null, 58.1f, 1.79f, false, null, "NV0160", "AB", null },
                    { 159, null, 57.1f, 1.78f, false, null, "NV0159", "AB", null },
                    { 158, null, 61.1f, 1.77f, false, null, "NV0158", "B", null },
                    { 163, null, 57.1f, 1.72f, false, null, "NV0163", "B", null },
                    { 54, null, 58.1f, 1.73f, false, null, "NV0054", "AB", null },
                    { 157, null, 60.1f, 1.76f, false, null, "NV0157", "A", null },
                    { 156, null, 56.1f, 1.75f, false, null, "NV0156", "O", null },
                    { 155, null, 59.1f, 1.74f, false, null, "NV0155", "AB", null },
                    { 154, null, 58.1f, 1.73f, false, null, "NV0154", "AB", null },
                    { 55, null, 59.1f, 1.74f, false, null, "NV0055", "AB", null },
                    { 14, null, 58.1f, 1.73f, false, null, "NV0014", "AB", null },
                    { 153, null, 57.1f, 1.72f, false, null, "NV0153", "B", null },
                    { 13, null, 57.1f, 1.72f, false, null, "NV0013", "B", null },
                    { 38, null, 61.1f, 1.77f, false, null, "NV0038", "B", null },
                    { 164, null, 58.1f, 1.73f, false, null, "NV0164", "AB", null },
                    { 11, null, 50.1f, 1.7f, false, null, "NV0011", "O", null },
                    { 176, null, 56.1f, 1.75f, false, null, "NV0176", "O", null },
                    { 175, null, 59.1f, 1.74f, false, null, "NV0175", "AB", null },
                    { 174, null, 58.1f, 1.73f, false, null, "NV0174", "AB", null },
                    { 9, null, 57.1f, 1.78f, false, null, "NV0009", "AB", null },
                    { 173, null, 57.1f, 1.72f, false, null, "NV0173", "B", null },
                    { 51, null, 50.1f, 1.7f, false, null, "NV0051", "O", null },
                    { 172, null, 66.1f, 1.71f, false, null, "NV0172", "A", null },
                    { 165, null, 59.1f, 1.74f, false, null, "NV0165", "AB", null },
                    { 39, null, 57.1f, 1.78f, false, null, "NV0039", "AB", null },
                    { 170, null, 58.1f, 1.79f, false, null, "NV0170", "AB", null },
                    { 10, null, 58.1f, 1.79f, false, null, "NV0010", "AB", null },
                    { 169, null, 57.1f, 1.78f, false, null, "NV0169", "AB", null },
                    { 168, null, 61.1f, 1.77f, false, null, "NV0168", "B", null },
                    { 52, null, 66.1f, 1.71f, false, null, "NV0052", "A", null },
                    { 167, null, 60.1f, 1.76f, false, null, "NV0167", "A", null },
                    { 166, null, 56.1f, 1.75f, false, null, "NV0166", "O", null },
                    { 171, null, 50.1f, 1.7f, false, null, "NV0171", "O", null },
                    { 21, null, 50.1f, 1.7f, false, null, "NV0021", "O", null },
                    { 152, null, 66.1f, 1.71f, false, null, "NV0152", "A", null },
                    { 150, null, 58.1f, 1.79f, false, null, "NV0150", "AB", null }
                });

            migrationBuilder.InsertData(
                table: "YTe",
                columns: new[] { "id", "benhTat", "canNang", "chieuCao", "khuyetTat", "luuY", "maNhanVien", "nhomMau", "tinhTrangSucKhoe" },
                values: new object[,]
                {
                    { 59, null, 57.1f, 1.78f, false, null, "NV0059", "AB", null },
                    { 37, null, 60.1f, 1.76f, false, null, "NV0037", "A", null },
                    { 135, null, 59.1f, 1.74f, false, null, "NV0135", "AB", null },
                    { 134, null, 58.1f, 1.73f, false, null, "NV0134", "AB", null },
                    { 19, null, 57.1f, 1.78f, false, null, "NV0019", "AB", null },
                    { 133, null, 57.1f, 1.72f, false, null, "NV0133", "B", null },
                    { 132, null, 66.1f, 1.71f, false, null, "NV0132", "A", null },
                    { 137, null, 60.1f, 1.76f, false, null, "NV0137", "A", null },
                    { 60, null, 58.1f, 1.79f, false, null, "NV0060", "AB", null },
                    { 130, null, 58.1f, 1.79f, false, null, "NV0130", "AB", null },
                    { 20, null, 58.1f, 1.79f, false, null, "NV0020", "AB", null },
                    { 129, null, 57.1f, 1.78f, false, null, "NV0129", "AB", null },
                    { 128, null, 61.1f, 1.77f, false, null, "NV0128", "B", null },
                    { 61, null, 50.1f, 1.7f, false, null, "NV0061", "O", null },
                    { 127, null, 60.1f, 1.76f, false, null, "NV0127", "A", null },
                    { 126, null, 56.1f, 1.75f, false, null, "NV0126", "O", null },
                    { 131, null, 50.1f, 1.7f, false, null, "NV0131", "O", null },
                    { 151, null, 50.1f, 1.7f, false, null, "NV0151", "O", null },
                    { 18, null, 61.1f, 1.77f, false, null, "NV0018", "B", null },
                    { 139, null, 57.1f, 1.78f, false, null, "NV0139", "AB", null },
                    { 15, null, 59.1f, 1.74f, false, null, "NV0015", "AB", null },
                    { 149, null, 57.1f, 1.78f, false, null, "NV0149", "AB", null },
                    { 56, null, 56.1f, 1.75f, false, null, "NV0056", "O", null },
                    { 148, null, 61.1f, 1.77f, false, null, "NV0148", "B", null },
                    { 147, null, 60.1f, 1.76f, false, null, "NV0147", "A", null },
                    { 146, null, 56.1f, 1.75f, false, null, "NV0146", "O", null },
                    { 16, null, 56.1f, 1.75f, false, null, "NV0016", "O", null },
                    { 138, null, 61.1f, 1.77f, false, null, "NV0138", "B", null },
                    { 145, null, 59.1f, 1.74f, false, null, "NV0145", "AB", null },
                    { 144, null, 58.1f, 1.73f, false, null, "NV0144", "AB", null },
                    { 143, null, 57.1f, 1.72f, false, null, "NV0143", "B", null },
                    { 142, null, 66.1f, 1.71f, false, null, "NV0142", "A", null },
                    { 17, null, 60.1f, 1.76f, false, null, "NV0017", "A", null },
                    { 141, null, 50.1f, 1.7f, false, null, "NV0141", "O", null },
                    { 58, null, 61.1f, 1.77f, false, null, "NV0058", "B", null },
                    { 140, null, 58.1f, 1.79f, false, null, "NV0140", "AB", null },
                    { 57, null, 60.1f, 1.76f, false, null, "NV0057", "A", null },
                    { 42, null, 66.1f, 1.71f, false, null, "NV0042", "A", null }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "bangChung", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 1, "1", null, null, null, 1, null, "HD01", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(6758), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, false },
                    { 140, "1", null, null, null, 1, null, "HD140", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9244), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 141, "1", null, null, null, 1, null, "HD141", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9251), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 142, "1", null, null, null, 1, null, "HD142", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9258), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 143, "1", null, null, null, 1, null, "HD143", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9265), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 144, "1", null, null, null, 1, null, "HD144", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9272), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 145, "1", null, null, null, 1, null, "HD145", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9283), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 146, "1", null, null, null, 1, null, "HD146", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9291), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 147, "1", null, null, null, 1, null, "HD147", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9297), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 148, "1", null, null, null, 1, null, "HD148", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 149, "1", null, null, null, 1, null, "HD149", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9312), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 150, "1", null, null, null, 1, null, "HD150", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9318), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 151, "1", null, null, null, 1, null, "HD151", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9325), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 152, "1", null, null, null, 1, null, "HD152", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9332), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 153, "1", null, null, null, 1, null, "HD153", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9339), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 154, "1", null, null, null, 1, null, "HD154", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9345), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 155, "1", null, null, null, 1, null, "HD155", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9352), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 156, "1", null, null, null, 1, null, "HD156", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9359), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 157, "1", null, null, null, 1, null, "HD157", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9366), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 158, "1", null, null, null, 1, null, "HD158", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9373), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 159, "1", null, null, null, 1, null, "HD159", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9379), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 160, "1", null, null, null, 1, null, "HD160", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9386), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 161, "1", null, null, null, 1, null, "HD161", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9393), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 162, "1", null, null, null, 1, null, "HD162", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9400), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 139, "1", null, null, null, 1, null, "HD139", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9237), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 138, "1", null, null, null, 1, null, "HD138", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9231), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 137, "1", null, null, null, 1, null, "HD137", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9224), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 136, "1", null, null, null, 1, null, "HD136", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9217), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 112, "1", null, null, null, 1, null, "HD112", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9051), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 113, "1", null, null, null, 1, null, "HD113", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9058), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 114, "1", null, null, null, 1, null, "HD114", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9066), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 115, "1", null, null, null, 1, null, "HD115", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9073), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 116, "1", null, null, null, 1, null, "HD116", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9080), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 117, "1", null, null, null, 1, null, "HD117", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9087), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 118, "1", null, null, null, 1, null, "HD118", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9095), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 119, "1", null, null, null, 1, null, "HD119", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9102), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 120, "1", null, null, null, 1, null, "HD120", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9108), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 121, "1", null, null, null, 1, null, "HD121", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9115), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 122, "1", null, null, null, 1, null, "HD122", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9122), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 163, "1", null, null, null, 1, null, "HD163", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9406), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 123, "1", null, null, null, 1, null, "HD123", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9129), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 125, "1", null, null, null, 1, null, "HD125", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9143), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "bangChung", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 126, "1", null, null, null, 1, null, "HD126", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9150), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 127, "1", null, null, null, 1, null, "HD127", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9156), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 128, "1", null, null, null, 1, null, "HD128", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9163), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 129, "1", null, null, null, 1, null, "HD129", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9170), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 130, "1", null, null, null, 1, null, "HD130", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9177), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 131, "1", null, null, null, 1, null, "HD131", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9183), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 132, "1", null, null, null, 1, null, "HD132", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9190), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 133, "1", null, null, null, 1, null, "HD133", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9197), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 134, "1", null, null, null, 1, null, "HD134", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9204), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 135, "1", null, null, null, 1, null, "HD135", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9210), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 124, "1", null, null, null, 1, null, "HD124", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9135), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 110, "1", null, null, null, 1, null, "HD110", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9037), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 164, "1", null, null, null, 1, null, "HD164", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9414), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 166, "1", null, null, null, 1, null, "HD166", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9427), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 195, "1", null, null, null, 1, null, "HD195", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9625), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 196, "1", null, null, null, 1, null, "HD196", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9637), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 197, "1", null, null, null, 1, null, "HD197", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9644), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 198, "1", null, null, null, 1, null, "HD198", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9651), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 199, "1", null, null, null, 1, null, "HD199", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9658), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 200, "1", null, null, null, 1, null, "HD200", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9665), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 201, "1", null, null, null, 1, null, "HD201", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9672), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 202, "1", null, null, null, 1, null, "HD202", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9678), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 203, "1", null, null, null, 1, null, "HD203", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9686), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 204, "1", null, null, null, 1, null, "HD204", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9693), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 205, "1", null, null, null, 1, null, "HD205", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9699), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 206, "1", null, null, null, 1, null, "HD206", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9706), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 207, "1", null, null, null, 1, null, "HD207", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9713), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 208, "1", null, null, null, 1, null, "HD208", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9719), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 209, "1", null, null, null, 1, null, "HD209", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9727), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 210, "1", null, null, null, 1, null, "HD210", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9733), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 211, "1", null, null, null, 1, null, "HD211", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9741), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 212, "1", null, null, null, 1, null, "HD212", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9748), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 213, "1", null, null, null, 1, null, "HD213", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9755), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 214, "1", null, null, null, 1, null, "HD214", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9762), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 215, "1", null, null, null, 1, null, "HD215", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9769), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 216, "1", null, null, null, 1, null, "HD216", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9776), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 217, "1", null, null, null, 1, null, "HD217", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9782), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 194, "1", null, null, null, 1, null, "HD194", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9618), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 193, "1", null, null, null, 1, null, "HD193", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9611), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 192, "1", null, null, null, 1, null, "HD192", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9605), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 191, "1", null, null, null, 1, null, "HD191", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9598), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 167, "1", null, null, null, 1, null, "HD167", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9434), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "bangChung", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 168, "1", null, null, null, 1, null, "HD168", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9441), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 169, "1", null, null, null, 1, null, "HD169", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9448), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 170, "1", null, null, null, 1, null, "HD170", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9455), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 171, "1", null, null, null, 1, null, "HD171", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9462), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 172, "1", null, null, null, 1, null, "HD172", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9468), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 173, "1", null, null, null, 1, null, "HD173", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9475), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 174, "1", null, null, null, 1, null, "HD174", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9482), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 175, "1", null, null, null, 1, null, "HD175", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9488), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 176, "1", null, null, null, 1, null, "HD176", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9495), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 177, "1", null, null, null, 1, null, "HD177", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9502), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 165, "1", null, null, null, 1, null, "HD165", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9420), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 178, "1", null, null, null, 1, null, "HD178", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9509), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 180, "1", null, null, null, 1, null, "HD180", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9522), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 181, "1", null, null, null, 1, null, "HD181", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9529), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 182, "1", null, null, null, 1, null, "HD182", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9536), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 183, "1", null, null, null, 1, null, "HD183", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9542), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 184, "1", null, null, null, 1, null, "HD184", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9550), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 185, "1", null, null, null, 1, null, "HD185", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9556), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 186, "1", null, null, null, 1, null, "HD186", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9563), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 187, "1", null, null, null, 1, null, "HD187", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9570), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 188, "1", null, null, null, 1, null, "HD188", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9577), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 189, "1", null, null, null, 1, null, "HD189", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9584), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 190, "1", null, null, null, 1, null, "HD190", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9591), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 179, "1", null, null, null, 1, null, "HD179", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9515), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 218, "1", null, null, null, 1, null, "HD218", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 109, "1", null, null, null, 1, null, "HD109", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9029), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 107, "1", null, null, null, 1, null, "HD107", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9015), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 30, "1", null, null, null, 1, null, "HD30", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8421), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 31, "1", null, null, null, 1, null, "HD31", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8429), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 32, "1", null, null, null, 1, null, "HD32", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8436), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 33, "1", null, null, null, 1, null, "HD33", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8443), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 34, "1", null, null, null, 1, null, "HD34", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8450), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 35, "1", null, null, null, 1, null, "HD35", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8456), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 36, "1", null, null, null, 1, null, "HD36", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8463), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 37, "1", null, null, null, 1, null, "HD37", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8516), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 38, "1", null, null, null, 1, null, "HD38", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8523), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 39, "1", null, null, null, 1, null, "HD39", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8531), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 40, "1", null, null, null, 1, null, "HD40", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8538), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 41, "1", null, null, null, 1, null, "HD41", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8545), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 42, "1", null, null, null, 1, null, "HD42", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8552), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 43, "1", null, null, null, 1, null, "HD43", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8566), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 44, "1", null, null, null, 1, null, "HD44", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8574), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "bangChung", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 45, "1", null, null, null, 1, null, "HD45", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8581), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 46, "1", null, null, null, 1, null, "HD46", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8588), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 47, "1", null, null, null, 1, null, "HD47", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8595), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 48, "1", null, null, null, 1, null, "HD48", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8602), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 49, "1", null, null, null, 1, null, "HD49", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8608), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 50, "1", null, null, null, 1, null, "HD50", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8616), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 51, "1", null, null, null, 1, null, "HD51", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8623), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 52, "1", null, null, null, 1, null, "HD52", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8630), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 29, "1", null, null, null, 1, null, "HD29", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8414), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 28, "1", null, null, null, 1, null, "HD28", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8408), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 27, "1", null, null, null, 1, null, "HD27", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8401), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 26, "1", null, null, null, 1, null, "HD26", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8394), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 2, "1", null, null, null, 1, null, "HD01", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8172), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 3, "1", null, null, null, 1, null, "HD03", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8227), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 4, "1", null, null, null, 1, null, "HD04", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8237), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 5, "1", null, null, null, 1, null, "HD05", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8244), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 6, "1", null, null, null, 1, null, "HD06", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8252), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 7, "1", null, null, null, 1, null, "HD07", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8259), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 8, "1", null, null, null, 1, null, "HD08", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8267), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 9, "1", null, null, null, 1, null, "HD09", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8274), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 10, "1", null, null, null, 1, null, "HD10", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8281), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 11, "1", null, null, null, 1, null, "HD11", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8288), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 12, "1", null, null, null, 1, null, "HD12", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8295), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 53, "1", null, null, null, 1, null, "HD53", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8637), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 13, "1", null, null, null, 1, null, "HD13", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8303), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 15, "1", null, null, null, 1, null, "HD15", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8318), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 16, "1", null, null, null, 1, null, "HD16", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8325), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 17, "1", null, null, null, 1, null, "HD17", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8332), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 18, "1", null, null, null, 1, null, "HD18", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8339), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 19, "1", null, null, null, 1, null, "HD19", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8345), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 20, "1", null, null, null, 1, null, "HD20", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8352), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 21, "1", null, null, null, 1, null, "HD21", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8359), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 22, "1", null, null, null, 1, null, "HD22", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8366), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 23, "1", null, null, null, 1, null, "HD23", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8374), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 24, "1", null, null, null, 1, null, "HD24", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8380), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 25, "1", null, null, null, 1, null, "HD25", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8387), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 14, "1", null, null, null, 1, null, "HD14", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8310), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 108, "1", null, null, null, 1, null, "HD108", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9022), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 54, "1", null, null, null, 1, null, "HD54", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8643), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 56, "1", null, null, null, 1, null, "HD56", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8657), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 85, "1", null, null, null, 1, null, "HD85", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8857), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 86, "1", null, null, null, 1, null, "HD86", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8865), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "bangChung", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 87, "1", null, null, null, 1, null, "HD87", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8872), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 88, "1", null, null, null, 1, null, "HD88", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8879), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 89, "1", null, null, null, 1, null, "HD89", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8886), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 90, "1", null, null, null, 1, null, "HD90", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8893), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 91, "1", null, null, null, 1, null, "HD91", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8900), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 92, "1", null, null, null, 1, null, "HD92", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8907), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 111, "1", null, null, null, 1, null, "HD111", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9044), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 93, "1", null, null, null, 1, null, "HD93", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8914), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 94, "1", null, null, null, 1, null, "HD94", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8925), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 95, "1", null, null, null, 1, null, "HD95", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8933), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 96, "1", null, null, null, 1, null, "HD96", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8940), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 97, "1", null, null, null, 1, null, "HD97", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8946), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 98, "1", null, null, null, 1, null, "HD98", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8953), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 99, "1", null, null, null, 1, null, "HD99", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8960), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 100, "1", null, null, null, 1, null, "HD100", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 101, "1", null, null, null, 1, null, "HD101", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8974), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 102, "1", null, null, null, 1, null, "HD102", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8981), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 103, "1", null, null, null, 1, null, "HD103", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8988), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 104, "1", null, null, null, 1, null, "HD104", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8994), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 105, "1", null, null, null, 1, null, "HD105", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9001), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 106, "1", null, null, null, 1, null, "HD106", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9008), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 84, "1", null, null, null, 1, null, "HD84", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8851), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 83, "1", null, null, null, 1, null, "HD83", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8844), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 82, "1", null, null, null, 1, null, "HD82", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8837), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 81, "1", null, null, null, 1, null, "HD81", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8830), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 57, "1", null, null, null, 1, null, "HD57", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8664), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 58, "1", null, null, null, 1, null, "HD58", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8671), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 59, "1", null, null, null, 1, null, "HD59", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8678), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 60, "1", null, null, null, 1, null, "HD60", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8685), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 61, "1", null, null, null, 1, null, "HD61", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8692), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 62, "1", null, null, null, 1, null, "HD62", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8699), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 63, "1", null, null, null, 1, null, "HD63", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8706), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 64, "1", null, null, null, 1, null, "HD64", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8713), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 65, "1", null, null, null, 1, null, "HD65", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8719), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 66, "1", null, null, null, 1, null, "HD66", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8726), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 67, "1", null, null, null, 1, null, "HD67", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8733), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 55, "1", null, null, null, 1, null, "HD55", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8650), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 68, "1", null, null, null, 1, null, "HD68", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8740), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 70, "1", null, null, null, 1, null, "HD70", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8755), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 71, "1", null, null, null, 1, null, "HD71", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8762), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 72, "1", null, null, null, 1, null, "HD72", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 73, "1", null, null, null, 1, null, "HD73", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8776), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "bangChung", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 74, "1", null, null, null, 1, null, "HD74", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8783), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 75, "1", null, null, null, 1, null, "HD75", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8790), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 76, "1", null, null, null, 1, null, "HD76", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8796), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 77, "1", null, null, null, 1, null, "HD77", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8803), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 78, "1", null, null, null, 1, null, "HD78", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8810), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 79, "1", null, null, null, 1, null, "HD79", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8817), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 80, "1", null, null, null, 1, null, "HD80", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8824), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 69, "1", null, null, null, 1, null, "HD69", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(8747), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true },
                    { 219, "1", null, null, null, 1, null, "HD219", new DateTime(2021, 11, 14, 23, 32, 48, 528, DateTimeKind.Local).AddTicks(9796), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, true }
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
                name: "IX_DieuChuyen_idPhongBan",
                table: "DieuChuyen",
                column: "idPhongBan");

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
                name: "IX_Luong_idNhomLuong",
                table: "Luong",
                column: "idNhomLuong");

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
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

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
                name: "TrinhDoVanHoa");

            migrationBuilder.DropTable(
                name: "YTe");

            migrationBuilder.DropTable(
                name: "DanhMucChucVu");

            migrationBuilder.DropTable(
                name: "DanhMucTinhChatLaoDong");

            migrationBuilder.DropTable(
                name: "DanhMucKhenThuongKyLuat");

            migrationBuilder.DropTable(
                name: "DanhMucNhomLuong");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "DanhMucNgoaiNgu");

            migrationBuilder.DropTable(
                name: "DanhMucNguoiThan");

            migrationBuilder.DropTable(
                name: "DanhMucChuyenMon");

            migrationBuilder.DropTable(
                name: "DanhMucHinhThucDaoTao");

            migrationBuilder.DropTable(
                name: "DanhMucTrinhDo");

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
                name: "danhMucTinhChatLaoDongs");

            migrationBuilder.DropTable(
                name: "DanhMucTonGiao");
        }
    }
}
