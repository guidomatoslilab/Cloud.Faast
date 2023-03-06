using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;

namespace Cloud.Faast.Integracion.Dao.Repository.Metriks.Empleado
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ProgresoDbContext _context;

        public EmpleadoRepository(ProgresoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EmpleadoResponseDto BuscarPorCorreo(string correo)
        {
            EmpleadoResponseDto empleadoResponse =  _context.Empleado
                .Join(_context.Cargo,empleado => empleado.prg_int_idcargo, cargo => cargo.prg_int_idcargo,(empleado, cargo) => new {empleado, cargo})
                .Where(w => w.empleado.prg_vch_correo.ToLower().Equals(correo.ToLower()) && w.empleado.prg_int_estado.Equals(1))
                .Select(s => new EmpleadoResponseDto()
                {
                    Id = s.empleado.prg_int_idempleado,
                    Nombre = s.empleado.prg_vch_nombre,
                    Telefono = s.empleado.prg_vch_telefono,
                    Rut = s.empleado.prg_vch_correo,
                    Cargo = s.cargo.prg_vch_nombre
                })
                .FirstOrDefault();

            return empleadoResponse;
        }
    }
}
