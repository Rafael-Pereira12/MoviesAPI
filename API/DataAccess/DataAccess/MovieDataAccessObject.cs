using System;
using Microsoft.EntityFrameworkCore;
using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.DataAccess
{
    public class MovieDataAccessObject : BaseDataAccessObject<Movie>
    {
        public MovieDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {

        }
    }
}