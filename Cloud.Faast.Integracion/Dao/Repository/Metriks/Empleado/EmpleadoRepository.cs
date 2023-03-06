using Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;

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
