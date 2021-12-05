using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Seeded_Data_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93df58cf-9e81-4595-8b3c-66df9fab069a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e37c42a8-98cc-4803-ae36-71540bc81254");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 23, 7, 23, 305, DateTimeKind.Local).AddTicks(1654), new DateTime(2021, 11, 27, 23, 7, 23, 334, DateTimeKind.Local).AddTicks(3144) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 23, 7, 23, 334, DateTimeKind.Local).AddTicks(4883), new DateTime(2021, 11, 27, 23, 7, 23, 334, DateTimeKind.Local).AddTicks(4898) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "aebb4f99-87ed-4eb9-ac87-19e2652706f7", "f5811810-3239-41f8-9400-2e9aab0f69cf", new DateTime(2021, 11, 27, 23, 7, 23, 302, DateTimeKind.Local).AddTicks(3743), null, "Admin", "ADMIN", new DateTime(2021, 11, 27, 23, 7, 23, 302, DateTimeKind.Local).AddTicks(4794), null },
                    { "9711ffd2-1fed-42ac-89bd-c3d95d73c781", "c737b2af-1319-4090-bdd6-dc4e990742ff", new DateTime(2021, 11, 27, 23, 7, 23, 302, DateTimeKind.Local).AddTicks(5633), null, "Manager", "MANAGER", new DateTime(2021, 11, 27, 23, 7, 23, 302, DateTimeKind.Local).AddTicks(5645), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 23, 7, 23, 336, DateTimeKind.Local).AddTicks(4378), new DateTime(2021, 11, 27, 23, 7, 23, 336, DateTimeKind.Local).AddTicks(4388) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 27, 23, 7, 23, 336, DateTimeKind.Local).AddTicks(3083), new DateTime(2021, 11, 27, 23, 7, 23, 336, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.InsertData(
                table: "Data",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "NetworkProvider", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("ce185a95-533e-425c-adf4-a5770766564b"), new DateTime(2021, 11, 27, 23, 7, 23, 335, DateTimeKind.Local).AddTicks(3206), null, "Mtn", new DateTime(2021, 11, 27, 23, 7, 23, 335, DateTimeKind.Local).AddTicks(3919), null },
                    { new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"), new DateTime(2021, 11, 27, 23, 7, 23, 335, DateTimeKind.Local).AddTicks(4598), null, "Airtel", new DateTime(2021, 11, 27, 23, 7, 23, 335, DateTimeKind.Local).AddTicks(4608), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9711ffd2-1fed-42ac-89bd-c3d95d73c781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aebb4f99-87ed-4eb9-ac87-19e2652706f7");

            migrationBuilder.DeleteData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"));

            migrationBuilder.DeleteData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"));

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
    }
}
