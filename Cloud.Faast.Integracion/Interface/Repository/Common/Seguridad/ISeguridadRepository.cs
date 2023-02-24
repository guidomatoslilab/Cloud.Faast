using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad
{
    public interface ISeguridadRepository
    {
        public bool Guardar(ContratoEntity dataItem);
        public ContratoApiKeyEntity ObtenerApiKey(string method, string key, string provider, string country);
    }
}
