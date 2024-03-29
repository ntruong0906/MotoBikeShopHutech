using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class modelResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectionLinkRequests");

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    partnerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    accessKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    localMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responseTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    errorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extraData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.partnerCode);
                });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 3, 30, 1, 22, 50, 112, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 3, 30, 1, 22, 50, 112, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 3, 30, 1, 22, 50, 112, DateTimeKind.Local).AddTicks(3640));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.CreateTable(
                name: "collectionLinkRequests",
                columns: table => new
                {
                    requestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    amount = table.Column<long>(type: "bigint", nullable: false),
                    autoCapture = table.Column<bool>(type: "bit", nullable: false),
                    extraData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ipnUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderGroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partnerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    redirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storeId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
