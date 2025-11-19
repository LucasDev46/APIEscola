

using Microsoft.EntityFrameworkCore;
using School.Business.Interface.Repository;
using School.Data.Context;
using System.Linq.Expressions;

namespace School.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SchoolDbContext _context;

        public Repository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public Task<T> SelectByQuery(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
