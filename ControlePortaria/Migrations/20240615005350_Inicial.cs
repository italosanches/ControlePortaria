using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePortaria.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    CarroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CarroModelo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Kilometragem = table.Column<int>(type: "int", nullable: false),
                    CarroDisponivel = table.Column<bool>(type: "bit", nullable: false),
                    Fabricante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.CarroID);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PessoaTelefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Portaria",
                columns: table => new
                {
                    PortariaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    CarroID = table.Column<int>(type: "int", nullable: false),
                    HorarioSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioChegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KilometragemSaida = table.Column<int>(type: "int", nullable: false),
                    FotoKilometragem = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portaria", x => x.PortariaID);
                    table.ForeignKey(
                        name: "FK_Portaria_Carro_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carro",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portaria_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portaria_CarroID",
                table: "Portaria",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Portaria_PessoaID",
                table: "Portaria",
                column: "PessoaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portaria");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
