namespace Cloud.Faast.Integracion.Model.Entity.Common.Seguridad
{
    public class ContratoEntity
    {
        public int id { get; set; }
        public string? controller { get; set; }
        public string? action { get; set; }
        public string? contrato { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}
