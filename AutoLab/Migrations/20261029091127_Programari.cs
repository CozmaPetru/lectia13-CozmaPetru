using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class Programari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutomobilId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nume = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Ziua = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programari", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programari");
        }
    }
}
