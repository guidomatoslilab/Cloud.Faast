using Cloud.Faast.HangFire.Interface.Repository.Orsan;
using Cloud.Faast.HangFire.Model.Entity.Orsan;

namespace Cloud.Faast.HangFire.Logic
{
    
    public class OperacionDocumentoLogic
    {
        private readonly IOperationDocumentoRepository _operationDocumentoRepository;
        public OperacionDocumentoLogic
        (
            IOperationDocumentoRepository operationDocumentoRepository
        )
        {
            _operationDocumentoRepository = operationDocumentoRepository;
        }

        public async Task<IEnumerable<OperacionDocumentoEntity>> ObtenerData()
        {
            var response = await _operationDocumentoRepository.ToExecuteProcedureWithReturns("sp_sel_reporte_excel_duemint");
            return response;
        }
    }
    
}
