using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado
{
    public interface IEmpleadoRepository
    {
        EmpleadoResponseDto BuscarPorCorreo(string correo);
    }
}
