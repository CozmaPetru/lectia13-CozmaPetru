using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class Initiala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Modelul = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    AnFabricatie = table.Column<int>(type: "INTEGER", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    DataInmatricularii = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Kilometraj = table.Column<int>(type: "INTEGER", nullable: true),
                    EsteDisponibil = table.Column<bool>(type: "INTEGER", nullable: false),
                    Descriere = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobile", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Automobile",
                columns: new[] { "Id", "AnFabricatie", "DataInmatricularii", "Descriere", "EsteDisponibil", "Kilometraj", "Marca", "Modelul", "Pret" },
                values: new object[,]
                {
                    { 1, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Un singur proprietar. Revizii la reprezentanță.", true, 86400, "Dacia", "Logan", 128500m },
                    { 2, 2017, new DateTime(2017, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Motor 1.6 TDI, cutie manuală.", true, 142000, "Volkswagen", "Golf", 189990.50m },
                    { 3, 2026, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automobil nou, hibrid.", true, null, "Toyota", "Corolla", 465000m },
                    { 4, 2020, new DateTime(2020, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vândut. Se păstrează în listă pentru istoric.", false, 98750, "Skoda", "Octavia", 254300m },
                    { 5, 2016, new DateTime(2016, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consum mic, potrivit pentru oraș.", true, 167300, "Renault", "Clio", 99800.75m },
                    { 6, 2022, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tracțiune integrală, cameră de parcare.", true, 41200, "Hyundai", "Tucson", 398000m },
                    { 7, 2018, new DateTime(2018, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rezervat de un client.", false, 121900, "Ford", "Focus", 156450m },
                    { 8, 2026, new DateTime(2026, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automobil nou, garanție 7 ani.", true, null, "Kia", "Sportage", 512000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobile");
        }
    }
}
