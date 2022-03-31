using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Address_Table_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ba8e0a4-7117-49e0-a239-0d853dfc22e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99b4fb24-028c-41f0-bf05-c3c6ca6e5990");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5199), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5405) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5580), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "eb912cd4-cd95-4b45-9412-a6de00d6b9a7", "7cba6282-9e65-430c-a4ec-dbccb1e46a5f", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2306), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2603), null },
                    { "c07b4c67-2db9-44f5-89e8-cebe95d26cb6", "47fc3213-33d5-4320-9aba-13ed00040c48", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2789), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2790), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(3313), new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(2935), new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(9186), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(8808), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(9035) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c07b4c67-2db9-44f5-89e8-cebe95d26cb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb912cd4-cd95-4b45-9412-a6de00d6b9a7");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Address");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(1991), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(2471), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "99b4fb24-028c-41f0-bf05-c3c6ca6e5990", "bbd8d6d2-d29e-4e7c-b819-857cef75aa11", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(8009), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(8615), null },
                    { "0ba8e0a4-7117-49e0-a239-0d853dfc22e4", "bcb4184c-b6de-4695-a28c-c529e6f18006", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(9270), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(9272), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(326), new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(327) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(21), new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(6288), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(6289) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(5962), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(6139) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");
        }
    }
}
