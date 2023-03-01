using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Service.Metriks.Persona
{
    public interface IPersonaService
    {
        PersonaResponseDto Buscar(PersonaRequestDto request);
        Task<BusquedaPersonaResponseDto> BuscarPersona(BusquedaPersonaRequestDto requestDto);
    }
}
