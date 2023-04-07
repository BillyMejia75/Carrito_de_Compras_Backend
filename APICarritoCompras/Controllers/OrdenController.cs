using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using APICarritoCompras.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarritoCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenRepositorio _ordenRepositorio;
        protected ResponseDTO _response;

        public OrdenController(IOrdenRepositorio ordenRepositorio)
        {
            _ordenRepositorio = ordenRepositorio;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<Orden>> GetOrdenes()
        {
            try
            {
                var listaOrdenes = await _ordenRepositorio.GetOrdenes();
                _response.Result = listaOrdenes;
                _response.DisplayMessage = "Lista de Ordenes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(OrdenDTO ordenDTO)
        {
            try
            {
                OrdenDTO nuevaOrden = await _ordenRepositorio.CreateUpdate(ordenDTO);
                _response.Result = nuevaOrden;
                _response.DisplayMessage = "Orden agregada exitosamente";
                return CreatedAtAction("GetOrdenes", new { id = nuevaOrden.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Ocurrió un error al agregar la orden";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
