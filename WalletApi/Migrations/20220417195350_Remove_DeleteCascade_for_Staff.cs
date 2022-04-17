using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    public partial class Remove_DeleteCascade_for_Staff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address",
                column: "StaffId",
                principalTable: "StaffProfile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StaffProfile_StaffId",
                table: "Address",
                column: "StaffId",
                principalTable: "StaffProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
