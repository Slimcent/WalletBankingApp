using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Drop_Address_And_Staff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "StaffProfile");

            //migrationBuilder.DeleteData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"));

            //migrationBuilder.DeleteData(
            //    table: "AirTimes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"));

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "5a983c37-816e-4ed4-95e3-580c095f7c75");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "e8b25f23-f93d-4224-8223-9ba5a0f2c1f6");

            //migrationBuilder.DeleteData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"));

            //migrationBuilder.DeleteData(
            //    table: "Bills",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"));

            //migrationBuilder.DeleteData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"));

            //migrationBuilder.DeleteData(
            //    table: "Data",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce185a95-533e-425c-adf4-a5770766564b"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotNo = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_StaffProfile_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffProfile",
                        principalColumn: "Id");
                });

            //migrationBuilder.InsertData(
            //    table: "AirTimes",
            //    columns: new[] { "Id", "CreatedAt", "CreatedBy", "NetworkProvider", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1da5eb5f-04cc-4f0e-afa6-52b3c78bedf9"), new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9042), null, "Mtn", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9042), null },
            //        { new Guid("d584f98c-4a22-482d-bc9e-c1899aedcc57"), new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9044), null, "Airtel", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9044), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Name", "NormalizedName", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { "5a983c37-816e-4ed4-95e3-580c095f7c75", "0c2dee79-a1c7-47d7-be9b-3b3e02e1c41c", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(8885), null, "Admin", "ADMIN", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(8896), null },
            //        { "e8b25f23-f93d-4224-8223-9ba5a0f2c1f6", "50a4ceb4-eea6-4296-ba5d-143386880aa5", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(8901), null, "Manager", "MANAGER", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(8901), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Bills",
            //    columns: new[] { "Id", "Amount", "BillName", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("637c3058-f4c2-45aa-a30c-301cc5d2d101"), 3000m, "GOTV", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9166), null, new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9167), null },
            //        { new Guid("f1179901-af52-4774-b8e5-76e76b55c8c5"), 6500m, "DSTV", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9162), null, new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9164), null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Data",
            //    columns: new[] { "Id", "CreatedAt", "CreatedBy", "NetworkProvider", "UpdatedAt", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("9806f26b-e013-4dff-812a-afba47d2fbe0"), new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9119), null, "Airtel", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9120), null },
            //        { new Guid("ce185a95-533e-425c-adf4-a5770766564b"), new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9117), null, "Mtn", new DateTime(2022, 4, 17, 13, 18, 47, 316, DateTimeKind.Local).AddTicks(9118), null }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StaffId",
                table: "Address",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_UserId",
                table: "StaffProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
