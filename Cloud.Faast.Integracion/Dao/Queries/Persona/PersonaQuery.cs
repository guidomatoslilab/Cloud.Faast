using Cloud.Faast.Integracion.Common.VariablesEntorno;
using Cloud.Faast.Integracion.Interface.Queries.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Microsoft.Extensions.Options;

namespace Cloud.Faast.Integracion.Dao.Queries.Persona
{
    public class PersonaQuery : IPersonaQuery
    {
        private readonly IOptions<AppSettings> _config;

        public PersonaQuery(IOptions<AppSettings> config)
        {
            _config = config;
        }

        public string Buscar(PersonaRequestDto requestDto)
        {

            var sql = $@"
                SELECT 
                    persona.prg_int_idpersona AS Id,
                    persona.prg_vch_razonsocial AS RazonSocial,
                    empleado.prg_vch_correo AS CorreoEjecutivo,
                    CASE
                        WHEN {requestDto.Tipo} = {_config.Value.TipoPersona?.Cliente} THEN TRUE
                        ELSE EXISTS( SELECT 
                                prg_int_idpersona
                            FROM
                                tbl_prg_persona
                            WHERE
                                prg_vch_rut = '{requestDto.Rut}'
                                    AND prg_int_idtipo = {_config.Value.TipoPersona?.Cliente}
                            LIMIT 1)
                    END AS Cliente,
                    CASE
                        WHEN {requestDto.Tipo} = {_config.Value.TipoPersona?.Deudor} THEN TRUE
                        ELSE EXISTS( SELECT 
                                prg_int_idpersona
                            FROM
                                tbl_prg_persona
                            WHERE
                                prg_vch_rut = '{requestDto.Rut}'
                                    AND prg_int_idtipo = {_config.Value.TipoPersona?.Deudor}
                            LIMIT 1)
                    END AS Deudor,
                    persona.prg_int_estado AS Estado
                FROM
                    tbl_prg_persona persona
                        LEFT JOIN
                    tbl_prg_personaempleado pempleado ON persona.prg_int_idpersona = pempleado.prg_int_idpersona
                        AND pempleado.prg_int_idnegocio = CASE
                        WHEN  {requestDto.Tipo} = {_config.Value.TipoPersona?.Cliente} THEN {_config.Value.TipoNegocio?.BackOffice}
                        ELSE {_config.Value.TipoNegocio?.BackOffice}
                    END
                        LEFT JOIN
                    tbl_prg_empleado empleado ON pempleado.prg_int_idempleado = empleado.prg_int_idempleado
                WHERE
                    persona.prg_vch_rut = '{requestDto.Rut}'
                        AND persona.prg_int_idtipo = {requestDto.Tipo};
            ";

            return sql;

        }
    }
}
