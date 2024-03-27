using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CachThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CachVanChuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhiVanChuyen = table.Column<double>(type: "float", nullable: false),
                    MaTrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenCongTy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NguoiLienLac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    MaHH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    MoTaDonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySX = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false),
                    SoLanXem = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNCC = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.MaHH);
                    table.ForeignKey(
                        name: "FK_HangHoas_Loais_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loais",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangHoas_NhaCungCaps_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NhaCungCaps",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHds",
                columns: table => new
                {
                    MaCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaHH = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHds", x => x.MaCT);
                    table.ForeignKey(
                        name: "FK_ChiTietHds_HangHoas_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoas",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHds_HoaDons_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YeuThiches",
                columns: table => new
                {
                    MaYT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHH = table.Column<int>(type: "int", nullable: true),
                    MaKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayChon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuThiches", x => x.MaYT);
                    table.ForeignKey(
                        name: "FK_YeuThiches_HangHoas_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoas",
                        principalColumn: "MaHH");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHds_MaHD",
                table: "ChiTietHds",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHds_MaHH",
                table: "ChiTietHds",
                column: "MaHH");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaNCC",
                table: "HangHoas",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_YeuThiches_MaHH",
                table: "YeuThiches",
                column: "MaHH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHds");

            migrationBuilder.DropTable(
                name: "YeuThiches");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "HangHoas");

            migrationBuilder.DropTable(
                name: "Loais");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");
        }
    }
}
