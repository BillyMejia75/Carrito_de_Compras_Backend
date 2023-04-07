using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? NombreProducto { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
