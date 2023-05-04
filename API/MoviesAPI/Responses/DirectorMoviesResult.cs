namespace MoviesAPI.Responses
{
    public class DirectorMoviesResult
    {
        public Guid Uuid { get; set; }

        public string DirectorName { get; set; }

        public static DirectorMoviesResult FromModel(DirectorMoviesResult model)
        {
            return new DirectorMoviesResult { DirectorName = model.DirectorName, Uuid = model.Uuid };
        }
    }
}
