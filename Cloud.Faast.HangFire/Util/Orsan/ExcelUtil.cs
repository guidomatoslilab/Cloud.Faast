using ClosedXML.Excel;
using Cloud.Faast.HangFire.Model.Dto.Orsan;

namespace Cloud.Faast.HangFire.Util.Orsan
{
    public class ExcelUtil
    {
        public static byte[] BuildXlsxFile(List<ReporteOperacionDocumentoResponseDto> reporte)
        {

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet1");

                    GenerateHeaders(worksheet);
                    GenerateBody(reporte, worksheet);

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return content;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void GenerateBody(List<ReporteOperacionDocumentoResponseDto> reporte, IXLWorksheet worksheet)
        {
            for (int index = 1; index <= reporte.Count; index++)
            {
                worksheet.Cell(index + 1, 1).Value = reporte[index - 1].RutCliente;
                worksheet.Cell(index + 1, 2).Value = reporte[index - 1].RazonSocialCliente;
                worksheet.Cell(index + 1, 3).Value = reporte[index - 1].RutDeudor;
                worksheet.Cell(index + 1, 4).Value = reporte[index - 1].RazonSocialDeudor;
                worksheet.Cell(index + 1, 5).Value = reporte[index - 1].NumeroOperacion;
                worksheet.Cell(index + 1, 6).Value = reporte[index - 1].CodigoTipoDocumento;
                worksheet.Cell(index + 1, 7).Value = reporte[index - 1].NumeroDocumento;
                worksheet.Cell(index + 1, 8).Value = reporte[index - 1].FechaCesion;
                worksheet.Cell(index + 1, 9).Value = reporte[index - 1].PorcentajeAnticipado;
                worksheet.Cell(index + 1, 10).Value = reporte[index - 1].MontoDocumento;
                worksheet.Cell(index + 1, 11).Value = reporte[index - 1].MontoSaldoDeudor;
                worksheet.Cell(index + 1, 12).Value = reporte[index - 1].MontoAnticipado;
                worksheet.Cell(index + 1, 13).Value = reporte[index - 1].MontoSaldoCliente;
                worksheet.Cell(index + 1, 14).Value = reporte[index - 1].CodigoEstadoDocumento;
                worksheet.Cell(index + 1, 15).Value = reporte[index - 1].FechaVencimiento;
                worksheet.Cell(index + 1, 16).Value = reporte[index - 1].FechaVencimientoReal;
                worksheet.Cell(index + 1, 17).Value = reporte[index - 1].CantidadDiasMora;
                worksheet.Cell(index + 1, 18).Value = reporte[index - 1].NumeroFacturaDP;
                worksheet.Cell(index + 1, 19).Value = reporte[index - 1].FechaAbono;
                worksheet.Cell(index + 1, 20).Value = reporte[index - 1].FechaGestion;
                worksheet.Cell(index + 1, 21).Value = reporte[index - 1].ComentarioGestion;
                worksheet.Cell(index + 1, 22).Value = reporte[index - 1].NombreEjecutivoCobranza;
                worksheet.Cell(index + 1, 23).Value = reporte[index - 1].NombreEjecutivo;
                worksheet.Cell(index + 1, 24).Value = reporte[index - 1].CodigoEstadoCobranza;
                worksheet.Cell(index + 1, 25).Value = reporte[index - 1].NombreEstadoGestion;
                worksheet.Cell(index + 1, 26).Value = reporte[index - 1].NombreSucursal;
                worksheet.Cell(index + 1, 27).Value = reporte[index - 1].MontoLineaAprobada;
                worksheet.Cell(index + 1, 28).Value = reporte[index - 1].MontoLineaDisponible;
                worksheet.Cell(index + 1, 29).Value = reporte[index - 1].Tramo;
                worksheet.Cell(index + 1, 30).Value = reporte[index - 1].NombreGrupo;
                worksheet.Cell(index + 1, 31).Value = reporte[index - 1].NombreTamanioEmpresaCliente;
                worksheet.Cell(index + 1, 32).Value = reporte[index - 1].NombreTerminoGiroCliente;
                worksheet.Cell(index + 1, 33).Value = reporte[index - 1].MontoVentaUfCliente;
                worksheet.Cell(index + 1, 34).Value = reporte[index - 1].NombreTamanioEmpresaDeudor;
                worksheet.Cell(index + 1, 35).Value = reporte[index - 1].NombreTerminoGiroDeudor;
                worksheet.Cell(index + 1, 36).Value = reporte[index - 1].MontoVentaUfDeudor;
            }
        }

        private static void GenerateHeaders(IXLWorksheet worksheet)
        {
            worksheet.Cell(1, 1).Value = "RUT CLIENTE";
            worksheet.Cell(1, 2).Value = "CLIENTE";
            worksheet.Cell(1, 3).Value = "RUT DEUDOR";
            worksheet.Cell(1, 4).Value = "DEUDOR";
            worksheet.Cell(1, 5).Value = "Nº OPE";
            worksheet.Cell(1, 6).Value = "TIPO DCTO";
            worksheet.Cell(1, 7).Value = "Nº DCTO";
            worksheet.Cell(1, 8).Value = "FECHA CES";
            worksheet.Cell(1, 9).Value = "% FINANC";
            worksheet.Cell(1, 10).Value = "MONTO DOC";
            worksheet.Cell(1, 11).Value = "SALDO MTO.DOC.";
            worksheet.Cell(1, 12).Value = "MONTO FINANC.";
            worksheet.Cell(1, 13).Value = "SALDO MTO.FINANC.";
            worksheet.Cell(1, 14).Value = "ESTADO";
            worksheet.Cell(1, 15).Value = "VCTO NOM";
            worksheet.Cell(1, 16).Value = "NUEVO VTO";
            worksheet.Cell(1, 17).Value = "DIAS MORA";
            worksheet.Cell(1, 18).Value = "DP";
            worksheet.Cell(1, 19).Value = "FECHA PAGO";
            worksheet.Cell(1, 20).Value = "FECHA ULT. GESTIÓN";
            worksheet.Cell(1, 21).Value = "OBSERVACIÓN";
            worksheet.Cell(1, 22).Value = "COBRADOR";
            worksheet.Cell(1, 23).Value = "EJECUTIVO";
            worksheet.Cell(1, 24).Value = "CODIGO EST. COB.";
            worksheet.Cell(1, 25).Value = "ESTADO COBRANZA";
            worksheet.Cell(1, 26).Value = "SUCURSAL";
            worksheet.Cell(1, 27).Value = "LINEA APROBADA";
            worksheet.Cell(1, 28).Value = "LINEA DISPONIBLE";
            worksheet.Cell(1, 29).Value = "TRAMO";
            worksheet.Cell(1, 30).Value = "GRUPO";
            worksheet.Cell(1, 31).Value = "TAMAÑO EMPRESA CLIENTE";
            worksheet.Cell(1, 32).Value = "TERMINO GIRO CLIENTE";
            worksheet.Cell(1, 33).Value = "VENTAS EN UF CLIENTE";
            worksheet.Cell(1, 34).Value = "TAMAÑO EMPRESA DEUDOR";
            worksheet.Cell(1, 35).Value = "TERMINO GIRO DEUDOR";
            worksheet.Cell(1, 36).Value = "VENTAS EN UF DEUDOR";
        }
    }
}
