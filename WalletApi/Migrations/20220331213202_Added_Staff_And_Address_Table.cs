using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Added_Staff_And_Address_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1048213a-f434-46d4-be70-f7cf7280cd45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea103df2-d931-439a-ad99-6564bf05d0fd");

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

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_Address_AddressId",
            //    table: "Customers",
            //    column: "AddressId",
            //    principalTable: "Address",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Customers_Address_AddressId",
            //    table: "Customers");

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
                values: new object[] { new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(3883), new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(4223), new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(4224) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ea103df2-d931-439a-ad99-6564bf05d0fd", "bffba74c-3993-434b-88ba-0ee44d0fafd2", new DateTime(2022, 3, 31, 21, 36, 7, 603, DateTimeKind.Local).AddTicks(4339), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 21, 36, 7, 603, DateTimeKind.Local).AddTicks(4658), null },
                    { "1048213a-f434-46d4-be70-f7cf7280cd45", "74bb73b6-4952-44f4-ba64-0a7785322f1a", new DateTime(2022, 3, 31, 21, 36, 7, 603, DateTimeKind.Local).AddTicks(4907), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 21, 36, 7, 603, DateTimeKind.Local).AddTicks(4909), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(9806), new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(9462), new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(7072), new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(7073) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(6760), new DateTime(2022, 3, 31, 21, 36, 7, 604, DateTimeKind.Local).AddTicks(6919) });
        }
    }
}
