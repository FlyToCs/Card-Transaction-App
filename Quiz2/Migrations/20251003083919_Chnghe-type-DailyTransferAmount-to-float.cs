using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz2.Migrations
{
    /// <inheritdoc />
    public partial class ChnghetypeDailyTransferAmounttofloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "DailyTransferAmount",
                table: "Cards",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DailyTransferAmount",
                table: "Cards",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
