using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarritoCompras.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Orden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Orden",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
