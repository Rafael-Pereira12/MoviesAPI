using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Requests
{
    public class GenreRequest
    {
        public Guid? Uuid { get; set; }
        public string? Name { get; set; }

        public Genre ToModel()
        {
            var result = new Genre { Name = Name };
            if (Uuid != null)
            {
                result.Uuid = Uuid.Value;
            }
            return result;
        }
    }
}

