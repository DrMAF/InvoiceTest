using Core.Domain;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll(null).ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _repository.Get(predicate, null).ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, List<string> includes)
        {
            return _repository.Get(predicate, includes).ToList();
        }

        public IEnumerable<T> GetAll(List<string> includes)
        {
            return _repository.GetAll(includes).ToList();
        }

        public T GetByID(int id)
        {
            return _repository.GetByID(id, null);
        }

        public T GetByID(int id, List<string> includes)
        {
            return _repository.GetByID(id, includes);
        }

        public int Add(T entity)
        {
            return _repository.Add(entity);
        }

        public void Add(List<T> entites)
        {
            foreach (T item in entites)
            {
                Add(item);
            }
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Update(List<T> entity)
        {
            foreach (T item in entity)
            {
                Update(item);
            }
        }

        public void Delete(int id, bool softDelete = false)
        {
            var entity = GetByID(id);
            Delete(entity, softDelete);
        }

        public void Delete(Expression<Func<T, bool>> predicate, bool softDelete = false)
        {
            var entities = Get(predicate);

            if (entities != null && entities.Any())
            {
                foreach (T entity in entities)
                {
                    Delete(entity, softDelete);
                }
            }
        }

        public void Delete(T entity, bool softDelete = false)
        {
            _repository.Delete(entity, softDelete);
        }
    }
}
