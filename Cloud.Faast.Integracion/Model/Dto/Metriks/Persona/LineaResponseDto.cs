namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Persona
{
    public class LineaResponseDto
    {
        public decimal LineaAutorizada { get; set; }
        public decimal LineaDisponible { get; set; }
        public string? FechaAprobacion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? Estado { get; set; }
        public string? Vigente { get; set; }
    }
}
