using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMSolution.Data.Migrations
{
    public partial class xxxxxxxxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anh", x => x.id);
                });

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
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "a524723c-2f98-4c84-8ee6-982055e04cce", "admin", "admin", "Administrator role" },
                    { new Guid("30c6f17d-e44f-4e5d-9bf9-1bd98c377cec"), "3147b9a3-ae97-4e5d-a0ac-9409783b326b", "user", "user", "User role" }
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
                    { new Guid("1db26eb2-1870-4129-f60a-08d9978ff76b"), 0, "5f073822-561b-4c20-9043-0ecbf6073923", "hieudongtru@gmail.com", true, false, null, "hieudongtru@gmail.com", "user1", "AQAAAAEAACcQAAAAEBUep6LmOjJaZQIRwbO8h+UcwsnR2owRS0ERjLA/N4V0tAyu6R5edDDAFh4UpDpiJQ==", "01231243", false, "", false, "user1", "Đào Ngọc Hưởng", new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "a2a233e0-7314-4c5b-8dcd-bb4fcd941ae7", "hieudongtru@gmail.com", true, false, null, "hieudongtru@gmail.com", "admin", "AQAAAAEAACcQAAAAEATP/8jUZX69jucCSEK0fB6Td4FsgLeqDGHscV9j7uLhiLMcEybpm79seAjW/AgedA==", "01231243", false, "", false, "admin", "Mai Trung Hiếu", new DateTime(1998, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                    { 16, 4, "T015", "Tổ 15" },
                    { 17, 4, "T016", "Tổ 16" },
                    { 20, 5, "T019", "Tổ 19" },
                    { 15, 4, "T014", "Tổ 14" },
                    { 14, 4, "T013", "Tổ 13" },
                    { 13, 3, "T012", "Tổ 12" },
                    { 12, 3, "T011", "Tổ 11" },
                    { 11, 3, "T010", "Tổ 10" },
                    { 10, 3, "T09", "Tổ 9" },
                    { 18, 5, "T017", "Tổ 17" },
                    { 9, 2, "T08", "Tổ 8" },
                    { 7, 2, "T06", "Tổ 6" },
                    { 6, 2, "T06", "Tổ 5" },
                    { 5, 1, "T05", "Tổ 4" },
                    { 4, 1, "T04", "Tổ 3" },
                    { 3, 1, "T03", "Tổ 2" },
                    { 2, 1, "T02", "Tổ 1" },
                    { 1, 1, "T01", "Tổ 1" },
                    { 21, 5, "T020", "Tổ 20" },
                    { 8, 2, "T07", "Tổ 7" },
                    { 19, 5, "T018", "Tổ 18" }
                });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 11, 1, "NV00010", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 101, 1, "NV00100", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0342", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 6, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0341", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 7, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0340", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 10, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0339", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 4, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0338", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 5, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0337", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0336", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0335", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 6, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0334", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 9, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0333", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 6, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0332", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 6, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0331", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 6, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false },
                    { "NV0330", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 7, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0318", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lê Nguyễn Diệu Hương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 1, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0328", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Nguyễn Thị Bích Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 8, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0327", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trần Tuấn Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 10, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0326", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Phạm Thị Phương Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 10, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0325", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Quang Long", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 12, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0324", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Hoàng Tùng Lâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 7, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0323", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 5, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0322", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 2, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0321", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 7, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0320", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Nam Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 11, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0319", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 9, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0343", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1977, 6, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0317", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tiến Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 5, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0316", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 12, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0329", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 6, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0344", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0355", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 2, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0315", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 6, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0354", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 3, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0353", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0352", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0351", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 3, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0350", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 1, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0349", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 4, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0348", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 9, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0347", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 5, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0345", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 2, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0314", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thu Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0302", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trần Bình", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 4, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0255", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 3, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, true }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0254", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 9, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0253", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 12, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0303", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Điệp Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 4, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0374", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
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
                    { "NV0284", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Đặng Gia Như", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 6, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0297", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Thị Phương Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0375", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 1, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0387", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 4, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
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
                    { "NV0470", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 9, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0471", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 4, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0499", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 11, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
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
                    { "NV0404", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Bùi Trung Minh Trí", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 9, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0403", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Minh Thư", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 1, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0402", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kiểm toán nội bộ", null, "0961441404", "02466666", null, null, null, true, null, "Dương Phúc Thịnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1980, 7, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0252", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 6, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0386", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 12, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0433", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Diệp Lam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 4, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0432", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hồ Nguyễn Minh Khuê", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0431", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đinh Ngọc Khánh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 5, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0239", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 3, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0249", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0090", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Ngọc Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 9, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0089", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "	Lưu Ngọc Hiền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 7, 8, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0088", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Gia Hân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0087", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Phí Vũ Trí Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0086", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0085", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng An Đông", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0084", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Văn Đạt", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 4, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0083", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Điệp Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 2, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0065", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Lê Tất Hoàng Phát", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0064", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Đặng Gia Như", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0091", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Sỹ Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0092", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Phương Hoa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0111", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, true, null, "Vũ Đức Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0093", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thanh Huyền", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0121", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hoài Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0120", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðức Tường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0119", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Thế Phương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 24, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0118", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hữu Canh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0117", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phước An", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0116", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðức Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0115", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hùng Phong", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0114", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Kiến Ðức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0113", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quang Danh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0112", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Ðình Sang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0221", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Phúc Tâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false },
                    { "NV0110", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "	Lê Quỳnh Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0109", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Lê Trung Nguyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0063", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Uyên Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1988, 10, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0062", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Khánh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 9, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0060", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1983, 7, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0027", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Hữu Hiệp Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 1, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0026", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Khoa Minh Hoàng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0025", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Xuân Hòa", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 11, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0024", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Lê Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0023", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thị Ngân Hà", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0022", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Hương Giang", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 8, 30, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0021", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mạc Trung Đức", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 7, 5, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0020", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 6, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2012, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, true },
                    { "NV0019", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thái Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 5, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0018", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2029, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1969, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0017", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Người bị địch bắt tù, đày", "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, true, false, null, null, null, null, new DateTime(2021, 3, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2039, 3, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1999, 3, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0016", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2036, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0015", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 2, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2033, 2, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 2, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0014", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Khắc Việt Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 1, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2033, 1, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 1, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0013", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2032, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0012", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2031, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0011", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2041, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 3, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0010", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2029, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0009", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2038, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0008", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2000, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0007", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 2, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2028, 2, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1968, 2, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0006", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2033, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0005", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Thái Bình", null, "Thái Bình", null, null, false, "Thái Bình", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0004", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0003", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0002", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0001", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đào Ngọc Hưởng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2016, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 4, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Điện Biên", null, "Hưng Yên", null, null, false, "Hưng Yên", "Việt Nam", null, "Hà Nội", null, "Điện Biên", 1, true, false },
                    { "NV0028", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Mạnh Hùng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 2, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0029", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Vũ Gia Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1997, 3, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0030", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Trần Tuấn Hưng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 4, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0031", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Gia Minh", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, false, true },
                    { "NV0059", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Bảo Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0058", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "	Đỗ Hải Nam", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 5, 27, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0057", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Mai Hoàng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 5, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0056", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Ngô Gia Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 4, 22, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0055", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trọng Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 3, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0054", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Nhật Mai", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 3, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0053", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 2, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0052", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 1, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0051", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hà Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 12, 29, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0050", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 12, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0049", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đinh Thùy Linh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0048", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Bảo Liên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 10, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0047", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", "Nhà có người là thương binh", "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Quốc Huy", 1, 1, 1, 1, true, true, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1986, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 9, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1993, 4, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, true, "Hà Nội", "Việt Nam", null, "Hà Nội", "Thương binh loại B", "Hà Nội", 1, true, false },
                    { "NV0061", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Minh Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 8, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0046", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, true, null, "Trần Đức Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 8, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0044", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Lê Khánh Vy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 6, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0043", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Trịnh Thiên Trường", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1985, 5, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0042", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Thành Trung", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 4, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0041", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đặng Huyền Thi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0040", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Vũ Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1982, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0039", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Tô Diệu Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0038", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Nguyễn Hương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 12, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0037", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Phương Thảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0036", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Thành", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 10, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0035", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đoàn Hoàng Sơn", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 9, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0034", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đàm Yến Nhi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1992, 8, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0033", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Quang Ngọc", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 7, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0032", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Hoàng Mỹ", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 6, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0045", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Vũ Ngọc Diệp", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 7, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0200", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "024666661", null, null, null, true, null, "Hồ Việt Huy", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 16, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0199", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "024666662", null, null, null, false, null, "Phạm Thanh Tâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0198", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Telesales", null, "0961441404", "024666663", null, null, null, false, null, "Ngô Ngọc Quỳnh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0240", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần An Dương", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1989, 9, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0500", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Trần Kim Ngân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1974, 11, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0238", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Tiến Dũng", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 12, 18, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0237", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Tăng Phương Chi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1976, 8, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0236", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Trần Thị Minh Châu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1978, 2, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0188", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên vận hành", null, "0961441404", "02466666", null, null, null, true, null, "Phan Thiện Sinh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1991, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0235", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đỗ Hoàng Gia Bảo", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1972, 11, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0233", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Phạm Thị Hiền Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1984, 1, 10, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0232", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Phạm Hoàng Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1975, 1, 12, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0231", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lưu Trang Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 3, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0230", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hoàng Đức Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1993, 1, 28, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0229", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Đặng Tuấn Anh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1986, 3, 1, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0228", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Lý Trà My", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1973, 8, 17, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0227", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đình Chính", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1979, 11, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0226", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1971, 2, 2, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0225", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Đăng Hải", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1981, 10, 11, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0224", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Nguyễn Công Minh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1990, 8, 19, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0223", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Hà Nhật Dân", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1970, 12, 15, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0222", "/user-content/87b55866-cc4f-48a9-8a94-010d7c9197ce.jpg", null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "Mai Trung Hiếu", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1987, 9, 14, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { "NV0132", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, false, null, "Hà Hồng Quế", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 1, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0131", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "0961441404", "02466666", null, null, null, true, null, "ồ Minh Tiế", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
                    { "NV0130", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Nhân viên kinh doanh", null, "09614414042", "024666665", null, null, null, false, null, "Nguyễn Nguyên Khôi", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1998, 3, 20, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
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
                    { "NV0161", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Hoàng Bảo Trâm", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1996, 6, 26, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "maNhanVien", "anh", "atm", "bhxh", "bhyt", "cccd", "chucVuHienTai", "coQuanTuyenDung", "conChinhSach", "congViecChinh", "danhHieuCaoNhat", "diDong", "dienThoai", "dienThoaiKhac", "email", "facebook", "gioiTinh", "hoChieu", "hoTen", "idDanToc", "idDanhMucHonNhan", "idNgachCongChuc", "idTonGiao", "laConChinhSach", "laThuongBinh", "lyDoNghiViec", "maSoThue", "ngachCongChucNoiDung", "nganHang", "ngayCapCCCD", "ngayCapHoChieu", "ngayChinhThuc", "ngayHetHanCCCD", "ngayHetHanHoChieu", "ngayNghiViec", "ngayNhapNgu", "ngaySinh", "ngayThuViec", "ngayTuyenDung", "ngayVaoBan", "ngayVaoDang", "ngayVaoDangChinhThuc", "ngayVaoDoan", "ngayXuatNgu", "ngheNghiep", "noiCapCCCD", "noiCapHoChieu", "noiSinh", "noiThamGia", "quanHamCaoNhat", "quanNhan", "queQuan", "quocTich", "skype", "tamTru", "thuongBinh", "thuongTru", "tinhChatLaoDong", "trangThaiLaoDong", "vaoDang" },
                values: new object[,]
                {
                    { "NV0160", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Đỗ Mai Thanh", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1995, 5, 25, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, false, false },
                    { "NV0159", null, null, null, null, "040828462", "Nhân Viên", "Phát Đạt", null, "Chuyên viên phân tích tài chính", null, "0961441404", "02466666", null, null, null, false, null, "Bùi Mai Quyên", 1, 1, 1, 1, false, false, null, null, null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2021, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1994, 4, 23, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, "Sinh viên", "Hà Nội", null, "Hà Nội", null, null, false, "Hà Nội", "Việt Nam", null, "Hà Nội", null, "Hà Nội", 1, true, false },
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
                    { 1, "Không", 1, 1, "NV0001", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(6740), 1, false },
                    { 143, "Ahihi", 1, 2, "NV0141", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1086), 8, true },
                    { 47, "Ahihi", 1, 1, "NV0045", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(530), 2, true },
                    { 142, "Ahihi", 1, 2, "NV0140", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1081), 8, true },
                    { 141, "Ahihi", 1, 2, "NV0139", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1074), 7, true },
                    { 48, "Ahihi", 1, 1, "NV0046", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(533), 2, true },
                    { 140, "Ahihi", 1, 2, "NV0138", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1070), 7, true },
                    { 49, "Ahihi", 1, 1, "NV0047", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(535), 2, true },
                    { 139, "Ahihi", 1, 2, "NV0137", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1066), 7, true },
                    { 138, "Ahihi", 1, 2, "NV0136", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1059), 7, true },
                    { 50, "Ahihi", 1, 1, "NV0048", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(537), 2, true },
                    { 137, "Ahihi", 1, 2, "NV0135", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1056), 7, true },
                    { 51, "Ahihi", 1, 1, "NV0049", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(540), 2, true },
                    { 136, "Ahihi", 1, 2, "NV0134", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1049), 7, true },
                    { 135, "Ahihi", 1, 2, "NV0133", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1045), 7, true },
                    { 52, "Ahihi", 1, 1, "NV0050", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(542), 2, true },
                    { 134, "Ahihi", 1, 2, "NV0132", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1041), 7, true },
                    { 53, "Ahihi", 1, 1, "NV0051", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(544), 2, true },
                    { 133, "Ahihi", 1, 2, "NV0131", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1036), 7, true },
                    { 132, "Ahihi", 1, 2, "NV0130", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1029), 7, true },
                    { 54, "Ahihi", 1, 1, "NV0052", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(546), 2, true },
                    { 131, "Ahihi", 1, 2, "NV0129", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1020), 7, true },
                    { 55, "Ahihi", 1, 1, "NV0053", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(548), 2, true },
                    { 130, "Ahihi", 1, 2, "NV0128", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1014), 7, true },
                    { 129, "Ahihi", 1, 2, "NV0127", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1010), 7, true },
                    { 56, "Ahihi", 1, 1, "NV0054", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(553), 2, true },
                    { 128, "Ahihi", 1, 2, "NV0126", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1001), 7, true },
                    { 57, "Ahihi", 1, 1, "NV0055", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(560), 2, true },
                    { 127, "Ahihi", 1, 2, "NV0125", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(998), 7, true },
                    { 126, "Ahihi", 1, 2, "NV0124", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(993), 7, true },
                    { 46, "Ahihi", 1, 1, "NV0044", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(526), 2, true },
                    { 58, "Ahihi", 1, 1, "NV0056", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(563), 2, true },
                    { 144, "Ahihi", 1, 2, "NV0142", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1088), 8, true },
                    { 45, "Ahihi", 1, 1, "NV0043", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(523), 2, true },
                    { 163, "Ahihi", 1, 2, "NV0161", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1282), 9, true },
                    { 34, "Ahihi", 1, 1, "NV0032", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(487), 1, true },
                    { 162, "Ahihi", 1, 2, "NV0160", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1191), 9, true },
                    { 161, "Ahihi", 1, 2, "NV0159", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1187), 8, true },
                    { 35, "Ahihi", 1, 1, "NV0033", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(489), 1, true },
                    { 160, "Ahihi", 1, 2, "NV0158", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1164), 8, true },
                    { 36, "Ahihi", 1, 1, "NV0034", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(494), 1, true },
                    { 159, "Ahihi", 1, 2, "NV0157", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1160), 8, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 158, "Ahihi", 1, 2, "NV0156", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1155), 8, true },
                    { 37, "Ahihi", 1, 1, "NV0035", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(497), 1, true },
                    { 157, "Ahihi", 1, 2, "NV0155", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1152), 8, true },
                    { 156, "Ahihi", 1, 2, "NV0154", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1150), 8, true },
                    { 38, "Ahihi", 1, 1, "NV0036", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(499), 1, true },
                    { 155, "Ahihi", 1, 2, "NV0153", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1139), 8, true },
                    { 39, "Ahihi", 1, 1, "NV0037", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(506), 1, true },
                    { 154, "Ahihi", 1, 2, "NV0152", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1135), 8, true },
                    { 153, "Ahihi", 1, 2, "NV0151", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1128), 8, true },
                    { 40, "Ahihi", 1, 1, "NV0038", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(508), 1, true },
                    { 152, "Ahihi", 1, 2, "NV0150", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1122), 8, true },
                    { 41, "Ahihi", 1, 1, "NV0039", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(511), 1, true },
                    { 151, "Ahihi", 1, 2, "NV0149", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1120), 8, true },
                    { 150, "Ahihi", 1, 2, "NV0148", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1117), 8, true },
                    { 42, "Ahihi", 1, 1, "NV0040", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(513), 2, true },
                    { 149, "Ahihi", 1, 2, "NV0147", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1115), 8, true },
                    { 43, "Ahihi", 1, 1, "NV0041", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(518), 2, true },
                    { 148, "Ahihi", 1, 2, "NV0146", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1107), 8, true },
                    { 147, "Ahihi", 1, 2, "NV0145", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1102), 8, true },
                    { 44, "Ahihi", 1, 1, "NV0042", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(521), 2, true },
                    { 146, "Ahihi", 1, 2, "NV0144", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1098), 8, true },
                    { 145, "Ahihi", 1, 2, "NV0143", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1094), 8, true },
                    { 125, "Ahihi", 1, 2, "NV0123", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(985), 7, true },
                    { 124, "Ahihi", 1, 2, "NV0122", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(981), 7, true },
                    { 59, "Ahihi", 1, 1, "NV0057", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(566), 2, true },
                    { 73, "Ahihi", 1, 1, "NV0071", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(666), 4, true },
                    { 101, "Ahihi", 1, 2, "NV0099", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(853), 5, true },
                    { 74, "Ahihi", 1, 1, "NV0072", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(668), 4, true },
                    { 100, "Ahihi", 1, 2, "NV0098", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(849), 5, true },
                    { 99, "Ahihi", 1, 2, "NV0097", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(843), 5, true },
                    { 75, "Ahihi", 1, 1, "NV0073", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(677), 4, true },
                    { 98, "Ahihi", 1, 2, "NV0096", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(837), 5, true },
                    { 76, "Ahihi", 1, 1, "NV0074", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(712), 4, true },
                    { 97, "Ahihi", 1, 2, "NV0095", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(829), 5, true },
                    { 96, "Ahihi", 1, 2, "NV0094", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(825), 5, true },
                    { 77, "Ahihi", 1, 1, "NV0075", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(717), 4, true },
                    { 95, "Ahihi", 1, 2, "NV0093", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(821), 5, true },
                    { 78, "Ahihi", 1, 1, "NV0076", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(719), 4, true },
                    { 113, "Ahihi", 1, 2, "NV0111", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(920), 6, true },
                    { 94, "Ahihi", 1, 2, "NV0092", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(817), 5, true },
                    { 79, "Ahihi", 1, 1, "NV0077", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(726), 4, true },
                    { 93, "Ahihi", 1, 2, "NV0091", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(815), 5, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 80, "Ahihi", 1, 1, "NV0078", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(732), 4, true },
                    { 92, "Ahihi", 1, 2, "NV0090", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(808), 5, true },
                    { 91, "Ahihi", 1, 2, "NV0089", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(802), 5, true },
                    { 81, "Ahihi", 1, 1, "NV0079", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(738), 4, true },
                    { 90, "Ahihi", 1, 2, "NV0088", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(797), 5, true },
                    { 82, "Ahihi", 1, 2, "NV0080", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(746), 5, true },
                    { 89, "Ahihi", 1, 2, "NV0087", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(788), 5, true },
                    { 88, "Ahihi", 1, 2, "NV0086", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(784), 5, true },
                    { 83, "Ahihi", 1, 2, "NV0081", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(748), 5, true },
                    { 87, "Ahihi", 1, 2, "NV0085", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(782), 5, true },
                    { 84, "Ahihi", 1, 2, "NV0082", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(763), 5, true },
                    { 86, "Ahihi", 1, 2, "NV0084", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(777), 5, true },
                    { 102, "Ahihi", 1, 2, "NV0100", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(857), 6, true },
                    { 103, "Ahihi", 1, 2, "NV0101", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(868), 6, true },
                    { 72, "Ahihi", 1, 1, "NV0070", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(663), 4, true },
                    { 104, "Ahihi", 1, 2, "NV0102", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(871), 6, true },
                    { 123, "Ahihi", 1, 2, "NV0121", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(975), 7, true },
                    { 60, "Ahihi", 1, 1, "NV0058", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(571), 2, true },
                    { 122, "Ahihi", 1, 2, "NV0120", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(973), 7, true },
                    { 121, "Ahihi", 1, 2, "NV0119", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(968), 6, true },
                    { 61, "Ahihi", 1, 1, "NV0059", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(576), 2, true },
                    { 120, "Ahihi", 1, 2, "NV0118", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(961), 6, true },
                    { 62, "Ahihi", 1, 1, "NV0060", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(582), 4, true },
                    { 119, "Ahihi", 1, 2, "NV0117", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(957), 6, true },
                    { 118, "Ahihi", 1, 2, "NV0116", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(953), 6, true },
                    { 63, "Ahihi", 1, 1, "NV0061", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(589), 4, true },
                    { 117, "Ahihi", 1, 2, "NV0115", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(949), 6, true },
                    { 64, "Ahihi", 1, 1, "NV0062", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(597), 4, true },
                    { 116, "Ahihi", 1, 2, "NV0114", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(940), 6, true },
                    { 115, "Ahihi", 1, 2, "NV0113", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(933), 6, true },
                    { 33, "Ahihi", 1, 1, "NV0031", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(484), 1, true },
                    { 65, "Ahihi", 1, 1, "NV0063", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(601), 4, true },
                    { 66, "Ahihi", 1, 1, "NV0064", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(606), 4, true },
                    { 112, "Ahihi", 1, 2, "NV0110", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(913), 6, true },
                    { 111, "Ahihi", 1, 2, "NV0109", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(908), 6, true },
                    { 67, "Ahihi", 1, 1, "NV0065", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(613), 4, true },
                    { 110, "Ahihi", 1, 2, "NV0108", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(902), 6, true },
                    { 68, "Ahihi", 1, 1, "NV0066", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(618), 4, true },
                    { 109, "Ahihi", 1, 2, "NV0107", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(894), 6, true },
                    { 108, "Ahihi", 1, 2, "NV0106", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(892), 6, true },
                    { 69, "Ahihi", 1, 1, "NV0067", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(623), 4, true },
                    { 107, "Ahihi", 1, 2, "NV0105", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(885), 6, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 70, "Ahihi", 1, 1, "NV0068", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(628), 4, true },
                    { 106, "Ahihi", 1, 2, "NV0104", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(881), 6, true },
                    { 105, "Ahihi", 1, 2, "NV0103", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(876), 6, true },
                    { 71, "Ahihi", 1, 1, "NV0069", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(653), 4, true },
                    { 114, "Ahihi", 1, 2, "NV0112", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(928), 6, true },
                    { 164, "Ahihi", 1, 2, "NV0162", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1287), 9, true },
                    { 85, "Ahihi", 1, 2, "NV0083", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(769), 5, true },
                    { 165, "Ahihi", 1, 2, "NV0163", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1300), 9, true },
                    { 185, "Ahihi", 1, 3, "NV0183", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1358), 10, true },
                    { 20, "Ahihi", 1, 1, "NV0018", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(448), 3, true },
                    { 8, "Ahihi", 1, 1, "NV0006", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(398), 3, true },
                    { 184, "Ahihi", 1, 3, "NV0182", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1355), 10, true },
                    { 203, "Ahihi", 1, 3, "NV0201", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1421), 11, true },
                    { 183, "Ahihi", 1, 3, "NV0181", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1352), 10, true },
                    { 21, "Ahihi", 1, 1, "NV0019", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(451), 3, true },
                    { 204, "Ahihi", 1, 3, "NV0202", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1426), 11, true },
                    { 182, "Ahihi", 1, 3, "NV0180", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1349), 10, true },
                    { 7, "Ahihi", 1, 1, "NV0005", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(395), 3, true },
                    { 22, "Ahihi", 1, 1, "NV0020", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(453), 1, true },
                    { 181, "Ahihi", 1, 2, "NV0179", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1347), 9, true },
                    { 205, "Ahihi", 1, 3, "NV0203", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1428), 11, true },
                    { 195, "Ahihi", 1, 3, "NV0193", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1395), 10, true },
                    { 180, "Ahihi", 1, 2, "NV0178", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1345), 9, true },
                    { 6, "Ahihi", 1, 1, "NV0004", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(391), 3, true },
                    { 179, "Ahihi", 1, 2, "NV0177", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1341), 9, true },
                    { 206, "Ahihi", 1, 3, "NV0204", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1431), 11, true },
                    { 24, "Ahihi", 1, 1, "NV0022", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(458), 1, true },
                    { 178, "Ahihi", 1, 2, "NV0176", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1338), 9, true },
                    { 207, "Ahihi", 1, 3, "NV0205", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1433), 11, true },
                    { 19, "Ahihi", 1, 1, "NV0017", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(443), 3, true },
                    { 202, "Ahihi", 1, 3, "NV0200", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1417), 11, true },
                    { 186, "Ahihi", 1, 3, "NV0184", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1361), 10, true },
                    { 9, "Ahihi", 1, 1, "NV0007", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(401), 3, true },
                    { 196, "Ahihi", 1, 3, "NV0194", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1399), 10, true },
                    { 13, "Ahihi", 1, 1, "NV0011", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(416), 3, true },
                    { 194, "Ahihi", 1, 3, "NV0192", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1392), 10, true },
                    { 197, "Ahihi", 1, 3, "NV0195", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1403), 10, true },
                    { 193, "Ahihi", 1, 3, "NV0191", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1390), 10, true },
                    { 14, "Ahihi", 1, 1, "NV0012", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(418), 3, true },
                    { 11, "Ahihi", 1, 1, "NV0009", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(405), 3, true },
                    { 192, "Ahihi", 1, 3, "NV0190", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1387), 10, true },
                    { 198, "Ahihi", 1, 3, "NV0196", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1405), 10, true }
                });

            migrationBuilder.InsertData(
                table: "DieuChuyen",
                columns: new[] { "id", "chiTiet", "idChucVu", "idPhongBan", "maNhanVien", "ngayHieuLuc", "to", "trangThai" },
                values: new object[,]
                {
                    { 15, "Ahihi", 1, 1, "NV0013", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(425), 3, true },
                    { 177, "Ahihi", 1, 2, "NV0175", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1336), 9, true },
                    { 191, "Ahihi", 1, 3, "NV0189", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1384), 10, true },
                    { 190, "Ahihi", 1, 3, "NV0188", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1380), 10, true },
                    { 16, "Ahihi", 1, 1, "NV0014", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(427), 3, true },
                    { 10, "Ahihi", 1, 1, "NV0008", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(403), 3, true },
                    { 189, "Ahihi", 1, 3, "NV0187", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1371), 10, true },
                    { 200, "Ahihi", 1, 3, "NV0198", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1411), 10, true },
                    { 17, "Ahihi", 1, 1, "NV0015", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(431), 3, true },
                    { 188, "Ahihi", 1, 3, "NV0186", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1367), 10, true },
                    { 201, "Ahihi", 1, 3, "NV0199", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1415), 10, true },
                    { 187, "Ahihi", 1, 3, "NV0185", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1363), 10, true },
                    { 18, "Ahihi", 1, 1, "NV0016", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(434), 3, true },
                    { 199, "Ahihi", 1, 3, "NV0197", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1408), 10, true },
                    { 5, "Ahihi", 1, 1, "NV0003", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(389), 3, true },
                    { 23, "Ahihi", 1, 1, "NV0021", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(455), 1, true },
                    { 25, "Ahihi", 1, 1, "NV0023", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(461), 1, true },
                    { 27, "Ahihi", 1, 1, "NV0025", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(465), 1, true },
                    { 172, "Ahihi", 1, 2, "NV0170", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1320), 9, true },
                    { 28, "Ahihi", 1, 1, "NV0026", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(470), 1, true },
                    { 171, "Ahihi", 1, 2, "NV0169", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1315), 9, true },
                    { 170, "Ahihi", 1, 2, "NV0168", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1313), 9, true },
                    { 29, "Ahihi", 1, 1, "NV0027", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(473), 1, true },
                    { 169, "Ahihi", 1, 2, "NV0167", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1311), 9, true },
                    { 30, "Ahihi", 1, 1, "NV0028", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(475), 1, true },
                    { 168, "Ahihi", 1, 2, "NV0166", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1309), 9, true },
                    { 167, "Ahihi", 1, 2, "NV0165", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1305), 9, true },
                    { 31, "Ahihi", 1, 1, "NV0029", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(479), 1, true },
                    { 166, "Ahihi", 1, 2, "NV0164", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1302), 9, true },
                    { 3, "Ahihi", 1, 1, "NV0001", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(379), 3, true },
                    { 2, "Ahihi", 1, 2, "NV0001", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(277), 2, false },
                    { 32, "Ahihi", 1, 1, "NV0030", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(482), 1, true },
                    { 173, "Ahihi", 1, 2, "NV0171", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1325), 9, true },
                    { 209, "Ahihi", 1, 3, "NV0207", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1438), 11, true },
                    { 12, "Ahihi", 1, 1, "NV0010", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(411), 3, true },
                    { 26, "Ahihi", 1, 1, "NV0024", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(463), 1, true },
                    { 175, "Ahihi", 1, 2, "NV0173", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1330), 9, true },
                    { 208, "Ahihi", 1, 3, "NV0206", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1436), 11, true },
                    { 176, "Ahihi", 1, 2, "NV0174", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1333), 9, true },
                    { 4, "Ahihi", 1, 1, "NV0002", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(385), 3, true },
                    { 174, "Ahihi", 1, 2, "NV0172", new DateTime(2021, 11, 6, 16, 19, 30, 742, DateTimeKind.Local).AddTicks(1327), 9, true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[] { "HD213", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4704), 1, 1, "NV0213", true });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD197", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4598), 1, 1, "NV0197", true },
                    { "HD214", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4711), 1, 1, "NV0214", true },
                    { "HD106", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3974), 1, 1, "NV0106", true },
                    { "HD112", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4014), 1, 1, "NV0112", true },
                    { "HD95", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3900), 1, 1, "NV0095", true },
                    { "HD86", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3839), 1, 1, "NV0086", true },
                    { "HD196", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4591), 1, 1, "NV0196", true },
                    { "HD107", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3981), 1, 1, "NV0107", true },
                    { "HD215", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4720), 1, 1, "NV0215", true },
                    { "HD216", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4727), 1, 1, "NV0216", true },
                    { "HD110", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4001), 1, 1, "NV0110", true },
                    { "HD108", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3988), 1, 1, "NV0108", true },
                    { "HD105", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3968), 1, 1, "NV0105", true },
                    { "HD111", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4008), 1, 1, "NV0111", true },
                    { "HD195", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4585), 1, 1, "NV0195", true },
                    { "HD85", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3832), 1, 1, "NV0085", true },
                    { "HD109", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3994), 1, 1, "NV0109", true },
                    { "HD217", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4734), 1, 1, "NV0217", true },
                    { "HD204", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4644), 1, 1, "NV0204", true },
                    { "HD84", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3826), 1, 1, "NV0084", true },
                    { "HD194", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4578), 1, 1, "NV0194", true },
                    { "HD205", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4651), 1, 1, "NV0205", true },
                    { "HD94", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3893), 1, 1, "NV0094", true },
                    { "HD91", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3873), 1, 1, "NV0091", true },
                    { "HD87", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3845), 1, 1, "NV0087", true },
                    { "HD212", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4698), 1, 1, "NV0212", true },
                    { "HD98", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3920), 1, 1, "NV0098", true },
                    { "HD97", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3913), 1, 1, "NV0097", true },
                    { "HD99", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3927), 1, 1, "NV0099", true },
                    { "HD207", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4664), 1, 1, "NV0207", true },
                    { "HD201", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4624), 1, 1, "NV0201", true },
                    { "HD218", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4741), 1, 1, "NV0218", true },
                    { "HD208", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4671), 1, 1, "NV0208", true },
                    { "HD100", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3934), 1, 1, "NV0100", true },
                    { "HD206", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4657), 1, 1, "NV0206", true },
                    { "HD90", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3865), 1, 1, "NV0090", true },
                    { "HD209", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4678), 1, 1, "NV0209", true },
                    { "HD200", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4618), 1, 1, "NV0200", true },
                    { "HD101", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3940), 1, 1, "NV0101", true },
                    { "HD203", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4638), 1, 1, "NV0203", true },
                    { "HD89", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3859), 1, 1, "NV0089", true },
                    { "HD102", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3947), 1, 1, "NV0102", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD199", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4611), 1, 1, "NV0199", true },
                    { "HD93", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3887), 1, 1, "NV0093", true },
                    { "HD211", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4691), 1, 1, "NV0211", true },
                    { "HD103", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3954), 1, 1, "NV0103", true },
                    { "HD92", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3880), 1, 1, "NV0092", true },
                    { "HD96", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3906), 1, 1, "NV0096", true },
                    { "HD88", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3852), 1, 1, "NV0088", true },
                    { "HD198", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4604), 1, 1, "NV0198", true },
                    { "HD104", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3960), 1, 1, "NV0104", true },
                    { "HD202", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4631), 1, 1, "NV0202", true },
                    { "HD210", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4684), 1, 1, "NV0210", true },
                    { "HD122", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4088), 1, 1, "NV0122", true },
                    { "HD113", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4021), 1, 1, "NV0113", true },
                    { "HD148", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4263), 1, 1, "NV0148", true },
                    { "HD171", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4419), 1, 1, "NV0171", true },
                    { "HD83", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3819), 1, 1, "NV0083", true },
                    { "HD146", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4250), 1, 1, "NV0146", true },
                    { "HD172", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4425), 1, 1, "NV0172", true },
                    { "HD145", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4244), 1, 1, "NV0145", true },
                    { "HD173", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4432), 1, 1, "NV0173", true },
                    { "HD149", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4270), 1, 1, "NV0149", true },
                    { "HD144", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4236), 1, 1, "NV0144", true },
                    { "HD174", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4439), 1, 1, "NV0174", true },
                    { "HD142", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4223), 1, 1, "NV0142", true },
                    { "HD175", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4447), 1, 1, "NV0175", true },
                    { "HD141", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4217), 1, 1, "NV0141", true },
                    { "HD140", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4209), 1, 1, "NV0140", true },
                    { "HD176", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4453), 1, 1, "NV0176", true },
                    { "HD139", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4203), 1, 1, "NV0139", true },
                    { "HD143", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4230), 1, 1, "NV0143", true },
                    { "HD170", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4412), 1, 1, "NV0170", true },
                    { "HD150", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4277), 1, 1, "NV0150", true },
                    { "HD169", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4405), 1, 1, "NV0169", true },
                    { "HD161", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4352), 1, 1, "NV0161", true },
                    { "HD163", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4366), 1, 1, "NV0163", true },
                    { "HD160", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4346), 1, 1, "NV0160", true },
                    { "HD164", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4372), 1, 1, "NV0164", true },
                    { "HD159", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4339), 1, 1, "NV0159", true },
                    { "HD158", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4332), 1, 1, "NV0158", true },
                    { "HD165", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4379), 1, 1, "NV0165", true },
                    { "HD157", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4325), 1, 1, "NV0157", true },
                    { "HD156", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4319), 1, 1, "NV0156", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD166", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4385), 1, 1, "NV0166", true },
                    { "HD155", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4312), 1, 1, "NV0155", true },
                    { "HD167", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4392), 1, 1, "NV0167", true },
                    { "HD154", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4305), 1, 1, "NV0154", true },
                    { "HD153", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4298), 1, 1, "NV0153", true },
                    { "HD168", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4399), 1, 1, "NV0168", true },
                    { "HD152", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4290), 1, 1, "NV0152", true },
                    { "HD151", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4283), 1, 1, "NV0151", true },
                    { "HD177", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4460), 1, 1, "NV0177", true },
                    { "HD193", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4572), 1, 1, "NV0193", true },
                    { "HD138", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4196), 1, 1, "NV0138", true },
                    { "HD178", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4466), 1, 1, "NV0178", true },
                    { "HD123", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4095), 1, 1, "NV0123", true },
                    { "HD187", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4532), 1, 1, "NV0187", true },
                    { "HD162", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4359), 1, 1, "NV0162", true },
                    { "HD121", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4082), 1, 1, "NV0121", true },
                    { "HD188", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4538), 1, 1, "NV0188", true },
                    { "HD120", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4075), 1, 1, "NV0120", true },
                    { "HD119", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4068), 1, 1, "NV0119", true },
                    { "HD186", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4524), 1, 1, "NV0186", true },
                    { "HD189", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4545), 1, 1, "NV0189", true },
                    { "HD190", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4552), 1, 1, "NV0190", true },
                    { "HD117", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4048), 1, 1, "NV0117", true },
                    { "HD116", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4041), 1, 1, "NV0116", true },
                    { "HD191", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4558), 1, 1, "NV0191", true },
                    { "HD115", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4034), 1, 1, "NV0115", true },
                    { "HD114", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4027), 1, 1, "NV0114", true },
                    { "HD192", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4565), 1, 1, "NV0192", true },
                    { "HD118", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4061), 1, 1, "NV0118", true },
                    { "HD124", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4102), 1, 1, "NV0124", true },
                    { "HD125", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4109), 1, 1, "NV0125", true },
                    { "HD185", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4513), 1, 1, "NV0185", true },
                    { "HD136", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4183), 1, 1, "NV0136", true },
                    { "HD179", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4473), 1, 1, "NV0179", true },
                    { "HD135", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4176), 1, 1, "NV0135", true },
                    { "HD134", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4169), 1, 1, "NV0134", true },
                    { "HD180", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4480), 1, 1, "NV0180", true },
                    { "HD133", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4162), 1, 1, "NV0133", true },
                    { "HD181", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4486), 1, 1, "NV0181", true },
                    { "HD132", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4156), 1, 1, "NV0132", true },
                    { "HD131", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4149), 1, 1, "NV0131", true },
                    { "HD182", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4493), 1, 1, "NV0182", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD130", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4142), 1, 1, "NV0130", true },
                    { "HD129", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4136), 1, 1, "NV0129", true },
                    { "HD183", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4500), 1, 1, "NV0183", true },
                    { "HD128", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4129), 1, 1, "NV0128", true },
                    { "HD184", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4506), 1, 1, "NV0184", true },
                    { "HD127", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4122), 1, 1, "NV0127", true },
                    { "HD126", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4115), 1, 1, "NV0126", true },
                    { "HD137", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4190), 1, 1, "NV0137", true },
                    { "HD147", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4257), 1, 1, "NV0147", true },
                    { "HD219", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(4747), 1, 1, "NV0219", true },
                    { "HD42", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3532), 1, 1, "NV0042", true },
                    { "HD12", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3329), 1, 1, "NV0012", true },
                    { "HD24", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3411), 1, 1, "NV0024", true },
                    { "HD60", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3665), 1, 1, "NV0060", true },
                    { "HD25", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3418), 1, 1, "NV0025", true },
                    { "HD11", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3323), 1, 1, "NV0011", true },
                    { "HD73", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3751), 1, 1, "NV0073", true },
                    { "HD59", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3659), 1, 1, "NV0059", true },
                    { "HD26", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3425), 1, 1, "NV0026", true },
                    { "HD58", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3652), 1, 1, "NV0058", true },
                    { "HD10", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3316), 1, 1, "NV0010", true },
                    { "HD74", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3758), 1, 1, "NV0074", true },
                    { "HD27", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3432), 1, 1, "NV0027", true },
                    { "HD57", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3645), 1, 1, "NV0057", true },
                    { "HD28", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3438), 1, 1, "NV0028", true },
                    { "HD56", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3638), 1, 1, "NV0056", true },
                    { "HD29", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3445), 1, 1, "NV0029", true },
                    { "HD75", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3764), 1, 1, "NV0075", true },
                    { "HD61", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3672), 1, 1, "NV0061", true },
                    { "HD67", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3711), 1, 1, "NV0067", true },
                    { "HD72", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3744), 1, 1, "NV0072", true },
                    { "HD23", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3405), 1, 1, "NV0023", true },
                    { "HD68", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3718), 1, 1, "NV0068", true },
                    { "HD17", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3363), 1, 1, "NV0017", true },
                    { "HD19", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3378), 1, 1, "NV0019", true },
                    { "HD66", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3705), 1, 1, "NV0066", true },
                    { "HD16", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3356), 1, 1, "NV0016", true },
                    { "HD69", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3725), 1, 1, "NV0069", true },
                    { "HD20", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3384), 1, 1, "NV0020", true },
                    { "HD65", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3698), 1, 1, "NV0065", true },
                    { "HD21", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3391), 1, 1, "NV0021", true },
                    { "HD70", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3731), 1, 1, "NV0070", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD15", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3349), 1, 1, "NV0015", true },
                    { "HD64", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3692), 1, 1, "NV0064", true },
                    { "HD22", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3398), 1, 1, "NV0022", true },
                    { "HD14", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3342), 1, 1, "NV0014", true },
                    { "HD63", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3685), 1, 1, "NV0063", true },
                    { "HD71", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3738), 1, 1, "NV0071", true },
                    { "HD62", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3678), 1, 1, "NV0062", true },
                    { "HD13", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3336), 1, 1, "NV0013", true },
                    { "HD55", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3631), 1, 1, "NV0055", true },
                    { "HD09", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3309), 1, 1, "NV0008", true },
                    { "HD76", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3771), 1, 1, "NV0076", true },
                    { "HD48", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3571), 1, 1, "NV0048", true },
                    { "HD36", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3492), 1, 1, "NV0036", true },
                    { "HD03", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3262), 1, 1, "NV0003", true },
                    { "HD80", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3798), 1, 1, "NV0080", true },
                    { "HD37", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3498), 1, 1, "NV0037", true },
                    { "HD47", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3565), 1, 1, "NV0047", true },
                    { "HD46", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3558), 1, 1, "NV0046", true },
                    { "HD38", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3505), 1, 1, "NV0038", true },
                    { "HD49", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3578), 1, 1, "NV0049", true },
                    { "HD39", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3511), 1, 1, "NV0039", true },
                    { "HD81", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3804), 1, 1, "NV0081", true },
                    { "HD44", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3545), 1, 1, "NV0044", true },
                    { "HD40", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3518), 1, 1, "NV0040", true },
                    { "HD41", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3524), 1, 1, "NV0041", true },
                    { "HD43", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3538), 1, 1, "NV0043", true },
                    { "HD82", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3811), 1, 1, "NV0082", true },
                    { "HD02", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3183), 1, 1, "NV0001", true },
                    { "HD01", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 739, DateTimeKind.Local).AddTicks(1475), 1, 1, "NV0001", false },
                    { "HD45", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3551), 1, 1, "NV0045", true },
                    { "HD08", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3301), 1, 1, "NV0008", true },
                    { "HD18", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3370), 1, 1, "NV0018", true },
                    { "HD04", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3273), 1, 1, "NV0004", true },
                    { "HD30", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3452), 1, 1, "NV0030", true },
                    { "HD54", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3624), 1, 1, "NV0054", true },
                    { "HD31", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3458), 1, 1, "NV0031", true },
                    { "HD07", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3294), 1, 1, "NV0007", true },
                    { "HD53", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3617), 1, 1, "NV0053", true },
                    { "HD32", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3465), 1, 1, "NV0032", true },
                    { "HD77", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3778), 1, 1, "NV0077", true },
                    { "HD52", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3610), 1, 1, "NV0052", true },
                    { "HD79", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3791), 1, 1, "NV0079", true }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "maHopDong", "ghiChu", "hopDongDenNgay", "hopDongTuNgay", "idChucDanh", "idLoaiHopDong", "maNhanVien", "trangThai" },
                values: new object[,]
                {
                    { "HD06", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3287), 1, 1, "NV0006", true },
                    { "HD78", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3784), 1, 1, "NV0078", true },
                    { "HD51", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3604), 1, 1, "NV0051", true },
                    { "HD34", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3479), 1, 1, "NV0034", true },
                    { "HD50", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3596), 1, 1, "NV0050", true },
                    { "HD05", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3281), 1, 1, "NV0005", true },
                    { "HD35", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3485), 1, 1, "NV0035", true },
                    { "HD33", null, new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(3471), 1, 1, "NV0033", true }
                });

            migrationBuilder.InsertData(
                table: "KhenThuongKyLuat",
                columns: new[] { "id", "anh", "idDanhMucKhenThuong", "loai", "lyDo", "maNhanVien", "noiDung" },
                values: new object[,]
                {
                    { 9, null, 1, true, null, "NV0022", "Thưởng nhân viên suất sắc" },
                    { 10, null, 1, false, null, "NV0056", "Thưởng nhân viên suất sắc" },
                    { 5, null, 1, false, null, "NV0035", "Thưởng nhân viên suất sắc" },
                    { 7, null, 1, true, null, "NV0023", "Thưởng nhân viên suất sắc" },
                    { 4, null, 1, true, null, "NV0021", "Thưởng nhân viên suất sắc" },
                    { 3, null, 1, true, null, "NV0009", "Thưởng nhân viên suất sắc" },
                    { 6, null, 1, true, null, "NV0078", "Thưởng nhân viên suất sắc" },
                    { 1, null, 1, true, null, "NV0001", "Thưởng nhân viên suất sắc" },
                    { 2, null, 1, false, null, "NV0001", "Thưởng nhân viên suất sắc" },
                    { 8, null, 1, false, null, "NV0099", "Thưởng nhân viên suất sắc" },
                    { 12, null, 1, false, null, "NV0091", "Thưởng nhân viên suất sắc" },
                    { 11, null, 1, true, null, "NV0081", "Thưởng nhân viên suất sắc" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 157, "Không", "NV0157", "Không", "Không" },
                    { 5, "Không", "NV0005", "Không", "Không" },
                    { 182, "Không", "NV0182", "Không", "Không" },
                    { 33, "Không", "NV0033", "Không", "Không" },
                    { 201, "Không", "NV0201", "Không", "Không" },
                    { 34, "Không", "NV0034", "Không", "Không" },
                    { 155, "Không", "NV0155", "Không", "Không" },
                    { 202, "Không", "NV0202", "Không", "Không" },
                    { 156, "Không", "NV0156", "Không", "Không" },
                    { 200, "Không", "NV0200", "Không", "Không" },
                    { 6, "Không", "NV0006", "Không", "Không" },
                    { 32, "Không", "NV0032", "Không", "Không" },
                    { 4, "Không", "NV0004", "Không", "Không" },
                    { 159, "Không", "NV0159", "Không", "Không" },
                    { 160, "Không", "NV0160", "Không", "Không" },
                    { 199, "Không", "NV0199", "Không", "Không" },
                    { 31, "Không", "NV0031", "Không", "Không" },
                    { 198, "Không", "NV0198", "Không", "Không" },
                    { 161, "Không", "NV0161", "Không", "Không" },
                    { 30, "Không", "NV0030", "Không", "Không" },
                    { 7, "Không", "NV0007", "Không", "Không" },
                    { 158, "Không", "NV0158", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 203, "Không", "NV0203", "Không", "Không" },
                    { 35, "Không", "NV0035", "Không", "Không" },
                    { 162, "Không", "NV0162", "Không", "Không" },
                    { 145, "Không", "NV0145", "Không", "Không" },
                    { 146, "Không", "NV0146", "Không", "Không" },
                    { 40, "Không", "NV0040", "Không", "Không" },
                    { 1, "Không", "NV0001", "Không", "Không" },
                    { 147, "Không", "NV0147", "Không", "Không" },
                    { 39, "Không", "NV0039", "Không", "Không" },
                    { 148, "Không", "NV0148", "Không", "Không" },
                    { 209, "Không", "NV0209", "Không", "Không" },
                    { 208, "Không", "NV0208", "Không", "Không" },
                    { 149, "Không", "NV0149", "Không", "Không" },
                    { 38, "Không", "NV0038", "Không", "Không" },
                    { 207, "Không", "NV0207", "Không", "Không" },
                    { 206, "Không", "NV0206", "Không", "Không" },
                    { 150, "Không", "NV0150", "Không", "Không" },
                    { 37, "Không", "NV0037", "Không", "Không" },
                    { 151, "Không", "NV0151", "Không", "Không" },
                    { 2, "Không", "NV0002", "Không", "Không" },
                    { 205, "Không", "NV0205", "Không", "Không" },
                    { 152, "Không", "NV0152", "Không", "Không" },
                    { 36, "Không", "NV0036", "Không", "Không" },
                    { 204, "Không", "NV0204", "Không", "Không" },
                    { 3, "Không", "NV0003", "Không", "Không" },
                    { 153, "Không", "NV0153", "Không", "Không" },
                    { 154, "Không", "NV0154", "Không", "Không" },
                    { 197, "Không", "NV0197", "Không", "Không" },
                    { 196, "Không", "NV0196", "Không", "Không" },
                    { 17, "Không", "NV0017", "Không", "Không" },
                    { 173, "Không", "NV0173", "Không", "Không" },
                    { 188, "Không", "NV0188", "Không", "Không" },
                    { 13, "Không", "NV0013", "Không", "Không" },
                    { 174, "Không", "NV0174", "Không", "Không" },
                    { 22, "Không", "NV0022", "Không", "Không" },
                    { 175, "Không", "NV0175", "Không", "Không" },
                    { 187, "Không", "NV0187", "Không", "Không" },
                    { 14, "Không", "NV0014", "Không", "Không" },
                    { 176, "Không", "NV0176", "Không", "Không" },
                    { 21, "Không", "NV0021", "Không", "Không" },
                    { 186, "Không", "NV0186", "Không", "Không" },
                    { 189, "Không", "NV0189", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 41, "Không", "NV0041", "Không", "Không" },
                    { 185, "Không", "NV0185", "Không", "Không" },
                    { 178, "Không", "NV0178", "Không", "Không" },
                    { 15, "Không", "NV0015", "Không", "Không" },
                    { 184, "Không", "NV0184", "Không", "Không" },
                    { 179, "Không", "NV0179", "Không", "Không" },
                    { 19, "Không", "NV0019", "Không", "Không" },
                    { 16, "Không", "NV0016", "Không", "Không" },
                    { 183, "Không", "NV0183", "Không", "Không" },
                    { 180, "Không", "NV0180", "Không", "Không" },
                    { 18, "Không", "NV0018", "Không", "Không" },
                    { 181, "Không", "NV0181", "Không", "Không" },
                    { 177, "Không", "NV0177", "Không", "Không" },
                    { 12, "Không", "NV0012", "Không", "Không" },
                    { 23, "Không", "NV0023", "Không", "Không" },
                    { 172, "Không", "NV0172", "Không", "Không" },
                    { 29, "Không", "NV0029", "Không", "Không" },
                    { 8, "Không", "NV0008", "Không", "Không" },
                    { 164, "Không", "NV0164", "Không", "Không" },
                    { 28, "Không", "NV0028", "Không", "Không" },
                    { 195, "Không", "NV0195", "Không", "Không" },
                    { 165, "Không", "NV0165", "Không", "Không" },
                    { 194, "Không", "NV0194", "Không", "Không" },
                    { 166, "Không", "NV0166", "Không", "Không" },
                    { 27, "Không", "NV0027", "Không", "Không" },
                    { 9, "Không", "NV0009", "Không", "Không" },
                    { 193, "Không", "NV0193", "Không", "Không" },
                    { 167, "Không", "NV0167", "Không", "Không" },
                    { 26, "Không", "NV0026", "Không", "Không" },
                    { 10, "Không", "NV0010", "Không", "Không" },
                    { 168, "Không", "NV0168", "Không", "Không" },
                    { 192, "Không", "NV0192", "Không", "Không" },
                    { 169, "Không", "NV0169", "Không", "Không" },
                    { 25, "Không", "NV0025", "Không", "Không" },
                    { 20, "Không", "NV0010", "Không", "Không" },
                    { 191, "Không", "NV0191", "Không", "Không" },
                    { 170, "Không", "NV0170", "Không", "Không" },
                    { 24, "Không", "NV0024", "Không", "Không" },
                    { 11, "Không", "NV0011", "Không", "Không" },
                    { 171, "Không", "NV0171", "Không", "Không" },
                    { 190, "Không", "NV0190", "Không", "Không" },
                    { 163, "Không", "NV0163", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 82, "Không", "NV0082", "Không", "Không" },
                    { 144, "Không", "NV0144", "Không", "Không" },
                    { 90, "Không", "NV0090", "Không", "Không" },
                    { 63, "Không", "NV0063", "Không", "Không" },
                    { 112, "Không", "NV0112", "Không", "Không" },
                    { 111, "Không", "NV0111", "Không", "Không" },
                    { 62, "Không", "NV0062", "Không", "Không" },
                    { 113, "Không", "NV0113", "Không", "Không" },
                    { 114, "Không", "NV0114", "Không", "Không" },
                    { 61, "Không", "NV0061", "Không", "Không" },
                    { 115, "Không", "NV0115", "Không", "Không" },
                    { 60, "Không", "NV0060", "Không", "Không" },
                    { 116, "Không", "NV0116", "Không", "Không" },
                    { 92, "Không", "NV0092", "Không", "Không" },
                    { 76, "Không", "NV0076", "Không", "Không" },
                    { 117, "Không", "NV0117", "Không", "Không" },
                    { 59, "Không", "NV0059", "Không", "Không" },
                    { 118, "Không", "NV0118", "Không", "Không" },
                    { 58, "Không", "NV0058", "Không", "Không" },
                    { 119, "Không", "NV0119", "Không", "Không" },
                    { 91, "Không", "NV0091", "Không", "Không" },
                    { 77, "Không", "NV0077", "Không", "Không" },
                    { 120, "Không", "NV0120", "Không", "Không" },
                    { 57, "Không", "NV0057", "Không", "Không" },
                    { 72, "Không", "NV0072", "Không", "Không" },
                    { 56, "Không", "NV0056", "Không", "Không" },
                    { 122, "Không", "NV0122", "Không", "Không" },
                    { 123, "Không", "NV0123", "Không", "Không" },
                    { 75, "Không", "NV0075", "Không", "Không" },
                    { 55, "Không", "NV0055", "Không", "Không" },
                    { 110, "Không", "NV0110", "Không", "Không" },
                    { 109, "Không", "NV0109", "Không", "Không" },
                    { 98, "Không", "NV0098", "Không", "Không" },
                    { 71, "Không", "NV0071", "Không", "Không" },
                    { 99, "Không", "NV0099", "Không", "Không" },
                    { 96, "Không", "NV0096", "Không", "Không" },
                    { 70, "Không", "NV0070", "Không", "Không" },
                    { 73, "Không", "NV0073", "Không", "Không" },
                    { 100, "Không", "NV0100", "Không", "Không" },
                    { 101, "Không", "NV0101", "Không", "Không" },
                    { 95, "Không", "NV0095", "Không", "Không" },
                    { 69, "Không", "NV0069", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 102, "Không", "NV0102", "Không", "Không" },
                    { 68, "Không", "NV0068", "Không", "Không" },
                    { 103, "Không", "NV0103", "Không", "Không" },
                    { 104, "Không", "NV0104", "Không", "Không" },
                    { 67, "Không", "NV0067", "Không", "Không" },
                    { 105, "Không", "NV0105", "Không", "Không" },
                    { 94, "Không", "NV0094", "Không", "Không" },
                    { 74, "Không", "NV0074", "Không", "Không" },
                    { 66, "Không", "NV0066", "Không", "Không" },
                    { 106, "Không", "NV0106", "Không", "Không" },
                    { 107, "Không", "NV0107", "Không", "Không" },
                    { 65, "Không", "NV0065", "Không", "Không" },
                    { 108, "Không", "NV0108", "Không", "Không" },
                    { 42, "Không", "NV0042", "Không", "Không" },
                    { 64, "Không", "NV0064", "Không", "Không" },
                    { 93, "Không", "NV0093", "Không", "Không" },
                    { 124, "Không", "NV0124", "Không", "Không" },
                    { 121, "Không", "NV0121", "Không", "Không" },
                    { 78, "Không", "NV0078", "Không", "Không" },
                    { 49, "Không", "NV0049", "Không", "Không" },
                    { 133, "Không", "NV0133", "Không", "Không" },
                    { 134, "Không", "NV0134", "Không", "Không" },
                    { 89, "Không", "NV0089", "Không", "Không" },
                    { 48, "Không", "NV0048", "Không", "Không" },
                    { 135, "Không", "NV0135", "Không", "Không" },
                    { 80, "Không", "NV0080", "Không", "Không" },
                    { 47, "Không", "NV0047", "Không", "Không" },
                    { 136, "Không", "NV0136", "Không", "Không" },
                    { 137, "Không", "NV0137", "Không", "Không" },
                    { 85, "Không", "NV0085", "Không", "Không" },
                    { 132, "Không", "NV0132", "Không", "Không" },
                    { 46, "Không", "NV0046", "Không", "Không" },
                    { 45, "Không", "NV0045", "Không", "Không" },
                    { 139, "Không", "NV0139", "Không", "Không" },
                    { 140, "Không", "NV0140", "Không", "Không" },
                    { 44, "Không", "NV0044", "Không", "Không" },
                    { 141, "Không", "NV0141", "Không", "Không" },
                    { 84, "Không", "NV0084", "Không", "Không" },
                    { 43, "Không", "NV0043", "Không", "Không" },
                    { 81, "Không", "NV0081", "Không", "Không" },
                    { 142, "Không", "NV0142", "Không", "Không" },
                    { 143, "Không", "NV0143", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LichSuBanThan",
                columns: new[] { "lsbt_id", "lsbt_biBatDiTu", "lsbt_maNhanVien", "lsbt_thamGiaChinhTri", "lsbt_thanNhanNuocNgoai" },
                values: new object[,]
                {
                    { 83, "Không", "NV0083", "Không", "Không" },
                    { 138, "Không", "NV0138", "Không", "Không" },
                    { 50, "Không", "NV0050", "Không", "Không" },
                    { 86, "Không", "NV0086", "Không", "Không" },
                    { 97, "Không", "NV0097", "Không", "Không" },
                    { 127, "Không", "NV0127", "Không", "Không" },
                    { 131, "Không", "NV0131", "Không", "Không" },
                    { 88, "Không", "NV0088", "Không", "Không" },
                    { 128, "Không", "NV0128", "Không", "Không" },
                    { 52, "Không", "NV0052", "Không", "Không" },
                    { 129, "Không", "NV0129", "Không", "Không" },
                    { 79, "Không", "NV0079", "Không", "Không" },
                    { 54, "Không", "NV0054", "Không", "Không" },
                    { 51, "Không", "NV0051", "Không", "Không" },
                    { 126, "Không", "NV0126", "Không", "Không" },
                    { 53, "Không", "NV0053", "Không", "Không" },
                    { 87, "Không", "NV0087", "Không", "Không" },
                    { 125, "Không", "NV0125", "Không", "Không" },
                    { 130, "Không", "NV0130", "Không", "Không" }
                });

            migrationBuilder.InsertData(
                table: "LienHeKhanCap",
                columns: new[] { "lhkc_id", "lhkc_diaChi", "lhkc_dienThoai", "lhkc_email", "lhkc_hoTen", "lhkc_maNhanVien", "lhkc_quanHe" },
                values: new object[] { 1, "Hà Nội", "0123434324", null, "Mai Trung Hiếu", "NV0001", "Bạn" });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 74, 1, "NV0073", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 12, 1, "NV0011", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 90, 1, "NV0089", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 73, 1, "NV0072", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 84, 1, "NV0083", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 79, 1, "NV0078", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 91, 1, "NV0090", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 78, 1, "NV0077", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 96, 1, "NV0095", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 5, 1, "NV0004", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 95, 1, "NV0094", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 97, 1, "NV0096", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 85, 1, "NV0084", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 6, 1, "NV0005", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 89, 1, "NV0088", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 1, 1, "NV0001", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 8, 1, "NV0007", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 18, 1, "NV0007", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 76, 1, "NV0075", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 80, 1, "NV0079", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 3, 1, "NV0002", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 88, 1, "NV0087", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 87, 1, "NV0086", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 10, 1, "NV0009", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 4, 1, "NV0003", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 77, 1, "NV0076", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 81, 1, "NV0080", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 7, 1, "NV0006", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 9, 1, "NV0008", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 86, 1, "NV0085", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 75, 1, "NV0074", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 2, 1, "NV0001", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Đại học Bách Khoa", "khá" },
                    { 94, 1, "NV0093", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 93, 1, "NV0092", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 21, 1, "NV0020", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 72, 1, "NV0071", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 98, 1, "NV0097", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 55, 1, "NV0054", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 30, 1, "NV0029", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 31, 1, "NV0030", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 54, 1, "NV0053", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 53, 1, "NV0052", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 32, 1, "NV0031", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 33, 1, "NV0032", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 52, 1, "NV0051", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 51, 1, "NV0050", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 34, 1, "NV0033", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 35, 1, "NV0034", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 50, 1, "NV0049", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 49, 1, "NV0048", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 36, 1, "NV0035", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 48, 1, "NV0047", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 37, 1, "NV0036", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 47, 1, "NV0046", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 38, 1, "NV0037", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 46, 1, "NV0045", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 39, 1, "NV0038", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 45, 1, "NV0044", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 40, 1, "NV0039", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 44, 1, "NV0043", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 41, 1, "NV0040", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 43, 1, "NV0042", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 42, 1, "NV0041", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 29, 1, "NV0028", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NgoaiNgu",
                columns: new[] { "id", "idDanhMucNgoaiNgu", "maNhanVien", "ngayCap", "noiCap", "trinhDo" },
                values: new object[,]
                {
                    { 28, 1, "NV0027", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 56, 1, "NV0055", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 27, 1, "NV0026", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 13, 1, "NV0012", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 99, 1, "NV0098", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 14, 1, "NV0013", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 100, 1, "NV0099", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 71, 1, "NV0070", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 15, 1, "NV0014", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 70, 1, "NV0069", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 16, 1, "NV0015", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 69, 1, "NV0068", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 17, 1, "NV0016", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 68, 1, "NV0067", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 67, 1, "NV0066", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 57, 1, "NV0056", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 19, 1, "NV0018", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 83, 1, "NV0082", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 20, 1, "NV0019", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 58, 1, "NV0057", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 26, 1, "NV0025", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 59, 1, "NV0058", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 25, 1, "NV0024", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 60, 1, "NV0059", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 24, 1, "NV0023", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 61, 1, "NV0060", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 62, 1, "NV0061", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 23, 1, "NV0022", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 63, 1, "NV0062", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 22, 1, "NV0021", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 64, 1, "NV0063", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 65, 1, "NV0064", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" },
                    { 66, 1, "NV0065", new DateTime(2017, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "Hà Nội", "khá" }
                });

            migrationBuilder.InsertData(
                table: "NguoiThan",
                columns: new[] { "id", "diaChi", "dienThoai", "gioiTinh", "idDanhMucNguoiThan", "khac", "maNhanVien", "ngaySinh", "ngheNghiep", "quanHe", "tenNguoiThan" },
                values: new object[,]
                {
                    { 1, "điện biên", "0914637668", true, 1, null, "NV0001", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Nguyễn Đăng Hải" },
                    { 2, "điện biên", "0914637668", true, 1, null, "NV0001", new DateTime(1965, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), "kinh doanh Tại Nhà", "Bố", "Mai Trung Hiếu" }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoVanHoa",
                columns: new[] { "id", "denThoiGian", "idChuyenMon", "idHinhThucDaoTao", "idTrinhDo", "maNhanVien", "tenTruong", "tuThoiGian" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 1, "NV0001", "Hà Nội", null },
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
                    { 1, "1", null, null, 1, null, "HD01", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(7682), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, false },
                    { 140, "1", null, null, 1, null, "HD140", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1826), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 141, "1", null, null, 1, null, "HD141", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1842), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 142, "1", null, null, 1, null, "HD142", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1854), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 143, "1", null, null, 1, null, "HD143", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1866), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 144, "1", null, null, 1, null, "HD144", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1880), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 145, "1", null, null, 1, null, "HD145", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1895), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 146, "1", null, null, 1, null, "HD146", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1911), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 147, "1", null, null, 1, null, "HD147", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1941), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 148, "1", null, null, 1, null, "HD148", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1957), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 149, "1", null, null, 1, null, "HD149", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1968), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 150, "1", null, null, 1, null, "HD150", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1982), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 151, "1", null, null, 1, null, "HD151", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1999), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 152, "1", null, null, 1, null, "HD152", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2016), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 153, "1", null, null, 1, null, "HD153", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2034), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 154, "1", null, null, 1, null, "HD154", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2190), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 155, "1", null, null, 1, null, "HD155", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2204), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 156, "1", null, null, 1, null, "HD156", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2217), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 157, "1", null, null, 1, null, "HD157", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2231), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 158, "1", null, null, 1, null, "HD158", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2246), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 159, "1", null, null, 1, null, "HD159", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2258), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 160, "1", null, null, 1, null, "HD160", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2272), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 161, "1", null, null, 1, null, "HD161", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2285), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 162, "1", null, null, 1, null, "HD162", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2300), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 139, "1", null, null, 1, null, "HD139", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1812), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 138, "1", null, null, 1, null, "HD138", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1797), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 137, "1", null, null, 1, null, "HD137", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1782), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 136, "1", null, null, 1, null, "HD136", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1769), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 112, "1", null, null, 1, null, "HD112", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1293), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 113, "1", null, null, 1, null, "HD113", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1308), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 114, "1", null, null, 1, null, "HD114", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1322), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 115, "1", null, null, 1, null, "HD115", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1337), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 116, "1", null, null, 1, null, "HD116", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1351), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 117, "1", null, null, 1, null, "HD117", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1365), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 118, "1", null, null, 1, null, "HD118", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1379), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 119, "1", null, null, 1, null, "HD119", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1391), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 120, "1", null, null, 1, null, "HD120", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1406), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 121, "1", null, null, 1, null, "HD121", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1424), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 122, "1", null, null, 1, null, "HD122", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1439), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 163, "1", null, null, 1, null, "HD163", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2314), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 123, "1", null, null, 1, null, "HD123", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1453), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 125, "1", null, null, 1, null, "HD125", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1481), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 126, "1", null, null, 1, null, "HD126", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1494), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 127, "1", null, null, 1, null, "HD127", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1506), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 128, "1", null, null, 1, null, "HD128", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1521), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 129, "1", null, null, 1, null, "HD129", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1536), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 130, "1", null, null, 1, null, "HD130", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1549), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 131, "1", null, null, 1, null, "HD131", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1561), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 132, "1", null, null, 1, null, "HD132", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1575), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 133, "1", null, null, 1, null, "HD133", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1589), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 134, "1", null, null, 1, null, "HD134", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1743), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 135, "1", null, null, 1, null, "HD135", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1757), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 124, "1", null, null, 1, null, "HD124", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1466), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 110, "1", null, null, 1, null, "HD110", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1263), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 164, "1", null, null, 1, null, "HD164", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2329), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 166, "1", null, null, 1, null, "HD166", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2356), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 195, "1", null, null, 1, null, "HD195", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2780), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 196, "1", null, null, 1, null, "HD196", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2794), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 197, "1", null, null, 1, null, "HD197", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2808), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 198, "1", null, null, 1, null, "HD198", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2822), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 199, "1", null, null, 1, null, "HD199", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2837), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 200, "1", null, null, 1, null, "HD200", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2852), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 201, "1", null, null, 1, null, "HD201", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2879), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 202, "1", null, null, 1, null, "HD202", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2898), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 203, "1", null, null, 1, null, "HD203", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2920), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 204, "1", null, null, 1, null, "HD204", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2935), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 205, "1", null, null, 1, null, "HD205", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2947), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 206, "1", null, null, 1, null, "HD206", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2965), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 207, "1", null, null, 1, null, "HD207", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2979), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 208, "1", null, null, 1, null, "HD208", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2996), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 209, "1", null, null, 1, null, "HD209", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3008), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 210, "1", null, null, 1, null, "HD210", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3021), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 211, "1", null, null, 1, null, "HD211", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3033), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 212, "1", null, null, 1, null, "HD212", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3052), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 213, "1", null, null, 1, null, "HD213", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3067), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 214, "1", null, null, 1, null, "HD214", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3082), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 215, "1", null, null, 1, null, "HD215", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3096), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 216, "1", null, null, 1, null, "HD216", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3109), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 217, "1", null, null, 1, null, "HD217", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3122), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 194, "1", null, null, 1, null, "HD194", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2769), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 193, "1", null, null, 1, null, "HD193", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2754), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 192, "1", null, null, 1, null, "HD192", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2741), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 191, "1", null, null, 1, null, "HD191", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2726), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 167, "1", null, null, 1, null, "HD167", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2372), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 168, "1", null, null, 1, null, "HD168", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2387), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 169, "1", null, null, 1, null, "HD169", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2401), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 170, "1", null, null, 1, null, "HD170", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2413), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 171, "1", null, null, 1, null, "HD171", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2427), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 172, "1", null, null, 1, null, "HD172", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2441), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 173, "1", null, null, 1, null, "HD173", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2455), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 174, "1", null, null, 1, null, "HD174", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2468), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 175, "1", null, null, 1, null, "HD175", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2479), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 176, "1", null, null, 1, null, "HD176", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2493), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 177, "1", null, null, 1, null, "HD177", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2509), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 165, "1", null, null, 1, null, "HD165", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2341), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 178, "1", null, null, 1, null, "HD178", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2524), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 180, "1", null, null, 1, null, "HD180", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2560), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 181, "1", null, null, 1, null, "HD181", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2576), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 182, "1", null, null, 1, null, "HD182", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2590), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 183, "1", null, null, 1, null, "HD183", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2607), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 184, "1", null, null, 1, null, "HD184", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2624), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 185, "1", null, null, 1, null, "HD185", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2638), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 186, "1", null, null, 1, null, "HD186", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2649), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 187, "1", null, null, 1, null, "HD187", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2662), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 188, "1", null, null, 1, null, "HD188", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2678), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 189, "1", null, null, 1, null, "HD189", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2698), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 190, "1", null, null, 1, null, "HD190", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2712), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 179, "1", null, null, 1, null, "HD179", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(2546), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 218, "1", null, null, 1, null, "HD218", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3134), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 109, "1", null, null, 1, null, "HD109", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1247), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 107, "1", null, null, 1, null, "HD107", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1219), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 30, "1", null, null, 1, null, "HD30", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(100), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 31, "1", null, null, 1, null, "HD31", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(113), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 32, "1", null, null, 1, null, "HD32", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(126), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 33, "1", null, null, 1, null, "HD33", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(141), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 34, "1", null, null, 1, null, "HD34", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(156), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 35, "1", null, null, 1, null, "HD35", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(170), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 36, "1", null, null, 1, null, "HD36", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(185), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 37, "1", null, null, 1, null, "HD37", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(200), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 38, "1", null, null, 1, null, "HD38", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(214), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 39, "1", null, null, 1, null, "HD39", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(227), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 40, "1", null, null, 1, null, "HD40", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(260), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 41, "1", null, null, 1, null, "HD41", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(279), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 42, "1", null, null, 1, null, "HD42", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(294), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 43, "1", null, null, 1, null, "HD43", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(309), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 44, "1", null, null, 1, null, "HD44", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(322), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 45, "1", null, null, 1, null, "HD45", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(336), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 46, "1", null, null, 1, null, "HD46", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(348), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 47, "1", null, null, 1, null, "HD47", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(360), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 48, "1", null, null, 1, null, "HD48", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(377), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 49, "1", null, null, 1, null, "HD49", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(392), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 50, "1", null, null, 1, null, "HD50", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(408), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 51, "1", null, null, 1, null, "HD51", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(421), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 52, "1", null, null, 1, null, "HD52", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(435), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 29, "1", null, null, 1, null, "HD29", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(86), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 28, "1", null, null, 1, null, "HD28", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(73), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 27, "1", null, null, 1, null, "HD27", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(60), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 26, "1", null, null, 1, null, "HD26", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(48), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 2, "1", null, null, 1, null, "HD01", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9580), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 3, "1", null, null, 1, null, "HD03", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9708), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 4, "1", null, null, 1, null, "HD04", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9729), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 5, "1", null, null, 1, null, "HD05", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9745), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 6, "1", null, null, 1, null, "HD06", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9757), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 7, "1", null, null, 1, null, "HD07", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9774), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 8, "1", null, null, 1, null, "HD08", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 9, "1", null, null, 1, null, "HD09", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9808), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 10, "1", null, null, 1, null, "HD10", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9821), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 11, "1", null, null, 1, null, "HD11", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9836), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 12, "1", null, null, 1, null, "HD12", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9851), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 53, "1", null, null, 1, null, "HD53", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(448), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 13, "1", null, null, 1, null, "HD13", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9864), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 15, "1", null, null, 1, null, "HD15", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9892), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 16, "1", null, null, 1, null, "HD16", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9907), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 17, "1", null, null, 1, null, "HD17", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9923), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 18, "1", null, null, 1, null, "HD18", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9937), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 19, "1", null, null, 1, null, "HD19", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 20, "1", null, null, 1, null, "HD20", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9966), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 21, "1", null, null, 1, null, "HD21", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9979), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 22, "1", null, null, 1, null, "HD22", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9993), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 23, "1", null, null, 1, null, "HD23", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(6), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 24, "1", null, null, 1, null, "HD24", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(20), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 25, "1", null, null, 1, null, "HD25", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(36), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 14, "1", null, null, 1, null, "HD14", new DateTime(2021, 11, 6, 16, 19, 30, 740, DateTimeKind.Local).AddTicks(9879), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 108, "1", null, null, 1, null, "HD108", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1232), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 54, "1", null, null, 1, null, "HD54", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(466), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 56, "1", null, null, 1, null, "HD56", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(490), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 85, "1", null, null, 1, null, "HD85", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(886), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 86, "1", null, null, 1, null, "HD86", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(901), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 87, "1", null, null, 1, null, "HD87", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(915), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 88, "1", null, null, 1, null, "HD88", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(929), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 89, "1", null, null, 1, null, "HD89", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(944), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 90, "1", null, null, 1, null, "HD90", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(960), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 91, "1", null, null, 1, null, "HD91", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(975), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 92, "1", null, null, 1, null, "HD92", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(988), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 111, "1", null, null, 1, null, "HD111", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1275), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 93, "1", null, null, 1, null, "HD93", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1014), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 94, "1", null, null, 1, null, "HD94", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1028), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 95, "1", null, null, 1, null, "HD95", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1044), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 96, "1", null, null, 1, null, "HD96", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1059), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 97, "1", null, null, 1, null, "HD97", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1074), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 98, "1", null, null, 1, null, "HD98", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1089), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 99, "1", null, null, 1, null, "HD99", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1105), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 100, "1", null, null, 1, null, "HD100", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1120), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 101, "1", null, null, 1, null, "HD101", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1133), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 102, "1", null, null, 1, null, "HD102", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1147), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 103, "1", null, null, 1, null, "HD103", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1161), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 104, "1", null, null, 1, null, "HD104", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1174), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 105, "1", null, null, 1, null, "HD105", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1188), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 106, "1", null, null, 1, null, "HD106", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(1203), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 84, "1", null, null, 1, null, "HD84", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(872), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 83, "1", null, null, 1, null, "HD83", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(858), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 82, "1", null, null, 1, null, "HD82", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(844), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 81, "1", null, null, 1, null, "HD81", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(829), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 57, "1", null, null, 1, null, "HD57", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(504), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 58, "1", null, null, 1, null, "HD58", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(518), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 59, "1", null, null, 1, null, "HD59", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(532), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 60, "1", null, null, 1, null, "HD60", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(546), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 61, "1", null, null, 1, null, "HD61", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(562), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 62, "1", null, null, 1, null, "HD62", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(577), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 63, "1", null, null, 1, null, "HD63", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(588), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 64, "1", null, null, 1, null, "HD64", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(601), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 65, "1", null, null, 1, null, "HD65", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(617), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 66, "1", null, null, 1, null, "HD66", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(630), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 67, "1", null, null, 1, null, "HD67", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(644), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 55, "1", null, null, 1, null, "HD55", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(478), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 68, "1", null, null, 1, null, "HD68", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(656), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 70, "1", null, null, 1, null, "HD70", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(686), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 71, "1", null, null, 1, null, "HD71", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(699), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 72, "1", null, null, 1, null, "HD72", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 73, "1", null, null, 1, null, "HD73", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(727), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "id", "bacLuong", "ghiChu", "heSoLuong", "idNhomLuong", "luongCoBan", "maHopDong", "ngayHieuLuc", "ngayKetThuc", "phuCapKhac", "phuCapTrachNhiem", "thoiHanLenLuong", "tongLuong", "trangThai" },
                values: new object[,]
                {
                    { 74, "1", null, null, 1, null, "HD74", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(741), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 75, "1", null, null, 1, null, "HD75", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(754), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 76, "1", null, null, 1, null, "HD76", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(767), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 77, "1", null, null, 1, null, "HD77", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(780), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 78, "1", null, null, 1, null, "HD78", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(793), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 79, "1", null, null, 1, null, "HD79", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(805), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 80, "1", null, null, 1, null, "HD80", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(817), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 69, "1", null, null, 1, null, "HD69", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(671), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true },
                    { 219, "1", null, null, 1, null, "HD219", new DateTime(2021, 11, 6, 16, 19, 30, 741, DateTimeKind.Local).AddTicks(3146), new DateTime(2022, 3, 21, 13, 26, 0, 0, DateTimeKind.Unspecified), null, null, "một năm", null, true }
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
                name: "Anh");

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
