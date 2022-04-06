using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Removed_AddressId_From_Staff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Address_AddressId1",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_AddressId1",
                table: "StaffProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d414dfe-6f9c-4bd8-a964-df1afaa725bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c16468-8dd9-4f58-b29b-50db714d300d");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "StaffProfile");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "StaffProfile");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(6925), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(7264), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(7266) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "a9208264-95d8-4d5a-abb5-a2237ca03cf9", "3ec88781-2079-42ea-a14e-578b1bf3737d", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(6698), null, "Admin", "ADMIN", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(7185), null },
                    { "a37beef7-53df-44dd-ba36-5e5291415e60", "9c9fcff2-1f42-442e-8ada-120a1d07c59b", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(7392), null, "Manager", "MANAGER", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(7394), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2940), new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2942) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2649), new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9996), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9998) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9672), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9844) });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StaffId",
                table: "Address",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address",
                column: "StaffId",
                principalTable: "StaffProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StaffId",
                table: "Address");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37beef7-53df-44dd-ba36-5e5291415e60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9208264-95d8-4d5a-abb5-a2237ca03cf9");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "StaffProfile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId1",
                table: "StaffProfile",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(4690), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(5097) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(5387), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "f7c16468-8dd9-4f58-b29b-50db714d300d", "39ee5aa5-5f75-496a-a650-a0be36990bbe", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(872), null, "Admin", "ADMIN", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(1315), null },
                    { "4d414dfe-6f9c-4bd8-a964-df1afaa725bd", "a6094ea1-1f8b-400b-9941-15c255a1389e", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(1669), null, "Manager", "MANAGER", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(1673), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(2321), new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(1987), new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(9110), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(9112) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(8950) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_AddressId1",
                table: "StaffProfile",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Address_AddressId1",
                table: "StaffProfile",
                column: "AddressId1",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
