using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;

namespace Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad
{
    public interface ISeguridadRepository
    {
        public bool Guardar(ContratoEntity dataItem);
        public ContratoApiKeyEntity? ObtenerApiKey(string method, string key, string provider, string country);
        public UsuarioIntegracionEntity? Login(string? usuario, string? clave);
        public UsuarioIntegracionEntity? ObtenerPorUsuario(string? usuario);
    }
}
