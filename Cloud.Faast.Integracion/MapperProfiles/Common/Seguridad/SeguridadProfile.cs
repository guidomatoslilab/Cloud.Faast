using AutoMapper;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;

namespace Cloud.Faast.Integracion.MapperProfiles.Common.Seguridad
{
    public class SeguridadProfile : Profile
    {
        public SeguridadProfile()
        {
            #region MAPEO DTO A ENTITY

            CreateMap<ContratoDto, ContratoEntity>()
            .ForMember(x => x.id, y => y.MapFrom(c => c.Id))
            .ForMember(x => x.controller, y => y.MapFrom(c => c.Controller))
            .ForMember(x => x.fecha_creacion, y => y.MapFrom(c => c.FechaCreacion))
            .ForMember(x => x.contrato, y => y.MapFrom(c => c.Contrato))
            .ForMember(x => x.action, y => y.MapFrom(c => c.Action));

            #endregion

            #region MAPEO ENTITY A DTO

            CreateMap<ContratoApiKeyEntity, ContratoApiKeyDto>()
            .ForMember(x => x.Id, y => y.MapFrom(c => c.id))
            .ForMember(x => x.Country, y => y.MapFrom(c => c.country))
            .ForMember(x => x.Provider, y => y.MapFrom(c => c.provider))
            .ForMember(x => x.Status, y => y.MapFrom(c => c.status))
            .ForMember(x => x.Key, y => y.MapFrom(c => c.key))
            .ForMember(x => x.Method, y => y.MapFrom(c => c.method));

            #endregion
        }
    }
}
