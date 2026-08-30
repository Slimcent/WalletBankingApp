using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApi.Migrations
{
    /// <inheritdoc />
    public partial class Removed_Airtime_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Data",
                table: "Data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AirTimes",
                table: "AirTimes");

            migrationBuilder.RenameTable(
                name: "Data",
                newName: "NetworkData");

            migrationBuilder.RenameTable(
                name: "AirTimes",
                newName: "AirTime");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "NetworkData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NetworkProvider",
                table: "NetworkData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "NetworkData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "AirTime",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NetworkProvider",
                table: "AirTime",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AirTime",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkData",
                table: "NetworkData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirTime",
                table: "AirTime",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkData",
                table: "NetworkData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AirTime",
                table: "AirTime");

            migrationBuilder.RenameTable(
                name: "NetworkData",
                newName: "Data");

            migrationBuilder.RenameTable(
                name: "AirTime",
                newName: "AirTimes");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Data",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NetworkProvider",
                table: "Data",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Data",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "AirTimes",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NetworkProvider",
                table: "AirTimes",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AirTimes",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Data",
                table: "Data",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirTimes",
                table: "AirTimes",
                column: "Id");
        }
    }
}
