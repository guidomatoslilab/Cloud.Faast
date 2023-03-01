using AutoMapper;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using Cloud.Faast.Integracion.ViewModel.Common.Seguridad;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            CreateMap<UsuarioIntegracionEntity, UsuarioIntegracionDto>()
            .ForMember(x => x.Id, y => y.MapFrom(c => c.id))
            .ForMember(x => x.Nombre, y => y.MapFrom(c => c.name))
            .ForMember(x => x.Usuario, y => y.MapFrom(c => c.user))
            .ForMember(x => x.Clave, y => y.MapFrom(c => c.password))
            .ForMember(x => x.SecretKey, y => y.MapFrom(c => c.secret_key))
            .ForMember(x => x.FechaCreacion, y => y.MapFrom(c => c.creation_date))
            .ForMember(x => x.Status, y => y.MapFrom(c => c.status));


            #endregion

            #region MAPEO VIEWMODEL A DTO

            CreateMap<LoginRequestViewModel, LoginRequestDto>();

            #endregion

            #region MAPEO DTO A VIEWMODEL

            CreateMap<LoginResponseDto, LoginResponseViewModel>();

            #endregion
        }
    }
}
