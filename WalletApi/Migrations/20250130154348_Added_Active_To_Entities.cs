using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_Active_To_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Wallets",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "StampDutyCharges",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StaffProfile",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Customers",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsDeletd",
                table: "Bills",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetRoles",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsDeletd",
                table: "AirTimes",
                newName: "Active");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TransactionStampDutyCharges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProfilePictures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TransactionStampDutyCharges");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProfilePictures");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Wallets",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "StampDutyCharges",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "StaffProfile",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Customers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Bills",
                newName: "IsDeletd");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "AspNetRoles",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "AirTimes",
                newName: "IsDeletd");
        }
    }
}
