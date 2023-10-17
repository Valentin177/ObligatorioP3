using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class veintedos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenazaEcosistema");

            migrationBuilder.DropTable(
                name: "AmenazaEspecie");

            migrationBuilder.DropTable(
                name: "EcosistemaEspecie");

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaidEcosistema",
                table: "Especies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecieidEspecie",
                table: "Ecosistemas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EcosistemaidEcosistema",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecieidEspecie",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EcosistemaidEcosistema",
                table: "Especies",
                column: "EcosistemaidEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_EspecieidEspecie",
                table: "Ecosistemas",
                column: "EspecieidEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EcosistemaidEcosistema",
                table: "Amenazas",
                column: "EcosistemaidEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieidEspecie",
                table: "Amenazas",
                column: "EspecieidEspecie");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                table: "Amenazas",
                column: "EcosistemaidEcosistema",
                principalTable: "Ecosistemas",
                principalColumn: "idEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Especies_EspecieidEspecie",
                table: "Amenazas",
                column: "EspecieidEspecie",
                principalTable: "Especies",
                principalColumn: "idEspecie");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_Especies_EspecieidEspecie",
                table: "Ecosistemas",
                column: "EspecieidEspecie",
                principalTable: "Especies",
                principalColumn: "idEspecie");

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
                name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                table: "Amenazas");

            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Especies_EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_Especies_EspecieidEspecie",
                table: "Ecosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Especies_Ecosistemas_EcosistemaidEcosistema",
                table: "Especies");

            migrationBuilder.DropIndex(
                name: "IX_Especies_EcosistemaidEcosistema",
                table: "Especies");

            migrationBuilder.DropIndex(
                name: "IX_Ecosistemas_EspecieidEspecie",
                table: "Ecosistemas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EcosistemaidEcosistema",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EcosistemaidEcosistema",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "EspecieidEspecie",
                table: "Ecosistemas");

            migrationBuilder.DropColumn(
                name: "EcosistemaidEcosistema",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.CreateTable(
                name: "AmenazaEcosistema",
                columns: table => new
                {
                    amenazasidAmenaza = table.Column<int>(type: "int", nullable: false),
                    ecosistemasidEcosistema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazaEcosistema", x => new { x.amenazasidAmenaza, x.ecosistemasidEcosistema });
                    table.ForeignKey(
                        name: "FK_AmenazaEcosistema_Amenazas_amenazasidAmenaza",
                        column: x => x.amenazasidAmenaza,
                        principalTable: "Amenazas",
                        principalColumn: "idAmenaza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazaEcosistema_Ecosistemas_ecosistemasidEcosistema",
                        column: x => x.ecosistemasidEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "idEcosistema",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenazaEspecie",
                columns: table => new
                {
                    AmenazasEspecieidAmenaza = table.Column<int>(type: "int", nullable: false),
                    especiesidEspecie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazaEspecie", x => new { x.AmenazasEspecieidAmenaza, x.especiesidEspecie });
                    table.ForeignKey(
                        name: "FK_AmenazaEspecie_Amenazas_AmenazasEspecieidAmenaza",
                        column: x => x.AmenazasEspecieidAmenaza,
                        principalTable: "Amenazas",
                        principalColumn: "idAmenaza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazaEspecie_Especies_especiesidEspecie",
                        column: x => x.especiesidEspecie,
                        principalTable: "Especies",
                        principalColumn: "idEspecie",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_AmenazaEcosistema_ecosistemasidEcosistema",
                table: "AmenazaEcosistema",
                column: "ecosistemasidEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEspecie_especiesidEspecie",
                table: "AmenazaEspecie",
                column: "especiesidEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaEspecie_especiesidEspecie",
                table: "EcosistemaEspecie",
                column: "especiesidEspecie");
        }
    }
}
