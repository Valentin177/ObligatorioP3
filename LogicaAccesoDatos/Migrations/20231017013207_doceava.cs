using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class doceava : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                table: "Amenazas");

            migrationBuilder.RenameColumn(
                name: "EcosistemaidEcosistema",
                table: "Amenazas",
                newName: "Amenazas");

            migrationBuilder.RenameIndex(
                name: "IX_Amenazas_EcosistemaidEcosistema",
                table: "Amenazas",
                newName: "IX_Amenazas_Amenazas");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Ecosistemas_Amenazas",
                table: "Amenazas",
                column: "Amenazas",
                principalTable: "Ecosistemas",
                principalColumn: "idEcosistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Ecosistemas_Amenazas",
                table: "Amenazas");

            migrationBuilder.RenameColumn(
                name: "Amenazas",
                table: "Amenazas",
                newName: "EcosistemaidEcosistema");

            migrationBuilder.RenameIndex(
                name: "IX_Amenazas_Amenazas",
                table: "Amenazas",
                newName: "IX_Amenazas_EcosistemaidEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                table: "Amenazas",
                column: "EcosistemaidEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "idEcosistema");
        }
    }
}
