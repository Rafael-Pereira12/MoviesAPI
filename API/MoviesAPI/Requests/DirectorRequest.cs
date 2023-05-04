using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Requests
{
    public class DirectorRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Director ToModel()
        {
            var result = new Director { Name = Name, BirthDate = BirthDate };
            if (Uuid != null)
            {
                result.Uuid = Uuid.Value;
            }
            return result;
        }
    }
}
