using System;
using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.DataAccess
{
    public class ActorDataAccessObject : BaseDataAccessObject<Actor>
    {
        public ActorDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {

        }
    }
}
