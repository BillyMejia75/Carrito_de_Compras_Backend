using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;

namespace APICarritoCompras.Repositorio
{
    public interface IProductoRepositorio
    {
        Task<List<ProductoDTO>> GetProductos();

        Task<ProductoDTO> GetProductoById(int id);

        Task<ProductoDTO> CreateUpdate(ProductoDTO productoDTO);

        Task<bool> DeleteProducto(int id);

    }
}
