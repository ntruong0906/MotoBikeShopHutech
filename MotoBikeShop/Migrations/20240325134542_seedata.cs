using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class seedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Loai",
                columns: new[] { "MaLoai", "Hinh", "MoTa", "TenLoai", "TenLoaiAlias" },
                values: new object[,]
                {
                    { 1, "xecon.png", "Xe này để đua ", "Xe Côn", "xe-con" },
                    { 2, "xega.png", "Xe này để tán gái", "Xe ga", "xe-ga" },
                    { 3, "xeso.png", "Xe này để đi làm", "Xe số", "xe-so" }
                });

            migrationBuilder.InsertData(
                table: "NhaCungCap",
                columns: new[] { "MaNCC", "DiaChi", "DienThoai", "Email", "Logo", "MoTa", "NguoiLienLac", "TenCongTy" },
                values: new object[,]
                {
                    { "NCC001", "Địa chỉ ABC", "123456789", "info@gmail.com", "logo1.png", "nhà cung cấp vip1", "Người liên hệ ABC", "Công ty ABC" },
                    { "NCC002", "Địa chỉ XYZ", "987654321", "info@gmail.com", "logo2.png", "nhà cung cấp vip2", "Người liên hệ XYZ", "Công ty XYZ" },
                    { "NCC003", "Địa chỉ DEF", "555555555", "info@gmail.com", "logo3.png", "nhà cung cấp vip3", "Người liên hệ DEF", "Công ty DEF" }
                });

            migrationBuilder.InsertData(
                table: "HangHoa",
                columns: new[] { "MaHH", "DonGia", "GiamGia", "Hinh", "MaLoai", "MaNCC", "MoTa", "MoTaDonVi", "NgaySX", "SoLanXem", "TenAlias", "TenHH" },
                values: new object[,]
                {
                    { 1, 400000.0, 9999999.0, "xecon.png", 1, "NCC002", "xe này cực đẹp", "VND", new DateTime(2024, 3, 25, 20, 45, 41, 795, DateTimeKind.Local).AddTicks(9652), 99, "exciter", "Exciter" },
                    { 2, 300000.0, 9999999.0, "xega.png", 2, "NCC001", "xe này cực đẹp", "VND", new DateTime(2024, 3, 25, 20, 45, 41, 795, DateTimeKind.Local).AddTicks(9668), 99, "vario", "Vario" },
                    { 3, 100000.0, 9999999.0, "xeso.png", 3, "NCC003", "xe này cực đẹp", "VND", new DateTime(2024, 3, 25, 20, 45, 41, 795, DateTimeKind.Local).AddTicks(9669), 99, "wave-rsx", "Wave RSX" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "MaHH",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "MaHH",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "MaHH",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loai",
                keyColumn: "MaLoai",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loai",
                keyColumn: "MaLoai",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loai",
                keyColumn: "MaLoai",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNCC",
                keyValue: "NCC001");

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNCC",
                keyValue: "NCC002");

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNCC",
                keyValue: "NCC003");
        }
    }
}
