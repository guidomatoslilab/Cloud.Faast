using AutoMapper;
using Cloud.Faast.Integracion.Model.Contract.Persona;
using Cloud.Faast.Integracion.Model.Dto.Persona;
using Cloud.Faast.Integracion.Model.Entity.Persona;
using Cloud.Faast.Integracion.ViewModel.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.MapperProfiles.PersonaProfiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            #region MAPEO DTO A VIEWMODEL
            CreateMap<PersonaResponseDto,PersonaResponseViewModel>();
            CreateMap<BusquedaPersonaResponseDto, BusquedaPersonaResponseViewModel>();
            
            #endregion
        }
    }
}
