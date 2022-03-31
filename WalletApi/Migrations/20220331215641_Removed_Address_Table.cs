using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Removed_Address_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a94c00e-b0db-4c09-85a0-d816133b4ac6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b716d882-afeb-4609-a5ca-e05baeb3386e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotNo = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                values: new object[] { new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(3537), new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(4126), new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(4129) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "b716d882-afeb-4609-a5ca-e05baeb3386e", "2c790b34-9672-44be-af88-e7e8b7c24c89", new DateTime(2022, 3, 31, 22, 32, 1, 517, DateTimeKind.Local).AddTicks(9060), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 22, 32, 1, 517, DateTimeKind.Local).AddTicks(9462), null },
                    { "7a94c00e-b0db-4c09-85a0-d816133b4ac6", "7c3187e3-8095-4dc5-af54-05425494f6d4", new DateTime(2022, 3, 31, 22, 32, 1, 517, DateTimeKind.Local).AddTicks(9766), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 22, 32, 1, 517, DateTimeKind.Local).AddTicks(9768), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 32, 1, 520, DateTimeKind.Local).AddTicks(1821), new DateTime(2022, 3, 31, 22, 32, 1, 520, DateTimeKind.Local).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 32, 1, 520, DateTimeKind.Local).AddTicks(1387), new DateTime(2022, 3, 31, 22, 32, 1, 520, DateTimeKind.Local).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(7925), new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(7927) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(7387), new DateTime(2022, 3, 31, 22, 32, 1, 519, DateTimeKind.Local).AddTicks(7662) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            
        }
    }
}
