using Cloud.Faast.HangFire.Dao.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cloud.Faast.HangFire.Dao.Common
{
    public class BaseRepository<T> where T : class
    {
        protected readonly OrsanDbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(OrsanDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
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

        public virtual async Task<T?> FindAsync(
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

        public virtual async Task<T?> FindAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}