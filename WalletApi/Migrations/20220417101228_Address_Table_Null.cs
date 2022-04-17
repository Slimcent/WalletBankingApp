using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Address_Table_Null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StaffId",
                table: "Address");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "3a7561ce-54af-45ab-8638-0ac5ed7a0a6e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "4819077d-e76b-4f3f-b228-cf207880200e");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "StaffProfile",
                type: "uniqueidentifier",
                nullable: true);

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2483), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2485) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2488), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2489) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "a2ddaa4a-d48f-4867-8ab2-63ba8d8c4055", "2ac53f3f-06b3-4c2d-bdf8-85609d5f5add", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2280), null, "Manager", "MANAGER", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2280), null },
            //        { "b77c7a08-c9a7-453f-a79c-1566fa5f5a27", "b3cfadcd-8161-4806-bae8-a15ffdc9e97c", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2256), null, "Admin", "ADMIN", new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2273), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2684), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2685) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2679), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2681) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2588), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2589) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2584), new DateTime(2022, 4, 17, 11, 12, 28, 1, DateTimeKind.Local).AddTicks(2585) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Address_AddressId",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_AddressId",
                table: "StaffProfile");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a2ddaa4a-d48f-4867-8ab2-63ba8d8c4055");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "b77c7a08-c9a7-453f-a79c-1566fa5f5a27");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "StaffProfile");

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3946), new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3948) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3951), new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3952) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "3a7561ce-54af-45ab-8638-0ac5ed7a0a6e", "07a3bc3e-43fe-4e13-a7e7-f6bf333ec7f1", new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3693), null, "Admin", "ADMIN", new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3709), null },
            //        { "4819077d-e76b-4f3f-b228-cf207880200e", "6c7f20f7-4d4a-4f6b-894d-c76a8370cc94", new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3715), null, "Manager", "MANAGER", new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(3716), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4125), new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4126) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4121), new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4122) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4048), new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4048) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4043), new DateTime(2022, 4, 17, 11, 2, 51, 189, DateTimeKind.Local).AddTicks(4045) });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StaffId",
                table: "Address",
                column: "StaffId",
                unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Address_StaffProfile_StaffId",
            //    table: "Address",
            //    column: "StaffId",
            //    principalTable: "StaffProfile",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
