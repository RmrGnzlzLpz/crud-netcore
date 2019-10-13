using Microsoft.EntityFrameworkCore;

namespace ng_core_crud.Models
{
   public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; }
    }
}