namespace Cloud.Faast.Integracion.ViewModel.Metriks.Factoring
{
    public class LiquidacionResponseViewModel
    {
        public string? RutCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? EstadoOperacion { get; set; }
        public string? FechaOperacion { get; set; }
        public string? FechaOtorgamiento { get; set; }
        public decimal PorcentajeAnticipo { get; set; }
        public decimal TasaOperacion { get; set; }
        public decimal ComisionOperacionFija { get; set; }
        public decimal IVAComisionFija { get; set; }
        public decimal ComisionOperacionVariable { get; set; }
        public decimal IVAComisionVariable { get; set; }
        public decimal GastosOperacion { get; set; }
        public decimal MontoOperacion { get; set; }
        public decimal MontoActicipable { get; set; }
        public decimal MontoRetencion { get; set; }
        public string? DiferenciaPrecio { get; set; }
        public decimal MontoAbono { get; set; }
        public string? FechaAbono { get; set; }
        public string? BancoAbono { get; set; }
        public string? NumeroCuentaAbono { get; set; }
        public List<DocumentoResponseViewModel>? Documentos { get; set; }
    }
}
