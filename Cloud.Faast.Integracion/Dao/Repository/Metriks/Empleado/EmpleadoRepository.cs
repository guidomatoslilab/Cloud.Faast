using Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Dao.Repository.Metriks.Empleado
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public EmpleadoResponseDto Buscar(string rut)
        {
            EmpleadoResponseDto responseDto = new()
            {
                Id = 1,
                Nombre = "Pabla Campusano",
                Email = "pabla.campusano@progreso.cl",
                Telefono = "987093178"
            };

            return responseDto;
        }
    }
}
