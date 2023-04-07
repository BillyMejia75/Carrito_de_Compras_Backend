using APICarritoCompras.Data;
using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICarritoCompras.Repositorio
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductoRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> CreateUpdate(ProductoDTO productoDTO)
        {
            Producto producto = _mapper.Map<ProductoDTO, Producto>(productoDTO);

            if(producto.IdProducto > 0)
            {
                _db.Productos.Update(producto);
            } else
            {
                await _db.Productos.AddAsync(producto);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Producto, ProductoDTO>(producto);
        }

        public async Task<bool> DeleteProducto(int id)
        {
            try
            {
                Producto producto = await _db.Productos.FindAsync(id);

                if(producto == null)
                {
                    return false;
                }

                _db.Productos.Remove(producto);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductoDTO> GetProductoById(int id)
        {
            Producto producto = await _db.Productos.FindAsync(id);

            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task<List<ProductoDTO>> GetProductos()
        {
            List<Producto> listaProductos = await _db.Productos.ToListAsync();

            return _mapper.Map<List<ProductoDTO>>(listaProductos);
        }
    }
}
