using Cloud.Faast.Integracion.Dao.Commons;
using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Cloud.Faast.Integracion.Model.QueryResult.Metriks.Persona;
using Microsoft.EntityFrameworkCore;

namespace Cloud.Faast.Integracion.Dao.Repository.Metriks.Persona
{
    public class PersonaRepository : BaseRepository<PersonaEntity>, IPersonaRepository
    {
        private readonly CommonRepository unitOfWork;
        private readonly IPersonaQuery _personaQuery;

        public PersonaRepository(ProgresoDbContext context, IPersonaQuery personaQuery) : base(context)
        {
            unitOfWork = new CommonRepository(context);
            _personaQuery = personaQuery;
        }

        public async Task<PersonaEntity> AddPersona(PersonaEntity persona)
        {
            unitOfWork.Add(persona);
            await unitOfWork.SaveChangesAsync();

            return persona;
        }

        public async Task<PersonaEntity> UpdatePersona(PersonaEntity persona)
        {
            unitOfWork.Update(persona);
            await unitOfWork.SaveChangesAsync();

            return persona;
        }

        public async Task<BusquedaPersonaResponseDto> SearchPersona(BusquedaPersonaRequestDto requestDto)
        {
            var busquedaPersonaResponseDto = new BusquedaPersonaResponseDto();

            var query = (from per in context.Persona
                         where
                           (per.prg_vch_rut == requestDto.rut)
                         select new BusquedaPersonaDto
                         {
                             Id = per.prg_int_idpersona,
                             RUT = per.prg_vch_rut ?? "",
                             Nombre = per.prg_vch_nombre ?? ""
                         });

            var result = await unitOfWork.GetQuery(query);
            busquedaPersonaResponseDto.Result = result.ToList();

            return busquedaPersonaResponseDto;
        }

        public BusquedaPersonaQueryResult? Buscar(PersonaRequestDto requestDto)
        {
            string query = _personaQuery.Buscar(requestDto);

            BusquedaPersonaQueryResult? entidad = context.BusquedaPersona.FromSqlRaw(query).AsNoTracking().AsEnumerable().FirstOrDefault();

            return entidad;

        }

        public List<ObtenerCondicionComercialQueryResult>? ObtenerCondicionComercial(ObtenerCondicionComercialRequestDto requestDto)
        {
            var query = _personaQuery.ObtenerCondicionComercial(requestDto);
            var listResponse = context.ObtenerCondicionComercial.FromSqlRaw(query).AsNoTracking().AsEnumerable().ToList();
            return listResponse;
        }
        
        public PersonaEntity? ObtenerPersona(string rut, int tipoPersona)
        {
            PersonaEntity?  entidad = context.Persona.Where(w => w.prg_vch_rut.Equals(rut) && w.prg_int_idtipo.Equals(tipoPersona)).FirstOrDefault();

            return entidad;

        }
    }
}
