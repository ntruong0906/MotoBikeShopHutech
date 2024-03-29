using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class nhanxet1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 3, 29, 18, 19, 41, 896, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 3, 29, 18, 19, 41, 896, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 3, 29, 18, 19, 41, 896, DateTimeKind.Local).AddTicks(6218));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 3, 29, 18, 17, 12, 25, DateTimeKind.Local).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 3, 29, 18, 17, 12, 25, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 3, 29, 18, 17, 12, 25, DateTimeKind.Local).AddTicks(4728));
        }
    }
}
