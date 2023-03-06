using AutoMapper;
using Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Common.Seguridad;

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

        public ContratoApiKeyDto ObtenerApiKey(string method, string key, string provider, string country)
        {
            ContratoApiKeyEntity contratoApiKey = _seguridadRepository.ObtenerApiKey(method, key, provider, country);

            return _mapper.Map<ContratoApiKeyDto>(contratoApiKey);
        }
    }
}
