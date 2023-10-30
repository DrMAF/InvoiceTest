using Core.Domain;
using System.Linq.Expressions;

namespace Core.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(List<string> includes);
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, List<string> includes);
        T GetByID(int id);
        T GetByID(int id, List<string> includes);
        int Add(T entity);
        void Add(List<T> entities);
        void Update(T entity);
        void Update(List<T> entity);
        void Delete(int id, bool softDelete = false);
        void Delete(Expression<Func<T, bool>> predicate, bool softDelete = false);
        void Delete(T entity, bool softDelete = false);
    }
}
