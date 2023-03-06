using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona
{
    public interface IPersonaCupoQuery
    {
        string ObtenerLineaPorPersona(string rut, int tipoPersona);
    }
}
