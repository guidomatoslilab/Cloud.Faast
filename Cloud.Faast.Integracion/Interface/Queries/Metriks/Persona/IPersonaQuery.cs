using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;

namespace Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona
{
    public interface IPersonaQuery
    {
        string Buscar(PersonaRequestDto requestDto);
        string ObtenerCondicionComercial(ObtenerCondicionComercialRequestDto requestDto);
    }
}
