using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Address_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "377367e1-c761-407e-8ef2-b1db70271872");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dbb1cb7-9c4a-4815-acc5-0d8009e94a0f");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlotNo = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(1991), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(2471), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "99b4fb24-028c-41f0-bf05-c3c6ca6e5990", "bbd8d6d2-d29e-4e7c-b819-857cef75aa11", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(8009), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(8615), null },
                    { "0ba8e0a4-7117-49e0-a239-0d853dfc22e4", "bcb4184c-b6de-4695-a28c-c529e6f18006", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(9270), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 25, 7, 975, DateTimeKind.Local).AddTicks(9272), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(326), new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(327) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(21), new DateTime(2022, 3, 31, 23, 25, 7, 978, DateTimeKind.Local).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(6288), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(6289) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(5962), new DateTime(2022, 3, 31, 23, 25, 7, 977, DateTimeKind.Local).AddTicks(6139) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ba8e0a4-7117-49e0-a239-0d853dfc22e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99b4fb24-028c-41f0-bf05-c3c6ca6e5990");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 56, 40, 895, DateTimeKind.Local).AddTicks(4625), new DateTime(2022, 3, 31, 22, 56, 40, 895, DateTimeKind.Local).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 56, 40, 895, DateTimeKind.Local).AddTicks(5351), new DateTime(2022, 3, 31, 22, 56, 40, 895, DateTimeKind.Local).AddTicks(5355) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "4dbb1cb7-9c4a-4815-acc5-0d8009e94a0f", "53efd5cf-3a9c-4e13-bab4-b52c90b8f4a9", new DateTime(2022, 3, 31, 22, 56, 40, 892, DateTimeKind.Local).AddTicks(8534), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 22, 56, 40, 892, DateTimeKind.Local).AddTicks(8969), null },
                    { "377367e1-c761-407e-8ef2-b1db70271872", "be15b4d7-9ff1-492d-ba13-7ac11711373a", new DateTime(2022, 3, 31, 22, 56, 40, 892, DateTimeKind.Local).AddTicks(9247), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 22, 56, 40, 892, DateTimeKind.Local).AddTicks(9250), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 56, 40, 896, DateTimeKind.Local).AddTicks(5087), new DateTime(2022, 3, 31, 22, 56, 40, 896, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 56, 40, 896, DateTimeKind.Local).AddTicks(4601), new DateTime(2022, 3, 31, 22, 56, 40, 896, DateTimeKind.Local).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 56, 40, 896, DateTimeKind.Local).AddTicks(233), new DateTime(2022, 3, 31, 22, 56, 40, 896, DateTimeKind.Local).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 56, 40, 895, DateTimeKind.Local).AddTicks(9614), new DateTime(2022, 3, 31, 22, 56, 40, 895, DateTimeKind.Local).AddTicks(9942) });
        }
    }
}
