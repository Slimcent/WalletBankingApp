using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Removed_FullName_from_User_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304f996d-685e-4c90-952b-fa3e846cd116");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9978d84f-a18d-43dc-b18f-eb54836164de");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1048213a-f434-46d4-be70-f7cf7280cd45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea103df2-d931-439a-ad99-6564bf05d0fd");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(3131), new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(3554), new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(3556) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "9978d84f-a18d-43dc-b18f-eb54836164de", "989f76c2-300d-449f-a4ff-31351094957a", new DateTime(2022, 3, 30, 0, 21, 19, 366, DateTimeKind.Local).AddTicks(6736), null, "Admin", "ADMIN", new DateTime(2022, 3, 30, 0, 21, 19, 366, DateTimeKind.Local).AddTicks(7487), null },
                    { "304f996d-685e-4c90-952b-fa3e846cd116", "7b0c3af1-0a6f-44b9-b00c-9ae87035c11e", new DateTime(2022, 3, 30, 0, 21, 19, 366, DateTimeKind.Local).AddTicks(7773), null, "Manager", "MANAGER", new DateTime(2022, 3, 30, 0, 21, 19, 366, DateTimeKind.Local).AddTicks(7776), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 30, 0, 21, 19, 369, DateTimeKind.Local).AddTicks(1236), new DateTime(2022, 3, 30, 0, 21, 19, 369, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 30, 0, 21, 19, 369, DateTimeKind.Local).AddTicks(725), new DateTime(2022, 3, 30, 0, 21, 19, 369, DateTimeKind.Local).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(6928), new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(6931) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(6434), new DateTime(2022, 3, 30, 0, 21, 19, 368, DateTimeKind.Local).AddTicks(6717) });
        }
    }
}
