using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class decimoquinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecieidEspecie",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieidEspecie",
                table: "Amenazas",
                column: "EspecieidEspecie");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Especies_EspecieidEspecie",
                table: "Amenazas",
                column: "EspecieidEspecie",
                principalTable: "Especies",
                principalColumn: "idEspecie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Especies_EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EspecieidEspecie",
                table: "Amenazas");
        }
    }
}
