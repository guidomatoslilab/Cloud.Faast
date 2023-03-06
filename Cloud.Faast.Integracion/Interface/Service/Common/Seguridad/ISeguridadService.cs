using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;

namespace Cloud.Faast.Integracion.Interface.Service.Common.Seguridad
{
    public interface ISeguridadService
    {
        public bool Guardar(ContratoDto dataItem);
        public ContratoApiKeyDto? ObtenerApiKey(string method, string? key, string? provider, string? country);
        public LoginResponseDto? Login(LoginRequestDto request);
        public UsuarioIntegracionDto? ObtenerPorUsuario(string usuario);


    }
}
