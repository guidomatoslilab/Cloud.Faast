using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;

namespace Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado
{
    public interface IEmpleadoRepository
    {
        EmpleadoResponseDto BuscarPorCorreo(string correo);
    }
}
