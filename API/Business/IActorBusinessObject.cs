using BeeEngineering.Learning.MoviesApp.Data;
using MoviesAPI.Business;

namespace Business
{
    public interface IActorBusinessObject
    {
        public Task<OperationResult> Insert(Actor actor);
        public Task<OperationResult<Actor>> Get(Guid uuid);
        public Task<OperationResult<List<Actor>>> List();
        public Task<OperationResult> Update(Actor actor);
        public Task<OperationResult> Delete(Actor actor);
    }
}
