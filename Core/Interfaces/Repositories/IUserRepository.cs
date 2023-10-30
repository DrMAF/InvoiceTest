using Core.Domain;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetByID(int id, List<string> includes);
        IQueryable<User> GetAll(List<string> includes);
        IQueryable<User> Get(Expression<Func<User, bool>> predicate, List<string> includes);
        int Add(User entity);
        void Update(User entity);
        void Delete(User entity, bool softDelete = false);
    }
}
