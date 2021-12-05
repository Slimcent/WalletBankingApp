using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Seeding_Bills_And_AirTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e74b01e-0f8f-4448-a352-ea0c8cfd7e3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac62309-1ced-4280-a44c-74c16f86b6ca");

            migrationBuilder.CreateTable(
                name: "AirTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StampDutyCharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StampDuty = table.Column<decimal>(type: "decimal(38,2)", nullable: false),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StampDutyCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StampDutyCharges_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AirTimes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "NetworkProvider", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"), new DateTime(2021, 11, 27, 17, 2, 2, 225, DateTimeKind.Local).AddTicks(8702), null, "Mtn", new DateTime(2021, 11, 27, 17, 2, 2, 225, DateTimeKind.Local).AddTicks(9564), null },
                    { new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"), new DateTime(2021, 11, 27, 17, 2, 2, 226, DateTimeKind.Local).AddTicks(305), null, "Airtel", new DateTime(2021, 11, 27, 17, 2, 2, 226, DateTimeKind.Local).AddTicks(320), null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "b90719d3-8ce7-4643-acf4-a20299068ed7", "809a936c-8723-47ed-8234-2a2d4a3f5372", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(6999), null, "Admin", "ADMIN", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(8879), null },
                    { "a1c26195-a09d-4023-a70e-4a3a2f3934c2", "88b5f9f5-fa02-4a56-890a-94226f666cf4", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(9932), null, "Manager", "MANAGER", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(9947), null }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Amount", "BillName", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"), 6500m, "DSTV", new DateTime(2021, 11, 27, 17, 2, 2, 226, DateTimeKind.Local).AddTicks(9619), null, new DateTime(2021, 11, 27, 17, 2, 2, 227, DateTimeKind.Local).AddTicks(291), null },
                    { new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"), 3000m, "GOTV", new DateTime(2021, 11, 27, 17, 2, 2, 227, DateTimeKind.Local).AddTicks(1151), null, new DateTime(2021, 11, 27, 17, 2, 2, 227, DateTimeKind.Local).AddTicks(1162), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StampDutyCharges_UserId",
                table: "StampDutyCharges",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirTimes");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "StampDutyCharges");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c26195-a09d-4023-a70e-4a3a2f3934c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90719d3-8ce7-4643-acf4-a20299068ed7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "fac62309-1ced-4280-a44c-74c16f86b6ca", "ec005a80-c350-4551-ab95-b1ac2be303d2", new DateTime(2021, 11, 26, 20, 14, 43, 51, DateTimeKind.Local).AddTicks(6945), null, "Admin", "ADMIN", new DateTime(2021, 11, 26, 20, 14, 43, 53, DateTimeKind.Local).AddTicks(3859), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "0e74b01e-0f8f-4448-a352-ea0c8cfd7e3c", "9efddbb8-4bb8-4882-a77e-ba6e5cfe6d4f", new DateTime(2021, 11, 26, 20, 14, 43, 53, DateTimeKind.Local).AddTicks(5507), null, "Manager", "MANAGER", new DateTime(2021, 11, 26, 20, 14, 43, 53, DateTimeKind.Local).AddTicks(5517), null });
        }
    }
}
