namespace Cloud.Faast.Integracion.Model.Dto.Common.Seguridad
{
    public class ContratoApiKeyDto
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? Provider { get; set; }
        public string? Method { get; set; }
        public string? Key { get; set; }
        public bool Status { get; set; }
    }
}
