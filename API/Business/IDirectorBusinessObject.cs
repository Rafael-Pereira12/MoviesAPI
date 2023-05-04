using BeeEngineering.Learning.MoviesApp.Data;
using Business.Model;
using MoviesAPI.Business;


namespace Business
{
    public interface IDirectorBusinessObject
    {
        public Task<OperationResult> Insert(Director director);
        public Task<OperationResult<Director>> Get(Guid uuid);
        public Task<OperationResult<List<Director>>> List();
        public Task<OperationResult> Update(Director director);
        public Task<OperationResult> Delete(Director director);
        public Task<OperationResult<List<MovieDirector>>> ListMovies();


    }
}
