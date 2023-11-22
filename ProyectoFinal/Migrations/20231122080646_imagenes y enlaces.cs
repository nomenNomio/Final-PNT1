using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class imagenesyenlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Refugios_SuRefugioId",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "SuRefugioId",
                table: "Mascotas",
                newName: "RefugioId");

            migrationBuilder.RenameIndex(
                name: "IX_Mascotas_SuRefugioId",
                table: "Mascotas",
                newName: "IX_Mascotas_RefugioId");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Refugios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Mascotas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Refugios_RefugioId",
                table: "Mascotas",
                column: "RefugioId",
                principalTable: "Refugios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Refugios_RefugioId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Refugios");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "RefugioId",
                table: "Mascotas",
                newName: "SuRefugioId");

            migrationBuilder.RenameIndex(
                name: "IX_Mascotas_RefugioId",
                table: "Mascotas",
                newName: "IX_Mascotas_SuRefugioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Refugios_SuRefugioId",
                table: "Mascotas",
                column: "SuRefugioId",
                principalTable: "Refugios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
