using Core.Domain;
using System.Linq.Expressions;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAll(List<string> includes);
        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate);
        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate, List<string> includes);
        User GetByID(int id);
        User GetByID(int id, List<string> includes);
        User GetByUserName(string userName);
        User GetByEmail(string email);
        User GetByPhone(string email);
        int Add(User entity);
        void Add(List<User> entities);
        void Update(User entity);
        void Update(List<User> entity);
        void Delete(int id, bool softDelete = false);
        void Delete(Expression<Func<User, bool>> predicate, bool softDelete = false);
        void Delete(User entity, bool softDelete = false);
    }
}
