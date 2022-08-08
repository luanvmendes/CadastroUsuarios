using Microsoft.EntityFrameworkCore;
using UsersService.Infra.Context;
using UsersService.Infra.Repository;

namespace UsersService.Infra.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<bool> SaveChangesAsync();
    }

    public interface IUsersUnitOfWork : IUnitOfWork<UsersContext> { }
}
