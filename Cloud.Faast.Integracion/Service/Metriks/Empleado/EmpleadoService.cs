using Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;

namespace Cloud.Faast.Integracion.Service.Metriks.Empleado
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public EmpleadoResponseDto BuscarPorCorreo(string rut)
        {
            EmpleadoResponseDto empleado = _empleadoRepository.BuscarPorCorreo(rut);
            return empleado;
        }
    }
}
