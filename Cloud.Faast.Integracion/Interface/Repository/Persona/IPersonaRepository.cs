using Cloud.Faast.Integracion.Model.Contract.Persona;
using Cloud.Faast.Integracion.Model.Dto.Persona;
using Cloud.Faast.Integracion.Model.Entity.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Repository.Persona
{
    public interface IPersonaRepository
    {
        PersonaResponseDto Buscar(string rut);
        Task<BusquedaPersonaResponseDto> SearchPersona(BusquedaPersonaRequestDto requestDto);
    }
}
