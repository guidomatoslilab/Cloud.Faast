using Cloud.Faast.HangFire.Model.Entity.Orsan;
using System.Linq.Expressions;

namespace Cloud.Faast.HangFire.Interface.Repository.Orsan
{
    public interface IOperationDocumentoRepository
    {
        Task<IEnumerable<OperacionDocumentoEntity>> ToExecuteProcedureWithReturns(
            string storedProcedureName = null,
            params Object[] parameters)
            ;
        Task<IEnumerable<OperacionDocumentoEntity>> ToListAsync(Expression<Func<OperacionDocumentoEntity, bool>> filter = null, Func<IQueryable<OperacionDocumentoEntity>, IOrderedQueryable<OperacionDocumentoEntity>> orderBy = null, string includeProperties = "");
        Task<OperacionDocumentoEntity> FindAsync(Expression<Func<OperacionDocumentoEntity, bool>> filter, string includeProperties = "");
    }
}
