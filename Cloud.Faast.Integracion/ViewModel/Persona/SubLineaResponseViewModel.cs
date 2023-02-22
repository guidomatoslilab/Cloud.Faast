﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.ViewModel.Persona
{
    public class SubLineaResponseViewModel
    {
        public string? RutDeudor { get; set; }
        public string? NombreDeudor { get; set; }
        public decimal MontoAutorizado { get; set; }
        public decimal MontoUtilizado { get; set; }
        public decimal MontoDisponible { get; set; }
        public string? EstadoDeudor { get; set; }
    }
}
