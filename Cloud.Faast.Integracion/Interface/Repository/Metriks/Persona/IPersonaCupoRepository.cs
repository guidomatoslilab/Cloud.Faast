using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona;

namespace Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona
{
    public interface IPersonaCupoRepository
    {
        BusquedaLineaResponseDto? ObtenerLineaPorPersona(string rut, int tipoPersona);
    }
}
