﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado
{
    public class EmpleadoResponseDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Rut { get; set; }
        public string? Cargo { get; set; }
    }
}
