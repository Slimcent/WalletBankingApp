using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Staff_Delete_Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_UserId",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Address_StaffId",
                table: "Address");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a37beef7-53df-44dd-ba36-5e5291415e60");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a9208264-95d8-4d5a-abb5-a2237ca03cf9");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5077), new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5078) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5084), new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5084) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "018dd14d-b73e-47a5-802f-49d19bbf774e", "74a66f36-3609-48ab-8481-a027fc492765", new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(4697), null, "Admin", "ADMIN", new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(4724), null },
            //        { "b830ac33-f7c0-459d-8ed6-649f9adb4030", "c87a2388-575f-45d4-81cd-853c0fb6e699", new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(4729), null, "Manager", "MANAGER", new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(4729), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5303), new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5303) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5298), new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5300) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5168), new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5168) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5161), new DateTime(2022, 4, 15, 20, 2, 6, 62, DateTimeKind.Local).AddTicks(5163) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_UserId",
                table: "StaffProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StaffId",
                table: "Address",
                column: "StaffId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address",
                column: "StaffId",
                principalTable: "StaffProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_UserId",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Address_StaffId",
                table: "Address");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "018dd14d-b73e-47a5-802f-49d19bbf774e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "b830ac33-f7c0-459d-8ed6-649f9adb4030");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(6925), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(7110) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(7264), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(7266) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "a37beef7-53df-44dd-ba36-5e5291415e60", "9c9fcff2-1f42-442e-8ada-120a1d07c59b", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(7392), null, "Manager", "MANAGER", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(7394), null },
            //        { "a9208264-95d8-4d5a-abb5-a2237ca03cf9", "3ec88781-2079-42ea-a14e-578b1bf3737d", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(6698), null, "Admin", "ADMIN", new DateTime(2022, 4, 3, 16, 56, 18, 966, DateTimeKind.Local).AddTicks(7185), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2940), new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2942) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2649), new DateTime(2022, 4, 3, 16, 56, 18, 968, DateTimeKind.Local).AddTicks(2801) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9996), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9998) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9672), new DateTime(2022, 4, 3, 16, 56, 18, 967, DateTimeKind.Local).AddTicks(9844) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_UserId",
                table: "StaffProfile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StaffId",
                table: "Address",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address",
                column: "StaffId",
                principalTable: "StaffProfile",
                principalColumn: "Id");
        }
    }
}
