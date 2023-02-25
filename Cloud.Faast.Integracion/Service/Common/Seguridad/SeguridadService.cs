using AutoMapper;
using Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Service.Common.Seguridad
{
    public class SeguridadService : ISeguridadService
    {
        private readonly ISeguridadRepository _seguridadRepository;
        private readonly IMapper _mapper;

        public SeguridadService(ISeguridadRepository seguridadRepository, IMapper mapper)
        {
            _seguridadRepository = seguridadRepository;
            _mapper = mapper;
        }

        public bool Guardar(ContratoDto dataItem)
        {
            ContratoEntity contrato = _mapper.Map<ContratoEntity>(dataItem);

            return _seguridadRepository.Guardar(contrato);
        }

        public LoginResponseDto? Login(LoginRequestDto request)
        {

            LoginResponseDto? response = null;

            var usuario = _seguridadRepository.Login(request.Usuario, request.Clave);

            if (usuario is not null)
            {
                response = new()
                {
                    Token = "";
                };
            }

            return response;
        }

        public ContratoApiKeyDto ObtenerApiKey(string method, string key, string provider, string country)
        {
            ContratoApiKeyEntity contratoApiKey = _seguridadRepository.ObtenerApiKey(method, key, provider, country);

            return _mapper.Map<ContratoApiKeyDto>(contratoApiKey);
        }
    }
}
