using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Dto.Seguridad
{
    public class ContratoApiKeyDto
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? Provider { get; set; }
        public string? Method { get; set; }
        public string? Key { get; set; }
        public bool Status { get; set; }
    }
}
