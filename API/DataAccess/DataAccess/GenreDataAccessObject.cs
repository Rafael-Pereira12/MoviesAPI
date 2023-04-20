using System;
using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.DataAccess
{
    public class GenreDataAccessObject : BaseDataAccessObject<Genre>
    {
        public GenreDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {

        }
    }
}