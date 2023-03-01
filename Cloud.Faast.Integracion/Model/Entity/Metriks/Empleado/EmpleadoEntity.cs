using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Model.Entity.Metriks.Empleado
{
    public class EmpleadoEntity
    {
        public int prg_int_idempleado { get; set; }
        public int prg_int_idcargo { get; set; }
        public string? prg_vch_nombre { get; set; }
        public string? prg_vch_apellido { get; set; }
        public string? prg_vch_rut { get; set; }
        public string? prg_vch_telefono { get; set; }
        public string? prg_vch_correo { get; set; }
        public int prg_int_estado { get; set; }
    }
}
