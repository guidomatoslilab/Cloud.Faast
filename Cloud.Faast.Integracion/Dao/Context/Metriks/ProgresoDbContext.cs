using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Cargo;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cloud.Faast.Integracion.Dao.Context.Metriks
{
    public class ProgresoDbContext : DbContext
    {
        public DbSet<PersonaEntity> Persona { get; set; }
        public DbSet<PersonaEmpleadoEntity> PersonaEmpleado { get; set; }
        public DbSet<EmpleadoEntity> Empleado { get; set; }

        //DEBERIAN ESTAR EN UNA BD APARTE PARA SEPARAR LA SEGURIDAD DEL NEGOCIO

        #region ENTIDADES DE SEGURIDAD
        public DbSet<ContratoEntity> Contrato { get; set; }
        public DbSet<CargoEntity> Cargo { get; set; }
        public DbSet<ContratoApiKeyEntity> ContratoApiKey { get; set; }
        public DbSet<UsuarioIntegracionEntity> UsuarioIntegracion { get; set; }
        #endregion

        #region ENTIDADES GENERADAS A PARTIR DE UNA QUERY
        public DbSet<BusquedaPersonaQueryResult> BusquedaPersona { get; set; }
        public DbSet<BusquedaLineaClienteQueryResult> BusquedaLineaCliente { get; set; }
        #endregion
        public ProgresoDbContext(DbContextOptions<ProgresoDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonaEntity>(entity =>
            {
                entity.ToTable("tbl_prg_persona");
                entity.HasKey(x => x.prg_int_idpersona);

            });

            modelBuilder.Entity<PersonaEmpleadoEntity>(entity =>
            {
                entity.ToTable("tbl_prg_personaempleado");
                entity.HasKey(x => x.prg_int_idpersonaempleado);

            });

            modelBuilder.Entity<EmpleadoEntity>(entity =>
            {
                entity.ToTable("tbl_prg_empleado");
                entity.HasKey(x => x.prg_int_idempleado);

            });


            modelBuilder.Entity<CargoEntity>(entity =>
            {
                entity.ToTable("tbl_prg_cargo");
                entity.HasKey(x => x.prg_int_idcargo);

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

            modelBuilder.Entity<UsuarioIntegracionEntity>(entity =>
            {
                entity.ToTable("tbl_usuario_integracion");
                entity.HasKey(x => x.id);

            });


            #region ENTIDADES GENERADAS A PARTIR DE UNA QUERY
            modelBuilder.Entity<BusquedaPersonaQueryResult>().HasNoKey();
            modelBuilder.Entity<BusquedaLineaClienteQueryResult>().HasNoKey();
            #endregion
        }
    }
}
