namespace PruebaAPI4.Repository
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> Get();
        public Task<TEntity> GetById(int id);
        public Task Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task Save();
    }
}