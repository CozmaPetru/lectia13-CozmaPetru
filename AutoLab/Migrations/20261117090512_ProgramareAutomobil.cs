using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLab.Migrations
{
    /// <inheritdoc />
    public partial class ProgramareAutomobil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Scris de mână: programările fără automobil nu pot primi cheie străină.
            migrationBuilder.Sql(
                "DELETE FROM Programari WHERE AutomobilId NOT IN (SELECT Id FROM Automobile);");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_AutomobilId",
                table: "Programari",
                column: "AutomobilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Automobile_AutomobilId",
                table: "Programari",
                column: "AutomobilId",
                principalTable: "Automobile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Automobile_AutomobilId",
                table: "Programari");

            migrationBuilder.DropIndex(
                name: "IX_Programari_AutomobilId",
                table: "Programari");
        }
    }
}
