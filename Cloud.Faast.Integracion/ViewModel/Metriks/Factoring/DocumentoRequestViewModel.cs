namespace Cloud.Faast.Integracion.ViewModel.Metriks.Factoring
{
    public class DocumentoRequestViewModel
    {
        public int TipoAnexo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? RutDeudor { get; set; }
        public string? NombreDeudor { get; set; }
        public string? FechaVencimientoDocumento { get; set; }
        public decimal MontoDocumento { get; set; }
    }
}
