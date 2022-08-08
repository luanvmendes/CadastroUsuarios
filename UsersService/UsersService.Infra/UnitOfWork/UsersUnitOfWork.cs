using System.Collections;
using UsersService.Infra.Context;
using UsersService.Infra.Repository;

namespace UsersService.Infra.UnitOfWork
{
    public class UsersUnitOfWork : IUsersUnitOfWork
    {
        private readonly UsersContext _usersContext;
        private Hashtable _repositories = new Hashtable();

        public UsersUnitOfWork(UsersContext usersContext, params (Type type, IRepository repository)[] repositories)
        {
            _usersContext = usersContext;
            repositories?.ToList().ForEach(i => _repositories.Add(i.type.Name, i.repository));
        }

        public void Dispose()
        {
            _usersContext.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            return (IRepository<TEntity>)_repositories[type];
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _usersContext.SaveChangesAsync();
            return true;
        }
    }
}
