using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Address_Table_No_Null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "32257101-11a4-4cfe-b698-e9e333e8c519");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "ab76d494-8784-4f34-ad07-b64d6ce11e5c");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "3a7561ce-54af-45ab-8638-0ac5ed7a0a6e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "4819077d-e76b-4f3f-b228-cf207880200e");

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6695), new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6696) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6698), new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6699) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "32257101-11a4-4cfe-b698-e9e333e8c519", "78151a75-b37f-4d8b-981f-aeffb6969158", new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6362), null, "Manager", "MANAGER", new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6363), null },
            //        { "ab76d494-8784-4f34-ad07-b64d6ce11e5c", "c9bc35f3-5ce4-4c74-af37-430a4fdb8dc5", new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6344), null, "Admin", "ADMIN", new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6358), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6857), new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6858) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6854), new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6855) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6794), new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6794) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6791), new DateTime(2022, 4, 16, 21, 22, 25, 424, DateTimeKind.Local).AddTicks(6793) });
        }
    }
}
