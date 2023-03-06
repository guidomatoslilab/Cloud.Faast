using AutoMapper;
using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Utils;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Faast.Integracion.Controllers.Metriks
{
    [Route("api/v1/Metriks/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(AuthorizationFilter))]
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult Buscar(PersonaRequestViewModel request)
        {

            var personaRequest = _mapper.Map<PersonaRequestDto>(request);

            PersonaResponseDto personaResponseDto = _personaService.Buscar(personaRequest);

            PersonaResponseViewModel response = _mapper.Map<PersonaResponseViewModel>(personaResponseDto);

            if (response is null)
            {
                return NotFound(new ResponseApi(Variables.CodigosRespuesta.NOTFOUND.ToString(), Variables.EstadosRespuesta.NOK, Variables.MensajesRespuesta.NOTFOUND, response));
            }

            return Ok(new ResponseApi(Variables.CodigosRespuesta.OK.ToString(), Variables.EstadosRespuesta.OK, Variables.MensajesRespuesta.OK, response));
        }



        [HttpGet]
        [Route("[action]/{rut}")]
        public ActionResult ObtenerLineas(string rut)
        {
            //EmpleadoResponseDto empleadoResponseDto = _personaService.Buscar(rut);

            //EmpleadoResponseViewModel response = _mapper.Map<EmpleadoResponseViewModel>(empleadoResponseDto);

            //return Ok(response);
            return Ok();
        }



        [HttpGet]
        [Route("[action]/{rut}")]
        public ActionResult ObtenerSubLineas(string rut)
        {
            //EmpleadoResponseDto empleadoResponseDto = _personaService.Buscar(rut);

            //EmpleadoResponseViewModel response = _mapper.Map<EmpleadoResponseViewModel>(empleadoResponseDto);

            //return Ok(response);
            return Ok();
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
