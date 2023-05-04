using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Responses
{
    public class MovieResult
    {
        public Guid? Uuid { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public static MovieResult FromModel(Movie movie)
        {
            return new MovieResult() { Uuid= movie.Uuid, Title= movie.Title, ReleaseDate= movie.ReleaseDate };
        }
    }
}
