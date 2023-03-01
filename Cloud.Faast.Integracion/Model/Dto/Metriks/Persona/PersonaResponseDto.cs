using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Dto.Metriks.Persona
{
    public class PersonaResponseDto
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public bool Cliente { get; set; }
        public bool Deudor { get; set; }
        public int Tipo { get; set; }
        public string? CorreoEjecutivo { get; set; }
        public int Estado { get; set; }
    }
}
