using Cloud.Faast.HangFire.Dao.Common;
using Cloud.Faast.HangFire.Dao.Context;
using Cloud.Faast.HangFire.Interface.Repository.Orsan;
using Cloud.Faast.HangFire.Model.Entity.Orsan;

namespace Cloud.Faast.HangFire.Dao.Repository.Orsan;

public class OperationDocumentoRepository : BaseRepository<OperacionDocumentoEntity>, IOperationDocumentoRepository
{
    private readonly CommonRepository unitOfWork;

    public OperationDocumentoRepository(OrsanDbContext context) : base(context)
    {
        unitOfWork = new CommonRepository(context);
    }

    public void ExportarExcel()
    {
        var test = unitOfWork.ToExecuteProcedureWithReturns("sdsds");
        
    }


}
