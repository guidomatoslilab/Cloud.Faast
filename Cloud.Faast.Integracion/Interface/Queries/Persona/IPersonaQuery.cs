using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;

namespace Cloud.Faast.Integracion.Interface.Queries.Persona
{
    public interface IPersonaQuery
    {
        string Buscar(PersonaRequestDto requestDto);
        string ObtenerCondicionComercial(ObtenerCondicionComercialRequestDto requestDto);
    }
}
