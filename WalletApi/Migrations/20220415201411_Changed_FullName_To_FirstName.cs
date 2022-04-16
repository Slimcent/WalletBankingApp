using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Changed_FullName_To_FirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "018dd14d-b73e-47a5-802f-49d19bbf774e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b830ac33-f7c0-459d-8ed6-649f9adb4030");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "StaffProfile",
                newName: "FirstName");

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6709), new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6710) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6712), new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6712) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "83138db4-4d77-4ed6-8a2b-7adfec2fcc7a", "1908bedc-4165-42fa-a1d6-bf1a92167fa3", new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6531), null, "Admin", "ADMIN", new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6547), null },
            //        { "8afd8579-0221-4508-b767-3538c83e49ad", "9298fb83-e1a1-4a62-98b0-b180417bc6a6", new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6562), null, "Manager", "MANAGER", new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6563), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6814), new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6815) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6812), new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6812) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6764), new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6765) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6762), new DateTime(2022, 4, 15, 21, 14, 11, 451, DateTimeKind.Local).AddTicks(6762) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "83138db4-4d77-4ed6-8a2b-7adfec2fcc7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8afd8579-0221-4508-b767-3538c83e49ad");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "StaffProfile",
                newName: "FullName");

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
        }
    }
}
