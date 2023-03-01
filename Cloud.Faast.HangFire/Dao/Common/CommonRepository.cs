using Microsoft.EntityFrameworkCore;
using Cloud.Faast.HangFire.Dao.Context;
using Cloud.Faast.HangFire.Model.Entity;

namespace Cloud.Faast.HangFire.Dao.Common;

public class CommonRepository : BaseRepository<EntityBase>
{
    public CommonRepository(OrsanDbContext context) : base(context)
    {

    }

    public virtual async Task<List<T>> GetQuery<T>(IQueryable<T> query) where T : class
    {
        return await query.ToListAsync();
    }
}