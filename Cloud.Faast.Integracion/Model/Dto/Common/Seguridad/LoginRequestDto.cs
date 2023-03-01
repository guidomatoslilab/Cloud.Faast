using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Dto.Common.Seguridad
{
    public class LoginRequestDto
    {
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
    }
}
