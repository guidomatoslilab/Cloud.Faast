using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Entity.Seguridad
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
