using APICarritoCompras.Models;
using APICarritoCompras.Models.DTO;
using AutoMapper;

namespace APICarritoCompras
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductoDTO, Producto>();
                config.CreateMap<Producto, ProductoDTO>();

                config.CreateMap<UsuarioDTO, Usuario>();
                config.CreateMap<Usuario, UsuarioDTO>();/*.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.UsuarioRoles, opt => opt.MapFrom(src => src.UsuarioRoles));*/

                config.CreateMap<Usuario, UsuarioDetalleDTO>();
                config.CreateMap<UsuarioDetalleDTO, Usuario>();

                config.CreateMap<RolDTO, Rol>();
                config.CreateMap<Rol, RolDTO>();//.ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => src.Id));

                config.CreateMap<UsuarioRolDTO, UsuarioRol>();
                config.CreateMap<UsuarioRol, UsuarioRolDTO>();

                config.CreateMap<UsuarioRol, RolDTO>();
                config.CreateMap<RolDTO, UsuarioRol>();

                config.CreateMap<OrdenDTO, Orden>();
                config.CreateMap<Orden, OrdenDTO>();
            });

            return mappingConfig;
        }
    }
}
