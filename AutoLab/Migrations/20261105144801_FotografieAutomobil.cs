using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class FotografieAutomobil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fotografie",
                table: "Automobile",
                type: "TEXT",
                maxLength: 60,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fotografie",
                value: null);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fotografie",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotografie",
                table: "Automobile");
        }
    }
}
