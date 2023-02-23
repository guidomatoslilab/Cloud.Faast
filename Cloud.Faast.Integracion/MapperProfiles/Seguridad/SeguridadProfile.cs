using AutoMapper;
using Cloud.Faast.Integracion.Model.Contract.Persona;
using Cloud.Faast.Integracion.Model.Dto.Persona;
using Cloud.Faast.Integracion.Model.Dto.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Seguridad;
using Cloud.Faast.Integracion.ViewModel.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.MapperProfiles.Seguridad
{
    public class SeguridadProfile : Profile
    {
        public SeguridadProfile()
        {
            #region MAPEO DTO A ENTITY
            CreateMap<ContratoApiKeyDto, ContratoApiKeyEntity>()
            .ForMember(x => x.id, y => y.MapFrom(c =>c.Id))
            .ForMember(x => x.country, y => y.MapFrom(c => c.Country))
            .ForMember(x => x.provider, y => y.MapFrom(c => c.Provider))
            .ForMember(x => x.status, y => y.MapFrom(c => c.Status))
            .ForMember(x => x.key, y => y.MapFrom(c => c.Key))
            .ForMember(x => x.method, y => y.MapFrom(c => c.Method));


            CreateMap<ContratoDto, ContratoEntity>()
            .ForMember(x => x.id, y => y.MapFrom(c => c.Id))
            .ForMember(x => x.controller, y => y.MapFrom(c => c.Controller))
            .ForMember(x => x.fecha_creacion, y => y.MapFrom(c => c.FechaCreacion))
            .ForMember(x => x.contrato, y => y.MapFrom(c => c.Contrato))
            .ForMember(x => x.action, y => y.MapFrom(c => c.Action));

            #endregion
        }
    }
}
