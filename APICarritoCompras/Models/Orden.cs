using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICarritoCompras.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public float Total { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
