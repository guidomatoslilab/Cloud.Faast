namespace Cloud.Faast.Integracion.ViewModel.Metriks.Factoring
{
    public class DocumentoResponseViewModel
    {
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? RutDeudor { get; set; }
        public string? NombreDeudor { get; set; }
        public string? FechaVencimientoDocumento { get; set; }
        public decimal MontoDocumento { get; set; }
        public decimal MontoAnticipable { get; set; }
        public decimal DiferenciaPrecio { get; set; }
    }
}
