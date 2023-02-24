using Cloud.Faast.HangFire.Model.Dto.Orsan;

namespace Cloud.Faast.HangFire.Interface.Repository.Orsan
{
    public interface IOperacionDocumentoRepository
    {
        List<ReporteOperacionDocumentoResponseDto> ObtenerReporteOperacionDocumento();
    }
}
