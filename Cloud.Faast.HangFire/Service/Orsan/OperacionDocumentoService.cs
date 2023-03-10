using AutoMapper;
using Cloud.Faast.HangFire.Common;
using Cloud.Faast.HangFire.Interface.Repository.Orsan;
using Cloud.Faast.HangFire.Interface.Service.Orsan;
using Cloud.Faast.HangFire.Logic;
using Cloud.Faast.HangFire.Model.Dto.Orsan;
using Cloud.Faast.HangFire.Util;
using Cloud.Faast.HangFire.Util.Orsan;
using Hangfire;
using Hangfire.Console;
using Hangfire.MAMQSqlExtension;
using Hangfire.Server;
using Microsoft.Extensions.Options;
using Renci.SshNet;
using System.ComponentModel;

namespace Cloud.Faast.HangFire.Service.Orsan
{
    public class OperacionDocumentoService: IOperacionDocumentoService
    {
        string PATH_LOCAL = "";
        string PATH_DESTINO = "";
        readonly string subFolder = "ORSAN";
        string nombreArchivoLocalGenerado = "";

        private readonly IOperationDocumentoRepository _operacionDocumentoRepository;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IMapper _mapper;
        private readonly OperacionDocumentoLogic _operacionDocumentoLogic;

        public OperacionDocumentoService
        (
            IOperationDocumentoRepository operacionDocumentoRepository,
            IOptions<AppSettings> appSettings
            , IMapper mapper
        )
        {
            _operacionDocumentoRepository = operacionDocumentoRepository;
            _appSettings = appSettings;
            _mapper = mapper;
            _operacionDocumentoLogic = new OperacionDocumentoLogic(_operacionDocumentoRepository);
        }

        [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Delete)] //reintentos, por defecto son 10
        [DisableConcurrentExecution(timeoutInSeconds: 5)] //hacer que espere 1 segundo para que inicie el siguiente y si se lanzan 2 al mismo tiempo o continuo solo entra 1 y los otros caen en deleted
        [DisplayName("Transferir excel a FTP de Orsan")]
        [RetryInQueue("transfer_file_to_orsan")]
        public async Task TransferExcelToFTP(PerformContext context, CancellationToken ctoken)
        {
            try
            {
                PATH_LOCAL = _appSettings.Value.Orsan.FTP.RutaArchivoLocal;
                PATH_DESTINO = _appSettings.Value.Orsan.FTP.CarpetaDestino;

                var nombre_archivo_destino = $"{DateTime.Now:yyyyMMdd}.xls";

                byte[] excel_ready = Array.Empty<byte>();

                Log.WriteLine(context, "Ejecutando consulta hacia base de datos");

                var operacionesDocumentoResponseDto = new List<ReporteOperacionDocumentoResponseDto>();
                var listadoProcesar = await _operacionDocumentoLogic.ObtenerData();

                operacionesDocumentoResponseDto.AddRange(from operacionDocumento in listadoProcesar
                                                         let operacionDocumentoDto = _mapper.Map<ReporteOperacionDocumentoResponseDto>(operacionDocumento)
                                     select operacionDocumentoDto);


                if (operacionesDocumentoResponseDto.Count == 0)
                {
                    Log.WriteLine(context, "Consulta no devuelve datos");
                }
                else
                {
                    Log.WriteLine(context, $"Generando archivo Excel con {operacionesDocumentoResponseDto.Count():N0} registro(s)");
                    excel_ready = ConvertToExcel(operacionesDocumentoResponseDto);
                }

                if (excel_ready.Length > 0)
                {
                    Log.WriteLine(context, "Subiendo archivo xls a servidor FTP");
                    Log.WriteLine(context, "===================================");
                    Log.WriteLine(context, $"Servidor FTP: {_appSettings.Value.Orsan.FTP.Host}");
                    Log.WriteLine(context, $"Puerto: {_appSettings.Value.Orsan.FTP.Port}");
                    Log.WriteLine(context, $"Usuario FTP: {_appSettings.Value.Orsan.FTP.UserName}");
                    Log.WriteLine(context, $"Password FTP: {_appSettings.Value.Orsan.FTP.Password}");
                    Log.WriteLine(context, $"Carpeta archivo destino: {PATH_DESTINO}");
                    Log.WriteLine(context, $"Nombre archivo destino: {nombre_archivo_destino}");
                    Log.WriteLine(context, $"Ruta archivo local: {ObtenerRutaCarpetaLocal()}");
                    Log.WriteLine(context, $"Nombre archivo local: {ObtenerNombreArchivoLocal()}");
                    Log.WriteLine(context, "Transfiriendo archivo...");

                    var respuestaFTP = UploadFileToFTP(nombre_archivo_destino, context);

                    if (respuestaFTP)
                    {
                        Log.WriteLine(context, "Archivo excel transferido con éxito", ConsoleTextColor.Green);
                    }
                    else
                    {
                        Log.WriteLine(context, "Error al intentar transferir archivo hacia servidor FTP");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLine(context, "Error: " + ex.Message, ConsoleTextColor.Red);
            }
            finally
            {
                Log.WriteLine(context, "Proceso finalizado");
            }

        }

        private byte[] ConvertToExcel(List<ReporteOperacionDocumentoResponseDto> data)
        {
            try
            {
                GenerarNombreArchivoLocal();
                var ruta_carpeta_local = ObtenerRutaCarpetaLocal();
                var ruta_archivo_local = ObtenerRutaArchivoLocal();

                if (!Directory.Exists(ruta_carpeta_local))
                {
                    Directory.CreateDirectory(ruta_carpeta_local);
                }

                var excel_stream = ExcelUtil.BuildXlsxFile(data);
                File.WriteAllBytes(ruta_archivo_local, excel_stream);

                return excel_stream;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ObtenerRutaCarpetaLocal()
        {
            var carpeta_principal = Path.Combine(subFolder);
            var carpeta_dia = DateTime.Today.ToString("dd_MM_yyyy");
            return Path.Combine(PATH_LOCAL, carpeta_principal, carpeta_dia);
        }

        private string ObtenerRutaArchivoLocal()
        {
            return Path.Combine(ObtenerRutaCarpetaLocal(), ObtenerNombreArchivoLocal());
        }
        private string ObtenerNombreArchivoLocal()
        {
            return nombreArchivoLocalGenerado;
        }
        private void GenerarNombreArchivoLocal()
        {
            nombreArchivoLocalGenerado = $"{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        }

        private bool UploadFileToFTP(string nombre_archivo_destino, PerformContext context)
        {
            var respuesta = false;

            try
            {
                var ruta_archivo_local = Path.Combine(ObtenerRutaCarpetaLocal(), ObtenerNombreArchivoLocal());

                if (!File.Exists(ruta_archivo_local))
                {
                    throw new Exception($"No se encuentra el archivo local: {ruta_archivo_local}");
                }

                try
                {
                    using (var client = new SftpClient(_appSettings.Value.Orsan.FTP.Host, _appSettings.Value.Orsan.FTP.Port, _appSettings.Value.Orsan.FTP.UserName, _appSettings.Value.Orsan.FTP.Password))
                    {
                        client.Connect();

                        if (client.IsConnected)
                        {
                            using (FileStream fileStream = File.Open(ruta_archivo_local, FileMode.Open, FileAccess.Read))
                            {
                                client.UploadFile(fileStream, $@"{PATH_DESTINO}/{nombre_archivo_destino}");
                            }
                        }

                        client.Disconnect();

                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLine(context, $"Error: {ex.Message}", ConsoleTextColor.Red);
                }

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
