using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using APICarritoCompras.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarritoCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolRepositorio _rolRepositorio;
        protected ResponseDTO _response;

        public RolesController(IRolRepositorio rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<Rol>> GetRoles()
        {
            try
            {
                var roles = await _rolRepositorio.GetRoles();
                _response.Result = roles;
                _response.DisplayMessage = "Lista de Roles";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> GetRolesById(int id)
        {
            var rol = await _rolRepositorio.GetRolesById(id);

            if (rol == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al encontrar el rol";
            }

            _response.Result = rol;
            _response.DisplayMessage = "Rol encontrado";

            return Ok(_response);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, RolDTO rolDTO)
        {
            try
            {
                RolDTO actualizarRol = await _rolRepositorio.CreateUpdate(rolDTO);
                _response.Result = actualizarRol;
                _response.DisplayMessage = "Rol Actualizado";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Ocurrió un error al actualizar el Rol";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RolDTO>> PostRoles(RolDTO rolDTO)
        {
            try
            {
                RolDTO nuevoRol = await _rolRepositorio.CreateUpdate(rolDTO);
                _response.Result = nuevoRol;
                _response.DisplayMessage = "Rol agregado exitosamente";
                return CreatedAtAction("GetRoles", new { id = nuevoRol.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Ocurrió un error al agregar el Rol";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            try
            {
                var boolean = await _rolRepositorio.DeleteRol(id);

                if(boolean)
                {
                    _response.Result = boolean;
                    _response.DisplayMessage = "Rol eliminado";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "No se pudo borrar el Rol";
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
