using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Cargo;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Indicador;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Dao.Context.Metriks
{
    public class IndicadorDbContext : DbContext
    {
        public DbSet<IndicadorEntity> Indicador { get; set; }

        public IndicadorDbContext(DbContextOptions<IndicadorDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IndicadorEntity>(entity =>
            {
                entity.ToTable("tbl_indicador");
                entity.HasNoKey();

            });

        }


    }
}
