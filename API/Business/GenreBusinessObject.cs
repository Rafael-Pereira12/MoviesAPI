using BeeEngineering.Learning.MoviesApp.Data;
using Business.Exceptions;
using DataAccess.DataAccess;
using MoviesAPI.Business;


namespace Business
{
    public class GenreBusinessObject : BaseBusinessObject, IGenreBusinessObject
    {
        private readonly IGenreDataAccessObject _dao;

        public GenreBusinessObject(IGenreDataAccessObject dao)
        {
            _dao = dao;
        }

        public async Task<OperationResult<List<Genre>>> List()
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.List();
                return result;
            });
        }
       

        public async Task<OperationResult<Genre>> Get(Guid uuid)
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.Get(uuid);
                return result;
            });
        }

        private bool IsGenreNotValidForInsert(Genre genre)
        {
            return string.IsNullOrEmpty(genre.Name);

        }

        public async Task<OperationResult> Insert(Genre genre)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsGenreNotValidForInsert(genre)) throw new IncompleteModelException();
                await _dao.Insert(genre);
            });
        }


        public async Task<OperationResult> Update(Genre genre)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsGenreNotValidForInsert(genre))
                    throw new IncompleteModelException();
                await _dao.Update(genre);
            });
        }

        public async Task<OperationResult> Delete(Genre genre)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dao.Delete(genre);
            });
        }
    }
}
