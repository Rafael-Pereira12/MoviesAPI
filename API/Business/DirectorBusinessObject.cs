using BeeEngineering.Learning.MoviesApp.Data;
using BeeEngineering.Learning.MoviesApp.Data.Base;
using Business.Exceptions;
using Business.Model;
using DataAccess.DataAccess;
using MoviesAPI.Business;

namespace Business
{
    public class DirectorBusinessObject : BaseBusinessObject, IDirectorBusinessObject
    {
       private readonly IDirectorDataAccessObject _dao;

        public DirectorBusinessObject(IDirectorDataAccessObject dao)
        {
            _dao = dao;
        }

        public async Task<OperationResult<List<Director>>> List()
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.List();
                return result;
            });
        }

        public async Task<OperationResult<List<MovieDirector>>> ListMovies()
        {
            return await ExecuteOperationAsync<List<MovieDirector>>(async () =>
            {
                var result = new List<MovieDirector>();
                var operationResult = await _dao.GetAllDirectorMovies();
                foreach (var (director, movie) in operationResult)
                {
                    result.Add(new MovieDirector() { DirectorName = director.Name });
                }
                return result;
            });
        }

        public async Task<OperationResult<Director>> Get(Guid uuid)
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.Get(uuid);
                return result;
            });
        }

        private bool IsDirectorNotValidForInsert(Director director)
        {
            return string.IsNullOrEmpty(director.Name);

        }

        public async Task<OperationResult> Insert(Director director)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsDirectorNotValidForInsert(director)) throw new IncompleteModelException();
                await _dao.Insert(director);
            });
        }

        public async Task<OperationResult> Update(Director director)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsDirectorNotValidForInsert(director))
                    throw new IncompleteModelException();
                await _dao.Update(director);
            });
        }

        public async Task<OperationResult> Delete(Director director)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dao.Delete(director);
            });
        }

    }
}
