using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.ViewModel.Metriks.Persona
{
    public class BusquedaLineaDeudorResponseViewModel
    {
        public string? Rut { get; set; }
        public string? RazonSocial { get; set; }
        public decimal LineaAutorizada { get; set; }
        public decimal LineaUtilizada { get; set; }
        public decimal LineaDisponible { get; set; }
        public string? Estado { get; set; }
    }
}
