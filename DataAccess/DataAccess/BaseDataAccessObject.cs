using BeeEngineering.Learning.MoviesApp.Data;
using BeeEngineering.Learning.MoviesApp.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.DataAccess
{

    public abstract class BaseDataAccessObject<TEntity> where TEntity : Entity
    {
        protected readonly MoviesAppContext _dbContext;

        public BaseDataAccessObject(MoviesAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> List(bool skipDeleted = true)
        {
            return await _dbContext
                            .Set<TEntity>()
                            .Where(x => !skipDeleted || x.DeletedAt != DateTime.MinValue)
                            .ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity?> Get(Guid uuid, bool skipDeleted = true)
        {
            return await _dbContext
                            .Set<TEntity>()
                            .Where(x => !skipDeleted || x.DeletedAt == DateTime.MinValue)
                            .SingleOrDefaultAsync(x =>
                                x.Uuid == uuid
                             );
        }

        public async Task Update(TEntity entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entity.DeletedAt = DateTime.UtcNow;
            await Update(entity);
        }
    }
}

