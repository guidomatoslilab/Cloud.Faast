using Cloud.Faast.Integracion.Model.Contract.Persona;
using Cloud.Faast.Integracion.Model.Dto.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Repository.Empleado
{
    public interface IEmpleadoRepository
    {
        EmpleadoResponseDto Buscar(string rut);
    }
}
