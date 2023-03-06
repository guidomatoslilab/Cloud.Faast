using System.Linq.Expressions;
using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Microsoft.EntityFrameworkCore;

namespace Cloud.Faast.Integracion.Dao.Commons;

public class BaseRepository<T> where T : class
{
    protected readonly ProgresoDbContext context;
    protected readonly DbSet<T> dbSet;

    public BaseRepository(ProgresoDbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public async virtual Task<IEnumerable<T>> ToExecuteProcedureWithReturns(
        string storedProcedureName,
        params object[] parameters)
    {
        try
        {
            IQueryable<T> query = dbSet.FromSqlRaw<T>(storedProcedureName, parameters);
            return await query.ToListAsync();
        }
        catch
        {
            throw;
        }

    }

    public async virtual Task<IEnumerable<T>> ToListAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<T> query = dbSet;

        if (filter != null)

        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).AsNoTracking().ToListAsync();
        }
        else
        {
            return await query.AsNoTracking().ToListAsync();
        }
    }
    public async virtual Task<IEnumerable<T>> CustomToListAsync(
        Expression<Func<T, T>>? columns = null,
        Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (columns != null)
        {
            query = query.Select(columns);
        }

        return await query.ToListAsync();
    }
    public virtual IQueryable<T> Query(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).AsQueryable();
        }
        else
        {
            return query;
        }
    }

    public async virtual Task<T?> FindAsync(
        Expression<Func<T, bool>> filter,
        string includeProperties = "")
    {
        IQueryable<T> query = dbSet;

        query = query.Where(filter);

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        List<T> lstTemp = await query.AsNoTracking().ToListAsync();

        if (lstTemp.Count > 0)
        {
            return lstTemp[0];
        }
        else
        {
            return null;
        }
    }

    public async virtual Task<T?> FindAsync(object id)
    {
        return await dbSet.FindAsync(id);
    }
}