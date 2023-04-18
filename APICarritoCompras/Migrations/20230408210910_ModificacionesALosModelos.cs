using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICarritoCompras.Migrations
{
    public partial class ModificacionesALosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoOrdenId",
                table: "Orden",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadoOrden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoOrden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenProducto_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orden_EstadoOrdenId",
                table: "Orden",
                column: "EstadoOrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProducto_OrdenId",
                table: "OrdenProducto",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProducto_ProductoId",
                table: "OrdenProducto",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_EstadoOrden_EstadoOrdenId",
                table: "Orden",
                column: "EstadoOrdenId",
                principalTable: "EstadoOrden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_EstadoOrden_EstadoOrdenId",
                table: "Orden");

            migrationBuilder.DropTable(
                name: "EstadoOrden");

            migrationBuilder.DropTable(
                name: "OrdenProducto");

            migrationBuilder.DropIndex(
                name: "IX_Orden_EstadoOrdenId",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "EstadoOrdenId",
                table: "Orden");
        }
    }
}
