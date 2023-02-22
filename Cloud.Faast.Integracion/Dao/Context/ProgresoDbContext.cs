using Cloud.Faast.Integracion.Model.Entity.Persona;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cloud.Faast.Integracion.Dao.Context
{
    public class ProgresoDbContext : DbContext
    {
        public DbSet<PersonaEntity> Persona { get; set; }

        public ProgresoDbContext(DbContextOptions<ProgresoDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonaEntity>(entity =>
            {
                entity.ToTable("tbl_prg_persona");
                entity.HasKey(x => x.prg_int_idpersona);

            });

        }
    }
}
