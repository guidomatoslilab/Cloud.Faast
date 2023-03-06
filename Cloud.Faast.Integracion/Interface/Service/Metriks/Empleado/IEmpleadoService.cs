using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado
{
    public interface IEmpleadoService
    {
        EmpleadoResponseDto BuscarPorCorreo(string correo);
    }
}
