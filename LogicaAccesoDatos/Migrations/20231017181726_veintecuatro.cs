using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class veintecuatro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EcosistemaidEcosistema",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EcosistemaidEcosistema",
                table: "Amenazas",
                column: "EcosistemaidEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                table: "Amenazas",
                column: "EcosistemaidEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "idEcosistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EcosistemaidEcosistema",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EcosistemaidEcosistema",
                table: "Amenazas");
        }
    }
}
