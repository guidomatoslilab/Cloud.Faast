using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Service.Common.Seguridad
{
    public interface ISeguridadService
    {
        public bool Guardar(ContratoDto dataItem);
        public ContratoApiKeyDto ObtenerApiKey(string method, string key, string provider, string country);
        public LoginResponseDto? Login(LoginRequestDto request);

    }
}
