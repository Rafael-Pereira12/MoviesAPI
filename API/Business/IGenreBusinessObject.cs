using BeeEngineering.Learning.MoviesApp.Data;
using MoviesAPI.Business;

namespace Business
{
    public interface IGenreBusinessObject
    {
        public Task<OperationResult<List<Genre>>> List();
        public Task<OperationResult<Genre>> Get(Guid uuid);
        public Task<OperationResult> Insert(Genre genre);
        public Task<OperationResult> Update(Genre genre);
        public Task<OperationResult> Delete(Genre genre);
    }
}
