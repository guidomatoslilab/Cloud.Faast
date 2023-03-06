using Cloud.Faast.Integracion.Dao.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;

namespace Cloud.Faast.Integracion.Service.Metriks.Persona
{
    public class PersonaCupoService : IPersonaCupoService
    {
        private readonly IPersonaCupoRepository _personaCupoRepository;

        public PersonaCupoService(IPersonaCupoRepository personaCupoRepository)
        {
            _personaCupoRepository = personaCupoRepository;
        }

        public BusquedaLineaResponseDto? ObtenerLineaPorPersona(string rut, int tipoPersona)
        {
            BusquedaLineaResponseDto? response = _personaCupoRepository.ObtenerLineaPorPersona(rut, tipoPersona);

            response.LineaDisponible = (response?.LineaAutorizada ?? 0) - response.LineaUtilizada;

            return response;
        }
    }
}
