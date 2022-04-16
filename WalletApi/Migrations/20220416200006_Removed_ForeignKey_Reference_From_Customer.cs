using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Removed_ForeignKey_Reference_From_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Wallets_WalletId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_WalletId",
                table: "Customers");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "37b75c9d-94af-4f55-a317-e173d4f11c4e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "c23a4b92-6bc4-49f5-a929-5b61a88ca47b");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Customers");

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2366), new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2367) });

            //migrationBuilder.UpdateData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2370), new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2370) });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "347e1ca3-1bdd-4ac9-8aaa-86c284fe2e9e", "7f6beef0-b211-4e4e-a995-508a5473803f", new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2223), null, "Manager", "MANAGER", new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2223), null },
            //        { "9413e8b8-4914-4665-8288-1a0a5414f0fc", "d18efcf2-83a9-4ffd-b8af-516a0ebfc66f", new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2208), null, "Admin", "ADMIN", new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2217), null }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2473), new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2473) });

            //migrationBuilder.UpdateData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2470), new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2471) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2421), new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2422) });

            //migrationBuilder.UpdateData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
            //    columns: new[] { "CreatedAt", "UpdatedAt" },
            //    values: new object[] { new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2418), new DateTime(2022, 4, 16, 21, 0, 6, 99, DateTimeKind.Local).AddTicks(2420) });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallets",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customers_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Wallets_Customers_CustomerId",
            //    table: "Wallets",
            //    column: "CustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customers_CustomerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Customers_CustomerId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Address_CustomerId",
                table: "Address");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "347e1ca3-1bdd-4ac9-8aaa-86c284fe2e9e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "9413e8b8-4914-4665-8288-1a0a5414f0fc");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_WalletId",
                table: "Customers",
                column: "WalletId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_Wallets_WalletId",
            //    table: "Customers",
            //    column: "WalletId",
            //    principalTable: "Wallets",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
