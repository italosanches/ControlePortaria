using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePortaria.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoColunaPessoaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portaria_Carro_CarroID",
                table: "Portaria");

            migrationBuilder.DropIndex(
                name: "IX_Portaria_CarroID",
                table: "Portaria");

            migrationBuilder.DropColumn(
                name: "KilometragemSaida",
                table: "Portaria");

            migrationBuilder.AddColumn<int>(
                name: "PessoaStatus",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaStatus",
                table: "Pessoa");

            migrationBuilder.AddColumn<decimal>(
                name: "KilometragemSaida",
                table: "Portaria",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

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
    }
}
