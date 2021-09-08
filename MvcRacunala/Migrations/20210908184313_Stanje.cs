using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcRacunala.Migrations
{
    public partial class Stanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cijena",
                table: "Racunala",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Stanje",
                table: "Racunala",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stanje",
                table: "Racunala");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cijena",
                table: "Racunala",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
