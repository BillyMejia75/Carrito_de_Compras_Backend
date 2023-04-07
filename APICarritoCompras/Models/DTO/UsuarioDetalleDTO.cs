namespace APICarritoCompras.Models.DTO
{
    public class UsuarioDetalleDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        //public ICollection<RolDTO> UsuarioRoles { get; set; }
        public ICollection<UsuarioRolDTO> UsuarioRoles { get; set; }
        public ICollection<OrdenDTO> Ordenes { get; set; }
    }
}
