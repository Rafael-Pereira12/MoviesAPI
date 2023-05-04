using BeeEngineering.Learning.MoviesApp.Data;

namespace MoviesAPI.Responses
{
    public class GenreResult
    {
        public Guid? Uuid { get; set; }
        public string? Name { get; set; }

        public static GenreResult FromModel(Genre genre)
        {
            return new GenreResult() { Uuid = genre.Uuid, Name = genre.Name };
        }
    }
}
