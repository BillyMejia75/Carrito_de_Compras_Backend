using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class EstadoOrden
    {
        [Key]
        public int Id { get; set; }
        public string? Estado { get; set; }
        
    }
}
