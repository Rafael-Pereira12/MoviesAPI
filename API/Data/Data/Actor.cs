using BeeEngineering.Learning.MoviesApp.Data.Base;

namespace BeeEngineering.Learning.MoviesApp.Data
{

	public class Actor : NamedEntity
	{
        public DateTime BirthDate { get; set; }

        public virtual IEnumerable<MovieActor>? Movies	{ get; set; }
	}
}
