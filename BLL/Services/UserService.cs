using Core.Domain;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll(null).ToList();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _repository.Get(predicate, null).ToList();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate, List<string> includes)
        {
            return _repository.Get(predicate, includes).ToList();
        }

        public IEnumerable<User> GetAll(List<string> includes)
        {
            return _repository.GetAll(includes).ToList();
        }

        public User GetByID(int id)
        {
            return _repository.GetByID(id, null);
        }

        public User GetByID(int id, List<string> includes)
        {
            return _repository.GetByID(id, includes);
        }

        public User GetByUserName(string userName)
        {
            return _repository.GetAll(null).FirstOrDefault(usr => usr.UserName == userName);
        }

        public User GetByEmail(string email)
        {
            return _repository.GetAll(null).FirstOrDefault(usr => usr.Email == email);
        }

        public User GetByPhone(string phone)
        {
            return _repository.GetAll(null).FirstOrDefault(usr => usr.Phone == phone);
        }

        public int Add(User entity)
        {
            return _repository.Add(entity);
        }

        public void Add(List<User> entites)
        {
            foreach (User item in entites)
            {
                Add(item);
            }
        }

        public void Update(User entity)
        {
            _repository.Update(entity);
        }

        public void Update(List<User> entity)
        {
            foreach (User item in entity)
            {
                Update(item);
            }
        }

        public void Delete(int id, bool softDelete = false)
        {
            var entity = GetByID(id);
            Delete(entity, softDelete);
        }

        public void Delete(Expression<Func<User, bool>> predicate, bool softDelete = false)
        {
            var entities = Get(predicate);

            if (entities != null && entities.Any())
            {
                foreach (User entity in entities)
                {
                    Delete(entity, softDelete);
                }
            }
        }

        public void Delete(User entity, bool softDelete = false)
        {
            _repository.Delete(entity, softDelete);
        }
    }
}
