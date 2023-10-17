using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class decimosept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcosistemaEspecie");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaidEcosistema",
                table: "Especies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EcosistemaidEcosistema",
                table: "Especies",
                column: "EcosistemaidEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_Ecosistemas_EcosistemaidEcosistema",
                table: "Especies",
                column: "EcosistemaidEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "idEcosistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especies_Ecosistemas_EcosistemaidEcosistema",
                table: "Especies");

            migrationBuilder.DropIndex(
                name: "IX_Especies_EcosistemaidEcosistema",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "EcosistemaidEcosistema",
                table: "Especies");

            migrationBuilder.CreateTable(
                name: "EcosistemaEspecie",
                columns: table => new
                {
                    ecosistemasHabitadosidEcosistema = table.Column<int>(type: "int", nullable: false),
                    especiesidEspecie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaEspecie", x => new { x.ecosistemasHabitadosidEcosistema, x.especiesidEspecie });
                    table.ForeignKey(
                        name: "FK_EcosistemaEspecie_Ecosistemas_ecosistemasHabitadosidEcosistema",
                        column: x => x.ecosistemasHabitadosidEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "idEcosistema",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaEspecie_Especies_especiesidEspecie",
                        column: x => x.especiesidEspecie,
                        principalTable: "Especies",
                        principalColumn: "idEspecie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaEspecie_especiesidEspecie",
                table: "EcosistemaEspecie",
                column: "especiesidEspecie");
        }
    }
}
