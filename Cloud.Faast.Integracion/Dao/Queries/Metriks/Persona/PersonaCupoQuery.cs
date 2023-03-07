using Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona;
using Microsoft.Extensions.Options;
using Cloud.Faast.Integracion.Common.VariablesEntorno;

namespace Cloud.Faast.Integracion.Dao.Queries.Metriks.Persona
{
    public class PersonaCupoQuery : IPersonaCupoQuery
    {
        private readonly IOptions<AppSettings> _config;
        public PersonaCupoQuery(IOptions<AppSettings> config)
        {
            _config = config;
        }
        public string ObtenerLineaPorPersona(string rut, int tipoPersona)
        {
            var sql = $@"
                SELECT 
                    prg_int_idcupo AS Id,
                    prg_dec_monto AS LineaAutorizada,
                    DATE_FORMAT(prg_dat_crea, '%d/%m/%Y') AS FechaAprobacion,
                    DATE_FORMAT(prg_dat_vigencia, '%d/%m/%Y') AS FechaVencimiento,
                    CASE
                        WHEN DATE(prg_dat_vigencia) > DATE(NOW()) THEN 'VIGENTE'
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
                        AND prg_int_idnegocio = {_config.Value.TipoNegocio.Factoring}
                ORDER BY prg_int_idcupo DESC
                LIMIT 1;
            ";

            return sql;
        }
    }
}
