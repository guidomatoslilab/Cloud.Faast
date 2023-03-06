using AutoMapper;
using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Utils;
using Cloud.Faast.Integracion.ViewModel.Common.Seguridad;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Controllers.Common
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ISeguridadService _seguridadService;
        private readonly IMapper _mapper;

        public SeguridadController(ISeguridadService seguridadService, IMapper mapper)
        {
            _seguridadService = seguridadService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult Login(LoginRequestViewModel requestViewModel)
        {
            LoginRequestDto requestDto = _mapper.Map<LoginRequestDto>(requestViewModel);

            LoginResponseDto? loginResponseDto = _seguridadService.Login(requestDto);

            if (loginResponseDto is null)
            {
                return Unauthorized(new ResponseApi(Variables.CodigosRespuesta.UNAUTHORIZED.ToString(), Variables.EstadosRespuesta.NOK, "Usuario y/o clave son incorrectas.", null));
            }
            
            LoginResponseViewModel response = _mapper.Map<LoginResponseViewModel>(loginResponseDto);

            return Ok(new ResponseApi(Variables.CodigosRespuesta.OK.ToString(), Variables.EstadosRespuesta.OK, Variables.MensajesRespuesta.OK, response));
        }
    }
}
