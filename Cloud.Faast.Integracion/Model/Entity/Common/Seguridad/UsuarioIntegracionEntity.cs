using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Entity.Common.Seguridad
{
    public class UsuarioIntegracionEntity
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? user { get; set; }
        public string? password { get; set; }
        public string? country { get; set; }
        public string? secret_key { get; set; }
        public int token_expiration_time { get; set; }
        public DateTime creation_date { get; set; }
        public bool status { get; set; }

    }
}
