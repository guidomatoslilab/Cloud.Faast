using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Dao.Queries.Persona
{
    public static class PersonaQuery
    {
        public static string BuscarPersona(PersonaRequestDto requestDto)
        {

            var sql = $@"
                SELECT 
                    persona.prg_int_idpersona AS Id,
                    persona.prg_vch_razonsocial AS RazonSocial,
                    empleado.prg_vch_correo AS CorreoEjecutivo,
                    CASE
                        WHEN ${requestDto.Tipo} = 1 THEN TRUE
                        ELSE EXISTS( SELECT 
                                *
                            FROM
                                tbl_prg_persona
                            WHERE
                                prg_vch_rut = '6448697-7'
                                    AND prg_int_idtipo = 1
                            LIMIT 1)
                    END AS Cliente,
                    CASE
                        WHEN 2 = 2 THEN TRUE
                        ELSE EXISTS( SELECT 
                                *
                            FROM
                                tbl_prg_persona
                            WHERE
                                prg_vch_rut = '6448697-7'
                                    AND prg_int_idtipo = 2
                            LIMIT 1)
                    END AS Deudor,
                    persona.prg_int_estado AS Estado
                FROM
                    tbl_prg_persona persona
                        LEFT JOIN
                    tbl_prg_personaempleado pempleado ON persona.prg_int_idpersona = pempleado.prg_int_idpersona
                        AND pempleado.prg_int_idnegocio = CASE
                        WHEN 1 = 1 THEN 1
                        ELSE 2
                    END
                        LEFT JOIN
                    tbl_prg_empleado empleado ON pempleado.prg_int_idempleado = empleado.prg_int_idempleado
                WHERE
                    persona.prg_vch_rut = '6448697-7'
                        AND persona.prg_int_idtipo = 1;
            ";

            return sql;

        }
    }
}
