using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string? Imagen { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        


        public ICollection<OrdenProducto> OrdenProducto { get; set; }
    }
}
