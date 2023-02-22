using AutoMapper;
using Cloud.Faast.Integracion.Model.Dto.Empleado;
using Cloud.Faast.Integracion.ViewModel.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.MapperProfiles.Empleado
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
