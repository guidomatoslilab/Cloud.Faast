using AutoMapper;
using Cloud.Faast.Integracion.Interface.Service.Empleado;
using Cloud.Faast.Integracion.Interface.Service.Persona;
using Cloud.Faast.Integracion.Model.Dto.Empleado;
using Cloud.Faast.Integracion.ViewModel.Empleado;
using Cloud.Faast.Integracion.ViewModel.Persona;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Controllers
{
    [Route("api/v1/[controller]")]
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
        [Route("[action]/{rut}")]
        public ActionResult Buscar(string rut)
        {
            EmpleadoResponseDto empleadoResponseDto = _empleadoService.Buscar(rut);

            EmpleadoResponseViewModel response = _mapper.Map<EmpleadoResponseViewModel>(empleadoResponseDto);

            return Ok(response);
        }   
    }
}
