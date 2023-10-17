using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class decimocuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estadoConservacionEspecieidEstado",
                table: "Especies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Especies_estadoConservacionEspecieidEstado",
                table: "Especies",
                column: "estadoConservacionEspecieidEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_EstadosConservacion_estadoConservacionEspecieidEstado",
                table: "Especies",
                column: "estadoConservacionEspecieidEstado",
                principalTable: "EstadosConservacion",
                principalColumn: "idEstado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especies_EstadosConservacion_estadoConservacionEspecieidEstado",
                table: "Especies");

            migrationBuilder.DropIndex(
                name: "IX_Especies_estadoConservacionEspecieidEstado",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "estadoConservacionEspecieidEstado",
                table: "Especies");
        }
    }
}
