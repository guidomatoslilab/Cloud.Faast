namespace Cloud.Faast.Integracion.ViewModel.Metriks.Persona
{
    public class BusquedaLineaResponseViewModel
    {
        public decimal LineaAutorizada { get; set; }
        public decimal LineaUtilizada { get; set; }
        public decimal LineaDisponible { get; set; }
        public string? FechaAprobacion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? Estado { get; set; }
    }
}
