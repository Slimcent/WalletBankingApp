using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Made_Address_Table_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a8af085-247a-4e8a-89b3-e5698fa7cc11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67802be3-98c8-4cb7-9ee4-e5b639bb148a");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "PlotNo",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(4690), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(5097) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(5387), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "f7c16468-8dd9-4f58-b29b-50db714d300d", "39ee5aa5-5f75-496a-a650-a0be36990bbe", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(872), null, "Admin", "ADMIN", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(1315), null },
                    { "4d414dfe-6f9c-4bd8-a964-df1afaa725bd", "a6094ea1-1f8b-400b-9941-15c255a1389e", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(1669), null, "Manager", "MANAGER", new DateTime(2022, 4, 1, 14, 56, 18, 497, DateTimeKind.Local).AddTicks(1673), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(2321), new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(1987), new DateTime(2022, 4, 1, 14, 56, 18, 499, DateTimeKind.Local).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(9110), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(9112) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 4, 1, 14, 56, 18, 498, DateTimeKind.Local).AddTicks(8950) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d414dfe-6f9c-4bd8-a964-df1afaa725bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c16468-8dd9-4f58-b29b-50db714d300d");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlotNo",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(287), new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(758) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(1185) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "67802be3-98c8-4cb7-9ee4-e5b639bb148a", "b3e75703-db7e-4cfb-9760-482c5d60e585", new DateTime(2022, 4, 1, 13, 21, 39, 823, DateTimeKind.Local).AddTicks(2507), null, "Admin", "ADMIN", new DateTime(2022, 4, 1, 13, 21, 39, 823, DateTimeKind.Local).AddTicks(3008), null },
                    { "4a8af085-247a-4e8a-89b3-e5698fa7cc11", "d09bf0e5-e674-41f6-895f-fc49d82091c5", new DateTime(2022, 4, 1, 13, 21, 39, 823, DateTimeKind.Local).AddTicks(3329), null, "Manager", "MANAGER", new DateTime(2022, 4, 1, 13, 21, 39, 823, DateTimeKind.Local).AddTicks(3333), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 13, 21, 39, 826, DateTimeKind.Local).AddTicks(2817), new DateTime(2022, 4, 1, 13, 21, 39, 826, DateTimeKind.Local).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 13, 21, 39, 826, DateTimeKind.Local).AddTicks(2280), new DateTime(2022, 4, 1, 13, 21, 39, 826, DateTimeKind.Local).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(7677), new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(7680) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(7020), new DateTime(2022, 4, 1, 13, 21, 39, 825, DateTimeKind.Local).AddTicks(7385) });
        }
    }
}
