namespace APICarritoCompras.Models.DTO
{
    public class UsuarioRolDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int RolId { get; set; }

        public RolDTO Rol { get; set; }
    }
}
