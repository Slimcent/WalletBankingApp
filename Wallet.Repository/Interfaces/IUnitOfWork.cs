using System.Threading.Tasks;

namespace Wallet.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

    public interface IUnitofWork<TContext> : IUnitOfWork
    {
    }
}
