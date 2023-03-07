using AutoMapper;
using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Common.VariablesEntorno;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Utils;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cloud.Faast.Integracion.Controllers.Metriks
{
    [Route("api/v1/Metriks/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(AuthorizationFilter))]
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaService _personaService;
        private readonly IPersonaCupoService _personaCupoService;
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _config;
        public PersonaController(IPersonaService personaService, IMapper mapper, IPersonaCupoService personaCupoService, IOptions<AppSettings> config)
        {
            _personaService = personaService;
            _mapper = mapper;
            _personaCupoService = personaCupoService;
            _config = config;
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult Buscar(PersonaRequestViewModel request)
        {

            var personaRequest = _mapper.Map<PersonaRequestDto>(request);

            PersonaResponseDto? personaResponseDto = _personaService.Buscar(personaRequest);

            if (personaResponseDto is null)
            {
                return NotFound(new ResponseApi(Variables.CodigosRespuesta.NOTFOUND.ToString(), Variables.EstadosRespuesta.NOK, Variables.MensajesRespuesta.NOTFOUND, personaResponseDto));
            }

            PersonaResponseViewModel? response = _mapper.Map<PersonaResponseViewModel>(personaResponseDto);

            return Ok(new ResponseApi(Variables.CodigosRespuesta.OK.ToString(), Variables.EstadosRespuesta.OK, Variables.MensajesRespuesta.OK, response));
        }



        [HttpGet]
        [Route("[action]/{rut}")]
        public ActionResult ObtenerLineaCliente(string rut)
        {
            BusquedaLineaResponseDto? lineaResponseDto = _personaCupoService.ObtenerLineaPorPersona(rut, _config.Value.TipoPersona.Cliente);

            if (lineaResponseDto is null)
            {
                return NotFound(new ResponseApi(Variables.CodigosRespuesta.NOTFOUND.ToString(), Variables.EstadosRespuesta.NOK, Variables.MensajesRespuesta.NOTFOUND, lineaResponseDto));
            }

            BusquedaLineaResponseViewModel? response = _mapper.Map<BusquedaLineaResponseViewModel>(lineaResponseDto);

            return Ok(response);
        }



        [HttpGet]
        [Route("[action]/{rut}")]
        public ActionResult ObtenerLineaDeudor(string rut)
        {
            BusquedaLineaDeudorResponseDto? lineaDeudorResponseDto = _personaCupoService.ObtenerLineaPorDeudor(rut);


            if (lineaDeudorResponseDto is null)
            {
                return NotFound(new ResponseApi(Variables.CodigosRespuesta.NOTFOUND.ToString(), Variables.EstadosRespuesta.NOK, Variables.MensajesRespuesta.NOTFOUND, lineaDeudorResponseDto));
            }

            BusquedaLineaDeudorResponseViewModel? response = _mapper.Map<BusquedaLineaDeudorResponseViewModel>(lineaDeudorResponseDto);

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]/{rut}")]
        public async Task<IActionResult> Search(string rut)
        {
            //IActionResult response = BadRequest(new { message = ErrorMessage.RequestError });
            IActionResult response = BadRequest(new { message = "No se pudo realizar la consulta, ocurrio un error, consulte con su administrador." });

            var requestDto = new BusquedaPersonaRequestDto
            {
                rut = rut
            };
            var busquedaPersonaResponseDto = await _personaService.BuscarPersona(requestDto);


            if (busquedaPersonaResponseDto.Error == null)
            {
                var responseViewModel = _mapper.Map<BusquedaPersonaResponseViewModel>(busquedaPersonaResponseDto);
                response = Ok(responseViewModel);
            }

            return Ok(response);
        }
    }
}
