using BeeEngineering.Learning.MoviesApp.Data;
using System;

namespace MoviesAPI.DataAccess
{
    public class DirectorDataAccessObject : BaseDataAccessObject<Director>
    {
        public DirectorDataAccessObject(MoviesAppContext dbContext) : base(dbContext)
        {

        }
    }

}
