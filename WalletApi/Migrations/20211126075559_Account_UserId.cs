using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Account_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bc5ca0d-9ad1-4c41-baa7-46216f37fc48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1f33b27-d297-4cdc-accd-d956cc762f56");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "a3fefc71-e7bf-4976-9c78-8ba7ad9e30c6", "4c17bfcd-9d18-4378-9087-f59572147141", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(251), null, "Admin", "ADMIN", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(1393), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "f7c518d4-e6bf-4a75-87a8-c674b31b3576", "e3a0686f-4a3f-4bd0-aa93-8d6995042602", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(3016), null, "Manager", "MANAGER", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(3038), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3fefc71-e7bf-4976-9c78-8ba7ad9e30c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c518d4-e6bf-4a75-87a8-c674b31b3576");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "7bc5ca0d-9ad1-4c41-baa7-46216f37fc48", "d794d3a0-01e1-444b-843b-b90a8d0bd080", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(2018), null, "Admin", "ADMIN", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(3014), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "c1f33b27-d297-4cdc-accd-d956cc762f56", "a9fc4a23-aeca-4132-9e4d-28ed21a269e6", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(3915), null, "Manager", "MANAGER", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(3929), null });
        }
    }
}
