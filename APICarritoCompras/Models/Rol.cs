using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        public string? NombreRol { get; set; }

        public ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}
