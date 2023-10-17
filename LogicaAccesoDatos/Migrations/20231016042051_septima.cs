using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class septima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paisidPais",
                table: "Ecosistemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_paisidPais",
                table: "Ecosistemas",
                column: "paisidPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosistemas_Paises_paisidPais",
                table: "Ecosistemas",
                column: "paisidPais",
                principalTable: "Paises",
                principalColumn: "idPais",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosistemas_Paises_paisidPais",
                table: "Ecosistemas");

            migrationBuilder.DropIndex(
                name: "IX_Ecosistemas_paisidPais",
                table: "Ecosistemas");

            migrationBuilder.DropColumn(
                name: "paisidPais",
                table: "Ecosistemas");
        }
    }
}
