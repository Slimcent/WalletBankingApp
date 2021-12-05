using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "50060db9-5730-4f8f-9bf1-bbdcb3ca047e", "48a7158a-9bc1-48af-a590-276771146363", new DateTime(2021, 11, 18, 10, 12, 14, 321, DateTimeKind.Local).AddTicks(9115), null, "Admin", "ADMIN", new DateTime(2021, 11, 18, 10, 12, 14, 322, DateTimeKind.Local).AddTicks(835), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "5289b015-d38b-49cd-9fd6-5a5e01e69825", "7fcdadad-f913-413f-9c53-7aa6d13fa974", new DateTime(2021, 11, 18, 10, 12, 14, 322, DateTimeKind.Local).AddTicks(1766), null, "Manager", "MANAGER", new DateTime(2021, 11, 18, 10, 12, 14, 322, DateTimeKind.Local).AddTicks(1777), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50060db9-5730-4f8f-9bf1-bbdcb3ca047e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5289b015-d38b-49cd-9fd6-5a5e01e69825");
        }
    }
}
