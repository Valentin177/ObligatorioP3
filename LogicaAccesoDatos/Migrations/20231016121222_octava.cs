using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class octava : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_EstadosConservacion_estadoidEstado",
                table: "Ecosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_Paises_paisidPais",
                table: "Ecosistemas");

            migrationBuilder.AlterColumn<int>(
                name: "paisidPais",
                table: "Ecosistemas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "estadoidEstado",
                table: "Ecosistemas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_EstadosConservacion_estadoidEstado",
                table: "Ecosistemas",
                column: "estadoidEstado",
                principalTable: "EstadosConservacion",
                principalColumn: "idEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_Paises_paisidPais",
                table: "Ecosistemas",
                column: "paisidPais",
                principalTable: "Paises",
                principalColumn: "idPais");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_EstadosConservacion_estadoidEstado",
                table: "Ecosistemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_Paises_paisidPais",
                table: "Ecosistemas");

            migrationBuilder.AlterColumn<int>(
                name: "paisidPais",
                table: "Ecosistemas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estadoidEstado",
                table: "Ecosistemas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_EstadosConservacion_estadoidEstado",
                table: "Ecosistemas",
                column: "estadoidEstado",
                principalTable: "EstadosConservacion",
                principalColumn: "idEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_Paises_paisidPais",
                table: "Ecosistemas",
                column: "paisidPais",
                principalTable: "Paises",
                principalColumn: "idPais",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
