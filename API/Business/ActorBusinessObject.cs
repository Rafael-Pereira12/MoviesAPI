using BeeEngineering.Learning.MoviesApp.Data;
using Business.Exceptions;
using DataAccess.DataAccess;
using MoviesAPI.Business;

namespace Business
{
    public class ActorBusinessObject : BaseBusinessObject, IActorBusinessObject
    {
        private readonly IActorDataAccessObject _dao;

        public ActorBusinessObject(IActorDataAccessObject dao)
        {
            _dao = dao;
        }

        public async Task<OperationResult<List<Actor>>> List()
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.List();
                return result;
            });
        }

        public async Task<OperationResult<Actor?>> Get(Guid uuid)
        {
            return await ExecuteOperationAsync(async () =>
            {
                var result = await _dao.Get(uuid);
                return result;
            });
        }

        private bool IsActorNotValidForInsert(Actor actor)
        {
            return string.IsNullOrEmpty(actor.Name);
                  
        }

        public async Task<OperationResult> Insert(Actor actor)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsActorNotValidForInsert(actor)) throw new IncompleteModelException();
                await _dao.Insert(actor);
            });
        }

        public async Task<OperationResult> Update(Actor actor)
        {
            return await ExecuteOperationAsync(async () =>
            {
                if (IsActorNotValidForInsert(actor))
                    throw new IncompleteModelException();
                await _dao.Update(actor);
            });
        }
        public async Task<OperationResult> Delete(Actor actor)
        {
            return await ExecuteOperationAsync(async () =>
            {
                await _dao.Delete(actor);
            });
        }

    }
}
