using Cloud.Faast.Integracion.Common.Error;

namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Persona
{
    public class BusquedaPersonaResponseDto
    {
        public List<BusquedaPersonaDto>? Result { get; set; }
        public ServiceException? Error { get; set; }

    }
    public class BusquedaPersonaDto
    {
        public int? Id { get; set; }
        public string? RUT { get; set; }
        public string? Nombre { get; set; }
    }
}
