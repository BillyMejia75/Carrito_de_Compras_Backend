using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarritoCompras.Migrations
{
    public partial class RelacionOrdenCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Usuarios_UsuarioId",
                table: "Orden");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Orden",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Orden_UsuarioId",
                table: "Orden",
                newName: "IX_Orden_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Cliente_ClienteId",
                table: "Orden",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Cliente_ClienteId",
                table: "Orden");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Orden",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Orden_ClienteId",
                table: "Orden",
                newName: "IX_Orden_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Usuarios_UsuarioId",
                table: "Orden",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
