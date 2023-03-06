namespace Cloud.Faast.Integracion.Model.Dto.Common.Seguridad
{
    public class ContratoDto
    {
        public int Id { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Contrato { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
