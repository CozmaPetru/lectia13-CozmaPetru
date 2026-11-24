using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class CombustibilCaroserie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caroserie",
                table: "Automobile",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Combustibil",
                table: "Automobile",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "Sedan", "Benzină" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "Hatchback", "Motorină" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "Sedan", "Hibrid" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "Break", "Motorină" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "Hatchback", "Benzină" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "SUV", "Benzină" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "Hatchback", "Benzină" });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Caroserie", "Combustibil" },
                values: new object[] { "SUV", "Hibrid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caroserie",
                table: "Automobile");

            migrationBuilder.DropColumn(
                name: "Combustibil",
                table: "Automobile");
        }
    }
}
