using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz2.Migrations
{
    /// <inheritdoc />
    public partial class somepropertyaddtocard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LastLoginTime",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginAttempts",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "LoginAttempts",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Cards");
        }
    }
}
