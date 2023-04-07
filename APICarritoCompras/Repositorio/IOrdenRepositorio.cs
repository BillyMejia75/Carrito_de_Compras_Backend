using APICarritoCompras.Models.DTO;

namespace APICarritoCompras.Repositorio
{
    public interface IOrdenRepositorio
    {
        Task<List<OrdenDTO>> GetOrdenes();

        Task<OrdenDTO> CreateUpdate(OrdenDTO ordenDTO);
    }
}
