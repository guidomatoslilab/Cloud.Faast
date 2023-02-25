using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Dto.Common.Seguridad
{
    public class UsuarioIntegracionDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public string? SecretKey { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Status { get; set; }

    }
}
