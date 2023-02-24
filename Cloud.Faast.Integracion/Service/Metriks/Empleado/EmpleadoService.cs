using Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Service.Metriks.Empleado
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public EmpleadoResponseDto Buscar(string rut)
        {
            EmpleadoResponseDto empleado = _empleadoRepository.Buscar(rut);
            return empleado;
        }
    }
}
