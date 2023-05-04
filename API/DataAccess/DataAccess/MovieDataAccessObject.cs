using System;
using Microsoft.EntityFrameworkCore;
using BeeEngineering.Learning.MoviesApp.Data;
using DataAccess.DataAccess;
using System.Numerics;

namespace MoviesAPI.DataAccess
{
    public class MovieDataAccessObject : BaseDataAccessObject<Movie>, IMovieDataAccessObject
    {
        public MovieDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {
        }

        
    }

  
    
}