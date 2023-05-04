using BeeEngineering.Learning.MoviesApp.Data;
using MoviesAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public interface IDirectorDataAccessObject : IDataAccessObject<Director>
    {
        Task<Dictionary<Director, List<Movie>>> GetAllDirectorMovies();
    }
}
