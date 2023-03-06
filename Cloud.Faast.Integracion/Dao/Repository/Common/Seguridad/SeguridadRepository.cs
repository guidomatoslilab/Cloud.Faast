using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using Cloud.Faast.Integracion.Utils;

namespace Cloud.Faast.Integracion.Dao.Repository.Common.Seguridad
{
    public class SeguridadRepository : ISeguridadRepository
    {
        private readonly ProgresoDbContext _context;
        private readonly ILogger<SeguridadRepository> _logger;

        public SeguridadRepository(ProgresoDbContext context, ILogger<SeguridadRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public bool Guardar(ContratoEntity dataItem)
        {
            bool bandera;
            try
            {
                dataItem.fecha_creacion = DateTime.Now;
                _context.Contrato.Add(dataItem);
                _context.SaveChanges();

                bandera = true;
            }
            catch (Exception ex)
            {
                GeneralHelper.LogSentryIO(ex);
                _logger.LogError(ex, "SecurityRepository: Save");
                
                bandera = false;
            }
            return bandera;
        }

        public UsuarioIntegracionEntity? Login(string usuario, string clave)
        {
            UsuarioIntegracionEntity? entity;
            try
            {
                entity =  _context.UsuarioIntegracion
                    .Where(x => x.user.Equals(usuario) && x.password.Equals(clave) && x.status)
                    .FirstOrDefault();

            }
            catch (Exception ex)
            {
                GeneralHelper.LogSentryIO(ex);
                _logger.LogError(ex, "SecurityRepository: Login");
                entity = null;
            }

            return entity;
        }

        public ContratoApiKeyEntity? ObtenerApiKey(string method, string? key, string? provider, string? country)
        {
            ContratoApiKeyEntity? dataItem;
            try
            {
                dataItem = (from api in _context.ContratoApiKey
                            where
                            api.status == true
                            && api.method == method
                            && api.key == key
                            && api.country == country
                            && api.provider == provider
                            select api).FirstOrDefault();
            }
            catch (Exception ex)
            {
                GeneralHelper.LogSentryIO(ex);
                _logger.LogError(ex, "SecurityRepository: GetDataApiKey");
                dataItem = null;
            }
            return dataItem;
        }

        public UsuarioIntegracionEntity? ObtenerPorUsuario(string? usuario)
        {
            UsuarioIntegracionEntity? entity;
            try
            {
                entity = _context.UsuarioIntegracion
                    .Where(x => x.user.Equals(usuario) && x.status)
                    .FirstOrDefault();

            }
            catch (Exception ex)
            {
                GeneralHelper.LogSentryIO(ex);
                _logger.LogError(ex, "SecurityRepository: ObtenerPorUsuario");
                entity = null;
            }

            return entity;
        }
    }
}
