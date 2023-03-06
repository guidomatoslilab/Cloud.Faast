using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Interface.Queries.Persona
{
    public interface IPersonaQuery
    {
        string Buscar(PersonaRequestDto requestDto);
    }
}
