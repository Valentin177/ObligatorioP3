using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    idEspecie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreVulgar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoDesde = table.Column<int>(type: "int", nullable: false),
                    PesoHasta = table.Column<int>(type: "int", nullable: false),
                    LongDesde = table.Column<int>(type: "int", nullable: false),
                    LongHasta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.idEspecie);
                });

            migrationBuilder.CreateTable(
                name: "EstadosConservacion",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangoDesde = table.Column<int>(type: "int", nullable: false),
                    RangoHasta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosConservacion", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    idPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codigoIsoAlpha = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.idPais);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    idEcosistema = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area = table.Column<int>(type: "int", nullable: false),
                    estadoidEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.idEcosistema);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadosConservacion_estadoidEstado",
                        column: x => x.estadoidEstado,
                        principalTable: "EstadosConservacion",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    idAmenaza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gradoPeligrosidad = table.Column<int>(type: "int", nullable: false),
                    EcosistemaidEcosistema = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.idAmenaza);
                    table.ForeignKey(
                        name: "FK_Amenazas_Ecosistemas_EcosistemaidEcosistema",
                        column: x => x.EcosistemaidEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "idEcosistema");
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
                name: "IX_Amenazas_EcosistemaidEcosistema",
                table: "Amenazas",
                column: "EcosistemaidEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaEspecie_especiesidEspecie",
                table: "EcosistemaEspecie",
                column: "especiesidEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_estadoidEstado",
                table: "Ecosistemas",
                column: "estadoidEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_Nombre",
                table: "Ecosistemas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_codigoIsoAlpha",
                table: "Paises",
                column: "codigoIsoAlpha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                table: "Paises",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "EcosistemaEspecie");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "EstadosConservacion");
        }
    }
}
