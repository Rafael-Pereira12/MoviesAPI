using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Requests
{
    public class MovieRequest
    {
        public Guid? Uuid { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Movie ToModel()
        {
            var result = new Movie { Title = Title, ReleaseDate = ReleaseDate };
            if(Uuid != null)
            {
                result.Uuid = Uuid.Value;
            }
            return result;
        }
    }
}
