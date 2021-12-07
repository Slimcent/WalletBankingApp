using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Wallet.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T obj);
        Task<T> AddAsync(T obj);
        void AddRange(IList<T> obj);
        Task AddRangeAsync(IList<T> obj);

        T Update(T obj);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T GetById(object id);
        Task<T> GetByIdAsync(object id);


        T GetSingleByCondition(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable, IOrderedQueryable> orderby = null,
            params string[] includeProperties);

        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable, IOrderedQueryable> orderby = null,
            int? skip = null, int? take = null,
            params string[] includeProperties);

        T FindOneInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllAndInclude(params Expression<Func<T, object>>[] includeProperties);

        Task<bool> FindAnyAsync(Expression<Func<T, bool>> predicate = null);
        bool FindAny(Expression<Func<T, bool>> predicate = null);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Delete(T obj);
        void DeleteRange(IList<T> obj);
    }
}
