namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Persona
{
    public class ObtenerCondicionComercialResponseDto
    {
        public decimal PorcentajeAnticipo { get; set; }
        public decimal Tasa { get; set; }
        public string TipoComisionFija { get; set; } = "";
        public string MonedaComisionFija { get; set; } = "";
        public decimal ValorComisionFija { get; set; }
        public decimal ValorComisionFijaLBTR { get; set; }
        public decimal ValorComisionFijaNotificacionNotaria { get; set; }
        public decimal ValorComisionFijaGastos { get; set; }
        public decimal ComisionVariable { get; set; }
    }
}
