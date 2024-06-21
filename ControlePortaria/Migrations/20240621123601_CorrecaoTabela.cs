using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePortaria.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Portaria_CarroID",
                table: "Portaria",
                column: "CarroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portaria_Carro_CarroID",
                table: "Portaria",
                column: "CarroID",
                principalTable: "Carro",
                principalColumn: "CarroID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portaria_Carro_CarroID",
                table: "Portaria");

            migrationBuilder.DropIndex(
                name: "IX_Portaria_CarroID",
                table: "Portaria");
        }
    }
}
