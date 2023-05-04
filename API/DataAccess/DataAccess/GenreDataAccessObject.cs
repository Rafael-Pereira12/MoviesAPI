using System;
using BeeEngineering.Learning.MoviesApp.Data;
using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.DataAccess
{
    public class GenreDataAccessObject : BaseDataAccessObject<Genre>, IGenreDataAccessObject
    {
      
        public GenreDataAccessObject(MoviesAppContext dbContext) : base(dbContext) 
        {
            
        }

        //public async Task<List<Genre>> List()
        //{
        //    return await _dbContext.Set<Genre>().ToListAsync();
        //}

        //public async Task Insert(Genre genre)
        //{
        //    genre.CreatedAt = DateTime.Now;
        //    await _dbContext.Set<Genre>().AddAsync(genre);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task<Genre?> Get(Guid uuid)
        //{
        //    return await _dbContext.Set<Genre>().SingleOrDefaultAsync(x => x.Uuid == uuid);
        //}

        //public async Task Update(Genre genre)
        //{
        //    genre.UpdateAt = DateTime.Now;
        //    _dbContext.Set<Genre>().Update(genre);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task Delete(Genre genre)
        //{
        //    genre.DeletedAt = DateTime.Now;
        //    await Update(genre);
        //}
    }
}