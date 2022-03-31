using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletApi.Migrations
{
    public partial class Staff_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c07b4c67-2db9-44f5-89e8-cebe95d26cb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb912cd4-cd95-4b45-9412-a6de00d6b9a7");

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "StaffProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffProfile_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3097), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3289) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3474), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "38598db6-a09d-4981-8365-e4ca9dab3445", "388465b5-2cf3-4a4f-951a-ac58a23d1adb", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(576), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(918), null },
                    { "518262ad-d7c0-471b-adfb-e59d2431b216", "7f9664ec-ecdd-4883-990b-506a2abb9674", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(1183), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 48, 49, 23, DateTimeKind.Local).AddTicks(1185), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(9086), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(8757), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(8927) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(6075), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(5755), new DateTime(2022, 3, 31, 23, 48, 49, 24, DateTimeKind.Local).AddTicks(5923) });

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_AddressId",
                table: "StaffProfile",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_UserId",
                table: "StaffProfile",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38598db6-a09d-4981-8365-e4ca9dab3445");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "518262ad-d7c0-471b-adfb-e59d2431b216");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Address");

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5199), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5405) });

            migrationBuilder.UpdateData(
                table: "AirTimes",
                keyColumn: "Id",
                keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5580), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "eb912cd4-cd95-4b45-9412-a6de00d6b9a7", "7cba6282-9e65-430c-a4ec-dbccb1e46a5f", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2306), null, "Admin", "ADMIN", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2603), null },
                    { "c07b4c67-2db9-44f5-89e8-cebe95d26cb6", "47fc3213-33d5-4320-9aba-13ed00040c48", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2789), null, "Manager", "MANAGER", new DateTime(2022, 3, 31, 23, 39, 56, 315, DateTimeKind.Local).AddTicks(2790), null }
                });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(3313), new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(2935), new DateTime(2022, 3, 31, 23, 39, 56, 317, DateTimeKind.Local).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(9186), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "Data",
                keyColumn: "Id",
                keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(8808), new DateTime(2022, 3, 31, 23, 39, 56, 316, DateTimeKind.Local).AddTicks(9035) });
        }
    }
}
