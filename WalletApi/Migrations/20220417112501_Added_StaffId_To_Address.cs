using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Added_StaffId_To_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_StaffProfile_Address_AddressId",
            //    table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_AddressId",
                table: "StaffProfile");

            //migrationBuilder.DeleteData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"));

            //migrationBuilder.DeleteData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"));

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a2ddaa4a-d48f-4867-8ab2-63ba8d8c4055");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "b77c7a08-c9a7-453f-a79c-1566fa5f5a27");

            //migrationBuilder.DeleteData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"));

            //migrationBuilder.DeleteData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"));

            //migrationBuilder.DeleteData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"));

            //migrationBuilder.DeleteData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "StaffProfile");

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StaffId",
                table: "Address",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Address_StaffProfile_StaffId",
            //    table: "Address",
            //    column: "StaffId",
            //    principalTable: "StaffProfile",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Address_StaffProfile_StaffId",
            //    table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StaffId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "StaffProfile",
                type: "uniqueidentifier",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AirTimes",
            //    columns: new[] { "Id", "CreatedAt", "CreatedBy", "NetworkProvider", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2483), null, "Mtn", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2485), null },
            //        { new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2488), null, "Airtel", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2489), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "a2ddaa4a-d48f-4867-8ab2-63ba8d8c4055", "2ac53f3f-06b3-4c2d-bdf8-85609d5f5add", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2280), null, "Manager", "MANAGER", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2280), null },
            //        { "b77c7a08-c9a7-453f-a79c-1566fa5f5a27", "b3cfadcd-8161-4806-bae8-a15ffdc9e97c", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2256), null, "Admin", "ADMIN", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2273), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Bills",
            //    columns: new[] { "Id", "Amount", "BillName", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"), 3000m, "GOTV", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2684), null, new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2685), null },
            //        { new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"), 6500m, "DSTV", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2679), null, new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2681), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Data",
            //    columns: new[] { "Id", "CreatedAt", "CreatedBy", "NetworkProvider", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2588), null, "Airtel", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2589), null },
            //        { new Guid("ce185a95-533e-425c-adf4-a5770766564b"), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2584), null, "Mtn", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2585), null }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_AddressId",
                table: "StaffProfile",
                column: "AddressId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_StaffProfile_Address_AddressId",
            //    table: "StaffProfile",
            //    column: "AddressId",
            //    principalTable: "Address",
            //    principalColumn: "Id");
        }
    }
}
