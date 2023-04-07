using APICarritoCompras.Data;
using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICarritoCompras.Repositorio
{
    public class OrdenRepositorio : IOrdenRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public OrdenRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrdenDTO> CreateUpdate(OrdenDTO ordenDTO)
        {
            Orden orden = _mapper.Map<OrdenDTO, Orden>(ordenDTO);

            if(orden.Id > 0)
            {
                _db.Orden.Update(orden);
            } else
            {
                await _db.Orden.AddAsync(orden);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Orden, OrdenDTO>(orden);
        }

        public async Task<List<OrdenDTO>> GetOrdenes()
        {
            List<Orden> listaOrdenes = await _db.Orden.ToListAsync();

            return _mapper.Map<List<OrdenDTO>>(listaOrdenes);
        }
    }
}
