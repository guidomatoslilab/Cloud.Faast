﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Entity.Seguridad
{
    public class ContratoEntity
    {
        public int id { get; set; }
        public string? controller { get; set; }
        public string? action { get; set; }
        public string? contrato { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}
