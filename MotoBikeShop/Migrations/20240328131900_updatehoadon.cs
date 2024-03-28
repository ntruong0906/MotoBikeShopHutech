using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class updatehoadon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiMaTrangThai",
                table: "HoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HoaDons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TrangThais",
                columns: table => new
                {
                    MaTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThais", x => x.MaTrangThai);
                });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 3, 28, 20, 18, 59, 885, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 3, 28, 20, 18, 59, 885, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 3, 28, 20, 18, 59, 885, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TrangThaiMaTrangThai",
                table: "HoaDons",
                column: "TrangThaiMaTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_UserId",
                table: "HoaDons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_AspNetUsers_UserId",
                table: "HoaDons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_TrangThais_TrangThaiMaTrangThai",
                table: "HoaDons",
                column: "TrangThaiMaTrangThai",
                principalTable: "TrangThais",
                principalColumn: "MaTrangThai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_AspNetUsers_UserId",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_TrangThais_TrangThaiMaTrangThai",
                table: "HoaDons");

            migrationBuilder.DropTable(
                name: "TrangThais");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_TrangThaiMaTrangThai",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_UserId",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TrangThaiMaTrangThai",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HoaDons");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 3, 27, 17, 32, 42, 147, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 3, 27, 17, 32, 42, 147, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 3, 27, 17, 32, 42, 147, DateTimeKind.Local).AddTicks(1307));
        }
    }
}
