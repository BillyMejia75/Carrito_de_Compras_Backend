using APICarritoCompras.Models.DTO;

namespace APICarritoCompras.Repositorio
{
    public interface IRolRepositorio
    {
        Task<List<RolDTO>> GetRoles();

        Task<RolDTO> GetRolesById(int id);

        Task<RolDTO> CreateUpdate(RolDTO rolDTO);

        Task<bool> DeleteRol(int id);

    }
}
