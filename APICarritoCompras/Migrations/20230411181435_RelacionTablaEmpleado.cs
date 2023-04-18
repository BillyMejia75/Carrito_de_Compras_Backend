using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarritoCompras.Migrations
{
    public partial class RelacionTablaEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuarios_UsuarioId",
                table: "UsuarioRol");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "UsuarioRol",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "UsuarioRol",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_EmpleadoId",
                table: "UsuarioRol",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Usuarios_UsuarioId",
                table: "Empleados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Empleados_EmpleadoId",
                table: "UsuarioRol",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Usuarios_UsuarioId",
                table: "UsuarioRol",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Usuarios_UsuarioId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Empleados_EmpleadoId",
                table: "UsuarioRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuarios_UsuarioId",
                table: "UsuarioRol");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRol_EmpleadoId",
                table: "UsuarioRol");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "UsuarioRol");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Empleados");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "UsuarioRol",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Usuarios_UsuarioId",
                table: "UsuarioRol",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
