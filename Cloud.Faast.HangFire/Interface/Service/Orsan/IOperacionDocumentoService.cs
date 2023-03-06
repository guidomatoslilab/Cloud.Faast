using Hangfire.Server;

namespace Cloud.Faast.HangFire.Interface.Service.Orsan
{
    public interface IOperacionDocumentoService
    {
        Task TransferExcelToFTP(PerformContext context, CancellationToken ctoken);
    }
}
