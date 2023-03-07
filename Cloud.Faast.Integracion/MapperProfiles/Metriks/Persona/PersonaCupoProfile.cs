using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using AutoMapper;

namespace Cloud.Faast.Integracion.MapperProfiles.Metriks.Persona
{
    public class PersonaCupoProfile : Profile
    {
        public PersonaCupoProfile()
        {
            #region MAPEO DTO A VIEWMODEL

            CreateMap<BusquedaLineaResponseDto, BusquedaLineaResponseViewModel>();
            CreateMap<BusquedaLineaDeudorResponseDto, BusquedaLineaDeudorResponseViewModel>();

            #endregion
        }
    }
}
