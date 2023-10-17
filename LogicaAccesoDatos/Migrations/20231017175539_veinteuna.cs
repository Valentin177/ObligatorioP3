using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class veinteuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Ecosistemas_Amenazas",
                table: "Amenazas");

            migrationBuilder.DropForeignKey(
                name: "FK_Amenazas_Especies_EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_Amenazas",
                table: "Amenazas");

            migrationBuilder.DropIndex(
                name: "IX_Amenazas_EspecieidEspecie",
                table: "Amenazas");

            migrationBuilder.DropColumn(
                name: "Amenazas",
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

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEcosistema_ecosistemasidEcosistema",
                table: "AmenazaEcosistema",
                column: "ecosistemasidEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEspecie_especiesidEspecie",
                table: "AmenazaEspecie",
                column: "especiesidEspecie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenazaEcosistema");

            migrationBuilder.DropTable(
                name: "AmenazaEspecie");

            migrationBuilder.AddColumn<int>(
                name: "Amenazas",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecieidEspecie",
                table: "Amenazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_Amenazas",
                table: "Amenazas",
                column: "Amenazas");

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieidEspecie",
                table: "Amenazas",
                column: "EspecieidEspecie");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Ecosistemas_Amenazas",
                table: "Amenazas",
                column: "Amenazas",
                principalTable: "Ecosistemas",
                principalColumn: "idEcosistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenazas_Especies_EspecieidEspecie",
                table: "Amenazas",
                column: "EspecieidEspecie",
                principalTable: "Especies",
                principalColumn: "idEspecie");
        }
    }
}
