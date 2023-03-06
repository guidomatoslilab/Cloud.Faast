using Cloud.Faast.HangFire.Model.Entity.Orsan;

namespace Cloud.Faast.HangFire.Interface.Repository.Orsan
{
    public interface IOperationDocumentoRepository
    {
        Task<IEnumerable<OperacionDocumentoEntity>> ToExecuteProcedureWithReturns(
            string storedProcedureName,
            params object[] parameters)
            ;
    }
}
