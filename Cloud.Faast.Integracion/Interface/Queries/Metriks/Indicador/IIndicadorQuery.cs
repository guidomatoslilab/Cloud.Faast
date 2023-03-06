using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Queries.Metriks.Indicador
{
    public interface IIndicadorQuery
    {
        string ObtenerIndicadorPorPersona(string rut, int tipoPersona);
    }
}
