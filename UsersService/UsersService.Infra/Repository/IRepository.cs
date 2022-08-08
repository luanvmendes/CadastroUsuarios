namespace UsersService.Infra.Repository
{
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<TEntity> GetById(int id);
        ICollection<TEntity> GetAll();
    }

    public interface IRepository { }
}
