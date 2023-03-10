namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Factoring
{
    public class FactoringRequestDto
    {
        public string? RutCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? IdCanal { get; set; }
        public string? Estado { get; set; }
        public string? FechaOperacion { get; set; }
        public decimal PorcentajeAnticipo { get; set; }
        public decimal TasaOperacion { get; set; }
        public decimal ComisionOperacionFija { get; set; }
        public decimal ComisionOperacionVariable { get; set; }
        public decimal MontoOperacion { get; set; }
        public decimal MontoAnticipable { get; set; }
        public decimal DiferenciaPrecio { get; set; }
        public string? BancoAbono { get; set; }
        public string? NumeroCuentaAbono { get; set; }
        public List<DocumentoRequestDto>? Documentos { get; set; }
    }
}
