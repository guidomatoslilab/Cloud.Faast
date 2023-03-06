using AutoMapper;
using Cloud.Faast.Integracion.Common.Error;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;

namespace Cloud.Faast.Integracion.Service.Metriks.Persona
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mappper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mappper)
        {
            _personaRepository = personaRepository;
            _mappper = mappper;
        }

        public PersonaResponseDto Buscar(PersonaRequestDto requestDto)
        {
            BusquedaPersonaEntity? persona = _personaRepository.Buscar(requestDto);

            PersonaResponseDto response = _mappper.Map<PersonaResponseDto>(persona);

            return response;
        }

        public async Task<BusquedaPersonaResponseDto> BuscarPersona(BusquedaPersonaRequestDto requestDto)
        {
            BusquedaPersonaResponseDto response;
            try
            {
                response = await _personaRepository.SearchPersona(requestDto);
            }
            catch (Exception e)
            {
                response = new BusquedaPersonaResponseDto() { Error = new ServiceException(e.Message) };
            }

            return response;
        }
    }
}
