using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Responses
{
    public class DirectorResult
    {
        public Guid? Uuid { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public static ActorResult FromModel(Director director)
        {
            return new ActorResult() { Uuid = director.Uuid, Name = director.Name, BirthDate = director.BirthDate };
        }
    }
}
