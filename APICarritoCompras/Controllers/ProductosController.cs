using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using APICarritoCompras.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarritoCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;
        protected ResponseDTO _response;

        public ProductosController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<Producto>> GetProductos()
        {
            try
            {
                var lista = await _productoRepositorio.GetProductos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Productos";
            }
            catch (Exception ex) {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoById(int id)
        {
            var producto = await _productoRepositorio.GetProductoById(id);
            if (producto == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al encontrar el producto";
            }

            _response.Result = producto;
            _response.DisplayMessage = "Producto encontrado";

            return Ok(_response);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoDTO productoDTO)
        {
            try
            {
                ProductoDTO model = await _productoRepositorio.CreateUpdate(productoDTO);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Ocurrió un error";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(ProductoDTO productoDTO)
        {
            try
            {
                ProductoDTO nuevoProducto = await _productoRepositorio.CreateUpdate(productoDTO);
                _response.Result = nuevoProducto;
                _response.DisplayMessage = "Nuevo producto agregado";
                return CreatedAtAction("GetProductos", new { id = nuevoProducto.IdProducto}, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Ocurrió un error al agregar el producto";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                var estaBorrado = await _productoRepositorio.DeleteProducto(id);

                if(estaBorrado)
                {
                    _response.Result = estaBorrado;
                    _response.DisplayMessage = "Producto eliminado";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "No se pudo borrar el producto";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
