using APICarritoCompras.Data;
using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APICarritoCompras.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsuarioRepositorio(ApplicationDbContext db, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UsuarioDetalleDTO> GetUsuarioById(int id)
        {
            //Usuario usuario = await _db.Usuarios.FindAsync(id);
            Usuario usuario = await _db.Usuarios
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .Include(u => u.Ordenes).FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<UsuarioDetalleDTO>(usuario);
        }

        public async Task<List<UsuarioDTO>> GetUsuarios()
        {
            //List<Usuario> listaUsuarios = await _db.Usuarios.ToListAsync();
            //List<Usuario> listaUsuarios = await _db.Usuarios.Include(r => r.UsuarioRoles).ToListAsync();
            List<Usuario> listaUsuarios = await _db.Usuarios.ToListAsync();

            /*List<Usuario> listaUsuarios = await _db.Usuarios
                .Include(r => r.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .Include(o => o.Ordenes).ToListAsync();*/

            return _mapper.Map<List<UsuarioDTO>>(listaUsuarios);
        }

        public async Task<List<UsuarioDetalleDTO>> GetUsuarioDetalles()
        {
            List<Usuario> listaUsuarioDetalle = await _db.Usuarios
                .Include(r => r.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .Include(o => o.Ordenes).ToListAsync();

            return _mapper.Map<List<UsuarioDetalleDTO>>(listaUsuarioDetalle);
        }

        public async Task<string> Login(string username, string password)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.NombreUsuario.ToLower().Equals(username.ToLower()));

            if (usuario == null)
            {
                return "No user";
            }
            else if (!VerficarPasswordHash(password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return "Contraseña incorrecta";
            }
            else return CrearToken(usuario);
        }

        public async Task<string> Registrarse(Usuario usuario, string password)
        {
            try
            {
                if (await UserExiste(usuario.NombreUsuario))
                {
                    return "Existe";
                }

                CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;

                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();

                return CrearToken(usuario);
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<bool> UserExiste(string username)
        {
            var usuario = await _db.Usuarios.AnyAsync(x => x.NombreUsuario.ToLower().Equals(username.ToLower()));
            if (usuario)
            {
                return true;
            }
            return false;
        }

        public void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerficarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario)
            };

            //Aqui salta una excepcion
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
