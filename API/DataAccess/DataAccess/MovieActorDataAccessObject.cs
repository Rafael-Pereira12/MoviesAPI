using System;
using Microsoft.EntityFrameworkCore;
using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.DataAccess
{
    public class MovieActorDataAccessObject : BaseDataAccessObject<MovieActor>
    {
        public MovieActorDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {

        }
    }
}