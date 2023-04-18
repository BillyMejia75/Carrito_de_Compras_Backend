using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using APICarritoCompras.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarritoCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        protected ResponseDTO _response;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _response = new ResponseDTO();
        }

        /*[HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuarios()
        {
            try
            {
                var lista = await _usuarioRepositorio.GetUsuarios();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de usuarios";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }*/

        [HttpGet("Detalles")]
        public async Task<ActionResult<UsuarioDetalleDTO>> GetUsuarioDetalles()
        {
            try
            {
                var detalles = await _usuarioRepositorio.GetUsuarioDetalles();
                //Aqui va null el nombreRol
                _response.Result = detalles;
                _response.DisplayMessage = "Lista de detalles de usuario";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepositorio.GetUsuarioById(id);

            if (usuario == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El usuario no existe";

                return NotFound(_response);
            }

            _response.Result = usuario;
            _response.DisplayMessage = "Informacion del usuario";

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO usuario)
        {
            try
            {
                var respuesta = await _usuarioRepositorio.Login(usuario.NombreUsuario, usuario.Contraseña);

                if (respuesta == "No user")
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "El usuario no existe";
                    return BadRequest(_response);
                }
                if (respuesta == "Contraseña incorrecta")
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Contraseña incorrecta";
                    return BadRequest(_response);
                }

                //_response.Result = respuesta;
                JwTPackage jtp = new JwTPackage();
                jtp.UserName = usuario.NombreUsuario;
                jtp.Token = respuesta;
                _response.Result = jtp;
                _response.DisplayMessage = "Usuario conectado";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error interno";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPost("Registrarse")]
        public async Task<ActionResult> Register(UsuarioDTO usuario)
        {
            try
            {
                var respuesta = await _usuarioRepositorio.Registrarse(
                new Usuario
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Direccion = usuario.Direccion,
                    Telefono = usuario.Telefono,
                    TipoUsuario = usuario.TipoUsuario
                },  usuario.Contraseña);

                if (respuesta == "Existe")
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "El usuario ya existe";
                    return BadRequest(_response);
                }

                if (respuesta == "Error")
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Ocurrio un error al registrar el usuario";
                    return BadRequest(_response);
                }

                _response.DisplayMessage = "Usuario registrado con exito";
                //_response.Result = respuesta;

                JwTPackage jtp = new JwTPackage();
                jtp.UserName = usuario.NombreUsuario;
                jtp.Token = respuesta;
                _response.Result = jtp;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error interno al registrar el usuario";
                return BadRequest(_response);
            }
        }

        public class JwTPackage
        {
            public string UserName { get; set; }

            public string Token { get; set; }
        }
    }
}
