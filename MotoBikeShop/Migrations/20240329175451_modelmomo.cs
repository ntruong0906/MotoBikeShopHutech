using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class modelmomo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collectionLinkRequests",
                columns: table => new
                {
                    requestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    orderInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partnerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    redirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ipnUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<long>(type: "bigint", nullable: false),
                    orderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extraData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autoCapture = table.Column<bool>(type: "bit", nullable: false),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectionLinkRequests", x => x.requestId);
                });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 3, 30, 0, 54, 50, 267, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 3, 30, 0, 54, 50, 267, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 3, 30, 0, 54, 50, 267, DateTimeKind.Local).AddTicks(676));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectionLinkRequests");

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
    }
}
