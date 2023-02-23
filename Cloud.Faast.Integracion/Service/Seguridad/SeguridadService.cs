using AutoMapper;
using Cloud.Faast.Integracion.Interface.Repository.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Seguridad;
using Cloud.Faast.Integracion.Model.Entity.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Service.Seguridad
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
