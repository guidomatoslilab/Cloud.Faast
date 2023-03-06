using AutoMapper;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.MapperProfiles.Metriks.PersonaProfiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            #region MAPEO DTO A VIEWMODEL
            CreateMap<PersonaResponseDto,PersonaResponseViewModel>();
            CreateMap<BusquedaPersonaResponseDto, BusquedaPersonaResponseViewModel>();

            #endregion

            #region MAPEO DE VIEWMODEL A DTO

            CreateMap<PersonaRequestViewModel, PersonaRequestDto>();

            #endregion

            #region MAPEO DE QUERY RESULT A DTO

            CreateMap<BusquedaPersonaQueryResult, PersonaResponseDto>();

            #endregion
        }
    }
}
