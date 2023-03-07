using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona;


namespace Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona
{
    public interface IPersonaRepository
    {
        BusquedaPersonaQueryResult? Buscar(PersonaRequestDto requestDto);
        Task<BusquedaPersonaResponseDto> SearchPersona(BusquedaPersonaRequestDto requestDto);
        List<ObtenerCondicionComercialQueryResult>? ObtenerCondicionComercial(ObtenerCondicionComercialRequestDto requestDto);
    }
}
