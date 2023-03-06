using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona
{
    public class BusquedaLineaClienteQueryResult
    {
        public int Id { get; set; }
        public decimal LineaAutorizada { get; set; }
        public string? FechaAprobacion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? Estado { get; set; }
    }
}
