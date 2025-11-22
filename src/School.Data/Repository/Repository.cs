

using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Data.Context;
using System.Linq.Expressions;

namespace School.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SchoolDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(SchoolDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public Task<T> SelectByQuery(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

    }
}
