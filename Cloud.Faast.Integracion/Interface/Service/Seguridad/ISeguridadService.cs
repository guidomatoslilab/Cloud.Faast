using Cloud.Faast.Integracion.Model.Dto.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Service.Seguridad
{
    public interface ISeguridadService
    {
        public bool Guardar(ContratoDto dataItem);
        public ContratoApiKeyDto ObtenerApiKey(string method, string key, string provider, string country);
    }
}
