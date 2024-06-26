using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePortaria.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeColunasPortariaCarroPessoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portaria_Carro_CarroID",
                table: "Portaria");

            migrationBuilder.DropForeignKey(
                name: "FK_Portaria_Pessoa_PessoaID",
                table: "Portaria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portaria",
                table: "Portaria");

            migrationBuilder.RenameTable(
                name: "Portaria",
                newName: "Portarias");

            migrationBuilder.RenameColumn(
                name: "CarroID",
                table: "Carro",
                newName: "CarroId");

            migrationBuilder.RenameColumn(
                name: "PessoaID",
                table: "Portarias",
                newName: "PessoaId");

            migrationBuilder.RenameColumn(
                name: "CarroID",
                table: "Portarias",
                newName: "CarroId");

            migrationBuilder.RenameColumn(
                name: "PortariaID",
                table: "Portarias",
                newName: "PortariaId");

            migrationBuilder.RenameIndex(
                name: "IX_Portaria_PessoaID",
                table: "Portarias",
                newName: "IX_Portarias_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Portaria_CarroID",
                table: "Portarias",
                newName: "IX_Portarias_CarroId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoKilometragem",
                table: "Portarias",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portarias",
                table: "Portarias",
                column: "PortariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portarias_Carro_CarroId",
                table: "Portarias",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "CarroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portarias_Pessoa_PessoaId",
                table: "Portarias",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portarias_Carro_CarroId",
                table: "Portarias");

            migrationBuilder.DropForeignKey(
                name: "FK_Portarias_Pessoa_PessoaId",
                table: "Portarias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portarias",
                table: "Portarias");

            migrationBuilder.RenameTable(
                name: "Portarias",
                newName: "Portaria");

            migrationBuilder.RenameColumn(
                name: "CarroId",
                table: "Carro",
                newName: "CarroID");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Portaria",
                newName: "PessoaID");

            migrationBuilder.RenameColumn(
                name: "CarroId",
                table: "Portaria",
                newName: "CarroID");

            migrationBuilder.RenameColumn(
                name: "PortariaId",
                table: "Portaria",
                newName: "PortariaID");

            migrationBuilder.RenameIndex(
                name: "IX_Portarias_PessoaId",
                table: "Portaria",
                newName: "IX_Portaria_PessoaID");

            migrationBuilder.RenameIndex(
                name: "IX_Portarias_CarroId",
                table: "Portaria",
                newName: "IX_Portaria_CarroID");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoKilometragem",
                table: "Portaria",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portaria",
                table: "Portaria",
                column: "PortariaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portaria_Carro_CarroID",
                table: "Portaria",
                column: "CarroID",
                principalTable: "Carro",
                principalColumn: "CarroID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portaria_Pessoa_PessoaID",
                table: "Portaria",
                column: "PessoaID",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
