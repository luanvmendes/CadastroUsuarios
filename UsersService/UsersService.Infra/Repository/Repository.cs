using UsersService.Infra.Context;

namespace UsersService.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UsersContext _usersContext;

        public Repository(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        public void Add(TEntity entity)
        {
            _usersContext.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            _usersContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _usersContext.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _usersContext.Set<TEntity>().FindAsync(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return _usersContext.Set<TEntity>().ToList();
        }
    }
}
