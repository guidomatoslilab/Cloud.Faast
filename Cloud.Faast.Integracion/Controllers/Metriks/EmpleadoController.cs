using AutoMapper;
using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using Cloud.Faast.Integracion.Utils;
using Cloud.Faast.Integracion.ViewModel.Metriks.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Faast.Integracion.Controllers.Metriks
{
    [Route("api/v1/Metriks/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]/{correo}")]
        public ActionResult BuscarPorCorreo(string correo)
        {
            EmpleadoResponseDto? empleadoResponseDto = _empleadoService.BuscarPorCorreo(correo);

            EmpleadoResponseViewModel response = _mapper.Map<EmpleadoResponseViewModel>(empleadoResponseDto);

            if (response is null)
            {
                return NotFound(new ResponseApi(Variables.CodigosRespuesta.NOTFOUND.ToString(), Variables.EstadosRespuesta.NOK, Variables.MensajesRespuesta.NOTFOUND, response));
            }

            return Ok(new ResponseApi(Variables.CodigosRespuesta.OK.ToString(), Variables.EstadosRespuesta.OK, Variables.MensajesRespuesta.OK, response));
        }
    }
}
