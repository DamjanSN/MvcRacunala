using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcRacunala.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racunala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racunala", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racunala");
        }
    }
}
