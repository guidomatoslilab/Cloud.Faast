using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;


namespace Cloud.Faast.Integracion.Interface.Service.Metriks.Persona
{
    public interface IPersonaCupoService
    {
        BusquedaLineaResponseDto? ObtenerLineaPorPersona(string rut, int tipoPersona);
        BusquedaLineaDeudorResponseDto? ObtenerLineaPorDeudor(string rut);
    }
}
