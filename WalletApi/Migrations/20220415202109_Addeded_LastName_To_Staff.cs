using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Addeded_LastName_To_Staff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "83138db4-4d77-4ed6-8a2b-7adfec2fcc7a");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "8afd8579-0221-4508-b767-3538c83e49ad");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "StaffProfile",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8270), new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8270) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8272), new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8272) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "37b75c9d-94af-4f55-a317-e173d4f11c4e", "e4d476d2-5f61-4d27-aa3d-1021737dbd30", new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8077), null, "Admin", "ADMIN", new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8088), null },
            //        { "c23a4b92-6bc4-49f5-a929-5b61a88ca47b", "fc92ca81-ac7e-4223-ba56-4742c4a453ee", new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8092), null, "Manager", "MANAGER", new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8093), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8399), new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8400) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8396), new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8397) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8330), new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8331) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8328), new DateTime(2022, 4, 15, 21, 21, 9, 460, DateTimeKind.Local).AddTicks(8329) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "37b75c9d-94af-4f55-a317-e173d4f11c4e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "c23a4b92-6bc4-49f5-a929-5b61a88ca47b");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "StaffProfile");

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
    }
}
