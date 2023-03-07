using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;

namespace Cloud.Faast.Integracion.Interface.Queries.Metriks.CondicionComercial;

public interface ICondicionComercialQuery
{
    string Buscar(ObtenerCondicionComercialRequestDto requestDto);
}