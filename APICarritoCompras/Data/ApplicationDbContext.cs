using APICarritoCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace APICarritoCompras.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Producto> ?Productos { get; set; }
        public DbSet<Usuario> ?Usuarios { get; set; }
        public DbSet<Rol> ?Roles { get; set; }
        public DbSet<UsuarioRol> ?UsuarioRol { get; set; }
        public DbSet<Orden> ?Orden { get; set; }
    }
}
