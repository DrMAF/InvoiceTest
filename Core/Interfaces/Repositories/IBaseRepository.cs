using Core.Domain;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetByID(int id, List<string> includes);
        IQueryable<T> GetAll(List<string> includes);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, List<string> includes);
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity, bool softDelete = false);
    }
}
