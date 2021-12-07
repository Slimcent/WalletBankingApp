using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wallet.Repository.Interfaces;

namespace Wallet.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _dbContext.Set<T>();
        }

        public T Add(T obj)
        {
            _dbContext.Add(obj);
            return obj;
        }

        public async Task<T> AddAsync(T obj)
        {
            Add(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();

        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> predicate = null, Func<IQueryable, IOrderedQueryable> orderby = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            if (predicate is null) return _dbSet.ToList();
            return _dbSet.Where(predicate);
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> predicate = null, Func<IQueryable, IOrderedQueryable> orderby = null, params string[] includeProperties)
        {
            if (predicate is null) return _dbSet.ToList().FirstOrDefault();
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public async Task<bool> FindAnyAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is null) return await _dbSet.AnyAsync();
            return await _dbSet.AnyAsync(predicate);
        }

        public bool FindAny(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is null) return _dbSet.Any();
            return _dbSet.Any(predicate);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }


        public T Update(T obj)
        {
            _dbSet.Update(obj);
            return obj;
        }
        public void AddRange(IList<T> obj)
        {
            _dbSet.AddRange(obj);
        }

        public async Task AddRangeAsync(IList<T> obj)
        {
            await _dbSet.AddRangeAsync(obj);
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void DeleteRange(IList<T> obj)
        {
            _dbSet.RemoveRange(obj);
        }

        public T FindOneInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            T obj = query.FirstOrDefault(predicate);

            return obj;
        }

        public async Task<IEnumerable<T>> GetAllAndInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<T> results = await query.ToListAsync();
            return results;
        }

        private IQueryable<T> GetAllIncluding(Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();

            return includeProperties.Aggregate(queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
