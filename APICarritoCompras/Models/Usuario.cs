using APICarritoCompras.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace APICarritoCompras.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string? NombreUsuario { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public ICollection<UsuarioRol> UsuarioRoles { get; set; }

        public ICollection<Orden> Ordenes { get; set; }
    }
}
