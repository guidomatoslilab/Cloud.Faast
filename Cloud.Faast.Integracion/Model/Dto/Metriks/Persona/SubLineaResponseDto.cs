namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Persona
{
    public class SubLineaResponseDto
    {
        public string? RutDeudor { get; set; }
        public string? NombreDeudor { get; set; }
        public decimal MontoAutorizado { get; set; }
        public decimal MontoUtilizado { get; set; }
        public decimal MontoDisponible { get; set; }
        public string? EstadoDeudor { get; set; }
    }
}
