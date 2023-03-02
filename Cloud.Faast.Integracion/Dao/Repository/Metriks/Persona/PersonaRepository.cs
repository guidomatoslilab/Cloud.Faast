using Cloud.Faast.Integracion.Dao.Commons;
using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Entity.Metriks.Persona;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Dao.Repository.Metriks.Persona
{
    public class PersonaRepository : BaseRepository<PersonaEntity>, IPersonaRepository
    {
        private readonly CommonRepository unitOfWork;

        //public PersonaRepository(ProgresoDbContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        public PersonaRepository(ProgresoDbContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
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

        public BusquedaPersonaEntity? Buscar(PersonaRequestDto requestDto)
        {
            BusquedaPersonaEntity? entidad = context.BusquedaPersona.FromSqlRaw($"select prg_int_idpersona as Id, prg_vch_razonsocial as RazonSocial  from tbl_prg_persona where prg_int_idpersona = 445").FirstOrDefault();

            return entidad;

        }
    }
}
