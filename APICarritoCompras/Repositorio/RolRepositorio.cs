using APICarritoCompras.Data;
using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICarritoCompras.Repositorio
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public RolRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RolDTO> CreateUpdate(RolDTO rolDTO)
        {
            Rol rol = _mapper.Map<RolDTO, Rol>(rolDTO);

            if (rol.Id > 0)
            {
                _db.Roles.Update(rol);
            } else
            {
                await _db.Roles.AddAsync(rol);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Rol, RolDTO>(rol);
        }

        public async Task<List<RolDTO>> GetRoles()
        {
            List<Rol> roles = await _db.Roles.ToListAsync();

            return _mapper.Map<List<RolDTO>>(roles);
        }

        public async Task<RolDTO> GetRolesById(int id)
        {
            Rol rol = await _db.Roles.FindAsync(id);

            return _mapper.Map<RolDTO>(rol);
        }

        public async Task<bool> DeleteRol(int id)
        {
            try
            {
                Rol rol = await _db.Roles.FindAsync(id);
                
                if (rol == null )
                {
                    return false;
                }

                _db.Roles.Remove(rol);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
