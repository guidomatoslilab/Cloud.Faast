using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona
{
    public interface IPersonaRepository
    {
        BusquedaPersonaEntity? Buscar(PersonaRequestDto requestDto);
        Task<BusquedaPersonaResponseDto> SearchPersona(BusquedaPersonaRequestDto requestDto);
    }
}
