using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Bill_And_AirTime_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aff2951-dbfa-4f59-974f-a6a6c82ce747");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7288c87-06b2-4825-aad3-720ba433c758");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "fac62309-1ced-4280-a44c-74c16f86b6ca", "ec005a80-c350-4551-ab95-b1ac2be303d2", new DateTime(2021, 11, 26, 20, 14, 43, 51, DateTimeKind.Local).AddTicks(6945), null, "Admin", "ADMIN", new DateTime(2021, 11, 26, 20, 14, 43, 53, DateTimeKind.Local).AddTicks(3859), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "0e74b01e-0f8f-4448-a352-ea0c8cfd7e3c", "9efddbb8-4bb8-4882-a77e-ba6e5cfe6d4f", new DateTime(2021, 11, 26, 20, 14, 43, 53, DateTimeKind.Local).AddTicks(5507), null, "Manager", "MANAGER", new DateTime(2021, 11, 26, 20, 14, 43, 53, DateTimeKind.Local).AddTicks(5517), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e74b01e-0f8f-4448-a352-ea0c8cfd7e3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac62309-1ced-4280-a44c-74c16f86b6ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "8aff2951-dbfa-4f59-974f-a6a6c82ce747", "f34e3cdc-9b53-4a09-9cad-5cddbed6db76", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(1883), null, "Admin", "ADMIN", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(3553), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "d7288c87-06b2-4825-aad3-720ba433c758", "d0e5ea67-8d29-4d37-9372-0b2ac4e3afbc", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(4396), null, "Manager", "MANAGER", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(4407), null });
        }
    }
}
