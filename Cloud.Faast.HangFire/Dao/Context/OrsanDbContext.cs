using Cloud.Faast.HangFire.Model.Entity.Orsan;
using Microsoft.EntityFrameworkCore;

namespace Cloud.Faast.HangFire.Dao.Context
{
    public class OrsanDbContext : DbContext
    {
        public DbSet<OperacionDocumentoEntity> OperacionDocumento { get; set; }

        public OrsanDbContext(DbContextOptions<OrsanDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OperacionDocumentoEntity>(entity =>
            {
                entity.ToTable("tbl_operacion_documentos");
                entity.HasKey(x => x.Id);
            });

        }

    }
}
