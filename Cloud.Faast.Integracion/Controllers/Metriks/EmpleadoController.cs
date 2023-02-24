﻿using AutoMapper;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Empleado;
using Cloud.Faast.Integracion.ViewModel.Metriks.Empleado;
using Cloud.Faast.Integracion.ViewModel.Metriks.Persona;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Route("[action]/{rut}")]
        public ActionResult Buscar(string rut)
        {
            EmpleadoResponseDto empleadoResponseDto = _empleadoService.Buscar(rut);

            EmpleadoResponseViewModel response = _mapper.Map<EmpleadoResponseViewModel>(empleadoResponseDto);

            return Ok(response);
        }
    }
}