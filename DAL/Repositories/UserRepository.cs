using Microsoft.EntityFrameworkCore;
using Core.Domain;
using Core.Interfaces.Repositories;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public FinanceDbContext _context;
        protected DbSet<User> _entities;

        public UserRepository(FinanceDbContext context)
        {
            _context = context;
            _entities = context.Set<User>();
        }

        public IQueryable<User> GetAll(List<string> includes)
        {
            if (includes != null && includes.Any())
            {
                return _entities.AsNoTracking().UserWithIncludes(includes).OrderByDescending(o => o.Id);
            }

            return _entities.AsNoTracking().OrderByDescending(o => o.Id);
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate, List<string> includes)
        {
            return GetAll(includes).Where(predicate).OrderByDescending(o => o.Id);
        }

        public User GetByID(int id, List<string> includes)
        {
            return GetAll(includes).SingleOrDefault(i => i.Id == id);
        }

        public int Add(User entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(User entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
            }

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User entity, bool softDelete = false)
        {
            if (softDelete)
            {
                entity.IsDeleted = true;
                Update(entity); // hase Save inside
            }
            else
            {
                _entities.Attach(entity);
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
