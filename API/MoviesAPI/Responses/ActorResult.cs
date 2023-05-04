using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Responses
{
    public class ActorResult
    {
        public Guid? Uuid { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public static ActorResult FromModel(Actor actor)
        {
            return new ActorResult() { Uuid = actor.Uuid, Name = actor.Name, BirthDate = actor.BirthDate };
        }


    }
}
