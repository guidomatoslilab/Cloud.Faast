using AutoMapper;
using Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;
using Cloud.Faast.Integracion.Utils;
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
                var token = JwtHelper.GenerateToken(usuario.id.ToString(), usuario.secret_key,usuario.token_expiration_time);
                
                response = new()
                {
                    Token = token
                };
            }

            return response;
        }

        public ContratoApiKeyDto ObtenerApiKey(string method, string key, string provider, string country)
        {
            ContratoApiKeyEntity contratoApiKey = _seguridadRepository.ObtenerApiKey(method, key, provider, country);

            return _mapper.Map<ContratoApiKeyDto>(contratoApiKey);
        }

        public UsuarioIntegracionDto? ObtenerPorUsuario(string? usuario)
        {
            UsuarioIntegracionEntity? usuarioEncontrado = _seguridadRepository.ObtenerPorUsuario(usuario);

            return _mapper.Map<UsuarioIntegracionDto>(usuarioEncontrado);
        }
    }
}
