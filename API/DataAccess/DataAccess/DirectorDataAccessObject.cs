using BeeEngineering.Learning.MoviesApp.Data;
using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace MoviesAPI.DataAccess
{
    public class DirectorDataAccessObject : BaseDataAccessObject<Director>, IDirectorDataAccessObject
    {
        public DirectorDataAccessObject(MoviesAppContext dbContext) : base(dbContext) { }

        public async Task<List<Director>> List()
        {
            return await _dbContext.Set<Director>().ToListAsync();
        }

        public async Task<Dictionary<Director, List<Movie>>> GetAllDirectorMovies()
        {
            var query = from director in _dbContext.Directors
                        join movie in _dbContext.Movies on director.Id equals movie.DirectorId
                        where director.DeletedAt == DateTime.MinValue
                        select new { Director = director, Movie = movie };

            var queryResult = await query.ToListAsync();

            var uniqueDirectors = queryResult.Select(x => x.Director).Distinct();

            var result = new Dictionary<Director, List<Movie>>();
            foreach (var director in uniqueDirectors)
            {
                var movies = queryResult.Where(x => x.Director == director).Select(x => x.Movie).ToList();
                result.Add(director, movies);
            }

            return result;
        }
    }

}
