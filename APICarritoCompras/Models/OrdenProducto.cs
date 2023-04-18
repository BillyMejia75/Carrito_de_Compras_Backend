using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class OrdenProducto
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }


        public int OrdenId { get; set; }
        public Orden Orden { get; set; }


        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
