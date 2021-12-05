using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class TransactonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50060db9-5730-4f8f-9bf1-bbdcb3ca047e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5289b015-d38b-49cd-9fd6-5a5e01e69825");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "5fb493d8-0296-4d05-b24c-23cf64ca6014", "4631770c-7b59-4ee1-a12f-ffed5f9ff101", new DateTime(2021, 11, 24, 18, 10, 16, 364, DateTimeKind.Local).AddTicks(8294), null, "Admin", "ADMIN", new DateTime(2021, 11, 24, 18, 10, 16, 365, DateTimeKind.Local).AddTicks(554), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "02192aef-247f-4d74-9f61-17bfead4c509", "b4f85bbe-e1e9-4e08-a8ca-0bf0f074d219", new DateTime(2021, 11, 24, 18, 10, 16, 365, DateTimeKind.Local).AddTicks(1909), null, "Manager", "MANAGER", new DateTime(2021, 11, 24, 18, 10, 16, 365, DateTimeKind.Local).AddTicks(1931), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02192aef-247f-4d74-9f61-17bfead4c509");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fb493d8-0296-4d05-b24c-23cf64ca6014");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "50060db9-5730-4f8f-9bf1-bbdcb3ca047e", "48a7158a-9bc1-48af-a590-276771146363", new DateTime(2021, 11, 18, 10, 12, 14, 321, DateTimeKind.Local).AddTicks(9115), null, "Admin", "ADMIN", new DateTime(2021, 11, 18, 10, 12, 14, 322, DateTimeKind.Local).AddTicks(835), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "5289b015-d38b-49cd-9fd6-5a5e01e69825", "7fcdadad-f913-413f-9c53-7aa6d13fa974", new DateTime(2021, 11, 18, 10, 12, 14, 322, DateTimeKind.Local).AddTicks(1766), null, "Manager", "MANAGER", new DateTime(2021, 11, 18, 10, 12, 14, 322, DateTimeKind.Local).AddTicks(1777), null });
        }
    }
}
