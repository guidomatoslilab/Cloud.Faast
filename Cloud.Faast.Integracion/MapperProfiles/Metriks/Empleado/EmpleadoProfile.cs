using AutoMapper;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using Cloud.Faast.Integracion.ViewModel.Metriks.Empleado;

namespace Cloud.Faast.Integracion.MapperProfiles.Metriks.Empleado
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            #region MAPEO DTO A VIEWMODEL
            CreateMap<EmpleadoResponseDto, EmpleadoResponseViewModel>();
            #endregion
        }
    }
}
