using Cloud.Faast.Integracion.Model.Contract.Persona;
using Cloud.Faast.Integracion.Model.Dto.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Service.Persona
{
    public interface IPersonaService
    {
        PersonaResponseDto Buscar(string rut);
        Task<BusquedaPersonaResponseDto> BuscarPersona(BusquedaPersonaRequestDto requestDto);
    }
}
