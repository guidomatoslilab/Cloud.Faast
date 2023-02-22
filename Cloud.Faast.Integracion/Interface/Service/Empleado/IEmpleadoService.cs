using Cloud.Faast.Integracion.Model.Dto.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Service.Empleado
{
    public interface IEmpleadoService
    {
        EmpleadoResponseDto Buscar(string rut);
    }
}
