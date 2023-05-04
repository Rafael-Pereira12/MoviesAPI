using BeeEngineering.Learning.MoviesApp.Data.Base;

namespace Data.Data
{
    public class User : Entity
    {
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
    }
}
