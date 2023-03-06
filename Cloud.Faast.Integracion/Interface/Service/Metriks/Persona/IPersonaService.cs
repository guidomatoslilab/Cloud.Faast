using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;

namespace Cloud.Faast.Integracion.Interface.Service.Metriks.Persona
{
    public interface IPersonaService
    {
        PersonaResponseDto Buscar(string rut);
        Task<BusquedaPersonaResponseDto> BuscarPersona(BusquedaPersonaRequestDto requestDto);
    }
}
