using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Bills_AirTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3fefc71-e7bf-4976-9c78-8ba7ad9e30c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c518d4-e6bf-4a75-87a8-c674b31b3576");

            migrationBuilder.AddColumn<string>(
                name: "BillName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkProvider",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StampDuty",
                table: "Transactions",
                type: "decimal(38,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "8aff2951-dbfa-4f59-974f-a6a6c82ce747", "f34e3cdc-9b53-4a09-9cad-5cddbed6db76", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(1883), null, "Admin", "ADMIN", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(3553), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "d7288c87-06b2-4825-aad3-720ba433c758", "d0e5ea67-8d29-4d37-9372-0b2ac4e3afbc", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(4396), null, "Manager", "MANAGER", new DateTime(2021, 11, 26, 19, 44, 36, 87, DateTimeKind.Local).AddTicks(4407), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aff2951-dbfa-4f59-974f-a6a6c82ce747");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7288c87-06b2-4825-aad3-720ba433c758");

            migrationBuilder.DropColumn(
                name: "BillName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "NetworkProvider",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StampDuty",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "a3fefc71-e7bf-4976-9c78-8ba7ad9e30c6", "4c17bfcd-9d18-4378-9087-f59572147141", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(251), null, "Admin", "ADMIN", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(1393), null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "f7c518d4-e6bf-4a75-87a8-c674b31b3576", "e3a0686f-4a3f-4bd0-aa93-8d6995042602", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(3016), null, "Manager", "MANAGER", new DateTime(2021, 11, 26, 8, 55, 56, 837, DateTimeKind.Local).AddTicks(3038), null });
        }
    }
}
