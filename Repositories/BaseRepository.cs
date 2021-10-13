using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserProductManagementAPI.Infrastructure;

namespace UserProductManagementAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        
        public virtual void Add(T entity) => _context.Set<T>().Add(entity);

        public virtual void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public virtual void Delete(T entity) => _context.Remove(entity);

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (Expression<Func<T, object>> i in includes)
            {
                query = query.Include(i);
            }
            return query.ToList();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(predicate);
            foreach (Expression<Func<T, object>> i in includes)
            {
                query = query.Include(i);
            }
            return query.ToList();
        }
        
        public int SaveChanges() => _context.SaveChanges();
    }
}
