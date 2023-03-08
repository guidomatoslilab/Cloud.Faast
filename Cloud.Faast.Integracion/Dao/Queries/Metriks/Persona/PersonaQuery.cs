using Cloud.Faast.Integracion.Common.VariablesEntorno;
using Cloud.Faast.Integracion.Interface.Queries.Metriks.Persona;
using Cloud.Faast.Integracion.Model.Dto.Metriks.Persona;
using Microsoft.Extensions.Options;

namespace Cloud.Faast.Integracion.Dao.Queries.Metriks.Persona
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

        public string ObtenerCondicionComercial(ObtenerCondicionComercialRequestDto requestDto)
        {

            //var sql = $@"
            //SELECT 
            //0.0 as PorcentajeAnticipo,
            //0.0 as Tasa,
            //'' as TipoComisionFija,
            //'' as MonedaComisionFija,
            //0.0 as ValorComisionFija,
            //0.0 as ValorComisionFijaLBTR,
            //0.0 as ValorComisionFijaNotificacionNotaria,
            //0.0 as ValorComisionFijaGastos,
            //0.0 as ComisionVariable
            //;
            //";

            var sql = $@"
            SELECT
            IFNULL(pin.prg_dec_anticipo,-1) AS PorcentajeAnticipo,
            IFNULL(pin.prg_dec_tasa,-1) AS Tasa,
            '' as TipoComisionFija,
            '' as MonedaComisionFija,
            IFNULL(pin.prg_dec_comision,-1) AS ValorComisionFija,
            IFNULL(pin.prg_dec_lbtr,-1) AS ValorComisionFijaLBTR,
            IFNULL(pin.prg_dec_notificacionnotaria,-1) AS ValorComisionFijaNotificacionNotaria,
            IFNULL(pin.prg_dec_gastooperacional,-1) AS ValorComisionFijaGastos,
            0.0 as ComisionVariable
            FROM tbl_prg_personacliente_indicadores pin
            INNER JOIN tbl_prg_persona p
	            ON  p.prg_int_idpersona = pin.prg_int_idpersona
                AND p.prg_int_estado = 1
            INNER JOIN tbl_prg_empleado e
	            ON  e.prg_int_idempleado = pin.prg_int_idejecutivo
                AND e.prg_int_estado = 1
            WHERE
            pin.prg_int_idpersona = (SELECT prg_int_idpersona FROM tbl_prg_persona WHERE prg_vch_rut = 'sdad' AND prg_int_idtipo = 1)
            ;
            ";

            //var sql = $@"
            //SELECT 
            //pin.prg_dat_crea, 
            //pin.prg_int_personacliente_indicadores, 
            //pin.prg_int_idpersona, 
            //IFNULL(pin.prg_dec_plazo,-1) AS prg_dec_plazo, 
            //IFNULL(pin.prg_dec_anticipo,-1) AS prg_dec_anticipo, 
            //IFNULL(pin.prg_dec_tasa,-1) AS prg_dec_tasa, 
            //IFNULL(pin.prg_dec_comision,-1) AS prg_dec_comision, 
            //IFNULL(pin.prg_dec_lbtr,-1) AS prg_dec_lbtr, 
            //IFNULL(pin.prg_dec_gastooperacional,-1) AS prg_dec_gastooperacional, 
            //IFNULL(pin.prg_dec_notificacionnotaria,-1) AS prg_dec_notificacionnotaria,
            //pin.prg_int_idejecutivo, 
            //pin.prg_int_estado, 
            //CONCAT(e.prg_vch_nombre, ' ', e.prg_vch_apellido) AS nombreejecutivo 
            //FROM tbl_prg_personacliente_indicadores pin
            //INNER JOIN tbl_prg_persona p
            // ON  p.prg_int_idpersona = pin.prg_int_idpersona
            //    AND p.prg_int_estado = 1
            //INNER JOIN tbl_prg_empleado e
            // ON  e.prg_int_idempleado = pin.prg_int_idejecutivo
            //    AND e.prg_int_estado = 1
            //WHERE
            //pin.prg_int_idpersona = (SELECT prg_int_idpersona FROM tbl_prg_persona WHERE prg_vch_rut = '{requestDto.RutCliente}' AND prg_int_idtipo = {_config.Value.TipoPersona?.Cliente})
            //;
            //";

            return sql;
        }
    }
}
