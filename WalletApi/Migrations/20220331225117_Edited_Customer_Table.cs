using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Edited_Customer_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Wallets_WallettId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38598db6-a09d-4981-8365-e4ca9dab3445");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "518262ad-d7c0-471b-adfb-e59d2431b216");

            migrationBuilder.RenameColumn(
                name: "WallettId",
                table: "Customers",
                newName: "WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_WallettId",
                table: "Customers",
                newName: "IX_Customers_WalletId");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3101), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3296) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3459) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "9c750465-7a6c-476c-910e-4f4f236ded08", "4d4f09d7-4696-4ec8-88a6-6e1b73f3475b", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(3737), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(4035), null },
                    { "2845b59f-e5c0-4dfd-8b46-3130dae4197f", "54b2358e-c103-4686-8ca4-59e3c23b7ef1", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(4233), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(4235), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(9156), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(8838), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(9005) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(6169), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(6171) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(5841), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(6016) });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Wallets_WalletId",
                table: "Customers",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Wallets_WalletId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2845b59f-e5c0-4dfd-8b46-3130dae4197f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c750465-7a6c-476c-910e-4f4f236ded08");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "Customers",
                newName: "WallettId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_WalletId",
                table: "Customers",
                newName: "IX_Customers_WallettId");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3097), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3289) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3474), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "38598db6-a09d-4981-8365-e4ca9dab3445", "388465b5-2cf3-4a4f-951a-ac58a23d1adb", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(576), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(918), null },
                    { "518262ad-d7c0-471b-adfb-e59d2431b216", "7f9664ec-ecdd-4883-990b-506a2abb9674", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(1183), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(1185), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(9086), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(8757), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(8927) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(6075), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(5755), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(5923) });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Wallets_WallettId",
                table: "Customers",
                column: "WallettId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
