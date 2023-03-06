using Cloud.Faast.Integracion.Common.VariablesEntorno;
using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cloud.Faast.Integracion.Dao.Repository.Metriks.Persona
{
    public class PersonaCupoRepository : IPersonaCupoRepository
    {
        private readonly ProgresoDbContext _context;
        private readonly IndicadorDbContext _indicadorContext;
        private readonly IPersonaCupoQuery _personaCupoQuery;
        private readonly IOptions<AppSettings> _config;

        public PersonaCupoRepository(ProgresoDbContext context, IndicadorDbContext indicadorContext, IPersonaCupoQuery personaCupoQuery, IOptions<AppSettings> config)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _indicadorContext = indicadorContext ?? throw new ArgumentNullException(nameof(indicadorContext));
            _personaCupoQuery = personaCupoQuery;
            _config = config;
        }
        public BusquedaLineaResponseDto? ObtenerLineaPorPersona(string rut, int tipoPersona)
        {
            string query = _personaCupoQuery.ObtenerLineaPorPersona(rut, tipoPersona);

            BusquedaLineaPersonaQueryResult? entidad = _context.BusquedaLineaPersona.FromSqlRaw(query).AsNoTracking().AsEnumerable().FirstOrDefault();

            string tipoPersonaIndicador = tipoPersona == _config.Value.TipoPersona.Cliente ? "C" : "D";

            int rutEntero = int.Parse(rut.Substring(0, rut.Length - 2));

            decimal concentracion = _indicadorContext.Indicador.Where(x => x.rut.Equals(rut) && x.id_rut.Equals(rutEntero) && x.co_tipo.Equals(tipoPersonaIndicador))
                .Sum(s => s.mt_concentracion);


            BusquedaLineaResponseDto response = new BusquedaLineaResponseDto()
            {
                LineaAutorizada = entidad?.LineaAutorizada ?? 0,
                LineaUtilizada = concentracion,
                LineaDisponible = 0,
                FechaAprobacion = entidad?.FechaAprobacion,
                FechaVencimiento = entidad?.FechaVencimiento,
                Estado = entidad?.Estado
            };


            return response;
        }
    }
}
