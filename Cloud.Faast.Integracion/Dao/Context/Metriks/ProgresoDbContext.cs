using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cloud.Faast.Integracion.Dao.Context.Metriks
{
    public class ProgresoDbContext : DbContext
    {
        public DbSet<PersonaEntity> Persona { get; set; }
        public DbSet<ContratoEntity> Contrato { get; set; }
        public DbSet<ContratoApiKeyEntity> ContratoApiKey { get; set; }

        public ProgresoDbContext(DbContextOptions<ProgresoDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonaEntity>(entity =>
            {
                entity.ToTable("tbl_prg_persona");
                entity.HasKey(x => x.prg_int_idpersona);

            });

            modelBuilder.Entity<ContratoEntity>(entity =>
            {
                entity.ToTable("tbl_contrato");
                entity.HasKey(x => x.id);

            });

            modelBuilder.Entity<ContratoApiKeyEntity>(entity =>
            {
                entity.ToTable("tbl_contrato_apikey");
                entity.HasKey(x => x.id);

            });

        }
    }
}
