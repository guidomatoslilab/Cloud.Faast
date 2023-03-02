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

        public async Task<List<PersonaResponseDto>> Buscar(string rut, int tipo)
        {

            var x = await unitOfWork.ToExecuteProcedureWithReturns($"select prg_int_idpersona as Id, prg_vch_razonsocial as RazonSocial  from tbl_prg_persona where prg_int_idpersona = 445");

            //List<PersonaResponseDto> lista = unitOfWork.GroupJoin(unitOfWork.PersonaEmpleado,persona => persona.prg_int_idpersona,
            //    personaempleado => personaempleado.prg_int_idpersona,
            //    (persona, personaempleado) =>  new {persona, personaempleado})
            //    .SelectMany(s => s.personaempleado.DefaultIfEmpty(),(persona,personaempleado) => new {persona,personaempleado})
            //    .GroupJoin(unitOfWork.Empleado,ppe => ppe.personaempleado.prg_int_idempleado,
            //    empleado => empleado.prg_int_idempleado, (ppe, empleado) => new {ppe, empleado})
            //    .SelectMany(s => s.empleado.DefaultIfEmpty(), (ppe, empleado) => new { ppe.ppe.persona.persona, empleado })
            //    .Where(w => w.persona.prg_vch_rut.Equals(rut) &&  w.persona.prg_int_estado.Equals(1) && w.persona.prg_int_idtipo.Equals(tipo))
            //    .Select(s => new PersonaResponseDto()
            //    {
            //    Id = s.persona.prg_int_idpersona,
            //    //RazonSocial = s.persona.prg_vch_razonsocial,        
            //    //CorreoEjecutivo = s.empleado.prg_vch_correo,
            //    //Tipo = s.persona.prg_int_idtipo,
            //    //Estado = s.persona.prg_int_estado
            //    }).ToList();

            return new List<PersonaResponseDto>();

            //PersonaResponseDto aux = _context.Persona.Where(b => b.prg_vch_rut.Equals(rut))
            //.Select(s => new PersonaResponseDto()
            //{
            //    Id = s.prg_int_idpersona,
            //    RazonSocial = s.prg_vch_razonsocial,
            //    RutEjecutivo = s.prg_vch_rut
            //}).FirstOrDefault();
            //return aux;
        }
    }
}
