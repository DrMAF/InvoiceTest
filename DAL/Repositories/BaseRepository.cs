using Microsoft.EntityFrameworkCore;
using Core.Domain;
using Core.Interfaces.Repositories;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public FinanceDbContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(FinanceDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAll(List<string> includes)
        {
            if (includes != null && includes.Any())
            {
                return _entities.AsNoTracking().WithIncludes(includes).OrderByDescending(o => o.Id);
            }

            return _entities.AsNoTracking().OrderByDescending(o => o.Id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, List<string> includes)
        {
            return GetAll(includes).Where(predicate).OrderByDescending(o => o.Id);
        }

        public T GetByID(int id, List<string> includes)
        {
            return GetAll(includes).FirstOrDefault(i => i.Id == id);
        }

        public int Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
            }

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity, bool softDelete = false)
        {
            if (softDelete)
            {
                entity.IsDeleted = true;
                Update(entity); // has Save inside
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
