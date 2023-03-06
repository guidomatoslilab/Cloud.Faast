using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Common.VariablesEntorno
{
    public class AppSettings
    {
        public TipoPersona? TipoPersona { get; set; }
        public TipoNegocio? TipoNegocio { get; set; }
    }

    public class TipoPersona
    {
        public int Cliente { get; set; }
        public int Deudor { get; set; }
    }

    public class TipoNegocio
    {
        public int Factoring { get; set; }
        public int BackOffice { get; set; }
    }
}
