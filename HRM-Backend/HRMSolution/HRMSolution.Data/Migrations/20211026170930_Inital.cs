using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class Inital : Migration
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
                    hoTen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "LichSu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    thaoTac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hanhDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngayThucHien = table.Column<DateTime>(type: "datetime", nullable: false)
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
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    facebook = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    skype = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    maSoThue = table.Column<int>(type: "int", nullable: true),
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
                    bhxh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    bhyt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    atm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trangThaiLaoDong = table.Column<bool>(type: "bit", nullable: false),
                    ngayNghiViec = table.Column<DateTime>(type: "datetime", nullable: true),
                    lyDoNghiViec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_DieuChuyen_DanhMucPhongBan_idPhongBan",
                        column: x => x.idPhongBan,
                        principalTable: "DanhMucPhongBan",
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
                    hopDongTuNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    hopDongDenNgay = table.Column<DateTime>(type: "datetime", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    trangThai = table.Column<bool>(type: "bit", nullable: false),
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
                    lsbt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lsbt_biBatDiTu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    lsbt_thamGiaChinhTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    lsbt_thanNhanNuocNgoai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    lsbt_maNhanVien = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuBanThan", x => x.lsbt_id);
                    table.ForeignKey(
                        name: "FK_LichSuBanThan_NhanVien_lsbt_maNhanVien",
                        column: x => x.lsbt_maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LienHeKhanCap",
                columns: table => new
                {
                    lhkc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lhkc_hoTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lhkc_quanHe = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lhkc_dienThoai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lhkc_email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    lhkc_diaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    lhkc_maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHeKhanCap", x => x.lhkc_id);
                    table.ForeignKey(
                        name: "FK_LienHeKhanCap_NhanVien_lhkc_maNhanVien",
                        column: x => x.lhkc_maNhanVien,
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
                    yt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yt_nhomMau = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    yt_chieuCao = table.Column<float>(type: "real", nullable: true),
                    yt_canNang = table.Column<float>(type: "real", nullable: true),
                    yt_tinhTrangSucKhoe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    yt_benhTat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    yt_luuY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    yt_khuyetTat = table.Column<bool>(type: "bit", nullable: true),
                    yt_maNhanVien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTe", x => x.yt_id);
                    table.ForeignKey(
                        name: "FK_YTe_NhanVien_yt_maNhanVien",
                        column: x => x.yt_maNhanVien,
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
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "391d8d69-0a46-401c-b5c4-2f493d1fe6d4", "admin", "admin", "Administrator role" },
                    { new Guid("30c6f17d-e44f-4e5d-9bf9-1bd98c377cec"), "af5be8f8-0211-402d-ad89-c324fd965003", "user", "user", "User role" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") },
                    { new Guid("30c6f17d-e44f-4e5d-9bf9-1bd98c377cec"), new Guid("1db26eb2-1870-4129-f60a-08d9978ff76b") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "hoTen", "ngaySinh" },
                values: new object[,]
                {
                    { new Guid("1db26eb2-1870-4129-f60a-08d9978ff76b"), 0, "6aab07ec-7c96-482a-9719-b94034bab1ab", "hieudongtru@gmail.com", true, false, null, "hieudongtru@gmail.com", "user1", "AQAAAAEAACcQAAAAEEjnyULD44ACIXOB0QbYc89enZtM0wRyprwAVo54z3J52FFGcq0DgnkccmHP1PI/Bw==", "01231243", false, "", false, "user1", "Đào Ngọc Hưởng", new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "ce308986-eb30-4059-8fdf-7b84fb5ff563", "hieudongtru@gmail.com", true, false, null, "hieudongtru@gmail.com", "admin", "AQAAAAEAACcQAAAAEAlyLFSrvHFDw9HEo2kfNTqv+oXIwigViGj2h4febWkdZdllSJ9/TFzzX8w/11sDzA==", "01231243", false, "", false, "admin", "Mai Trung Hiếu", new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                    { 1, "CV01", 100000f, "Nhân viên" },
                    { 2, "CV02", 200000f, "Trưởng Phòng" },
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
                    { 4, "CM04", "Kế toán – kiểm toán" },
                    { 5, "CM05", "Kinh Tế" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucDanToc",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[,]
                {
                    { 3, "Thái" },
                    { 2, "Mông" },
                    { 1, "kinh" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucHinhThucDaoTao",
                columns: new[] { "id", "tenHinhThuc" },
                values: new object[,]
                {
                    { 2, "Cao đẳng" },
                    { 1, "Đại học" }
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
                    { 1, "Thưởng Nhân viên suất xác tháng", "Khen thưởng" },
                    { 2, "Thưởng Nhân viên suất xác năm", "Khen thưởng" },
                    { 3, "Thưởng Nhân viên suất xác quý", "Khen thưởng" },
                    { 4, "Phạt Nhân viên kém nhất tháng", "Kỷ luật" },
                    { 5, "Phạt Nhân viên kém nhất quý", "Kỷ luật" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiHopDong",
                columns: new[] { "id", "maLoaiHopDong", "tenLoaiHopDong" },
                values: new object[,]
                {
                    { 3, "MHD03", "Hợp đồng vô thời hạn" },
                    { 1, "MHD01", "Hợp đồng một năm" },
                    { 2, "MHD02", "Hợp đồng ba năm" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNgachCongChuc",
                columns: new[] { "id", "tenNgach" },
                values: new object[,]
                {
                    { 3, "Loại C" },
                    { 1, "Loại A" },
                    { 2, "Loại B" },
                    { 4, "Loại D" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNgoaiNgu",
                columns: new[] { "id", "tenDanhMuc" },
                values: new object[,]
                {
                    { 2, "Tiếng Trung Quốc" },
                    { 1, "Tiếng Anh" },
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
                table: "DanhMucNhomLuong",
                columns: new[] { "id", "maNhomLuong", "tenNhomLuong" },
                values: new object[,]
                {
                    { 1, "MNL01", "Nhóm 1" },
                    { 2, "MNL02", "Nhóm 2" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNhomLuong",
                columns: new[] { "id", "maNhomLuong", "tenNhomLuong" },
                values: new object[] { 3, "MNL03", "Nhóm 3" });

            migrationBuilder.InsertData(
                table: "DanhMucPhongBan",
                columns: new[] { "id", "maPhongBan", "tenPhongBan" },
                values: new object[,]
                {
                    { 5, "PB05", "5" },
                    { 3, "PB03", "3" },
                    { 1, "PB01", "1" },
                    { 4, "PB04", "4" },
                    { 2, "PB02", "2" }
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
                    { "NV0072", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Dương Phúc Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0073", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Minh Thư", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0074", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Trung Minh Trí", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0075", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Quốc Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0076", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Hữu Minh Tường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0081", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0078", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hùng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0079", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Ngọc Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0080", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Mai Tùng Bách", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0071", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trường Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0077", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Thị Phương Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0070", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Thanh Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0060", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0068", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Trần Trung Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0067", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phú Hải Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0066", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán", null, "0961441404", "02466666", null, null, null, true, null, "Đào Tuấn Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0065", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Lê Tất Hoàng Phát", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0064", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Đặng Gia Như", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0063", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Uyên Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0062", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Khánh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0061", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Minh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0082", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trần Bình", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0059", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0058", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "	Đỗ Hải Nam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0069", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Thành Tài", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0083", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Điệp Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0111", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Đức Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0085", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng An Đông", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0108", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Nguyễn Thị Bích Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0107", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trần Tuấn Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0106", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Phạm Thị Phương Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0105", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Quang Long", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0104", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hoàng Tùng Lâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0103", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0102", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0101", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0100", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Nam Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0099", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0098", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lê Nguyễn Diệu Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0084", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Văn Đạt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0097", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tiến Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0095", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0094", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thu Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0093", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thanh Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0057", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0092", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Phương Hoa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0091", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Sỹ Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0090", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Ngọc Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0089", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "	Lưu Ngọc Hiền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0088", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Gia Hân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0087", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phí Vũ Trí Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0086", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0096", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0056", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0045", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0054", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Nhật Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0024", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0023", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0022", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0021", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0020", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0019", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0018", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0017", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0016", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0015", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0014", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0025", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0013", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0011", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0010", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0009", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0008", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0007", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0006", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0005", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0004", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0003", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0002", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0001", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Đại học FPT", null, "Điện Biên", 1, true, false },
                    { "NV0012", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0026", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Khoa Minh Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0027", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Hiệp Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0028", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Mạnh Hùng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0053", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0052", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0051", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hà Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0050", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0049", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đinh Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0048", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Bảo Liên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0047", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quốc Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0046", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0109", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0044", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0043", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Thiên Trường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0042", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Thành Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0041", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Huyền Thi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0040", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0039", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tô Diệu Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0038", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0037", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0036", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Thành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0035", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0034", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0033", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0032", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0031", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0030", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0029", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, false, false },
                    { "NV0055", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trọng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false },
                    { "NV0110", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Đại học FPT", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 1, "Không", 1, 1, "NV0001", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(4841), 1, false },
                    { 2, "Ahihi", 1, 2, "NV0001", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(6679), 2, false },
                    { 3, "Ahihi", 1, 3, "NV0001", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(6735), 3, true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD05", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(622), 1, 1, "NV0005", true },
                    { "HD06", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(630), 1, 1, "NV0006", true },
                    { "HD04", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(613), 1, 1, "NV0004", true },
                    { "HD03", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(601), 1, 1, "NV0003", true },
                    { "HD02", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(516), 1, 1, "NV0001", true },
                    { "HD01", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 27, 0, 9, 28, 666, DateTimeKind.Local).AddTicks(8710), 1, 1, "NV0001", false }
                });

            migrationBuilder.InsertData(
                table: "KhenThuongKyLuat",
                columns: new[] { "id", "anh", "idDanhMucKhenThuong", "loai", "lyDo", "maNhanVien", "noiDung" },
                values: new object[,]
                {
                    { 10, null, 1, false, null, "NV0056", "Thưởng nhân viên suất sắc" },
                    { 11, null, 1, true, null, "NV0081", "Thưởng nhân viên suất sắc" },
                    { 7, null, 1, true, null, "NV0023", "Thưởng nhân viên suất sắc" },
                    { 9, null, 1, true, null, "NV0022", "Thưởng nhân viên suất sắc" },
                    { 4, null, 1, true, null, "NV0021", "Thưởng nhân viên suất sắc" },
                    { 3, null, 1, true, null, "NV0009", "Thưởng nhân viên suất sắc" },
                    { 6, null, 1, true, null, "NV0078", "Thưởng nhân viên suất sắc" },
                    { 5, null, 1, false, null, "NV0035", "Thưởng nhân viên suất sắc" },
                    { 8, null, 1, false, null, "NV0099", "Thưởng nhân viên suất sắc" },
                    { 12, null, 1, false, null, "NV0091", "Thưởng nhân viên suất sắc" },
                    { 2, null, 1, false, null, "NV0001", "Thưởng nhân viên suất sắc" },
                    { 1, null, 1, true, null, "NV0001", "Thưởng nhân viên suất sắc" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[] { 1, "Không", "NV0001", "Không", "Không" });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "lhkc_id", "lhkc_diaChi", "lhkc_dienThoai", "lhkc_email", "lhkc_hoTen", "lhkc_maNhanVien", "lhkc_quanHe" },
                values: new object[] { 1, "Hà Nội", "0123434324", null, "Mai Trung Hiếu", "NV0001", "Bạn" });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 2, 1, "NV0001", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Đại học Bách Khoa", "khá" },
                    { 1, 1, "NV0001", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Đại học FPT", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NguoiThan",
                columns: new[] { "id", "diaChi", "dienThoai", "gioiTinh", "idDanhMucNguoiThan", "khac", "maNhanVien", "ngaySinh", "ngheNghiep", "quanHe", "tenNguoiThan" },
                values: new object[,]
                {
                    { 2, "điện biên", "0914637668", true, 1, null, "NV0001", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Mai Trung Hiếu" },
                    { 1, "điện biên", "0914637668", true, 1, null, "NV0001", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Đăng Hải" }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoVanHoa",
                columns: new[] { "id", "denThoiGian", "idChuyenMon", "idHinhThucDaoTao", "idTrinhDo", "maNhanVien", "tenTruong", "tuThoiGian" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 1, "NV0001", "Đại Học FPT", null },
                    { 2, null, 1, 1, 1, "NV0001", "Đại Học Bách Khoa", null }
                });

            migrationBuilder.InsertData(
                table: "YTe",
                columns: new[] { "yt_id", "yt_benhTat", "yt_canNang", "yt_chieuCao", "yt_khuyetTat", "yt_luuY", "yt_maNhanVien", "yt_nhomMau", "yt_tinhTrangSucKhoe" },
                values: new object[] { 1, null, 56.1f, 1.73f, null, null, "NV0001", "O", null });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 1, "1", null, null, 1, null, "HD01", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(2706), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, false },
                    { 2, "1", null, null, 1, null, "HD01", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(3746), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 3, "1", null, null, 1, null, "HD03", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(3800), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 4, "1", null, null, 1, null, "HD04", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(3810), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 5, "1", null, null, 1, null, "HD05", new DateTime(2021, 10, 27, 0, 9, 28, 668, DateTimeKind.Local).AddTicks(3818), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
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
                name: "IX_LichSuBanThan_lsbt_maNhanVien",
                table: "LichSuBanThan",
                column: "lsbt_maNhanVien",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LienHeKhanCap_lhkc_maNhanVien",
                table: "LienHeKhanCap",
                column: "lhkc_maNhanVien",
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
                name: "IX_YTe_yt_maNhanVien",
                table: "YTe",
                column: "yt_maNhanVien",
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
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TrinhDoVanHoa");

            migrationBuilder.DropTable(
                name: "YTe");

            migrationBuilder.DropTable(
                name: "DanhMucChucVu");

            migrationBuilder.DropTable(
                name: "DanhMucPhongBan");

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
