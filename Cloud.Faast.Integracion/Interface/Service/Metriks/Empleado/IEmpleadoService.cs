using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;

namespace Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado
{
    public interface IEmpleadoService
    {
        EmpleadoResponseDto? BuscarPorCorreo(string correo);
    }
}
