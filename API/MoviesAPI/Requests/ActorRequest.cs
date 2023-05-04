using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Requests
{
    public class ActorRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Actor ToModel()
        {
            var result = new Actor { Name = Name, BirthDate = BirthDate};
            if (Uuid != null ) 
            {
                result.Uuid = Uuid.Value;
            }
            return result;
        }
    }
}
