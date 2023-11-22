using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class muchosAmuchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Cuentas_CuentaId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Refugios_Cuentas_CuentaId",
                table: "Refugios");

            migrationBuilder.DropIndex(
                name: "IX_Refugios_CuentaId",
                table: "Refugios");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_CuentaId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "Refugios");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "Mascotas");

            migrationBuilder.CreateTable(
                name: "CuentaMascotas",
                columns: table => new
                {
                    CuentasId = table.Column<int>(type: "int", nullable: false),
                    MascotasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaMascotas", x => new { x.CuentasId, x.MascotasId });
                    table.ForeignKey(
                        name: "FK_CuentaMascotas_Cuentas_CuentasId",
                        column: x => x.CuentasId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuentaMascotas_Mascotas_MascotasId",
                        column: x => x.MascotasId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaRefugios",
                columns: table => new
                {
                    CuentasId = table.Column<int>(type: "int", nullable: false),
                    RefugiosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaRefugios", x => new { x.CuentasId, x.RefugiosId });
                    table.ForeignKey(
                        name: "FK_CuentaRefugios_Cuentas_CuentasId",
                        column: x => x.CuentasId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuentaRefugios_Refugios_RefugiosId",
                        column: x => x.RefugiosId,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaMascotas_MascotasId",
                table: "CuentaMascotas",
                column: "MascotasId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaRefugios_RefugiosId",
                table: "CuentaRefugios",
                column: "RefugiosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentaMascotas");

            migrationBuilder.DropTable(
                name: "CuentaRefugios");

            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "Refugios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "Mascotas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refugios_CuentaId",
                table: "Refugios",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_CuentaId",
                table: "Mascotas",
                column: "CuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Cuentas_CuentaId",
                table: "Mascotas",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Refugios_Cuentas_CuentaId",
                table: "Refugios",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id");
        }
    }
}
