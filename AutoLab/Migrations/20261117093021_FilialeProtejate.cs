using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class FilialeProtejate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobile_Filiale_FilialaId",
                table: "Automobile");

            migrationBuilder.CreateIndex(
                name: "IX_Filiale_Denumire",
                table: "Filiale",
                column: "Denumire",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobile_Filiale_FilialaId",
                table: "Automobile",
                column: "FilialaId",
                principalTable: "Filiale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobile_Filiale_FilialaId",
                table: "Automobile");

            migrationBuilder.DropIndex(
                name: "IX_Filiale_Denumire",
                table: "Filiale");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobile_Filiale_FilialaId",
                table: "Automobile",
                column: "FilialaId",
                principalTable: "Filiale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
