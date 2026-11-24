using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class Filiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilialaId",
                table: "Automobile",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1); // modificat de mână: automobilele existente trec la filiala 1

            migrationBuilder.CreateTable(
                name: "Filiale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Denumire = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiale", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilialaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 2,
                column: "FilialaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 3,
                column: "FilialaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 4,
                column: "FilialaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 5,
                column: "FilialaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 6,
                column: "FilialaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 7,
                column: "FilialaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Automobile",
                keyColumn: "Id",
                keyValue: 8,
                column: "FilialaId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Filiale",
                columns: new[] { "Id", "Denumire" },
                values: new object[,]
                {
                    { 1, "Cahul" },
                    { 2, "Chișinău" },
                    { 3, "Bălți" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobile_FilialaId",
                table: "Automobile",
                column: "FilialaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobile_Filiale_FilialaId",
                table: "Automobile",
                column: "FilialaId",
                principalTable: "Filiale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobile_Filiale_FilialaId",
                table: "Automobile");

            migrationBuilder.DropTable(
                name: "Filiale");

            migrationBuilder.DropIndex(
                name: "IX_Automobile_FilialaId",
                table: "Automobile");

            migrationBuilder.DropColumn(
                name: "FilialaId",
                table: "Automobile");
        }
    }
}
