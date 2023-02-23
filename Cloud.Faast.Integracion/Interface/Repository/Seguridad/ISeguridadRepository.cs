using Cloud.Faast.Integracion.Model.Entity.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Repository.Seguridad
{
    public interface ISeguridadRepository
    {
        public bool Guardar(ContratoEntity dataItem);
        public ContratoApiKeyEntity ObtenerApiKey(string method, string key, string provider, string country);
    }
}
