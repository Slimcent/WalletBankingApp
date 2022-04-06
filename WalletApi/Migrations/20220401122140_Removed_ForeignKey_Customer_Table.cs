using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Removed_ForeignKey_Customer_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Address_AddressId",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_AddressId",
                table: "StaffProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2845b59f-e5c0-4dfd-8b46-3130dae4197f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c750465-7a6c-476c-910e-4f4f236ded08");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId1",
                table: "StaffProfile",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_AddressId1",
                table: "StaffProfile",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Address_AddressId1",
                table: "StaffProfile",
                column: "AddressId1",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Address_AddressId1",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_AddressId1",
                table: "StaffProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a8af085-247a-4e8a-89b3-e5698fa7cc11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67802be3-98c8-4cb7-9ee4-e5b639bb148a");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "StaffProfile");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3101), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3296) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(3459) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "9c750465-7a6c-476c-910e-4f4f236ded08", "4d4f09d7-4696-4ec8-88a6-6e1b73f3475b", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(3737), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(4035), null },
                    { "2845b59f-e5c0-4dfd-8b46-3130dae4197f", "54b2358e-c103-4686-8ca4-59e3c23b7ef1", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(4233), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 51, 16, 810, DateTimeKind.Local).AddTicks(4235), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(9156), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(8838), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(9005) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(6169), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(6171) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(5841), new DateTime(2022, 3, 31, 23, 51, 16, 811, DateTimeKind.Local).AddTicks(6016) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_AddressId",
                table: "StaffProfile",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Address_AddressId",
                table: "StaffProfile",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
