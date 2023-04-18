namespace APICarritoCompras.Models.DTO
{
    public class UsuarioDTO
    {
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? TipoUsuario { get; set; }

        //public ICollection<UsuarioRolDTO> UsuarioRoles { get; set; }

        //public ICollection<OrdenDTO> Ordenes { get; set; } 

    }
}
