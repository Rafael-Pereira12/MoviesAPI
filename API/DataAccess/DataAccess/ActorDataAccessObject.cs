using System;
using BeeEngineering.Learning.MoviesApp.Data;
using DataAccess.DataAccess;

namespace MoviesAPI.DataAccess
{
    public class ActorDataAccessObject : BaseDataAccessObject<Actor>, IActorDataAccessObject
    {
        public ActorDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {
        }

    }
}
