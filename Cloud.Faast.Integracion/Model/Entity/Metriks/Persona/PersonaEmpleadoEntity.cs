using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Entity.Metriks.Persona
{
    public class PersonaEmpleadoEntity
    {
        public int prg_int_idpersonaempleado { get; set; }
        public int prg_int_idpersona { get; set; }
        public int prg_int_idnegocio { get; set; }
        public int prg_int_idempleado { get; set; }
        public int prg_int_idcargo { get; set; }
        public int prg_int_estado { get; set; }
    }
}
