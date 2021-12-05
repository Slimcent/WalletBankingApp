using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Transaction_Sender_And_Receiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02192aef-247f-4d74-9f61-17bfead4c509");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fb493d8-0296-4d05-b24c-23cf64ca6014");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverWalletId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderWalletId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "1c9d352f-bfb6-4c22-9e15-b8eb863b854c", "70b18e7b-76fe-495f-8da1-f083830078dc", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(6410), null, "Admin", "ADMIN", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(8128), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "eca6d82d-b928-4ebf-bce6-b266f3152837", "abf926a5-c8a4-4c32-979c-b35cda7585d5", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(9037), null, "Manager", "MANAGER", new DateTime(2021, 11, 25, 15, 41, 18, 374, DateTimeKind.Local).AddTicks(9054), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c9d352f-bfb6-4c22-9e15-b8eb863b854c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca6d82d-b928-4ebf-bce6-b266f3152837");

            migrationBuilder.DropColumn(
                name: "ReceiverWalletId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderWalletId",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "5fb493d8-0296-4d05-b24c-23cf64ca6014", "4631770c-7b59-4ee1-a12f-ffed5f9ff101", new DateTime(2021, 11, 24, 18, 10, 16, 364, DateTimeKind.Local).AddTicks(8294), null, "Admin", "ADMIN", new DateTime(2021, 11, 24, 18, 10, 16, 365, DateTimeKind.Local).AddTicks(554), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "02192aef-247f-4d74-9f61-17bfead4c509", "b4f85bbe-e1e9-4e08-a8ca-0bf0f074d219", new DateTime(2021, 11, 24, 18, 10, 16, 365, DateTimeKind.Local).AddTicks(1909), null, "Manager", "MANAGER", new DateTime(2021, 11, 24, 18, 10, 16, 365, DateTimeKind.Local).AddTicks(1931), null });
        }
    }
}
