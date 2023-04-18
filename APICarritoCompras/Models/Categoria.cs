using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
