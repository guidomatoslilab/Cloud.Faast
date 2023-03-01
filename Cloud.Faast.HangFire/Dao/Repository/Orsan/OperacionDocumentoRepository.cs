using System.Data;
using Cloud.Faast.HangFire.Interface.Repository.Orsan;
using Cloud.Faast.HangFire.Model.Dto.Orsan;
using static Cloud.Faast.HangFire.Common.Constantes;

namespace Cloud.Faast.HangFire.Dao.Repository.Orsan
{
    public class OperacionDocumentoRepository : BaseConnection, IOperacionDocumentoRepository
    {

        public OperacionDocumentoRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public List<ReporteOperacionDocumentoResponseDto> ObtenerReporteOperacionDocumento()
        {
            var listObjetoAlter = new List<ReporteOperacionDocumentoResponseDto>();

            using (var dbConnection = Sql.ObtenerConexion(BaseDatos.FastOrsan))
            {
                dbConnection.Open();
                using (var cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.sp_sel_reporte_excel_duemint";

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var objeto = new ReporteOperacionDocumentoResponseDto
                            {
                                RutCliente = dr["rut_cliente"].ToString() ?? "",
                                RazonSocialCliente = dr["razon_social_cliente"].ToString() ?? "",
                                RutDeudor = dr["rut_deudor"].ToString() ?? "",
                                RazonSocialDeudor = dr["razon_social_deudor"].ToString() ?? "",
                                NumeroOperacion = Convert.ToInt32(dr["nu_operacion"].ToString()),
                                CodigoTipoDocumento = dr["co_tipo_documento"].ToString() ?? "",
                                NumeroDocumento = Convert.ToDecimal(dr["nu_documento"].ToString()),
                                FechaCesion = dr["fe_cesion"].ToString() ?? "",
                                PorcentajeAnticipado = dr["po_anticipado"].ToString() ?? "",
                                MontoDocumento = dr["mt_documento"].ToString() ?? "",
                                MontoSaldoDeudor = dr["mt_saldo_deudor"].ToString() ?? "",
                                MontoAnticipado = dr["mt_anticipado"].ToString() ?? "",
                                MontoSaldoCliente = dr["mt_saldo_cliente"].ToString() ?? "",
                                CodigoEstadoDocumento = dr["co_estado_documento"].ToString() ?? "",
                                FechaVencimiento = dr["fe_vencimiento"].ToString() ?? "",
                                FechaVencimientoReal = dr["fe_vencimiento_real"].ToString() ?? "",
                                CantidadDiasMora = Convert.ToInt32(dr["qt_dias_mora"].ToString()),
                                NumeroFacturaDP = dr["nu_factura_dp"].ToString() ?? "",
                                FechaAbono = dr["fe_abono"].ToString() ?? "",
                                FechaGestion = dr["fe_gestion"].ToString() ?? "",
                                ComentarioGestion = dr["tx_comentario_gestion"].ToString() ?? "",
                                NombreEjecutivoCobranza = dr["no_ejecutivo_cobranza"].ToString() ?? "",
                                NombreEjecutivo = dr["no_ejecutivo"].ToString() ?? "",
                                CodigoEstadoCobranza = Convert.ToInt32(dr["co_estado_cobranza"].ToString()),
                                NombreEstadoGestion = dr["no_estado_gestion"].ToString() ?? "",
                                NombreSucursal = dr["no_sucursal"].ToString() ?? "",
                                MontoLineaAprobada = dr["mt_linea_aprobada"].ToString() ?? "",
                                MontoLineaDisponible = dr["mt_linea_disponible"].ToString() ?? "",
                                Tramo = dr["tramo"].ToString() ?? "",
                                NombreGrupo = dr["no_grupo"].ToString() ?? "",
                                NombreTamanioEmpresaCliente = dr["no_tamanio_empresa_cliente"].ToString() ?? "",
                                NombreTerminoGiroCliente = dr["no_termino_giro_cliente"].ToString() ?? "",
                                MontoVentaUfCliente = dr["mt_ventas_uf_cliente"].ToString() ?? "",
                                NombreTamanioEmpresaDeudor = dr["no_tamanio_empresa_deudor"].ToString() ?? "",
                                NombreTerminoGiroDeudor = dr["no_termino_giro_deudor"].ToString() ?? "",
                                MontoVentaUfDeudor = dr["mt_ventas_uf_deudor"].ToString() ?? ""
                            };

                            listObjetoAlter.Add(objeto);
                        }
                    }
                }
                dbConnection.Close();
            }
            return listObjetoAlter;
        }
    }
}
