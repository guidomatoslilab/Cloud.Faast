using Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona;

namespace Cloud.Faast.Integracion.Dao.Queries.Metriks.Persona
{
    public class PersonaCupoQuery : IPersonaCupoQuery
    {
        public string ObtenerLineaPorPersona(string rut, int tipoPersona)
        {
            var sql = $@"
                SELECT 
                    prg_int_idcupo AS Id,
                    prg_dec_monto AS LineaAutorizada,
                    DATE_FORMAT(prg_dat_crea, '%d/%m/%Y') AS FechaAprobacion,
                    DATE_FORMAT(prg_dat_vigencia, '%d/%m/%Y') AS FechaVencimiento,
                    CASE
                        WHEN DATE(NOW()) <= DATE(prg_dat_vigencia) THEN 'VIGENTE'
                        ELSE 'NO VIGENTE'
                    END AS Estado
                FROM
                    tbl_prg_personacupo
                WHERE
                    prg_int_estado = 1
                        AND prg_int_idpersona = (SELECT 
                            prg_int_idpersona
                        FROM
                            tbl_prg_persona
                        WHERE
                            prg_vch_rut = '{rut}'
                                AND prg_int_idtipo = {tipoPersona}
                        LIMIT 1)
                        AND prg_int_idnegocio
                ORDER BY prg_dat_crea DESC
                LIMIT 1;
            ";

            return sql;
        }
    }
}
