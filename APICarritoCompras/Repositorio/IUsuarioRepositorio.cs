using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;

namespace APICarritoCompras.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioDTO>> GetUsuarios();

        Task<UsuarioDetalleDTO> GetUsuarioById(int id);

        Task<List<UsuarioDetalleDTO>> GetUsuarioDetalles();

        Task<string> Registrarse(Usuario usuario, string password);

        Task<string> Login(string username, string password);

        Task<bool> UserExiste(string username);
    }
}
