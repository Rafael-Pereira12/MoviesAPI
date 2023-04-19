using System;
using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.DataAccess
{
    public class MovieGenreDataAccessObject : BaseDataAccessObject<MovieGenre>
    {
        public MovieGenreDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {

        }
    }
}