using System.Linq.Expressions;

namespace School.Business.Interface.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectByQuery(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Commit();
    }
}
