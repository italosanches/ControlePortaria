using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePortaria.Migrations
{
    /// <inheritdoc />
    public partial class AjusteClassesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "KilometragemSaida",
                table: "Portaria",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Portaria",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "KilometragemChegada",
                table: "Portaria",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Portaria");

            migrationBuilder.DropColumn(
                name: "KilometragemChegada",
                table: "Portaria");

            migrationBuilder.AlterColumn<int>(
                name: "KilometragemSaida",
                table: "Portaria",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
