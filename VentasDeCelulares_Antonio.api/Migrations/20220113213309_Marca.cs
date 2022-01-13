using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasDeCelulares_Antonio.api.Migrations
{
    public partial class Marca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compania",
                columns: table => new
                {
                    IdCompania = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compania", x => x.IdCompania);
                });

            migrationBuilder.CreateTable(
                name: "Caracterisitcas",
                columns: table => new
                {
                    IdCaracteristicas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ram = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    EspacioInterno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Procesador = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdCompania = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracterisitcas", x => x.IdCaracteristicas);
                    table.ForeignKey(
                        name: "FK_Caracterisitcas_Compania_IdCompania",
                        column: x => x.IdCompania,
                        principalTable: "Compania",
                        principalColumn: "IdCompania",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    IdModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Activo = table.Column<bool>(type: "bit", maxLength: 120, nullable: false),
                    IdCaracteristicas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.IdModel);
                    table.ForeignKey(
                        name: "FK_Model_Caracterisitcas_IdCaracteristicas",
                        column: x => x.IdCaracteristicas,
                        principalTable: "Caracterisitcas",
                        principalColumn: "IdCaracteristicas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdModelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Marca_Model_IdModelo",
                        column: x => x.IdModelo,
                        principalTable: "Model",
                        principalColumn: "IdModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caracterisitcas_IdCompania",
                table: "Caracterisitcas",
                column: "IdCompania");

            migrationBuilder.CreateIndex(
                name: "IX_Marca_IdModelo",
                table: "Marca",
                column: "IdModelo");

            migrationBuilder.CreateIndex(
                name: "IX_Model_IdCaracteristicas",
                table: "Model",
                column: "IdCaracteristicas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Caracterisitcas");

            migrationBuilder.DropTable(
                name: "Compania");
        }
    }
}
