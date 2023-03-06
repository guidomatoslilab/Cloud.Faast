namespace Cloud.Faast.Integracion.Model.Entity.Common.Seguridad
{
    public class ContratoApiKeyEntity
    {
        public int id { get; set; }
        public string? country { get; set; }
        public string? provider { get; set; }
        public string? method { get; set; }
        public string? key { get; set; }
        public bool status { get; set; }
    }
}
