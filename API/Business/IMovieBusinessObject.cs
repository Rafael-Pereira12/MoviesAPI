using BeeEngineering.Learning.MoviesApp.Data;
using Business.Model;
using MoviesAPI.Business;


namespace Business
{
    public interface IMovieBusinessObject
    {
        public Task<OperationResult<List<Movie>>> List();
        public Task<OperationResult<Movie>> Get(Guid uuid);
        public Task<OperationResult> Insert(Movie movie);
        public Task<OperationResult> Update(Movie movie);
        public Task<OperationResult> Delete(Movie movie);

    }
}
