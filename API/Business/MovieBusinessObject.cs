using BeeEngineering.Learning.MoviesApp.Data;
using Business.Exceptions;
using Business.Model;
using DataAccess.DataAccess;
using MoviesAPI.Business;

namespace Business
{
    public class MovieBusinessObject : BaseBusinessObject, IMovieBusinessObject
    {
        private readonly IMovieDataAccessObject _dao;

        public MovieBusinessObject(IMovieDataAccessObject dao)
        {
            _dao = dao;
        }
        public async Task<OperationResult<List<Movie>>> List()
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.List();
                return result;
            });
        }

        

        public async Task<OperationResult<Movie?>> Get(Guid uuid)
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.Get(uuid);
                return result;
            });
        }

        private bool IsMovieNotValidForInsert(Movie movie)
        {
            return string.IsNullOrEmpty(movie.Title);

        }

        public async Task<OperationResult> Insert(Movie movie)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsMovieNotValidForInsert(movie)) throw new IncompleteModelException();
                await _dao.Insert(movie);
            });
        }

        public async Task<OperationResult> Update(Movie movie)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsMovieNotValidForInsert(movie))
                    throw new IncompleteModelException();
                await _dao.Update(movie);
            });
        }
        public async Task<OperationResult> Delete(Movie movie)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dao.Delete(movie);
            }); ;
        }

      
    }
}
