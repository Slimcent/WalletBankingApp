using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Transaction_Mode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c9d352f-bfb6-4c22-9e15-b8eb863b854c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca6d82d-b928-4ebf-bce6-b266f3152837");

            migrationBuilder.AddColumn<int>(
                name: "TransactionMode",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "7bc5ca0d-9ad1-4c41-baa7-46216f37fc48", "d794d3a0-01e1-444b-843b-b90a8d0bd080", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(2018), null, "Admin", "ADMIN", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(3014), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "c1f33b27-d297-4cdc-accd-d956cc762f56", "a9fc4a23-aeca-4132-9e4d-28ed21a269e6", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(3915), null, "Manager", "MANAGER", new DateTime(2021, 11, 25, 16, 18, 37, 849, DateTimeKind.Local).AddTicks(3929), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bc5ca0d-9ad1-4c41-baa7-46216f37fc48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1f33b27-d297-4cdc-accd-d956cc762f56");

            migrationBuilder.DropColumn(
                name: "TransactionMode",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "1c9d352f-bfb6-4c22-9e15-b8eb863b854c", "70b18e7b-76fe-495f-8da1-f083830078dc", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(6410), null, "Admin", "ADMIN", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(8128), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "eca6d82d-b928-4ebf-bce6-b266f3152837", "abf926a5-c8a4-4c32-979c-b35cda7585d5", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(9037), null, "Manager", "MANAGER", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(9054), null });
        }
    }
}
