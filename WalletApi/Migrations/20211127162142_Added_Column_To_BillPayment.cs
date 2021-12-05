using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Added_Column_To_BillPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c26195-a09d-4023-a70e-4a3a2f3934c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90719d3-8ce7-4643-acf4-a20299068ed7");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bills",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 21, 40, 615, DateTimeKind.Local).AddTicks(3062), new DateTime(2021, 11, 27, 17, 21, 40, 615, DateTimeKind.Local).AddTicks(3897) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 21, 40, 615, DateTimeKind.Local).AddTicks(4643), new DateTime(2021, 11, 27, 17, 21, 40, 615, DateTimeKind.Local).AddTicks(4654) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "e37c42a8-98cc-4803-ae36-71540bc81254", "5d5080b2-3a6e-443c-a789-4047c84d6795", new DateTime(2021, 11, 27, 17, 21, 40, 611, DateTimeKind.Local).AddTicks(9858), null, "Admin", "ADMIN", new DateTime(2021, 11, 27, 17, 21, 40, 612, DateTimeKind.Local).AddTicks(1419), null },
                    { "93df58cf-9e81-4595-8b3c-66df9fab069a", "78bdd33c-c0b4-4bcb-b64c-653878119edc", new DateTime(2021, 11, 27, 17, 21, 40, 612, DateTimeKind.Local).AddTicks(2501), null, "Manager", "MANAGER", new DateTime(2021, 11, 27, 17, 21, 40, 612, DateTimeKind.Local).AddTicks(2516), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 21, 40, 616, DateTimeKind.Local).AddTicks(6480), new DateTime(2021, 11, 27, 17, 21, 40, 616, DateTimeKind.Local).AddTicks(6494) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 21, 40, 616, DateTimeKind.Local).AddTicks(5070), new DateTime(2021, 11, 27, 17, 21, 40, 616, DateTimeKind.Local).AddTicks(5769) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93df58cf-9e81-4595-8b3c-66df9fab069a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e37c42a8-98cc-4803-ae36-71540bc81254");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 2, 2, 225, DateTimeKind.Local).AddTicks(8702), new DateTime(2021, 11, 27, 17, 2, 2, 225, DateTimeKind.Local).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 2, 2, 226, DateTimeKind.Local).AddTicks(305), new DateTime(2021, 11, 27, 17, 2, 2, 226, DateTimeKind.Local).AddTicks(320) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "b90719d3-8ce7-4643-acf4-a20299068ed7", "809a936c-8723-47ed-8234-2a2d4a3f5372", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(6999), null, "Admin", "ADMIN", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(8879), null },
                    { "a1c26195-a09d-4023-a70e-4a3a2f3934c2", "88b5f9f5-fa02-4a56-890a-94226f666cf4", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(9932), null, "Manager", "MANAGER", new DateTime(2021, 11, 27, 17, 2, 2, 222, DateTimeKind.Local).AddTicks(9947), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 2, 2, 227, DateTimeKind.Local).AddTicks(1151), new DateTime(2021, 11, 27, 17, 2, 2, 227, DateTimeKind.Local).AddTicks(1162) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 17, 2, 2, 226, DateTimeKind.Local).AddTicks(9619), new DateTime(2021, 11, 27, 17, 2, 2, 227, DateTimeKind.Local).AddTicks(291) });
        }
    }
}
