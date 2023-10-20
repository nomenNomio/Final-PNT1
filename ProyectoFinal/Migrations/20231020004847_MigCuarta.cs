using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class MigCuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refugios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refugios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refugios_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoDeSalud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    CantDuenios = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Vacunado = table.Column<bool>(type: "bit", nullable: false),
                    SuRefugioId = table.Column<int>(type: "int", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mascotas_Refugios_SuRefugioId",
                        column: x => x.SuRefugioId,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_CuentaId",
                table: "Mascotas",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_SuRefugioId",
                table: "Mascotas",
                column: "SuRefugioId");

            migrationBuilder.CreateIndex(
                name: "IX_Refugios_CuentaId",
                table: "Refugios",
                column: "CuentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Refugios");

            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
