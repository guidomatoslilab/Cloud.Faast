using Cloud.Faast.Integracion.Common.VariablesEntorno;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Cloud.Faast.Integracion.Utils.Exceptions;
using Microsoft.Extensions.Options;

namespace Cloud.Faast.Integracion.Service.Metriks.Persona
{
    public class PersonaCupoService : IPersonaCupoService
    {
        private readonly IPersonaCupoRepository _personaCupoRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IOptions<AppSettings> _config;

        public PersonaCupoService(IPersonaCupoRepository personaCupoRepository, IOptions<AppSettings> config, IPersonaRepository personaRepository)
        {
            _personaCupoRepository = personaCupoRepository;
            _config = config;   
            _personaRepository = personaRepository;
        }

        public BusquedaLineaResponseDto? ObtenerLineaPorPersona(string rut, int tipoPersona)
        {
            BusquedaLineaResponseDto? response = _personaCupoRepository.ObtenerLineaPorPersona(rut, tipoPersona);

            if (response is null)
            {
                return null;
            }

            response.LineaDisponible = (response?.LineaAutorizada ?? 0) - (response?.LineaUtilizada ?? 0);

            return response;
        }

        public BusquedaLineaDeudorResponseDto? ObtenerLineaPorDeudor(string rut)
        {
            PersonaEntity? persona =  _personaRepository.ObtenerPersona(rut, _config.Value.TipoPersona.Deudor);

            if (persona is null)
            {
                return null;
            }

            BusquedaLineaResponseDto? linea = ObtenerLineaPorPersona(rut, _config.Value.TipoPersona.Deudor);

            BusquedaLineaDeudorResponseDto response = new ()
            {
                LineaAutorizada = (linea?.LineaAutorizada ?? 0),
                LineaUtilizada = (linea?.LineaUtilizada ?? 0),
                LineaDisponible = (linea?.LineaDisponible ?? 0),
                Estado = linea?.Estado,
                Rut = persona?.prg_vch_rut,
                RazonSocial = persona?.prg_vch_razonsocial
            };

            return response;
        }
    }
}
