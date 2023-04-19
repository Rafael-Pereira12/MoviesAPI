using BeeEngineering.Learning.MoviesApp.Data.Base;


namespace MoviesAPI.DataAccess
{
    public interface IDataAccessObject<TEntity> where TEntity : Entity
    {
        public Task Insert(TEntity entity);
        public Task<TEntity?> Get(Guid uuid, bool skipDeleted = true);
        public Task<List<TEntity>> List(bool skipDeleted = true);
        public Task Update(TEntity entity);
        public Task Delete(TEntity entity);
    }
}