using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        public string? NombreProducto { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public float Precio { get; set; }

        [Required]
        public int Stock { get; set; }
        
    }
}
